using System.Windows.Forms;

namespace InventoryWin
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null!;
        private DataGridView dgvTransactions;
        private Button btnPurchaseOrder;
        private Button btnWarehouseTransfer;
        private Button btnInventoryReport;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.btnPurchaseOrder = new System.Windows.Forms.Button();
            this.btnWarehouseTransfer = new System.Windows.Forms.Button();
            this.btnInventoryReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Location = new System.Drawing.Point(12, 12);
            this.dgvTransactions.MultiSelect = false;
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.RowHeadersVisible = false;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.Size = new System.Drawing.Size(760, 330);
            this.dgvTransactions.TabIndex = 0;
            // 
            // btnPurchaseOrder
            // 
            this.btnPurchaseOrder.Location = new System.Drawing.Point(12, 358);
            this.btnPurchaseOrder.Name = "btnPurchaseOrder";
            this.btnPurchaseOrder.Size = new System.Drawing.Size(160, 30);
            this.btnPurchaseOrder.TabIndex = 1;
            this.btnPurchaseOrder.Text = "Purchase Order";
            this.btnPurchaseOrder.UseVisualStyleBackColor = true;
            this.btnPurchaseOrder.Click += new System.EventHandler(this.btnPurchaseOrder_Click);
            // 
            // btnWarehouseTransfer
            // 
            this.btnWarehouseTransfer.Location = new System.Drawing.Point(178, 358);
            this.btnWarehouseTransfer.Name = "btnWarehouseTransfer";
            this.btnWarehouseTransfer.Size = new System.Drawing.Size(190, 30);
            this.btnWarehouseTransfer.TabIndex = 2;
            this.btnWarehouseTransfer.Text = "Warehouse Management";
            this.btnWarehouseTransfer.UseVisualStyleBackColor = true;
            this.btnWarehouseTransfer.Click += new System.EventHandler(this.btnWarehouseTransfer_Click);
            // 
            // btnInventoryReport
            // 
            this.btnInventoryReport.Location = new System.Drawing.Point(374, 358);
            this.btnInventoryReport.Name = "btnInventoryReport";
            this.btnInventoryReport.Size = new System.Drawing.Size(160, 30);
            this.btnInventoryReport.TabIndex = 3;
            this.btnInventoryReport.Text = "Inventory Report";
            this.btnInventoryReport.UseVisualStyleBackColor = true;
            this.btnInventoryReport.Click += new System.EventHandler(this.btnInventoryReport_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 401);
            this.Controls.Add(this.btnInventoryReport);
            this.Controls.Add(this.btnWarehouseTransfer);
            this.Controls.Add(this.btnPurchaseOrder);
            this.Controls.Add(this.dgvTransactions);
            this.Name = "MainForm";
            this.Text = "Inventory Management";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
