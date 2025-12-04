using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using System.Collections.Generic;

namespace InventoryDashboardWin
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object? sender, EventArgs e)
        {
            LoadDemoData();

            cboLanguage.Items.Clear();
            cboLanguage.Items.Add("English");
            cboLanguage.Items.Add("Русский");
            cboLanguage.SelectedIndex = 0;
        }

        private void LoadDemoData()
        {
            var dtDept = new DataTable();
            dtDept.Columns.Add("Department");
            dtDept.Columns.Add("2019-08", typeof(decimal));
            dtDept.Columns.Add("2019-07", typeof(decimal));
            dtDept.Columns.Add("2019-03", typeof(decimal));
            dtDept.Columns.Add("2018-12", typeof(decimal));

            dtDept.Rows.Add("Yolka",        0,     42020,      0, 14800);
            dtDept.Rows.Add("Office Center",8800,  15000,      0,     0);
            dtDept.Rows.Add("Kazan 554",   1670,   9800,   5400,     0);

            dgvDeptSpending.DataSource = dtDept;
            dgvDeptSpending.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            HighlightDeptSpending(dtDept);

            var dtParts = new DataTable();
            dtParts.Columns.Add("Notes/Month");
            dtParts.Columns.Add("2019-08");
            dtParts.Columns.Add("2019-07");
            dtParts.Columns.Add("2019-03");
            dtParts.Columns.Add("2018-12");

            dtParts.Rows.Add("Highest Cost",
                "MOCA Engine Timing Chain Kit",
                "ALAVENTE 21100-35463 Carburetor",
                "bop control Kit F4",
                "Wireline log Counter K4");

            dtParts.Rows.Add("Most Number",
                "FAN 24" M480",
                "Ohmmeter M857",
                "ball bearings 1/2" .5",
                "");

            dgvMostUsedParts.DataSource = dtParts;
            dgvMostUsedParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var dtAssets = new DataTable();
            dtAssets.Columns.Add("Asset Name / Month");
            dtAssets.Columns.Add("2019-08");
            dtAssets.Columns.Add("2019-07");
            dtAssets.Columns.Add("2019-03");
            dtAssets.Columns.Add("2018-12");

            dtAssets.Rows.Add("Asset",
                "Drilling K580",
                "Hydro-processing Reactors L5878",
                "Storage Bullets ML80",
                "C LG process HCK reactor 358 mm");

            dtAssets.Rows.Add("Department",
                "Yolka",
                "Kazan 554",
                "Kazan 554",
                "Yolka");

            dgvCostlyAssets.DataSource = dtAssets;
            dgvCostlyAssets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            FillPieChart(dtDept);
            FillBarChart(dtDept);
        }

        private void HighlightDeptSpending(DataTable dt)
        {
            for (int col = 1; col < dt.Columns.Count; col++)
            {
                decimal min = decimal.MaxValue;
                decimal max = decimal.MinValue;

                foreach (DataRow row in dt.Rows)
                {
                    decimal value = Convert.ToDecimal(row[col]);
                    if (value < min) min = value;
                    if (value > max) max = value;
                }

                foreach (DataGridViewRow gvRow in dgvDeptSpending.Rows)
                {
                    decimal value = Convert.ToDecimal(gvRow.Cells[col].Value);
                    if (value == max && max > 0)
                        gvRow.Cells[col].Style.ForeColor = System.Drawing.Color.Red;
                    else if (value == min && min > 0)
                        gvRow.Cells[col].Style.ForeColor = System.Drawing.Color.Green;
                }
            }
        }

        private void FillPieChart(DataTable dt)
        {
            chartDeptRatio.Series.Clear();
            var series = new Series("Spending");
            series.ChartType = SeriesChartType.Pie;

            int monthColIndex = 1;
            foreach (DataRow row in dt.Rows)
            {
                string dept = row["Department"].ToString() ?? "";
                decimal value = Convert.ToDecimal(row[monthColIndex]);
                series.Points.AddXY(dept, value);
            }

            chartDeptRatio.Series.Add(series);
        }

        private void FillBarChart(DataTable dt)
        {
            chartMonthlySpending.Series.Clear();
            chartMonthlySpending.ChartAreas[0].AxisX.Interval = 1;

            for (int rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++)
            {
                var row = dt.Rows[rowIndex];
                string dept = row["Department"].ToString() ?? "";
                var series = new Series(dept);
                series.ChartType = SeriesChartType.Column;

                for (int colIndex = 1; colIndex < dt.Columns.Count; colIndex++)
                {
                    string month = dt.Columns[colIndex].ColumnName;
                    decimal value = Convert.ToDecimal(row[colIndex]);
                    series.Points.AddXY(month, value);
                }

                chartMonthlySpending.Series.Add(series);
            }
        }

        private void btnInventoryControl_Click(object? sender, EventArgs e)
        {
            using var f = new InventoryControlForm();
            f.ShowDialog(this);
        }

        private void btnClose_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void cboLanguage_SelectedIndexChanged(object? sender, EventArgs e)
        {
            string code = cboLanguage.SelectedItem?.ToString() switch
            {
                "Русский" => "ru",
                _ => "en"
            };

            ApplyLanguage(code);
        }

        private void ApplyLanguage(string langCode)
        {
            try
            {
                string file = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lang", langCode + ".xml");
                if (!System.IO.File.Exists(file))
                    return;

                var doc = XDocument.Load(file);
                var dict = new Dictionary<string, string>();
                foreach (var item in doc.Root!.Elements("Item"))
                {
                    string key = item.Attribute("Key")?.Value ?? "";
                    string val = item.Attribute("Value")?.Value ?? "";
                    if (!string.IsNullOrEmpty(key))
                        dict[key] = val;
                }

                if (dict.TryGetValue("Dashboard.Title", out var t)) this.Text = t;
                if (dict.TryGetValue("Dashboard.InventoryControlButton", out var inv)) btnInventoryControl.Text = inv;
                if (dict.TryGetValue("Common.Close", out var cl)) btnClose.Text = cl;
                if (dict.TryGetValue("Common.Language", out var langLbl)) lblLanguage.Text = langLbl;
                if (dict.TryGetValue("Dashboard.SpendingByDept", out var s1)) grpDeptSpending.Text = s1;
                if (dict.TryGetValue("Dashboard.MostUsedParts", out var s2)) grpMostUsedParts.Text = s2;
                if (dict.TryGetValue("Dashboard.CostlyAssets", out var s3)) grpCostlyAssets.Text = s3;
                if (dict.TryGetValue("Dashboard.DeptRatio", out var s4)) grpDeptRatio.Text = s4;
                if (dict.TryGetValue("Dashboard.MonthlyDeptSpending", out var s5)) grpMonthlySpending.Text = s5;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки языка: " + ex.Message);
            }
        }
    }
}
