using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Autobot2
{
    public partial class DTC_List : Form
    {
        private List<(string Code, string Description)> _allDtcs = new();
        private readonly string _csvPath =
            Path.Combine(Application.StartupPath, "DTC_List.csv");

        public DTC_List()
        {
            InitializeComponent();
            StyleGrid();
        }

        private void DTC_List_Load(object sender, EventArgs e)
        {
            LoadCsv();
            PopulateGrid(_allDtcs);

            // live search — filters as the user types
            tbxSearch.TextChanged += (s, _) => ApplyFilter(tbxSearch.Text.Trim());
            tbxSearch.PlaceholderText = "Search by code or description…";
        }

        // ── CSV loader ────────────────────────────────────────────────────────
        private void LoadCsv()
        {
            _allDtcs.Clear();

            if (!File.Exists(_csvPath))
            {
                MessageBox.Show(
                    $"DTC_List.csv not found.\n\nExpected location:\n{_csvPath}",
                    "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                foreach (var line in File.ReadLines(_csvPath).Skip(1)) // skip header
                {
                    var parts = line.Split(',', 2);
                    if (parts.Length == 2)
                    {
                        var code = parts[0].Trim().ToUpper();
                        var desc = parts[1].Trim().Trim('"');
                        if (!string.IsNullOrEmpty(code))
                            _allDtcs.Add((code, desc));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading CSV:\n{ex.Message}",
                                "CSV Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── filter logic ──────────────────────────────────────────────────────
        private void ApplyFilter(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                PopulateGrid(_allDtcs);
                return;
            }

            var upper = query.ToUpper();
            var filtered = _allDtcs
                .Where(d => d.Code.Contains(upper) ||
                            d.Description.ToUpper().Contains(upper))
                .ToList();

            PopulateGrid(filtered);
        }

        // ── grid population ───────────────────────────────────────────────────
        private void PopulateGrid(List<(string Code, string Description)> items)
        {
            dataGridView1.Rows.Clear();

            foreach (var (code, desc) in items)
            {
                int idx = dataGridView1.Rows.Add(code, desc);
                dataGridView1.Rows[idx].DefaultCellStyle.BackColor = CategoryColor(code);
            }

            // update title to show count
            Text = string.IsNullOrWhiteSpace(tbxSearch?.Text)
                ? $"DTC List — {items.Count} codes"
                : $"DTC List — {items.Count} result(s) found";
        }

        // ── category colour coding ────────────────────────────────────────────
        private static Color CategoryColor(string code) => code.Length > 0 ? code[0] switch
        {
            'P' => Color.FromArgb(255, 220, 220),   // Powertrain – soft red
            'B' => Color.FromArgb(255, 243, 190),   // Body       – soft amber
            'C' => Color.FromArgb(190, 220, 255),   // Chassis    – soft blue
            'U' => Color.FromArgb(190, 240, 200),   // Network    – soft green
            _ => Color.White
        } : Color.White;

        // ── grid styling ──────────────────────────────────────────────────────
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
    }
}