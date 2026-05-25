namespace Autobot2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnHome_Click(null, EventArgs.Empty);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            pnlDisplay.Controls.Clear();

            Home homeControl = new Home();
            homeControl.Dock = DockStyle.Fill;

            pnlDisplay.Controls.Add(homeControl);
        }

        private void btnDTC_Click(object sender, EventArgs e)
        {
            pnlDisplay.Controls.Clear();

            troubleCodes codes = new troubleCodes();
            codes.Dock = DockStyle.Fill;

            pnlDisplay.Controls.Add(codes);
        }

        private void btnMonitoring_Click(object sender, EventArgs e)
        {
            pnlDisplay.Controls.Clear();

            Monitoring monitoringControl = new Monitoring();
            monitoringControl.Dock = DockStyle.Fill;

            pnlDisplay.Controls.Add(monitoringControl);
        }

        private void btnDiagnosis_Click(object sender, EventArgs e)
        {
            pnlDisplay.Controls.Clear();
            Diagnosis diagnosisControl = new Diagnosis();
            diagnosisControl.Dock = DockStyle.Fill;

            pnlDisplay.Controls.Add(diagnosisControl);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            AppState.ClearOBD(); 
            base.OnFormClosing(e);
        }
    }
}
