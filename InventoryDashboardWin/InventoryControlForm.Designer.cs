using System.Windows.Forms;

namespace InventoryDashboardWin
{
    partial class InventoryControlForm
    {
        private System.ComponentModel.IContainer components = null!;
        private TextBox txtAssetName;
        private DateTimePicker dtpDate;
        private Label labelAsset;
        private Label labelDate;
        private GroupBox grpSearch;
        private ComboBox cboWarehouse;
        private ComboBox cboPart;
        private TextBox txtAmount;
        private ComboBox cboAllocationMethod;
        private Button btnAllocate;
        private Label labelWarehouse;
        private Label labelPart;
        private Label labelAmount;
        private Label labelAllocation;
        private GroupBox grpAllocated;
        private GroupBox grpAssigned;
        private DataGridView dgvAllocatedParts;
        private DataGridView dgvAssignedParts;
        private Button btnAssignToEm;
        private Button btnSubmit;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtAssetName = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.labelAsset = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.btnAllocate = new System.Windows.Forms.Button();
            this.cboAllocationMethod = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.cboPart = new System.Windows.Forms.ComboBox();
            this.cboWarehouse = new System.Windows.Forms.ComboBox();
            this.labelAllocation = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelPart = new System.Windows.Forms.Label();
            this.labelWarehouse = new System.Windows.Forms.Label();
            this.grpAllocated = new System.Windows.Forms.GroupBox();
            this.dgvAllocatedParts = new System.Windows.Forms.DataGridView();
            this.btnAssignToEm = new System.Windows.Forms.Button();
            this.grpAssigned = new System.Windows.Forms.GroupBox();
            this.dgvAssignedParts = new System.Windows.Forms.DataGridView();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpSearch.SuspendLayout();
            this.grpAllocated.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllocatedParts)).BeginInit();
            this.grpAssigned.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignedParts)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAsset
            // 
            this.labelAsset.AutoSize = true;
            this.labelAsset.Location = new System.Drawing.Point(12, 15);
            this.labelAsset.Name = "labelAsset";
            this.labelAsset.Size = new System.Drawing.Size(111, 15);
            this.labelAsset.TabIndex = 0;
            this.labelAsset.Text = "Asset Name (EM #):";
            // 
            // txtAssetName
            // 
            this.txtAssetName.Location = new System.Drawing.Point(150, 12);
            this.txtAssetName.Name = "txtAssetName";
            this.txtAssetName.Size = new System.Drawing.Size(250, 23);
            this.txtAssetName.TabIndex = 1;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(430, 15);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(34, 15);
            this.labelDate.TabIndex = 2;
            this.labelDate.Text = "Date:";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(470, 12);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 23);
            this.dtpDate.TabIndex = 3;
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.btnAllocate);
            this.grpSearch.Controls.Add(this.cboAllocationMethod);
            this.grpSearch.Controls.Add(this.txtAmount);
            this.grpSearch.Controls.Add(this.cboPart);
            this.grpSearch.Controls.Add(this.cboWarehouse);
            this.grpSearch.Controls.Add(this.labelAllocation);
            this.grpSearch.Controls.Add(this.labelAmount);
            this.grpSearch.Controls.Add(this.labelPart);
            this.grpSearch.Controls.Add(this.labelWarehouse);
            this.grpSearch.Location = new System.Drawing.Point(12, 50);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(776, 90);
            this.grpSearch.TabIndex = 4;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Search for parts";
            // 
            // labelWarehouse
            // 
            this.labelWarehouse.AutoSize = true;
            this.labelWarehouse.Location = new System.Drawing.Point(10, 24);
            this.labelWarehouse.Name = "labelWarehouse";
            this.labelWarehouse.Size = new System.Drawing.Size(65, 15);
            this.labelWarehouse.TabIndex = 0;
            this.labelWarehouse.Text = "Warehouse:";
            // 
            // cboWarehouse
            // 
            this.cboWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWarehouse.FormattingEnabled = true;
            this.cboWarehouse.Location = new System.Drawing.Point(90, 21);
            this.cboWarehouse.Name = "cboWarehouse";
            this.cboWarehouse.Size = new System.Drawing.Size(200, 23);
            this.cboWarehouse.TabIndex = 1;
            // 
            // labelPart
            // 
            this.labelPart.AutoSize = true;
            this.labelPart.Location = new System.Drawing.Point(310, 24);
            this.labelPart.Name = "labelPart";
            this.labelPart.Size = new System.Drawing.Size(33, 15);
            this.labelPart.TabIndex = 2;
            this.labelPart.Text = "Part:";
            // 
            // cboPart
            // 
            this.cboPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPart.FormattingEnabled = true;
            this.cboPart.Location = new System.Drawing.Point(350, 21);
            this.cboPart.Name = "cboPart";
            this.cboPart.Size = new System.Drawing.Size(200, 23);
            this.cboPart.TabIndex = 3;
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(570, 24);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(53, 15);
            this.labelAmount.TabIndex = 4;
            this.labelAmount.Text = "Amount:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(629, 21);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(60, 23);
            this.txtAmount.TabIndex = 5;
            // 
            // labelAllocation
            // 
            this.labelAllocation.AutoSize = true;
            this.labelAllocation.Location = new System.Drawing.Point(10, 56);
            this.labelAllocation.Name = "labelAllocation";
            this.labelAllocation.Size = new System.Drawing.Size(102, 15);
            this.labelAllocation.TabIndex = 6;
            this.labelAllocation.Text = "Allocation method:";
            // 
            // cboAllocationMethod
            // 
            this.cboAllocationMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAllocationMethod.FormattingEnabled = true;
            this.cboAllocationMethod.Items.AddRange(new object[] {
            "FIFO",
            "LIFO",
            "Minimum Price"});
            this.cboAllocationMethod.Location = new System.Drawing.Point(118, 53);
            this.cboAllocationMethod.Name = "cboAllocationMethod";
            this.cboAllocationMethod.Size = new System.Drawing.Size(200, 23);
            this.cboAllocationMethod.TabIndex = 7;
            // 
            // btnAllocate
            // 
            this.btnAllocate.Location = new System.Drawing.Point(650, 52);
            this.btnAllocate.Name = "btnAllocate";
            this.btnAllocate.Size = new System.Drawing.Size(110, 25);
            this.btnAllocate.TabIndex = 8;
            this.btnAllocate.Text = "Allocate";
            this.btnAllocate.UseVisualStyleBackColor = true;
            this.btnAllocate.Click += new System.EventHandler(this.btnAllocate_Click);
            // 
            // grpAllocated
            // 
            this.grpAllocated.Controls.Add(this.dgvAllocatedParts);
            this.grpAllocated.Location = new System.Drawing.Point(12, 146);
            this.grpAllocated.Name = "grpAllocated";
            this.grpAllocated.Size = new System.Drawing.Size(776, 140);
            this.grpAllocated.TabIndex = 5;
            this.grpAllocated.TabStop = false;
            this.grpAllocated.Text = "Allocated Parts";
            // 
            // dgvAllocatedParts
            // 
            this.dgvAllocatedParts.AllowUserToAddRows = false;
            this.dgvAllocatedParts.AllowUserToDeleteRows = false;
            this.dgvAllocatedParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllocatedParts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAllocatedParts.Location = new System.Drawing.Point(3, 19);
            this.dgvAllocatedParts.Name = "dgvAllocatedParts";
            this.dgvAllocatedParts.ReadOnly = true;
            this.dgvAllocatedParts.RowHeadersVisible = false;
            this.dgvAllocatedParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllocatedParts.Size = new System.Drawing.Size(770, 118);
            this.dgvAllocatedParts.TabIndex = 0;
            // 
            // btnAssignToEm
            // 
            this.btnAssignToEm.Location = new System.Drawing.Point(650, 292);
            this.btnAssignToEm.Name = "btnAssignToEm";
            this.btnAssignToEm.Size = new System.Drawing.Size(138, 27);
            this.btnAssignToEm.TabIndex = 6;
            this.btnAssignToEm.Text = "Assign to EM";
            this.btnAssignToEm.UseVisualStyleBackColor = true;
            this.btnAssignToEm.Click += new System.EventHandler(this.btnAssignToEm_Click);
            // 
            // grpAssigned
            // 
            this.grpAssigned.Controls.Add(this.dgvAssignedParts);
            this.grpAssigned.Location = new System.Drawing.Point(12, 325);
            this.grpAssigned.Name = "grpAssigned";
            this.grpAssigned.Size = new System.Drawing.Size(776, 150);
            this.grpAssigned.TabIndex = 7;
            this.grpAssigned.TabStop = false;
            this.grpAssigned.Text = "Assigned Parts";
            // 
            // dgvAssignedParts
            // 
            this.dgvAssignedParts.AllowUserToAddRows = false;
            this.dgvAssignedParts.AllowUserToDeleteRows = false;
            this.dgvAssignedParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssignedParts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAssignedParts.Location = new System.Drawing.Point(3, 19);
            this.dgvAssignedParts.Name = "dgvAssignedParts";
            this.dgvAssignedParts.ReadOnly = true;
            this.dgvAssignedParts.RowHeadersVisible = false;
            this.dgvAssignedParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssignedParts.Size = new System.Drawing.Size(770, 128);
            this.dgvAssignedParts.TabIndex = 0;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(532, 481);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(120, 30);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(668, 481);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // InventoryControlForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 523);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.grpAssigned);
            this.Controls.Add(this.btnAssignToEm);
            this.Controls.Add(this.grpAllocated);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.txtAssetName);
            this.Controls.Add(this.labelAsset);
            this.Name = "InventoryControlForm";
            this.Text = "Inventory Control";
            this.Load += new System.EventHandler(this.InventoryControlForm_Load);
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpAllocated.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllocatedParts)).EndInit();
            this.grpAssigned.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignedParts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
