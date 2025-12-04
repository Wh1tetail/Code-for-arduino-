using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryDashboardWin
{
    public partial class InventoryControlForm : Form
    {
        private readonly DataTable _allocated = new();
        private readonly DataTable _assigned = new();

        public InventoryControlForm()
        {
            InitializeComponent();
            InitTables();
        }

        private void InventoryControlForm_Load(object? sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Today;
            LoadWarehouses();
            LoadParts();
            cboAllocationMethod.SelectedIndex = 0;
        }

        private void InitTables()
        {
            _allocated.Columns.Add("PartId", typeof(int));
            _allocated.Columns.Add("PartName", typeof(string));
            _allocated.Columns.Add("BatchId", typeof(int));
            _allocated.Columns.Add("BatchNumber", typeof(string));
            _allocated.Columns.Add("UnitPrice", typeof(decimal));
            _allocated.Columns.Add("Amount", typeof(decimal));

            dgvAllocatedParts.DataSource = _allocated;
            dgvAllocatedParts.Columns["PartId"].Visible = false;
            dgvAllocatedParts.Columns["BatchId"].Visible = false;
            dgvAllocatedParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            _assigned.Columns.Add("PartId", typeof(int));
            _assigned.Columns.Add("PartName", typeof(string));
            _assigned.Columns.Add("BatchId", typeof(int));
            _assigned.Columns.Add("BatchNumber", typeof(string));
            _assigned.Columns.Add("UnitPrice", typeof(decimal));
            _assigned.Columns.Add("Amount", typeof(decimal));

            dgvAssignedParts.DataSource = _assigned;
            dgvAssignedParts.Columns["PartId"].Visible = false;
            dgvAssignedParts.Columns["BatchId"].Visible = false;
            dgvAssignedParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var col = new DataGridViewLinkColumn
            {
                HeaderText = "Action",
                Text = "Remove",
                UseColumnTextForLinkValue = true
            };
            dgvAssignedParts.Columns.Add(col);
            dgvAssignedParts.CellContentClick += dgvAssignedParts_CellContentClick;
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
                var dt = Db.Query("SELECT Id, Name FROM Parts ORDER BY Name");
                cboPart.DataSource = dt;
                cboPart.DisplayMember = "Name";
                cboPart.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки деталей: " + ex.Message);
            }
        }

        private void btnAllocate_Click(object? sender, EventArgs e)
        {
            if (cboWarehouse.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад.");
                return;
            }
            if (cboPart.SelectedValue == null)
            {
                MessageBox.Show("Выберите деталь.");
                return;
            }
            if (!decimal.TryParse(txtAmount.Text, out decimal needAmount) || needAmount <= 0)
            {
                MessageBox.Show("Некорректное количество.");
                return;
            }

            int warehouseId = (int)cboWarehouse.SelectedValue;
            int partId = (int)cboPart.SelectedValue;
            string method = cboAllocationMethod.SelectedItem?.ToString() ?? "FIFO";

            var sql = @"
SELECT 
    it.BatchId,
    ISNULL(pb.BatchNumber, '') AS BatchNumber,
    SUM(it.Quantity) AS Stock,
    MIN(it.TranDate) AS FirstDate,
    MAX(it.TranDate) AS LastDate
FROM InventoryTransactions it
LEFT JOIN PartBatches pb ON pb.Id = it.BatchId
WHERE it.WarehouseId = @Wh AND it.PartId = @Part
GROUP BY it.BatchId, pb.BatchNumber
HAVING SUM(it.Quantity) > 0";

            var dt = Db.Query(sql,
                new SqlParameter("@Wh", warehouseId),
                new SqlParameter("@Part", partId));

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Нет доступных остатков для выбранной детали.");
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                int? batchId = row["BatchId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["BatchId"]);
                decimal stock = Convert.ToDecimal(row["Stock"]);

                foreach (DataRow assigned in _assigned.Rows)
                {
                    int assignedPartId = (int)assigned["PartId"];
                    int? assignedBatchId = assigned["BatchId"] == DBNull.Value ? (int?)null : Convert.ToInt32(assigned["BatchId"]);
                    if (assignedPartId == partId && assignedBatchId == batchId)
                    {
                        stock -= (decimal)assigned["Amount"];
                    }
                }

                row["Stock"] = stock;
            }

            var rows = dt.Select("Stock > 0");
            if (rows.Length == 0)
            {
                MessageBox.Show("Доступного остатка с учётом уже назначенных деталей нет.");
                return;
            }

            Array.Sort(rows, (a, b) =>
            {
                if (method.StartsWith("FIFO"))
                {
                    return ((DateTime)a["FirstDate"]).CompareTo((DateTime)b["FirstDate"]);
                }
                else if (method.StartsWith("LIFO"))
                {
                    return -((DateTime)a["LastDate"]).CompareTo((DateTime)b["LastDate"]);
                }
                else
                {
                    return string.Compare(a["BatchNumber"].ToString(), b["BatchNumber"].ToString(), StringComparison.OrdinalIgnoreCase);
                }
            });

            _allocated.Rows.Clear();
            decimal remaining = needAmount;

            foreach (var r in rows)
            {
                if (remaining <= 0) break;
                decimal stock = (decimal)r["Stock"];
                if (stock <= 0) continue;

                decimal take = Math.Min(stock, remaining);
                remaining -= take;

                var newRow = _allocated.NewRow();
                newRow["PartId"] = partId;
                newRow["PartName"] = ((DataRowView)cboPart.SelectedItem)["Name"].ToString();
                newRow["BatchId"] = r["BatchId"] == DBNull.Value ? (object)DBNull.Value : r["BatchId"];
                newRow["BatchNumber"] = r["BatchNumber"].ToString();
                newRow["UnitPrice"] = 0m;
                newRow["Amount"] = take;
                _allocated.Rows.Add(newRow);
            }

            if (remaining > 0)
            {
                MessageBox.Show("Предупреждение: доступных запасов меньше, чем требуется. Распределено только " + (needAmount - remaining));
            }
        }

        private void btnAssignToEm_Click(object? sender, EventArgs e)
        {
            if (_allocated.Rows.Count == 0)
            {
                MessageBox.Show("Нет распределённых деталей.");
                return;
            }

            foreach (DataRow row in _allocated.Rows)
            {
                var newRow = _assigned.NewRow();
                newRow.ItemArray = (object[])row.ItemArray.Clone();
                _assigned.Rows.Add(newRow);
            }
            _allocated.Rows.Clear();
        }

        private void dgvAssignedParts_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAssignedParts.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
            {
                dgvAssignedParts.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnSubmit_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAssetName.Text))
            {
                MessageBox.Show("Укажите актив (EM number).");
                return;
            }
            if (_assigned.Rows.Count == 0)
            {
                MessageBox.Show("Нет назначенных деталей.");
                return;
            }

            MessageBox.Show("Детали успешно назначены активу "" + txtAssetName.Text + "".");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
