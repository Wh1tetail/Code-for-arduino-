using System.Windows.Forms;

namespace InventoryWin
{
    partial class PurchaseOrderForm
    {
        private System.ComponentModel.IContainer components = null!;
        private ComboBox cboWarehouse;
        private ComboBox cboPart;
        private ComboBox cboBatch;
        private TextBox txtAmount;
        private Button btnAddToList;
        private DataGridView dgvLines;
        private Button btnSubmit;
        private Button btnCancel;
        private DateTimePicker dtpDate;
        private Label labelWarehouse;
        private Label labelPart;
        private Label labelBatch;
        private Label labelAmount;
        private Label labelDate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cboWarehouse = new System.Windows.Forms.ComboBox();
            this.cboPart = new System.Windows.Forms.ComboBox();
            this.cboBatch = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.dgvLines = new System.Windows.Forms.DataGridView();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.labelWarehouse = new System.Windows.Forms.Label();
            this.labelPart = new System.Windows.Forms.Label();
            this.labelBatch = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).BeginInit();
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
            this.cboWarehouse.Location = new System.Drawing.Point(100, 12);
            this.cboWarehouse.Name = "cboWarehouse";
            this.cboWarehouse.Size = new System.Drawing.Size(250, 23);
            this.cboWarehouse.TabIndex = 1;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(380, 15);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(34, 15);
            this.labelDate.TabIndex = 2;
            this.labelDate.Text = "Date:";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(420, 12);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 23);
            this.dtpDate.TabIndex = 3;
            // 
            // labelPart
            // 
            this.labelPart.AutoSize = true;
            this.labelPart.Location = new System.Drawing.Point(12, 55);
            this.labelPart.Name = "labelPart";
            this.labelPart.Size = new System.Drawing.Size(60, 15);
            this.labelPart.TabIndex = 4;
            this.labelPart.Text = "Part name:";
            // 
            // cboPart
            // 
            this.cboPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPart.FormattingEnabled = true;
            this.cboPart.Location = new System.Drawing.Point(100, 52);
            this.cboPart.Name = "cboPart";
            this.cboPart.Size = new System.Drawing.Size(200, 23);
            this.cboPart.TabIndex = 5;
            this.cboPart.SelectedIndexChanged += new System.EventHandler(this.cboPart_SelectedIndexChanged);
            // 
            // labelBatch
            // 
            this.labelBatch.AutoSize = true;
            this.labelBatch.Location = new System.Drawing.Point(320, 55);
            this.labelBatch.Name = "labelBatch";
            this.labelBatch.Size = new System.Drawing.Size(76, 15);
            this.labelBatch.TabIndex = 6;
            this.labelBatch.Text = "Batch number:";
            // 
            // cboBatch
            // 
            this.cboBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBatch.FormattingEnabled = true;
            this.cboBatch.Location = new System.Drawing.Point(402, 52);
            this.cboBatch.Name = "cboBatch";
            this.cboBatch.Size = new System.Drawing.Size(150, 23);
            this.cboBatch.TabIndex = 7;
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(570, 55);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(53, 15);
            this.labelAmount.TabIndex = 8;
            this.labelAmount.Text = "Amount:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(629, 52);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(80, 23);
            this.txtAmount.TabIndex = 9;
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(715, 51);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(75, 25);
            this.btnAddToList.TabIndex = 10;
            this.btnAddToList.Text = "Add";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // dgvLines
            // 
            this.dgvLines.AllowUserToAddRows = false;
            this.dgvLines.AllowUserToDeleteRows = false;
            this.dgvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLines.Location = new System.Drawing.Point(12, 90);
            this.dgvLines.Name = "dgvLines";
            this.dgvLines.ReadOnly = true;
            this.dgvLines.RowHeadersVisible = false;
            this.dgvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLines.Size = new System.Drawing.Size(778, 260);
            this.dgvLines.TabIndex = 11;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(534, 365);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(120, 30);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(670, 365);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 30);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PurchaseOrderForm
            // 
            this.ClientSize = new System.Drawing.Size(802, 407);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.dgvLines);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.cboBatch);
            this.Controls.Add(this.labelBatch);
            this.Controls.Add(this.cboPart);
            this.Controls.Add(this.labelPart);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.cboWarehouse);
            this.Controls.Add(this.labelWarehouse);
            this.Name = "PurchaseOrderForm";
            this.Text = "Purchase Order";
            this.Load += new System.EventHandler(this.PurchaseOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
