namespace Autobot2
{
    partial class Monitoring
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CodeArtEng.Gauge.Themes.ThemeColors themeColors4 = new CodeArtEng.Gauge.Themes.ThemeColors();
            CodeArtEng.Gauge.Themes.ThemeColors themeColors5 = new CodeArtEng.Gauge.Themes.ThemeColors();
            CodeArtEng.Gauge.Themes.ThemeColors themeColors6 = new CodeArtEng.Gauge.Themes.ThemeColors();
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            lblStatus = new Label();
            lblRpm = new Label();
            btnStart = new Button();
            cgRPM = new CodeArtEng.Gauge.CircularGauge();
            cgSpeed = new CodeArtEng.Gauge.CircularGauge();
            lblSpeed = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1075, 125);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 42F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(131, 19);
            label1.Name = "label1";
            label1.Size = new Size(363, 85);
            label1.TabIndex = 1;
            label1.Text = "Monitoring";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.speedometer__1_;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 125);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(15, 512);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(49, 20);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Status";
            // 
            // lblRpm
            // 
            lblRpm.AutoSize = true;
            lblRpm.Location = new Point(769, 444);
            lblRpm.Name = "lblRpm";
            lblRpm.Size = new Size(42, 20);
            lblRpm.TabIndex = 3;
            lblRpm.Text = "RPM:";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(890, 483);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 29);
            btnStart.TabIndex = 4;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // cgRPM
            // 
            cgRPM.Location = new Point(638, 131);
            cgRPM.Name = "cgRPM";
            cgRPM.ResetValue = 0D;
            cgRPM.ScaleFactor = 1D;
            cgRPM.Size = new Size(300, 300);
            cgRPM.TabIndex = 5;
            cgRPM.Title = "";
            cgRPM.Unit = "RPM";
            themeColors4.KnobInnerBorderColor = Color.FromArgb(200, 200, 200);
            themeColors4.KnobTone = Color.FromArgb(200, 200, 200);
            cgRPM.UserDefinedColors.Base = themeColors4;
            themeColors5.KnobInnerBorderColor = Color.FromArgb(200, 200, 200);
            themeColors5.KnobTone = Color.FromArgb(200, 200, 200);
            cgRPM.UserDefinedColors.Error = themeColors5;
            themeColors6.KnobInnerBorderColor = Color.FromArgb(200, 200, 200);
            themeColors6.KnobTone = Color.FromArgb(200, 200, 200);
            cgRPM.UserDefinedColors.Warning = themeColors6;
            // 
            // cgSpeed
            // 
            cgSpeed.Location = new Point(168, 131);
            cgSpeed.Name = "cgSpeed";
            cgSpeed.ResetValue = 0D;
            cgSpeed.ScaleFactor = 1D;
            cgSpeed.Size = new Size(300, 300);
            cgSpeed.TabIndex = 6;
            cgSpeed.Title = "";
            cgSpeed.Unit = "km/h";
            // 
            // lblSpeed
            // 
            lblSpeed.AutoSize = true;
            lblSpeed.Location = new Point(301, 444);
            lblSpeed.Name = "lblSpeed";
            lblSpeed.Size = new Size(54, 20);
            lblSpeed.TabIndex = 7;
            lblSpeed.Text = "Speed:";
            // 
            // Monitoring
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblSpeed);
            Controls.Add(cgSpeed);
            Controls.Add(cgRPM);
            Controls.Add(btnStart);
            Controls.Add(lblRpm);
            Controls.Add(lblStatus);
            Controls.Add(panel1);
            Name = "Monitoring";
            Size = new Size(1075, 542);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label lblStatus;
        private Label lblRpm;
        private Button btnStart;
        private CodeArtEng.Gauge.CircularGauge cgRPM;
        private CodeArtEng.Gauge.CircularGauge cgSpeed;
        private Label lblSpeed;
    }
}
