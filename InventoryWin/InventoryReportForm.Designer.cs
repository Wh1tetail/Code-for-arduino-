using System.Windows.Forms;

namespace InventoryWin
{
    partial class InventoryReportForm
    {
        private System.ComponentModel.IContainer components = null!;
        private ComboBox cboWarehouse;
        private Label labelWarehouse;
        private GroupBox grpType;
        private RadioButton rbCurrentStock;
        private RadioButton rbReceivedStock;
        private RadioButton rbOutOfStock;
        private DataGridView dgvResult;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cboWarehouse = new System.Windows.Forms.ComboBox();
            this.labelWarehouse = new System.Windows.Forms.Label();
            this.grpType = new System.Windows.Forms.GroupBox();
            this.rbOutOfStock = new System.Windows.Forms.RadioButton();
            this.rbReceivedStock = new System.Windows.Forms.RadioButton();
            this.rbCurrentStock = new System.Windows.Forms.RadioButton();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.grpType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // labelWarehouse
            // 
            this.labelWarehouse.AutoSize = true;
            this.labelWarehouse.Location = new System.Drawing.Point(12, 15);
            this.labelWarehouse.Name = "labelWarehouse";
            this.labelWarehouse.Size = new System.Drawing.Size(65, 15);
            this.labelWarehouse.TabIndex = 0;
            this.labelWarehouse.Text = "Warehouse:";
            // 
            // cboWarehouse
            // 
            this.cboWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWarehouse.FormattingEnabled = true;
            this.cboWarehouse.Location = new System.Drawing.Point(83, 12);
            this.cboWarehouse.Name = "cboWarehouse";
            this.cboWarehouse.Size = new System.Drawing.Size(220, 23);
            this.cboWarehouse.TabIndex = 1;
            this.cboWarehouse.SelectedIndexChanged += new System.EventHandler(this.cboWarehouse_SelectedIndexChanged);
            // 
            // grpType
            // 
            this.grpType.Controls.Add(this.rbOutOfStock);
            this.grpType.Controls.Add(this.rbReceivedStock);
            this.grpType.Controls.Add(this.rbCurrentStock);
            this.grpType.Location = new System.Drawing.Point(320, 5);
            this.grpType.Name = "grpType";
            this.grpType.Size = new System.Drawing.Size(310, 40);
            this.grpType.TabIndex = 2;
            this.grpType.TabStop = false;
            this.grpType.Text = "Inventory Type";
            // 
            // rbCurrentStock
            // 
            this.rbCurrentStock.AutoSize = true;
            this.rbCurrentStock.Location = new System.Drawing.Point(10, 17);
            this.rbCurrentStock.Name = "rbCurrentStock";
            this.rbCurrentStock.Size = new System.Drawing.Size(92, 19);
            this.rbCurrentStock.TabIndex = 0;
            this.rbCurrentStock.TabStop = true;
            this.rbCurrentStock.Text = "Current stock";
            this.rbCurrentStock.UseVisualStyleBackColor = true;
            this.rbCurrentStock.CheckedChanged += new System.EventHandler(this.rbType_CheckedChanged);
            // 
            // rbReceivedStock
            // 
            this.rbReceivedStock.AutoSize = true;
            this.rbReceivedStock.Location = new System.Drawing.Point(108, 17);
            this.rbReceivedStock.Name = "rbReceivedStock";
            this.rbReceivedStock.Size = new System.Drawing.Size(100, 19);
            this.rbReceivedStock.TabIndex = 1;
            this.rbReceivedStock.TabStop = true;
            this.rbReceivedStock.Text = "Received stock";
            this.rbReceivedStock.UseVisualStyleBackColor = true;
            this.rbReceivedStock.CheckedChanged += new System.EventHandler(this.rbType_CheckedChanged);
            // 
            // rbOutOfStock
            // 
            this.rbOutOfStock.AutoSize = true;
            this.rbOutOfStock.Location = new System.Drawing.Point(214, 17);
            this.rbOutOfStock.Name = "rbOutOfStock";
            this.rbOutOfStock.Size = new System.Drawing.Size(82, 19);
            this.rbOutOfStock.TabIndex = 2;
            this.rbOutOfStock.TabStop = true;
            this.rbOutOfStock.Text = "Out of stock";
            this.rbOutOfStock.UseVisualStyleBackColor = true;
            this.rbOutOfStock.CheckedChanged += new System.EventHandler(this.rbType_CheckedChanged);
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(12, 60);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(776, 330);
            this.dgvResult.TabIndex = 3;
            // 
            // InventoryReportForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 402);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.grpType);
            this.Controls.Add(this.cboWarehouse);
            this.Controls.Add(this.labelWarehouse);
            this.Name = "InventoryReportForm";
            this.Text = "Inventory Report";
            this.Load += new System.EventHandler(this.InventoryReportForm_Load);
            this.grpType.ResumeLayout(false);
            this.grpType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
