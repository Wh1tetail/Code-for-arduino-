using System.Windows.Forms;

namespace InventoryWin
{
    partial class WarehouseTransferForm
    {
        private System.ComponentModel.IContainer components = null!;
        private ComboBox cboSourceWarehouse;
        private ComboBox cboDestinationWarehouse;
        private ComboBox cboPart;
        private ComboBox cboBatch;
        private TextBox txtAmount;
        private Button btnAddToList;
        private DataGridView dgvLines;
        private Button btnSubmit;
        private Button btnCancel;
        private DateTimePicker dtpDate;
        private Label labelSource;
        private Label labelDestination;
        private Label labelDate;
        private Label labelPart;
        private Label labelBatch;
        private Label labelAmount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cboSourceWarehouse = new System.Windows.Forms.ComboBox();
            this.cboDestinationWarehouse = new System.Windows.Forms.ComboBox();
            this.cboPart = new System.Windows.Forms.ComboBox();
            this.cboBatch = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.dgvLines = new System.Windows.Forms.DataGridView();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.labelSource = new System.Windows.Forms.Label();
            this.labelDestination = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelPart = new System.Windows.Forms.Label();
            this.labelBatch = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(12, 15);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(106, 15);
            this.labelSource.TabIndex = 0;
            this.labelSource.Text = "Source warehouse:";
            // 
            // cboSourceWarehouse
            // 
            this.cboSourceWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSourceWarehouse.FormattingEnabled = true;
            this.cboSourceWarehouse.Location = new System.Drawing.Point(130, 12);
            this.cboSourceWarehouse.Name = "cboSourceWarehouse";
            this.cboSourceWarehouse.Size = new System.Drawing.Size(220, 23);
            this.cboSourceWarehouse.TabIndex = 1;
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Location = new System.Drawing.Point(370, 15);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(135, 15);
            this.labelDestination.TabIndex = 2;
            this.labelDestination.Text = "Destination warehouse:";
            // 
            // cboDestinationWarehouse
            // 
            this.cboDestinationWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDestinationWarehouse.FormattingEnabled = true;
            this.cboDestinationWarehouse.Location = new System.Drawing.Point(511, 12);
            this.cboDestinationWarehouse.Name = "cboDestinationWarehouse";
            this.cboDestinationWarehouse.Size = new System.Drawing.Size(220, 23);
            this.cboDestinationWarehouse.TabIndex = 3;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(12, 50);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(34, 15);
            this.labelDate.TabIndex = 4;
            this.labelDate.Text = "Date:";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(130, 47);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 23);
            this.dtpDate.TabIndex = 5;
            // 
            // labelPart
            // 
            this.labelPart.AutoSize = true;
            this.labelPart.Location = new System.Drawing.Point(12, 90);
            this.labelPart.Name = "labelPart";
            this.labelPart.Size = new System.Drawing.Size(60, 15);
            this.labelPart.TabIndex = 6;
            this.labelPart.Text = "Part name:";
            // 
            // cboPart
            // 
            this.cboPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPart.FormattingEnabled = true;
            this.cboPart.Location = new System.Drawing.Point(130, 87);
            this.cboPart.Name = "cboPart";
            this.cboPart.Size = new System.Drawing.Size(200, 23);
            this.cboPart.TabIndex = 7;
            this.cboPart.SelectedIndexChanged += new System.EventHandler(this.cboPart_SelectedIndexChanged);
            // 
            // labelBatch
            // 
            this.labelBatch.AutoSize = true;
            this.labelBatch.Location = new System.Drawing.Point(350, 90);
            this.labelBatch.Name = "labelBatch";
            this.labelBatch.Size = new System.Drawing.Size(76, 15);
            this.labelBatch.TabIndex = 8;
            this.labelBatch.Text = "Batch number:";
            // 
            // cboBatch
            // 
            this.cboBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBatch.FormattingEnabled = true;
            this.cboBatch.Location = new System.Drawing.Point(432, 87);
            this.cboBatch.Name = "cboBatch";
            this.cboBatch.Size = new System.Drawing.Size(150, 23);
            this.cboBatch.TabIndex = 9;
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(600, 90);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(53, 15);
            this.labelAmount.TabIndex = 10;
            this.labelAmount.Text = "Amount:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(659, 87);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(80, 23);
            this.txtAmount.TabIndex = 11;
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(745, 86);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(75, 25);
            this.btnAddToList.TabIndex = 12;
            this.btnAddToList.Text = "Add";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // dgvLines
            // 
            this.dgvLines.AllowUserToAddRows = false;
            this.dgvLines.AllowUserToDeleteRows = false;
            this.dgvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLines.Location = new System.Drawing.Point(12, 125);
            this.dgvLines.Name = "dgvLines";
            this.dgvLines.ReadOnly = true;
            this.dgvLines.RowHeadersVisible = false;
            this.dgvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLines.Size = new System.Drawing.Size(808, 250);
            this.dgvLines.TabIndex = 13;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(588, 385);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(110, 30);
            this.btnSubmit.TabIndex = 14;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(710, 385);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 30);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // WarehouseTransferForm
            // 
            this.ClientSize = new System.Drawing.Size(832, 427);
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
            this.Controls.Add(this.cboDestinationWarehouse);
            this.Controls.Add(this.labelDestination);
            this.Controls.Add(this.cboSourceWarehouse);
            this.Controls.Add(this.labelSource);
            this.Name = "WarehouseTransferForm";
            this.Text = "Warehouse Management";
            this.Load += new System.EventHandler(this.WarehouseTransferForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
