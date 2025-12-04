using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace InventoryDashboardWin
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null!;
        private GroupBox grpDeptSpending;
        private GroupBox grpMostUsedParts;
        private GroupBox grpCostlyAssets;
        private GroupBox grpDeptRatio;
        private GroupBox grpMonthlySpending;
        private DataGridView dgvDeptSpending;
        private DataGridView dgvMostUsedParts;
        private DataGridView dgvCostlyAssets;
        private Chart chartDeptRatio;
        private Chart chartMonthlySpending;
        private Button btnInventoryControl;
        private Button btnClose;
        private ComboBox cboLanguage;
        private Label lblLanguage;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpDeptSpending = new System.Windows.Forms.GroupBox();
            this.dgvDeptSpending = new System.Windows.Forms.DataGridView();
            this.grpMostUsedParts = new System.Windows.Forms.GroupBox();
            this.dgvMostUsedParts = new System.Windows.Forms.DataGridView();
            this.grpCostlyAssets = new System.Windows.Forms.GroupBox();
            this.dgvCostlyAssets = new System.Windows.Forms.DataGridView();
            this.grpDeptRatio = new System.Windows.Forms.GroupBox();
            this.chartDeptRatio = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpMonthlySpending = new System.Windows.Forms.GroupBox();
            this.chartMonthlySpending = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnInventoryControl = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cboLanguage = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.grpDeptSpending.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptSpending)).BeginInit();
            this.grpMostUsedParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostUsedParts)).BeginInit();
            this.grpCostlyAssets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostlyAssets)).BeginInit();
            this.grpDeptRatio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDeptRatio)).BeginInit();
            this.grpMonthlySpending.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMonthlySpending)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDeptSpending
            // 
            this.grpDeptSpending.Controls.Add(this.dgvDeptSpending);
            this.grpDeptSpending.Location = new System.Drawing.Point(12, 12);
            this.grpDeptSpending.Name = "grpDeptSpending";
            this.grpDeptSpending.Size = new System.Drawing.Size(520, 150);
            this.grpDeptSpending.TabIndex = 0;
            this.grpDeptSpending.TabStop = true;
            this.grpDeptSpending.Text = "EM Spending by Department";
            // 
            // dgvDeptSpending
            // 
            this.dgvDeptSpending.AllowUserToAddRows = false;
            this.dgvDeptSpending.AllowUserToDeleteRows = false;
            this.dgvDeptSpending.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeptSpending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeptSpending.Location = new System.Drawing.Point(3, 19);
            this.dgvDeptSpending.Name = "dgvDeptSpending";
            this.dgvDeptSpending.ReadOnly = true;
            this.dgvDeptSpending.RowHeadersVisible = false;
            this.dgvDeptSpending.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeptSpending.Size = new System.Drawing.Size(514, 128);
            this.dgvDeptSpending.TabIndex = 0;
            // 
            // grpMostUsedParts
            // 
            this.grpMostUsedParts.Controls.Add(this.dgvMostUsedParts);
            this.grpMostUsedParts.Location = new System.Drawing.Point(12, 168);
            this.grpMostUsedParts.Name = "grpMostUsedParts";
            this.grpMostUsedParts.Size = new System.Drawing.Size(520, 130);
            this.grpMostUsedParts.TabIndex = 1;
            this.grpMostUsedParts.TabStop = false;
            this.grpMostUsedParts.Text = "Monthly Report for Most-Used Parts";
            // 
            // dgvMostUsedParts
            // 
            this.dgvMostUsedParts.AllowUserToAddRows = false;
            this.dgvMostUsedParts.AllowUserToDeleteRows = false;
            this.dgvMostUsedParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMostUsedParts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMostUsedParts.Location = new System.Drawing.Point(3, 19);
            this.dgvMostUsedParts.Name = "dgvMostUsedParts";
            this.dgvMostUsedParts.ReadOnly = true;
            this.dgvMostUsedParts.RowHeadersVisible = false;
            this.dgvMostUsedParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMostUsedParts.Size = new System.Drawing.Size(514, 108);
            this.dgvMostUsedParts.TabIndex = 0;
            // 
            // grpCostlyAssets
            // 
            this.grpCostlyAssets.Controls.Add(this.dgvCostlyAssets);
            this.grpCostlyAssets.Location = new System.Drawing.Point(12, 304);
            this.grpCostlyAssets.Name = "grpCostlyAssets";
            this.grpCostlyAssets.Size = new System.Drawing.Size(520, 130);
            this.grpCostlyAssets.TabIndex = 2;
            this.grpCostlyAssets.TabStop = false;
            this.grpCostlyAssets.Text = "Monthly Report of Costly Assets";
            // 
            // dgvCostlyAssets
            // 
            this.dgvCostlyAssets.AllowUserToAddRows = false;
            this.dgvCostlyAssets.AllowUserToDeleteRows = false;
            this.dgvCostlyAssets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCostlyAssets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCostlyAssets.Location = new System.Drawing.Point(3, 19);
            this.dgvCostlyAssets.Name = "dgvCostlyAssets";
            this.dgvCostlyAssets.ReadOnly = true;
            this.dgvCostlyAssets.RowHeadersVisible = false;
            this.dgvCostlyAssets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCostlyAssets.Size = new System.Drawing.Size(514, 108);
            this.dgvCostlyAssets.TabIndex = 0;
            // 
            // grpDeptRatio
            // 
            this.grpDeptRatio.Controls.Add(this.chartDeptRatio);
            this.grpDeptRatio.Location = new System.Drawing.Point(538, 12);
            this.grpDeptRatio.Name = "grpDeptRatio";
            this.grpDeptRatio.Size = new System.Drawing.Size(360, 200);
            this.grpDeptRatio.TabIndex = 3;
            this.grpDeptRatio.TabStop = false;
            this.grpDeptRatio.Text = "Department Spending Ratio";
            // 
            // chartDeptRatio
            // 
            ChartArea chartArea1 = new ChartArea();
            this.chartDeptRatio.ChartAreas.Add(chartArea1);
            this.chartDeptRatio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDeptRatio.Location = new System.Drawing.Point(3, 19);
            this.chartDeptRatio.Name = "chartDeptRatio";
            this.chartDeptRatio.Size = new System.Drawing.Size(354, 178);
            this.chartDeptRatio.TabIndex = 0;
            this.chartDeptRatio.Text = "chart1";
            // 
            // grpMonthlySpending
            // 
            this.grpMonthlySpending.Controls.Add(this.chartMonthlySpending);
            this.grpMonthlySpending.Location = new System.Drawing.Point(538, 218);
            this.grpMonthlySpending.Name = "grpMonthlySpending";
            this.grpMonthlySpending.Size = new System.Drawing.Size(360, 216);
            this.grpMonthlySpending.TabIndex = 4;
            this.grpMonthlySpending.TabStop = false;
            this.grpMonthlySpending.Text = "Monthly Department Spending";
            // 
            // chartMonthlySpending
            // 
            ChartArea chartArea2 = new ChartArea();
            this.chartMonthlySpending.ChartAreas.Add(chartArea2);
            this.chartMonthlySpending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartMonthlySpending.Location = new System.Drawing.Point(3, 19);
            this.chartMonthlySpending.Name = "chartMonthlySpending";
            this.chartMonthlySpending.Size = new System.Drawing.Size(354, 194);
            this.chartMonthlySpending.TabIndex = 0;
            this.chartMonthlySpending.Text = "chart2";
            // 
            // btnInventoryControl
            // 
            this.btnInventoryControl.Location = new System.Drawing.Point(12, 445);
            this.btnInventoryControl.Name = "btnInventoryControl";
            this.btnInventoryControl.Size = new System.Drawing.Size(140, 30);
            this.btnInventoryControl.TabIndex = 5;
            this.btnInventoryControl.Text = "Inventory Control";
            this.btnInventoryControl.UseVisualStyleBackColor = true;
            this.btnInventoryControl.Click += new System.EventHandler(this.btnInventoryControl_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(168, 445);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 30);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(640, 452);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(61, 15);
            this.lblLanguage.TabIndex = 7;
            this.lblLanguage.Text = "Language:";
            // 
            // cboLanguage
            // 
            this.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLanguage.FormattingEnabled = true;
            this.cboLanguage.Location = new System.Drawing.Point(707, 449);
            this.cboLanguage.Name = "cboLanguage";
            this.cboLanguage.Size = new System.Drawing.Size(191, 23);
            this.cboLanguage.TabIndex = 8;
            this.cboLanguage.SelectedIndexChanged += new System.EventHandler(this.cboLanguage_SelectedIndexChanged);
            // 
            // DashboardForm
            // 
            this.ClientSize = new System.Drawing.Size(910, 487);
            this.Controls.Add(this.cboLanguage);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnInventoryControl);
            this.Controls.Add(this.grpMonthlySpending);
            this.Controls.Add(this.grpDeptRatio);
            this.Controls.Add(this.grpCostlyAssets);
            this.Controls.Add(this.grpMostUsedParts);
            this.Controls.Add(this.grpDeptSpending);
            this.Name = "DashboardForm";
            this.Text = "Inventory Dashboard";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.grpDeptSpending.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptSpending)).EndInit();
            this.grpMostUsedParts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostUsedParts)).EndInit();
            this.grpCostlyAssets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostlyAssets)).EndInit();
            this.grpDeptRatio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDeptRatio)).EndInit();
            this.grpMonthlySpending.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartMonthlySpending)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
