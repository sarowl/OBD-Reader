namespace Autobot2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnDiagnosis = new Button();
            btnMonitoring = new Button();
            btnDTC = new Button();
            btnHome = new Button();
            pnlDisplay = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.WindowFrame;
            panel1.Controls.Add(btnDiagnosis);
            panel1.Controls.Add(btnMonitoring);
            panel1.Controls.Add(btnDTC);
            panel1.Controls.Add(btnHome);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 630);
            panel1.TabIndex = 0;
            // 
            // btnDiagnosis
            // 
            btnDiagnosis.Dock = DockStyle.Top;
            btnDiagnosis.FlatStyle = FlatStyle.Flat;
            btnDiagnosis.Font = new Font("HP Simplified Hans", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDiagnosis.ForeColor = SystemColors.Control;
            btnDiagnosis.Image = Properties.Resources.tools;
            btnDiagnosis.Location = new Point(0, 409);
            btnDiagnosis.Name = "btnDiagnosis";
            btnDiagnosis.Size = new Size(200, 137);
            btnDiagnosis.TabIndex = 3;
            btnDiagnosis.Text = "Diagnosis";
            btnDiagnosis.TextAlign = ContentAlignment.BottomCenter;
            btnDiagnosis.UseVisualStyleBackColor = true;
            btnDiagnosis.Click += btnDiagnosis_Click;
            // 
            // btnMonitoring
            // 
            btnMonitoring.Dock = DockStyle.Top;
            btnMonitoring.FlatStyle = FlatStyle.Flat;
            btnMonitoring.Font = new Font("HP Simplified Hans", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMonitoring.ForeColor = SystemColors.Control;
            btnMonitoring.Image = Properties.Resources.speedometer;
            btnMonitoring.Location = new Point(0, 272);
            btnMonitoring.Name = "btnMonitoring";
            btnMonitoring.Size = new Size(200, 137);
            btnMonitoring.TabIndex = 2;
            btnMonitoring.Text = "Monitoring";
            btnMonitoring.TextAlign = ContentAlignment.BottomCenter;
            btnMonitoring.UseVisualStyleBackColor = true;
            btnMonitoring.Click += btnMonitoring_Click;
            // 
            // btnDTC
            // 
            btnDTC.Dock = DockStyle.Top;
            btnDTC.FlatStyle = FlatStyle.Flat;
            btnDTC.Font = new Font("HP Simplified Hans", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDTC.ForeColor = SystemColors.Control;
            btnDTC.Image = Properties.Resources.engine;
            btnDTC.Location = new Point(0, 135);
            btnDTC.Name = "btnDTC";
            btnDTC.Size = new Size(200, 137);
            btnDTC.TabIndex = 1;
            btnDTC.Text = "Trouble Codes";
            btnDTC.TextAlign = ContentAlignment.BottomCenter;
            btnDTC.UseVisualStyleBackColor = true;
            btnDTC.Click += btnDTC_Click;
            // 
            // btnHome
            // 
            btnHome.Dock = DockStyle.Top;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("HP Simplified Hans", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHome.ForeColor = SystemColors.Control;
            btnHome.Image = Properties.Resources.wheel;
            btnHome.Location = new Point(0, 0);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(200, 135);
            btnHome.TabIndex = 0;
            btnHome.Text = "Home";
            btnHome.TextAlign = ContentAlignment.BottomCenter;
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // pnlDisplay
            // 
            pnlDisplay.BackColor = SystemColors.Control;
            pnlDisplay.Dock = DockStyle.Fill;
            pnlDisplay.Location = new Point(200, 0);
            pnlDisplay.Name = "pnlDisplay";
            pnlDisplay.Size = new Size(1082, 630);
            pnlDisplay.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlText;
            ClientSize = new Size(1282, 630);
            Controls.Add(pnlDisplay);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Autobot";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnHome;
        private Panel pnlDisplay;
        private Button btnDTC;
        private Button btnMonitoring;
        private Button btnDiagnosis;
    }
}
