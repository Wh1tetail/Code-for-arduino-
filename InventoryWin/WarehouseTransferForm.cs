using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryWin
{
    public partial class WarehouseTransferForm : Form
    {
        private readonly DataTable _lines = new();

        public WarehouseTransferForm()
        {
            InitializeComponent();
            InitLines();
        }

        private void WarehouseTransferForm_Load(object? sender, EventArgs e)
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
            var dt = Db.Query("SELECT Id, Name FROM Warehouses ORDER BY Name");
            cboSourceWarehouse.DataSource = dt.Copy();
            cboSourceWarehouse.DisplayMember = "Name";
            cboSourceWarehouse.ValueMember = "Id";

            cboDestinationWarehouse.DataSource = dt;
            cboDestinationWarehouse.DisplayMember = "Name";
            cboDestinationWarehouse.ValueMember = "Id";
        }

        private void LoadParts()
        {
            var dt = Db.Query("SELECT Id, Name, IsBatchTracked FROM Parts ORDER BY Name");
            cboPart.DataSource = dt;
            cboPart.DisplayMember = "Name";
            cboPart.ValueMember = "Id";
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
                    var dt = Db.Query("SELECT Id, BatchNumber FROM PartBatches WHERE PartId = @P",
                        new SqlParameter("@P", partId));
                    cboBatch.DataSource = dt;
                    cboBatch.DisplayMember = "BatchNumber";
                    cboBatch.ValueMember = "Id";
                }
                else
                {
                    cboBatch.DataSource = null;
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
            if (cboSourceWarehouse.SelectedValue == null || cboDestinationWarehouse.SelectedValue == null)
            {
                MessageBox.Show("Выберите склады.");
                return;
            }
            if (Equals(cboSourceWarehouse.SelectedValue, cboDestinationWarehouse.SelectedValue))
            {
                MessageBox.Show("Склады должны отличаться.");
                return;
            }
            if (_lines.Rows.Count == 0)
            {
                MessageBox.Show("Добавьте позиции.");
                return;
            }

            int sourceId = (int)cboSourceWarehouse.SelectedValue;
            int destId = (int)cboDestinationWarehouse.SelectedValue;
            DateTime date = dtpDate.Value.Date;

            using var conn = new SqlConnection(Db.ConnectionString);
            conn.Open();
            using var tran = conn.BeginTransaction();

            try
            {
                var cmdHeader = new SqlCommand(
                    "INSERT INTO WarehouseTransfers (SourceWarehouseId, DestinationWarehouseId, DocDate) " +
                    "VALUES (@S, @D, @Date); SELECT SCOPE_IDENTITY();", conn, tran);
                cmdHeader.Parameters.AddWithValue("@S", sourceId);
                cmdHeader.Parameters.AddWithValue("@D", destId);
                cmdHeader.Parameters.AddWithValue("@Date", date);
                int transferId = Convert.ToInt32(cmdHeader.ExecuteScalar());

                foreach (DataRow line in _lines.Rows)
                {
                    int partId = (int)line["PartId"];
                    object batchIdObj = line["BatchId"];
                    decimal amount = (decimal)line["Amount"];
                    int? batchId = batchIdObj == DBNull.Value ? (int?)null : Convert.ToInt32(batchIdObj);

                    var cmdLine = new SqlCommand(
                        "INSERT INTO WarehouseTransferLines (WarehouseTransferId, PartId, BatchId, Amount) " +
                        "VALUES (@Tr, @Part, @Batch, @Amt);", conn, tran);
                    cmdLine.Parameters.AddWithValue("@Tr", transferId);
                    cmdLine.Parameters.AddWithValue("@Part", partId);
                    cmdLine.Parameters.AddWithValue("@Amt", amount);
                    cmdLine.Parameters.AddWithValue("@Batch", (object?)batchId ?? DBNull.Value);
                    cmdLine.ExecuteNonQuery();

                    var cmdOut = new SqlCommand(
                        "INSERT INTO InventoryTransactions " +
                        "(PartId, WarehouseId, BatchId, TranDate, Quantity, SourceType, SourceId) " +
                        "VALUES (@Part, @Wh, @Batch, @Date, @Qty, 'WT_OUT', @Tr);", conn, tran);
                    cmdOut.Parameters.AddWithValue("@Part", partId);
                    cmdOut.Parameters.AddWithValue("@Wh", sourceId);
                    cmdOut.Parameters.AddWithValue("@Batch", (object?)batchId ?? DBNull.Value);
                    cmdOut.Parameters.AddWithValue("@Date", date);
                    cmdOut.Parameters.AddWithValue("@Qty", -amount);
                    cmdOut.Parameters.AddWithValue("@Tr", transferId);
                    cmdOut.ExecuteNonQuery();

                    var cmdIn = new SqlCommand(
                        "INSERT INTO InventoryTransactions " +
                        "(PartId, WarehouseId, BatchId, TranDate, Quantity, SourceType, SourceId) " +
                        "VALUES (@Part, @Wh, @Batch, @Date, @Qty, 'WT_IN', @Tr);", conn, tran);
                    cmdIn.Parameters.AddWithValue("@Part", partId);
                    cmdIn.Parameters.AddWithValue("@Wh", destId);
                    cmdIn.Parameters.AddWithValue("@Batch", (object?)batchId ?? DBNull.Value);
                    cmdIn.Parameters.AddWithValue("@Date", date);
                    cmdIn.Parameters.AddWithValue("@Qty", amount);
                    cmdIn.Parameters.AddWithValue("@Tr", transferId);
                    cmdIn.ExecuteNonQuery();
                }

                tran.Commit();
                MessageBox.Show("Перемещение сохранено.");
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
