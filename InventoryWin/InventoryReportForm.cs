using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryWin
{
    public partial class InventoryReportForm : Form
    {
        public InventoryReportForm()
        {
            InitializeComponent();
        }

        private void InventoryReportForm_Load(object? sender, EventArgs e)
        {
            LoadWarehouses();
        }

        private void LoadWarehouses()
        {
            var dt = Db.Query("SELECT Id, Name FROM Warehouses ORDER BY Name");
            cboWarehouse.DataSource = dt;
            cboWarehouse.DisplayMember = "Name";
            cboWarehouse.ValueMember = "Id";
        }

        private void rbType_CheckedChanged(object? sender, EventArgs e)
        {
            LoadReport();
        }

        private void cboWarehouse_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            if (cboWarehouse.SelectedValue == null) return;
            int warehouseId = (int)cboWarehouse.SelectedValue;

            var dt = Db.Query(@"
SELECT
    p.Name AS PartName,
    SUM(it.Quantity) AS CurrentStock,
    SUM(CASE WHEN it.Quantity > 0 THEN it.Quantity ELSE 0 END) AS ReceivedStock
FROM InventoryTransactions it
JOIN Parts p ON p.Id = it.PartId
WHERE it.WarehouseId = @Wh
GROUP BY p.Name
ORDER BY p.Name",
                new SqlParameter("@Wh", warehouseId));

            DataTable viewTable = dt;

            try
            {
                if (rbCurrentStock.Checked)
                {
                    var rows = dt.Select("CurrentStock > 0");
                    if (rows.Length > 0) viewTable = rows.CopyToDataTable();
                }
                else if (rbReceivedStock.Checked)
                {
                    var rows = dt.Select("ReceivedStock > 0");
                    if (rows.Length > 0) viewTable = rows.CopyToDataTable();
                }
                else if (rbOutOfStock.Checked)
                {
                    var rows = dt.Select("CurrentStock <= 0");
                    if (rows.Length > 0) viewTable = rows.CopyToDataTable();
                }
            }
            catch { }

            dgvResult.DataSource = viewTable;
            dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (!dgvResult.Columns.Contains("Action"))
            {
                var col = new DataGridViewLinkColumn
                {
                    Name = "Action",
                    HeaderText = "Action",
                    Text = "View Batch Numbers",
                    UseColumnTextForLinkValue = true
                };
                dgvResult.Columns.Add(col);
                dgvResult.CellContentClick += dgvResult_CellContentClick;
            }
        }

        private void dgvResult_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!(dgvResult.Columns[e.ColumnIndex] is DataGridViewLinkColumn)) return;
            if (cboWarehouse.SelectedValue == null) return;

            string partName = dgvResult.Rows[e.RowIndex].Cells["PartName"].Value?.ToString() ?? "";
            int warehouseId = (int)cboWarehouse.SelectedValue;

            var dtPart = Db.Query("SELECT Id FROM Parts WHERE Name = @Name",
                new SqlParameter("@Name", partName));
            if (dtPart.Rows.Count == 0) return;
            int partId = (int)dtPart.Rows[0]["Id"];

            var dt = Db.Query(@"
SELECT
    b.BatchNumber,
    SUM(it.Quantity) AS Stock
FROM InventoryTransactions it
JOIN PartBatches b ON b.Id = it.BatchId
WHERE it.WarehouseId = @Wh AND it.PartId = @PartId
GROUP BY b.BatchNumber
HAVING SUM(it.Quantity) <> 0
ORDER BY b.BatchNumber",
                new SqlParameter("@Wh", warehouseId),
                new SqlParameter("@PartId", partId));

            var f = new Form();
            var grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                DataSource = dt
            };
            f.Controls.Add(grid);
            f.Text = "Batches for " + partName;
            f.Width = 400;
            f.Height = 300;
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog(this);
        }
    }
}
