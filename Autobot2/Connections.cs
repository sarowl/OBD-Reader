using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace Autobot2
{
    public partial class Connections : Form
    {
        public event Action ConnectedSuccessfully;

        public Connections()
        {
            InitializeComponent();
            cbxProtocol.SelectedIndex = 0;
            cbxMethod.SelectedIndex = 0;
            PopulateComPorts();
        }

        private void PopulateComPorts()
        {
            cbxComPort.Items.Clear();
            string[] ports = SerialPort.GetPortNames();

            if (ports.Length > 0)
            {
                cbxComPort.Items.AddRange(ports);
                cbxComPort.SelectedIndex = 0;
            }
            else
            {
                cbxComPort.Items.Add("No ports found");
                cbxComPort.SelectedIndex = 0;
            }
        }

        private string GetProtocolCommand()
        {
            return cbxProtocol.SelectedIndex switch
            {
                0 => "ATSP0",   // Automatic
                1 => "ATSP6",   // CAN 11bit/500 — your confirmed ECU
                2 => "ATSP7",   // CAN 29bit/500
                3 => "ATSP8",   // CAN 11bit/250
                4 => "ATSP3",   // ISO 9141-2
                5 => "ATSP5",   // KWP slow init
                6 => "ATSP1",   // J1850 PWM
                7 => "ATSP2",   // J1850 VPW
                _ => "ATSP0"
            };
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (cbxComPort.SelectedItem == null ||
                cbxComPort.SelectedItem.ToString() == "No ports found")
            {
                lblStatus.ForeColor = Color.OrangeRed;
                lblStatus.Text = "⚠ No COM port selected.";
                return;
            }

            btnConnect.Enabled = false;
            lblStatus.ForeColor = Color.DodgerBlue;
            lblStatus.Text = "Connecting…";

            var obd = new OBD2Manager();

            bool ok = await obd.ConnectAsync(
                portName: cbxComPort.SelectedItem.ToString(),
                protocolCommand: GetProtocolCommand()
            );

            if (ok)
            {
                AppState.SetOBD(obd);
                lblStatus.ForeColor = Color.LimeGreen;
                lblStatus.Text = "✔ Connected!";

                await Task.Delay(600);
                ConnectedSuccessfully?.Invoke();
                this.Close();
            }
            else
            {
                lblStatus.ForeColor = Color.OrangeRed;
                lblStatus.Text = "✘ Could not connect. Check port & ignition.";
                btnConnect.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            PopulateComPorts();
        }
    }
}