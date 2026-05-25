using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autobot2
{
    public partial class troubleCodes : UserControl
    {
        private Dictionary<string, string> _dtcDictionary = new();
        private List<string> _activeCodes = new();
        private readonly Random _rng = new();

        private readonly string _csvPath =
            Path.Combine(Application.StartupPath, "DTC_List.csv");

        private static readonly string[] MockDtcPool =
        {
            "P0101","P0113","P0118","P0128","P0133",
            "P0171","P0174","P0300","P0301","P0302",
            "P0303","P0304","P0401","P0420","P0442",
            "P0455","P0505","P0700",
            "B0001","B0010","B0020",
            "C0035","C0040","C0051",
            "U0100","U0073","U0140"
        };

        public troubleCodes()
        {
            InitializeComponent();
            StyleGrid();
            LoadDtcDictionary();

            btnScan.Click += BtnScan_Click;
            btcClear.Click += BtnClear_Click;
        }

        
        private async void BtnScan_Click(object sender, EventArgs e)
        {
            SetButtonsEnabled(false);
            btnScan.Text = "Scanning…";
            dataGridView1.Rows.Clear();

            await Task.Delay(_rng.Next(1800, 3500));

            _activeCodes = MockDtcPool
                .OrderBy(_ => _rng.Next())
                .Take(_rng.Next(2, 7))
                .ToList();

            PopulateGrid(_activeCodes);

            btnScan.Text = "Scan";
            SetButtonsEnabled(true);

            MessageBox.Show(
                $"{_activeCodes.Count} trouble code(s) detected.",
                "Scan Complete",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private async void BtnClear_Click(object sender, EventArgs e)
        {
            if (_activeCodes.Count == 0)
            {
                MessageBox.Show(
                    "No active trouble codes to clear.",
                    "Nothing to Clear",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"Clear all {_activeCodes.Count} trouble code(s) from the ECU?\n\nProceed?",
                "Confirm Clear",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            SetButtonsEnabled(false);
            btcClear.Text = "Clearing…";

            await Task.Delay(_rng.Next(1000, 2000));

            _activeCodes.Clear();
            dataGridView1.Rows.Clear();

            btcClear.Text = "Clear";
            SetButtonsEnabled(true);

            MessageBox.Show(
                "All trouble codes cleared successfully.",
                "Clear Complete",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            new DTC_List().Show();
        }


        private void LoadDtcDictionary()
        {
            _dtcDictionary.Clear();

            if (!File.Exists(_csvPath)) return;

            try
            {
                foreach (var line in File.ReadLines(_csvPath).Skip(1))  
                {
                    var parts = line.Split(',', 2);
                    if (parts.Length == 2)
                    {
                        var code = parts[0].Trim().ToUpper();
                        var desc = parts[1].Trim().Trim('"');
                        if (!string.IsNullOrEmpty(code))
                            _dtcDictionary[code] = desc;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading DTC_List.csv:\n{ex.Message}",
                                "CSV Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateGrid(List<string> codes)
        {
            dataGridView1.Rows.Clear();

            foreach (var code in codes)
            {
                var upper = code.ToUpper();
                var desc = _dtcDictionary.TryGetValue(upper, out var d)
                            ? d
                            : "Description not found in DTC list";

                int idx = dataGridView1.Rows.Add(upper, desc);
                dataGridView1.Rows[idx].DefaultCellStyle.BackColor = CategoryColor(upper);
            }
        }

        private static Color CategoryColor(string code) => code.Length > 0 ? code[0] switch
        {
            'P' => Color.FromArgb(255, 220, 220),   
            'B' => Color.FromArgb(255, 243, 190),   
            'C' => Color.FromArgb(190, 220, 255),   
            'U' => Color.FromArgb(190, 240, 200),    
            _ => Color.White
        } : Color.White;

        private void StyleGrid()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void SetButtonsEnabled(bool enabled)
        {
            btnScan.Enabled = enabled;
            btcClear.Enabled = enabled;
            btnList.Enabled = enabled;
        }
    }
}