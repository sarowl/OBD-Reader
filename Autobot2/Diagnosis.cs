// Diagnosis.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Autobot2
{
    public partial class Diagnosis : UserControl
    {
        private bool _isPolling = false;

        private class PidStats
        {
            public double Sum = 0;
            public int Count = 0;
            public double Min = double.MaxValue;
            public double Max = double.MinValue;

            public void Update(double value)
            {
                Sum += value;
                Count++;
                if (value < Min) Min = value;
                if (value > Max) Max = value;
            }

            public double Avg => Count > 0 ? Sum / Count : 0;
        }

        private readonly Dictionary<string, PidStats> _stats = new()
        {
            { "0105", new PidStats() },
            { "0104", new PidStats() },
            { "010F", new PidStats() },
            { "0110", new PidStats() },
            { "010A", new PidStats() },
        };

        private const int ROW_COOLANT = 0;
        private const int ROW_LOAD = 1;
        private const int ROW_INTAKE = 2;
        private const int ROW_MAF = 3;
        private const int ROW_FUEL = 4;

        public Diagnosis()
        {
            InitializeComponent();
            AppState.ConnectionChanged += OnConnectionChanged;
            InitGrid();
        }

        private void InitGrid()
        {
            dgvPID.Rows.Clear();
            dgvPID.Rows.Add("0105", "Coolant Temp", "--", "--", "--", "--");
            dgvPID.Rows.Add("0104", "Engine Load", "--", "--", "--", "--");
            dgvPID.Rows.Add("010F", "Intake Air Temp", "--", "--", "--", "--");
            dgvPID.Rows.Add("0110", "MAF Air Flow", "--", "--", "--", "--");
            dgvPID.Rows.Add("010A", "Fuel Pressure", "--", "--", "--", "--");
        }

        private void OnConnectionChanged()
        {
            if (this.InvokeRequired) { this.BeginInvoke(OnConnectionChanged); return; }

            if (AppState.IsConnected)
            {
                btnStart.Enabled = true;
            }
            else
            {
                StopMonitoring();
                btnStart.Enabled = false;
                btnStart.Text = "Start";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_isPolling)
                StopMonitoring();
            else
                StartMonitoring();
        }

        private void StartMonitoring()
        {
            if (!AppState.IsConnected) return;

            foreach (var s in _stats.Values)
            {
                s.Sum = 0; s.Count = 0;
                s.Min = double.MaxValue;
                s.Max = double.MinValue;
            }
            InitGrid();

            AppState.OBD.CoolantTempReceived += OnCoolantTemp;
            AppState.OBD.EngineLoadReceived += OnEngineLoad;
            AppState.OBD.IntakeAirTempReceived += OnIntakeAirTemp;
            AppState.OBD.MafReceived += OnMaf;
            AppState.OBD.FuelPressureReceived += OnFuelPressure;
            AppState.OBD.StartPolling(250);

            _isPolling = true;
            btnStart.Text = "Stop";
        }

        private void StopMonitoring()
        {
            if (AppState.OBD != null)
            {
                AppState.OBD.StopPolling();
                AppState.OBD.CoolantTempReceived -= OnCoolantTemp;
                AppState.OBD.EngineLoadReceived -= OnEngineLoad;
                AppState.OBD.IntakeAirTempReceived -= OnIntakeAirTemp;
                AppState.OBD.MafReceived -= OnMaf;
                AppState.OBD.FuelPressureReceived -= OnFuelPressure;
            }

            _isPolling = false;
            btnStart.Text = "Start";
        }

        // ── Event handlers ───────────────────────────────────────

        private void OnCoolantTemp(double value)
        {
            if (this.InvokeRequired) { this.BeginInvoke(() => OnCoolantTemp(value)); return; }
            UpdateRow(ROW_COOLANT, "0105", value, $"{value:F1} °C");
        }

        private void OnEngineLoad(double value)
        {
            if (this.InvokeRequired) { this.BeginInvoke(() => OnEngineLoad(value)); return; }
            UpdateRow(ROW_LOAD, "0104", value, $"{value:F1} %");
        }

        private void OnIntakeAirTemp(double value)
        {
            if (this.InvokeRequired) { this.BeginInvoke(() => OnIntakeAirTemp(value)); return; }
            UpdateRow(ROW_INTAKE, "010F", value, $"{value:F1} °C");
        }

        private void OnMaf(double value)
        {
            if (this.InvokeRequired) { this.BeginInvoke(() => OnMaf(value)); return; }
            UpdateRow(ROW_MAF, "0110", value, $"{value:F2} g/s");
        }

        private void OnFuelPressure(double value)
        {
            if (this.InvokeRequired) { this.BeginInvoke(() => OnFuelPressure(value)); return; }
            UpdateRow(ROW_FUEL, "010A", value, $"{value:F1} kPa");
        }

        // ── Grid helper ──────────────────────────────────────────

        private void UpdateRow(int rowIndex, string pid, double value, string formatted)
        {
            var stats = _stats[pid];
            stats.Update(value);

            string unit = pid switch
            {
                "0105" or "010F" => "°C",
                "0104" => "%",
                "0110" => "g/s",
                "010A" => "kPa",
                _ => ""
            };

            string fmt = pid == "0110" ? "F2" : "F1";

            var row = dgvPID.Rows[rowIndex];
            row.Cells[colVal.Index].Value = formatted;
            row.Cells[colMin.Index].Value = $"{stats.Min.ToString(fmt)} {unit}".Trim();
            row.Cells[colAvg.Index].Value = $"{stats.Avg.ToString(fmt)} {unit}".Trim();
            row.Cells[colMax.Index].Value = $"{stats.Max.ToString(fmt)} {unit}".Trim();
        }

        private void UnsubscribeAll()
        {
            AppState.ConnectionChanged -= OnConnectionChanged;
            if (AppState.OBD != null)
            {
                AppState.OBD.CoolantTempReceived -= OnCoolantTemp;
                AppState.OBD.EngineLoadReceived -= OnEngineLoad;
                AppState.OBD.IntakeAirTempReceived -= OnIntakeAirTemp;
                AppState.OBD.MafReceived -= OnMaf;
                AppState.OBD.FuelPressureReceived -= OnFuelPressure;
            }
        }
    }
}