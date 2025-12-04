using System;
using System.Data;
using System.Windows.Forms;

namespace InventoryWin
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            try
            {
                LoadTransactions();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки движений: " + ex.Message);
            }
        }

        private void LoadTransactions()
        {
            string sql = @"
SELECT TOP 200
    p.Name           AS PartName,
    it.SourceType    AS [Transaction Type],
    it.TranDate      AS [Date],
    it.Quantity      AS Amount,
    it.WarehouseId   AS WarehouseId,
    it.BatchId       AS BatchId
FROM InventoryTransactions it
JOIN Parts p ON p.Id = it.PartId
ORDER BY it.TranDate DESC, it.Id DESC";

            var dt = Db.Query(sql);
            dgvTransactions.DataSource = dt;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnPurchaseOrder_Click(object? sender, EventArgs e)
        {
            using var f = new PurchaseOrderForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                LoadTransactions();
            }
        }

        private void btnWarehouseTransfer_Click(object? sender, EventArgs e)
        {
            using var f = new WarehouseTransferForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                LoadTransactions();
            }
        }

        private void btnInventoryReport_Click(object? sender, EventArgs e)
        {
            using var f = new InventoryReportForm();
            f.ShowDialog(this);
        }
    }
}
