namespace Autobot2
{
    partial class Home
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            btnConnect = new Button();
            btnDisconnect = new Button();
            panel2 = new Panel();
            lblBaud = new Label();
            label5 = new Label();
            lblProtocol = new Label();
            cbxConnection = new CheckBox();
            label3 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
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
            label1.Font = new Font("Impact", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(131, 17);
            label1.Name = "label1";
            label1.Size = new Size(303, 98);
            label1.TabIndex = 1;
            label1.Text = "Autobot";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.autohub_icon1;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 125);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnConnect
            // 
            btnConnect.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnConnect.Location = new Point(3, 458);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(534, 50);
            btnConnect.TabIndex = 1;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDisconnect.Location = new Point(543, 458);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(529, 50);
            btnDisconnect.TabIndex = 2;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblBaud);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(lblProtocol);
            panel2.Controls.Add(cbxConnection);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 514);
            panel2.Name = "panel2";
            panel2.Size = new Size(1075, 28);
            panel2.TabIndex = 3;
            // 
            // lblBaud
            // 
            lblBaud.AutoSize = true;
            lblBaud.Location = new Point(808, 5);
            lblBaud.Name = "lblBaud";
            lblBaud.Size = new Size(21, 20);
            lblBaud.TabIndex = 5;
            lblBaud.Text = "--";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(722, 5);
            label5.Name = "label5";
            label5.Size = new Size(80, 20);
            label5.TabIndex = 4;
            label5.Text = "Baud rate: ";
            // 
            // lblProtocol
            // 
            lblProtocol.AutoSize = true;
            lblProtocol.Location = new Point(440, 5);
            lblProtocol.Name = "lblProtocol";
            lblProtocol.Size = new Size(21, 20);
            lblProtocol.TabIndex = 3;
            lblProtocol.Text = "--";
            // 
            // cbxConnection
            // 
            cbxConnection.AutoSize = true;
            cbxConnection.Location = new Point(96, 3);
            cbxConnection.Name = "cbxConnection";
            cbxConnection.Size = new Size(18, 17);
            cbxConnection.TabIndex = 2;
            cbxConnection.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(366, 5);
            label3.Name = "label3";
            label3.Size = new Size(68, 20);
            label3.TabIndex = 1;
            label3.Text = "Protocol:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 5);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 0;
            label2.Text = "Connection:";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(btnDisconnect);
            Controls.Add(btnConnect);
            Controls.Add(panel1);
            Name = "Home";
            Size = new Size(1075, 542);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Button btnConnect;
        private Button btnDisconnect;
        private Panel panel2;
        private CheckBox cbxConnection;
        private Label label3;
        private Label label2;
        private Label lblProtocol;
        private Label lblBaud;
        private Label label5;
    }
}
