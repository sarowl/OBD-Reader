namespace Autobot2
{
    partial class troubleCodes
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
            dataGridView1 = new DataGridView();
            colCode = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            btnScan = new Button();
            btcClear = new Button();
            btnList = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            label1.Font = new Font("Impact", 40.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(131, 26);
            label1.Name = "label1";
            label1.Size = new Size(443, 82);
            label1.TabIndex = 1;
            label1.Text = "Trouble Codes";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.engine__1_1;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 125);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colCode, colDescription });
            dataGridView1.Location = new Point(45, 142);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(835, 383);
            dataGridView1.TabIndex = 1;
            // 
            // colCode
            // 
            colCode.HeaderText = "Code";
            colCode.MinimumWidth = 6;
            colCode.Name = "colCode";
            colCode.ReadOnly = true;
            colCode.Width = 80;
            // 
            // colDescription
            // 
            colDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescription.HeaderText = "Description";
            colDescription.MinimumWidth = 6;
            colDescription.Name = "colDescription";
            colDescription.ReadOnly = true;
            // 
            // btnScan
            // 
            btnScan.Location = new Point(924, 383);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(94, 29);
            btnScan.TabIndex = 2;
            btnScan.Text = "Scan";
            btnScan.UseVisualStyleBackColor = true;
            btnScan.Click += BtnScan_Click;
            // 
            // btcClear
            // 
            btcClear.Location = new Point(924, 442);
            btcClear.Name = "btcClear";
            btcClear.Size = new Size(94, 29);
            btcClear.TabIndex = 3;
            btcClear.Text = "Clear";
            btcClear.UseVisualStyleBackColor = true;
            btcClear.Click += BtnClear_Click;
            // 
            // btnList
            // 
            btnList.Location = new Point(924, 496);
            btnList.Name = "btnList";
            btnList.Size = new Size(94, 29);
            btnList.TabIndex = 4;
            btnList.Text = "DTC List";
            btnList.UseVisualStyleBackColor = true;
            btnList.Click += btnList_Click;
            // 
            // troubleCodes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnList);
            Controls.Add(btcClear);
            Controls.Add(btnScan);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "troubleCodes";
            Size = new Size(1075, 542);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colCode;
        private DataGridViewTextBoxColumn colDescription;
        private Button btnScan;
        private Button btcClear;
        private Button btnList;
    }
}
