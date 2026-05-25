// OBD2Manager.cs
using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace Autobot2
{
    public class OBD2Manager : IDisposable
    {
        private SerialPort _port;
        private CancellationTokenSource _cts;

        public event Action<int> RpmReceived;
        public event Action<double> SpeedReceived;
        public event Action<double> CoolantTempReceived;
        public event Action<double> ThrottleReceived;
        public event Action<double> EngineLoadReceived;
        public event Action<double> IntakeAirTempReceived;
        public event Action<double> MafReceived;
        public event Action<double> FuelPressureReceived;
        public event Action<string> RawLogReceived;
        public event Action<string> ErrorOccurred;

        public string PortName { get; private set; }
        public string ProtocolCommand { get; private set; }
        public string ProtocolName { get; private set; }
        public int BaudRate { get; private set; }

        public bool IsConnected => _port?.IsOpen ?? false;

        public async Task<bool> ConnectAsync(string portName, string protocolCommand = "ATSP0", int baudRate = 38400)
        {
            PortName = portName;
            ProtocolCommand = protocolCommand;
            ProtocolName = protocolCommand;
            BaudRate = baudRate;
            try
            {
                _port = new SerialPort(portName, baudRate)
                {
                    ReadTimeout = 2000,
                    WriteTimeout = 2000,
                    NewLine = "\r"
                };
                _port.Open();

                await SendCommandAsync("ATZ");
                await Task.Delay(1000);
                await SendCommandAsync("ATE0");
                await SendCommandAsync("ATL0");
                await SendCommandAsync("ATS0");
                await SendCommandAsync(protocolCommand);
                await SendCommandAsync("ATSH7DF");

                string resp = await SendCommandAsync("0100");
                if (resp.Contains("UNABLE") || resp.Contains("ERROR") || resp.Contains("NO DATA"))
                {
                    ErrorOccurred?.Invoke($"ECU not responding: {resp}");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke($"Connection failed: {ex.Message}");
                return false;
            }
        }

        public void Disconnect()
        {
            _cts?.Cancel();
            Thread.Sleep(300);
            _port?.Close();
            _port?.Dispose();
        }

        public void StartPolling(int intervalMs = 250)
        {
            if (_cts != null && !_cts.IsCancellationRequested) return;
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        await PollRpm();
                        await PollSpeed();
                        await PollCoolantTemp();
                        await PollThrottle();
                        await PollEngineLoad();
                        await PollIntakeAirTemp();
                        await PollMaf();
                        await PollFuelPressure();
                        await Task.Delay(intervalMs, token);
                    }
                    catch (OperationCanceledException) { break; }
                    catch (Exception ex)
                    {
                        ErrorOccurred?.Invoke($"Poll error: {ex.Message}");
                        await Task.Delay(500);
                    }
                }
            }, token);
        }

        public void StopPolling() => _cts?.Cancel();

        private async Task PollRpm()
        {
            string raw = await SendCommandAsync("010C");
            if (TryParseResponse(raw, "0C", out byte[] bytes) && bytes.Length >= 2)
                RpmReceived?.Invoke(((bytes[0] * 256) + bytes[1]) / 4);
        }

        private async Task PollSpeed()
        {
            string raw = await SendCommandAsync("010D");
            if (TryParseResponse(raw, "0D", out byte[] bytes) && bytes.Length >= 1)
                SpeedReceived?.Invoke(bytes[0]);
        }

        private async Task PollCoolantTemp()
        {
            string raw = await SendCommandAsync("0105");
            if (TryParseResponse(raw, "05", out byte[] bytes) && bytes.Length >= 1)
                CoolantTempReceived?.Invoke(bytes[0] - 40.0);
        }

        private async Task PollThrottle()
        {
            string raw = await SendCommandAsync("0111");
            if (TryParseResponse(raw, "11", out byte[] bytes) && bytes.Length >= 1)
                ThrottleReceived?.Invoke(bytes[0] * 100.0 / 255.0);
        }

        private async Task PollEngineLoad()
        {
            string raw = await SendCommandAsync("0104");
            if (TryParseResponse(raw, "04", out byte[] bytes) && bytes.Length >= 1)
                EngineLoadReceived?.Invoke(bytes[0] * 100.0 / 255.0);
        }

        private async Task PollIntakeAirTemp()
        {
            string raw = await SendCommandAsync("010F");
            if (TryParseResponse(raw, "0F", out byte[] bytes) && bytes.Length >= 1)
                IntakeAirTempReceived?.Invoke(bytes[0] - 40.0);
        }

        private async Task PollMaf()
        {
            string raw = await SendCommandAsync("0110");
            if (TryParseResponse(raw, "10", out byte[] bytes) && bytes.Length >= 2)
                MafReceived?.Invoke(((bytes[0] * 256) + bytes[1]) / 100.0);
        }

        private async Task PollFuelPressure()
        {
            string raw = await SendCommandAsync("010A");
            if (TryParseResponse(raw, "0A", out byte[] bytes) && bytes.Length >= 1)
                FuelPressureReceived?.Invoke(bytes[0] * 3.0);
        }

        private async Task<string> SendCommandAsync(string cmd)
        {
            if (_port == null || !_port.IsOpen) return string.Empty;

            _port.DiscardInBuffer();
            _port.WriteLine(cmd);

            await Task.Delay(100);

            string response = string.Empty;
            var deadline = DateTime.Now.AddMilliseconds(1500);
            while (DateTime.Now < deadline)
            {
                if (_port.BytesToRead > 0)
                {
                    response += _port.ReadExisting();
                    if (response.Contains(">")) break;
                }
                await Task.Delay(20);
            }

            RawLogReceived?.Invoke($">> {cmd}\n<< {response.Trim()}\n");
            return response.Trim();
        }

        private bool TryParseResponse(string raw, string pid, out byte[] dataBytes)
        {
            dataBytes = Array.Empty<byte>();
            if (string.IsNullOrWhiteSpace(raw)) return false;

            raw = raw.Replace(">", "").Replace("\r", "").Replace("\n", "").Replace(" ", "").Trim().ToUpper();

            string expected = "41" + pid.ToUpper();
            int idx = raw.IndexOf(expected, StringComparison.OrdinalIgnoreCase);
            if (idx < 0) return false;

            string payload = raw.Substring(idx + expected.Length);
            if (payload.Length < 2) return false;

            var result = new List<byte>();
            for (int i = 0; i + 1 < payload.Length; i += 2)
            {
                if (byte.TryParse(payload.Substring(i, 2),
                    System.Globalization.NumberStyles.HexNumber, null, out byte b))
                    result.Add(b);
            }

            dataBytes = result.ToArray();
            return result.Count > 0;
        }

        public void Dispose() => Disconnect();
    }
}