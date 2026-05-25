namespace Autobot2
{
    partial class Diagnosis
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UnsubscribeAll();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            dgvPID = new DataGridView();
            colPID = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colVal = new DataGridViewTextBoxColumn();
            colMin = new DataGridViewTextBoxColumn();
            colAvg = new DataGridViewTextBoxColumn();
            colMax = new DataGridViewTextBoxColumn();
            btnStart = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPID).BeginInit();
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
            label1.Size = new Size(333, 85);
            label1.TabIndex = 2;
            label1.Text = "Diagnosis";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.tools__1_;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 125);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // dgvPID
            // 
            dgvPID.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPID.Columns.AddRange(new DataGridViewColumn[] { colPID, colDescription, colVal, colMin, colAvg, colMax });
            dgvPID.Location = new Point(37, 147);
            dgvPID.Name = "dgvPID";
            dgvPID.RowHeadersWidth = 51;
            dgvPID.Size = new Size(999, 330);
            dgvPID.TabIndex = 1;
            // 
            // colPID
            // 
            colPID.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colPID.HeaderText = "PID";
            colPID.MinimumWidth = 6;
            colPID.Name = "colPID";
            colPID.ReadOnly = true;
            colPID.Width = 61;
            // 
            // colDescription
            // 
            colDescription.HeaderText = "Description";
            colDescription.MinimumWidth = 6;
            colDescription.Name = "colDescription";
            colDescription.ReadOnly = true;
            colDescription.Width = 300;
            // 
            // colVal
            // 
            colVal.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colVal.HeaderText = "Value";
            colVal.MinimumWidth = 6;
            colVal.Name = "colVal";
            colVal.ReadOnly = true;
            // 
            // colMin
            // 
            colMin.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMin.HeaderText = "Minimum";
            colMin.MinimumWidth = 6;
            colMin.Name = "colMin";
            colMin.ReadOnly = true;
            // 
            // colAvg
            // 
            colAvg.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colAvg.HeaderText = "Average";
            colAvg.MinimumWidth = 6;
            colAvg.Name = "colAvg";
            colAvg.ReadOnly = true;
            // 
            // colMax
            // 
            colMax.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMax.HeaderText = "Max";
            colMax.MinimumWidth = 6;
            colMax.Name = "colMax";
            colMax.ReadOnly = true;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(942, 496);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 29);
            btnStart.TabIndex = 3;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // Diagnosis
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnStart);
            Controls.Add(dgvPID);
            Controls.Add(panel1);
            Name = "Diagnosis";
            Size = new Size(1075, 542);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPID).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private DataGridView dgvPID;
        private DataGridViewTextBoxColumn colPID;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colVal;
        private DataGridViewTextBoxColumn colMin;
        private DataGridViewTextBoxColumn colAvg;
        private DataGridViewTextBoxColumn colMax;
        private Button btnStart;
    }
}