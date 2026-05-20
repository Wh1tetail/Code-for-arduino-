namespace WindowsFormsApp1
{
    partial class ManagementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagementForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.seoulStayDataSet = new WindowsFormsApp1.SeoulStayDataSet();
            this.seoulStayDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvOwner = new System.Windows.Forms.DataGridView();
            this.seoulStayDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.seoulStayDataSetBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddListing = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.seoulStayDataSetBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.seoulStayDataSet1 = new WindowsFormsApp1.SeoulStayDataSet1();
            this.amenitiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.amenitiesTableAdapter = new WindowsFormsApp1.SeoulStayDataSet1TableAdapters.AmenitiesTableAdapter();
            this.seoulStayDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.seoulStayDataSet1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.session1DataSet = new WindowsFormsApp1.Session1DataSet();
            this.session1DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemsTableAdapter = new WindowsFormsApp1.Session1DataSetTableAdapters.ItemsTableAdapter();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seoulStayDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seoulStayDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOwner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seoulStayDataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seoulStayDataSetBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seoulStayDataSetBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seoulStayDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amenitiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seoulStayDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seoulStayDataSet1BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.session1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.session1DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(5, 170);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(783, 302);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtSearch);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(775, 276);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "I\'m Traveler";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAddListing);
            this.tabPage2.Controls.Add(this.dgvOwner);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(775, 276);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "I\'m Owner / Manager";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(763, 214);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // seoulStayDataSet
            // 
            this.seoulStayDataSet.DataSetName = "SeoulStayDataSet";
            this.seoulStayDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // seoulStayDataSetBindingSource
            // 
            this.seoulStayDataSetBindingSource.DataSource = this.seoulStayDataSet;
            this.seoulStayDataSetBindingSource.Position = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(6, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(295, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Text = "Search destination";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(622, 141);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(713, 141);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvOwner
            // 
            this.dgvOwner.AllowUserToAddRows = false;
            this.dgvOwner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOwner.Location = new System.Drawing.Point(6, 59);
            this.dgvOwner.Name = "dgvOwner";
            this.dgvOwner.Size = new System.Drawing.Size(763, 180);
            this.dgvOwner.TabIndex = 0;
            this.dgvOwner.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOwner_CellContentClick);
            // 
            // seoulStayDataSetBindingSource1
            // 
            this.seoulStayDataSetBindingSource1.DataSource = this.seoulStayDataSet;
            this.seoulStayDataSetBindingSource1.Position = 0;
            // 
            // seoulStayDataSetBindingSource2
            // 
            this.seoulStayDataSetBindingSource2.DataSource = this.seoulStayDataSet;
            this.seoulStayDataSetBindingSource2.Position = 0;
            // 
            // btnAddListing
            // 
            this.btnAddListing.Location = new System.Drawing.Point(6, 17);
            this.btnAddListing.Name = "btnAddListing";
            this.btnAddListing.Size = new System.Drawing.Size(75, 23);
            this.btnAddListing.TabIndex = 1;
            this.btnAddListing.Text = "Add Listing";
            this.btnAddListing.UseVisualStyleBackColor = true;
            this.btnAddListing.Click += new System.EventHandler(this.btnAddListing_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(45, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(679, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(28, 486);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(35, 13);
            this.statusLabel.TabIndex = 5;
            this.statusLabel.Text = "label1";
            this.statusLabel.Click += new System.EventHandler(this.statusLabel_Click);
            // 
            // seoulStayDataSetBindingSource3
            // 
            this.seoulStayDataSetBindingSource3.DataSource = this.seoulStayDataSet;
            this.seoulStayDataSetBindingSource3.Position = 0;
            // 
            // seoulStayDataSet1
            // 
            this.seoulStayDataSet1.DataSetName = "SeoulStayDataSet1";
            this.seoulStayDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // amenitiesBindingSource
            // 
            this.amenitiesBindingSource.DataMember = "Amenities";
            this.amenitiesBindingSource.DataSource = this.seoulStayDataSet1;
            // 
            // amenitiesTableAdapter
            // 
            this.amenitiesTableAdapter.ClearBeforeFill = true;
            // 
            // seoulStayDataSet1BindingSource
            // 
            this.seoulStayDataSet1BindingSource.DataSource = this.seoulStayDataSet1;
            this.seoulStayDataSet1BindingSource.Position = 0;
            // 
            // seoulStayDataSet1BindingSource1
            // 
            this.seoulStayDataSet1BindingSource1.DataSource = this.seoulStayDataSet1;
            this.seoulStayDataSet1BindingSource1.Position = 0;
            // 
            // session1DataSet
            // 
            this.session1DataSet.DataSetName = "Session1DataSet";
            this.session1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // session1DataSetBindingSource
            // 
            this.session1DataSetBindingSource.DataSource = this.session1DataSet;
            this.session1DataSetBindingSource.Position = 0;
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataMember = "Items";
            this.itemsBindingSource.DataSource = this.session1DataSetBindingSource;
            // 
            // itemsTableAdapter
            // 
            this.itemsTableAdapter.ClearBeforeFill = true;
            // 
            // ManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(800, 511);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tabControl1);
            this.Name = "ManagementForm";
            this.Text = "ManagementForm";
            this.Load += new System.EventHandler(this.ManagementForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seoulStayDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seoulStayDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOwner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seoulStayDataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seoulStayDataSetBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seoulStayDataSetBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seoulStayDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amenitiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seoulStayDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seoulStayDataSet1BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.session1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.session1DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource seoulStayDataSetBindingSource;
        private SeoulStayDataSet seoulStayDataSet;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.BindingSource seoulStayDataSetBindingSource2;
        private System.Windows.Forms.Button btnAddListing;
        private System.Windows.Forms.DataGridView dgvOwner;
        private System.Windows.Forms.BindingSource seoulStayDataSetBindingSource1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.BindingSource seoulStayDataSetBindingSource3;
        private SeoulStayDataSet1 seoulStayDataSet1;
        private System.Windows.Forms.BindingSource amenitiesBindingSource;
        private SeoulStayDataSet1TableAdapters.AmenitiesTableAdapter amenitiesTableAdapter;
        private System.Windows.Forms.BindingSource seoulStayDataSet1BindingSource1;
        private System.Windows.Forms.BindingSource seoulStayDataSet1BindingSource;
        private System.Windows.Forms.BindingSource session1DataSetBindingSource;
        private Session1DataSet session1DataSet;
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private Session1DataSetTableAdapters.ItemsTableAdapter itemsTableAdapter;
    }
}