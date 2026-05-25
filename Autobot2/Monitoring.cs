// Monitoring.cs
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Autobot2
{
    public partial class Monitoring : UserControl
    {
        private bool _isPolling = false;

        public Monitoring()
        {
            InitializeComponent();
            AppState.ConnectionChanged += OnConnectionChanged;
        }

        private void OnConnectionChanged()
        {
            if (this.InvokeRequired) { this.BeginInvoke(OnConnectionChanged); return; }

            if (AppState.IsConnected)
            {
                lblStatus.Text = "● Connected";
                lblStatus.ForeColor = Color.LimeGreen;
                btnStart.Enabled = true;
            }
            else
            {
                StopMonitoring();
                lblStatus.Text = "● Not Connected";
                lblStatus.ForeColor = Color.OrangeRed;
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

            AppState.OBD.RpmReceived += OnRpmReceived;
            AppState.OBD.SpeedReceived += OnSpeedReceived;
            AppState.OBD.StartPolling(250);

            _isPolling = true;
            btnStart.Text = "Stop";
            lblStatus.Text = "● Live";
            lblStatus.ForeColor = Color.LimeGreen;
        }

        private void StopMonitoring()
        {
            if (AppState.OBD != null)
            {
                AppState.OBD.StopPolling();
                AppState.OBD.RpmReceived -= OnRpmReceived;
                AppState.OBD.SpeedReceived -= OnSpeedReceived;
            }

            _isPolling = false;
            btnStart.Text = "Start";

            // Reset displays
            lblRpm.Text = "RPM: --";
            lblSpeed.Text = "Speed: --";
            cgRPM.Value = 0;
            cgSpeed.Value = 0;

            if (AppState.IsConnected)
            {
                lblStatus.Text = "● Connected";
                lblStatus.ForeColor = Color.LimeGreen;
            }
        }

        private void OnRpmReceived(int rpm)
        {
            if (this.InvokeRequired) { this.BeginInvoke(() => OnRpmReceived(rpm)); return; }
            lblRpm.Text = $"RPM: {rpm:N0}";
            cgRPM.Value = rpm;
        }

        private void OnSpeedReceived(double speed)
        {
            if (this.InvokeRequired) { this.BeginInvoke(() => OnSpeedReceived(speed)); return; }
            lblSpeed.Text = $"Speed: {speed:N0} km/h";
            cgSpeed.Value = speed;
        }

        protected override void Dispose(bool disposing)
        {
            AppState.ConnectionChanged -= OnConnectionChanged;
            if (AppState.OBD != null)
            {
                AppState.OBD.RpmReceived -= OnRpmReceived;
                AppState.OBD.SpeedReceived -= OnSpeedReceived;
            }
            base.Dispose(disposing);
        }
    }
}