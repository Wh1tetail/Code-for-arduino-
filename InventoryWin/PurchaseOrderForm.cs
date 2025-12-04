using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryWin
{
    public partial class PurchaseOrderForm : Form
    {
        private readonly DataTable _lines = new();

        public PurchaseOrderForm()
        {
            InitializeComponent();
            InitLines();
        }

        private void PurchaseOrderForm_Load(object? sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Today;
            LoadWarehouses();
            LoadParts();
        }

        private void InitLines()
        {
            _lines.Columns.Add("PartId", typeof(int));
            _lines.Columns.Add("PartName", typeof(string));
            _lines.Columns.Add("BatchId", typeof(int));
            _lines.Columns.Add("BatchNumber", typeof(string));
            _lines.Columns.Add("Amount", typeof(decimal));

            dgvLines.DataSource = _lines;
            dgvLines.Columns["PartId"].Visible = false;
            dgvLines.Columns["BatchId"].Visible = false;

            var col = new DataGridViewLinkColumn
            {
                HeaderText = "Action",
                Text = "Remove",
                UseColumnTextForLinkValue = true
            };
            dgvLines.Columns.Add(col);
            dgvLines.CellContentClick += dgvLines_CellContentClick;
        }

        private void LoadWarehouses()
        {
            try
            {
                var dt = Db.Query("SELECT Id, Name FROM Warehouses ORDER BY Name");
                cboWarehouse.DataSource = dt;
                cboWarehouse.DisplayMember = "Name";
                cboWarehouse.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки складов: " + ex.Message);
            }
        }

        private void LoadParts()
        {
            try
            {
                var dt = Db.Query("SELECT Id, Name, IsBatchTracked FROM Parts ORDER BY Name");
                cboPart.DataSource = dt;
                cboPart.DisplayMember = "Name";
                cboPart.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки деталей: " + ex.Message);
            }
        }

        private void cboPart_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboPart.SelectedItem is DataRowView row)
            {
                bool isBatch = row.Row.Table.Columns.Contains("IsBatchTracked") &&
                               row["IsBatchTracked"] != DBNull.Value &&
                               (bool)row["IsBatchTracked"];

                cboBatch.Enabled = isBatch;

                if (isBatch)
                {
                    int partId = (int)row["Id"];
                    var dt = Db.Query(
                        "SELECT Id, BatchNumber FROM PartBatches WHERE PartId = @PartId ORDER BY BatchNumber",
                        new SqlParameter("@PartId", partId));
                    cboBatch.DataSource = dt;
                    cboBatch.DisplayMember = "BatchNumber";
                    cboBatch.ValueMember = "Id";
                }
                else
                {
                    cboBatch.DataSource = null;
                    cboBatch.Text = "";
                }
            }
        }

        private void btnAddToList_Click(object? sender, EventArgs e)
        {
            if (cboPart.SelectedItem is not DataRowView partRow)
            {
                MessageBox.Show("Выберите деталь.");
                return;
            }

            int partId = (int)partRow["Id"];
            string partName = partRow["Name"].ToString() ?? "";

            int? batchId = null;
            string batchNumber = "";

            bool isBatch = partRow.Row.Table.Columns.Contains("IsBatchTracked") &&
                           partRow["IsBatchTracked"] != DBNull.Value &&
                           (bool)partRow["IsBatchTracked"];

            if (isBatch)
            {
                if (cboBatch.SelectedItem is not DataRowView batchRow)
                {
                    MessageBox.Show("Выберите партию.");
                    return;
                }

                batchId = (int)batchRow["Id"];
                batchNumber = batchRow["BatchNumber"].ToString() ?? "";
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Некорректное количество.");
                return;
            }

            var row = _lines.NewRow();
            row["PartId"] = partId;
            row["PartName"] = partName;
            row["BatchId"] = batchId.HasValue ? (object)batchId.Value : DBNull.Value;
            row["BatchNumber"] = batchNumber;
            row["Amount"] = amount;
            _lines.Rows.Add(row);
        }

        private void dgvLines_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvLines.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
            {
                dgvLines.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnSubmit_Click(object? sender, EventArgs e)
        {
            if (cboWarehouse.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад.");
                return;
            }
            if (_lines.Rows.Count == 0)
            {
                MessageBox.Show("Добавьте позиции.");
                return;
            }

            int warehouseId = (int)cboWarehouse.SelectedValue;
            DateTime date = dtpDate.Value.Date;

            using var conn = new SqlConnection(Db.ConnectionString);
            conn.Open();
            using var tran = conn.BeginTransaction();

            try
            {
                var cmdOrder = new SqlCommand(
                    "INSERT INTO PurchaseOrders (WarehouseId, DocDate) VALUES (@Wh, @Date); SELECT SCOPE_IDENTITY();",
                    conn, tran);
                cmdOrder.Parameters.AddWithValue("@Wh", warehouseId);
                cmdOrder.Parameters.AddWithValue("@Date", date);
                int orderId = Convert.ToInt32(cmdOrder.ExecuteScalar());

                foreach (DataRow line in _lines.Rows)
                {
                    int partId = (int)line["PartId"];
                    object batchIdObj = line["BatchId"];
                    decimal amount = (decimal)line["Amount"];
                    int? batchId = batchIdObj == DBNull.Value ? (int?)null : Convert.ToInt32(batchIdObj);

                    var cmdLine = new SqlCommand(
                        "INSERT INTO PurchaseOrderLines (PurchaseOrderId, PartId, BatchId, Amount) " +
                        "VALUES (@OrderId, @PartId, @BatchId, @Amount);",
                        conn, tran);
                    cmdLine.Parameters.AddWithValue("@OrderId", orderId);
                    cmdLine.Parameters.AddWithValue("@PartId", partId);
                    cmdLine.Parameters.AddWithValue("@Amount", amount);
                    cmdLine.Parameters.AddWithValue("@BatchId", (object?)batchId ?? DBNull.Value);
                    cmdLine.ExecuteNonQuery();

                    var cmdInv = new SqlCommand(
                        "INSERT INTO InventoryTransactions " +
                        "(PartId, WarehouseId, BatchId, TranDate, Quantity, SourceType, SourceId) " +
                        "VALUES (@PartId, @Wh, @BatchId, @Date, @Qty, 'PO', @OrderId);",
                        conn, tran);
                    cmdInv.Parameters.AddWithValue("@PartId", partId);
                    cmdInv.Parameters.AddWithValue("@Wh", warehouseId);
                    cmdInv.Parameters.AddWithValue("@BatchId", (object?)batchId ?? DBNull.Value);
                    cmdInv.Parameters.AddWithValue("@Date", date);
                    cmdInv.Parameters.AddWithValue("@Qty", amount);
                    cmdInv.Parameters.AddWithValue("@OrderId", orderId);
                    cmdInv.ExecuteNonQuery();
                }

                tran.Commit();
                MessageBox.Show("Приход сохранён.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("Ошибка сохранения: " + ex.Message);
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
