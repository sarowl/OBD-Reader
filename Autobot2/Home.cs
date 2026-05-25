using System;
using System.Windows.Forms;

namespace Autobot2
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            SetDisconnectedState();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connections connectionsForm = new Connections();
            connectionsForm.ConnectedSuccessfully += OnConnectedSuccessfully;
            connectionsForm.Show();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            AppState.OBD?.Disconnect();
            AppState.SetOBD(null);
            SetDisconnectedState();
        }

        private void OnConnectedSuccessfully()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Action)OnConnectedSuccessfully);
                return;
            }

            var obd = AppState.OBD;
            if (obd == null) return;

            cbxConnection.Checked = true;
            cbxConnection.Text = obd.PortName;        
            lblProtocol.Text = obd.ProtocolName;    
            lblBaud.Text = obd.BaudRate.ToString(); 

            btnConnect.Enabled = false;
            btnDisconnect.Enabled = true;
        }

        private void SetDisconnectedState()
        {
            cbxConnection.Checked = false;
            cbxConnection.Text = "Not connected";
            lblProtocol.Text = "--";
            lblBaud.Text = "--";

            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
        }
    }
}