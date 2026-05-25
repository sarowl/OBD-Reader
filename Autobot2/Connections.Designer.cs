namespace Autobot2
{
    partial class Connections
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            cbxProtocol = new ComboBox();
            label3 = new Label();
            cbxMethod = new ComboBox();
            groupBox1 = new GroupBox();
            cbxComPort = new ComboBox();
            label4 = new Label();
            btnConnect = new Button();
            btnCancel = new Button();
            lblStatus = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(482, 125);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 28F, FontStyle.Bold);
            label1.Location = new Point(131, 34);
            label1.Name = "label1";
            label1.Size = new Size(281, 59);
            label1.TabIndex = 2;
            label1.Text = "Connections";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.connect;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 125);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 166);
            label2.Name = "label2";
            label2.Size = new Size(111, 20);
            label2.TabIndex = 1;
            label2.Text = "OBD2 Protocol:";
            // 
            // cbxProtocol
            // 
            cbxProtocol.FormattingEnabled = true;
            cbxProtocol.Items.AddRange(new object[] { "Automatic", "SAE J1850 PWM", "SAE J1850 VPW", "ISO 9141-2", "ISO 14230-4 KWP (5 Baud init)", "ISO 14230-4 KWP (fast init)", "ISO 15765-4 CAN (11 bit, 500kb)", "ISO 15765-4 CAN (29 bit, 500kb)", "ISO 15765-4 CAN (11 bit, 250kb)", "ISO 15765-4 CAN (29 bit, 250kb)" });
            cbxProtocol.Location = new Point(178, 158);
            cbxProtocol.Name = "cbxProtocol";
            cbxProtocol.Size = new Size(281, 28);
            cbxProtocol.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 200);
            label3.Name = "label3";
            label3.Size = new Size(143, 20);
            label3.TabIndex = 3;
            label3.Text = "Connection Method:";
            // 
            // cbxMethod
            // 
            cbxMethod.FormattingEnabled = true;
            cbxMethod.Items.AddRange(new object[] { "Serial Port", "Bluetooth", "WiFi" });
            cbxMethod.Location = new Point(178, 192);
            cbxMethod.Name = "cbxMethod";
            cbxMethod.Size = new Size(281, 28);
            cbxMethod.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbxComPort);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(12, 263);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(458, 104);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Connection Settings";
            // 
            // cbxComPort
            // 
            cbxComPort.FormattingEnabled = true;
            cbxComPort.Location = new Point(166, 39);
            cbxComPort.Name = "cbxComPort";
            cbxComPort.Size = new Size(281, 28);
            cbxComPort.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 42);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 0;
            label4.Text = "COM Port:";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(267, 435);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(94, 29);
            btnConnect.TabIndex = 6;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(376, 435);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(27, 388);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 20);
            lblStatus.TabIndex = 9;
            // 
            // Connections
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 484);
            Controls.Add(lblStatus);
            Controls.Add(btnCancel);
            Controls.Add(btnConnect);
            Controls.Add(groupBox1);
            Controls.Add(cbxMethod);
            Controls.Add(label3);
            Controls.Add(cbxProtocol);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Connections";
            Text = "Connections";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private ComboBox cbxProtocol;
        private Label label3;
        private ComboBox cbxMethod;
        private GroupBox groupBox1;
        private ComboBox cbxComPort;
        private Label label4;
        private Button btnConnect;
        private Button btnCancel;
        private Label lblStatus;
    }
}