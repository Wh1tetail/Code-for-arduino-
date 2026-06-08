namespace WindowsFormsApp1
{
    partial class AddEditListingForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.nudMaxNights = new System.Windows.Forms.NumericUpDown();
            this.nudMinNights = new System.Windows.Forms.NumericUpDown();
            this.nudBathrooms = new System.Windows.Forms.NumericUpDown();
            this.nudCapacity = new System.Windows.Forms.NumericUpDown();
            this.nudBeds = new System.Windows.Forms.NumericUpDown();
            this.nudBedrooms = new System.Windows.Forms.NumericUpDown();
            this.txtHostRules = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtExactAddress = new System.Windows.Forms.TextBox();
            this.txtApproxAddress = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.cmdType = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvAmenities = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvAttractions = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxNights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinNights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBathrooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBeds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBedrooms)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmenities)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttractions)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(4, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 384);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.nudMaxNights);
            this.tabPage1.Controls.Add(this.nudMinNights);
            this.tabPage1.Controls.Add(this.nudBathrooms);
            this.tabPage1.Controls.Add(this.nudCapacity);
            this.tabPage1.Controls.Add(this.nudBeds);
            this.tabPage1.Controls.Add(this.nudBedrooms);
            this.tabPage1.Controls.Add(this.txtHostRules);
            this.tabPage1.Controls.Add(this.txtDescription);
            this.tabPage1.Controls.Add(this.txtExactAddress);
            this.tabPage1.Controls.Add(this.txtApproxAddress);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtTitle);
            this.tabPage1.Controls.Add(this.cmdType);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 358);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "listing Detaile";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // nudMaxNights
            // 
            this.nudMaxNights.Location = new System.Drawing.Point(356, 268);
            this.nudMaxNights.Name = "nudMaxNights";
            this.nudMaxNights.Size = new System.Drawing.Size(67, 20);
            this.nudMaxNights.TabIndex = 30;
            // 
            // nudMinNights
            // 
            this.nudMinNights.Location = new System.Drawing.Point(238, 268);
            this.nudMinNights.Name = "nudMinNights";
            this.nudMinNights.Size = new System.Drawing.Size(67, 20);
            this.nudMinNights.TabIndex = 29;
            // 
            // nudBathrooms
            // 
            this.nudBathrooms.Location = new System.Drawing.Point(658, 47);
            this.nudBathrooms.Name = "nudBathrooms";
            this.nudBathrooms.Size = new System.Drawing.Size(67, 20);
            this.nudBathrooms.TabIndex = 28;
            // 
            // nudCapacity
            // 
            this.nudCapacity.Location = new System.Drawing.Point(71, 47);
            this.nudCapacity.Name = "nudCapacity";
            this.nudCapacity.Size = new System.Drawing.Size(67, 20);
            this.nudCapacity.TabIndex = 27;
            // 
            // nudBeds
            // 
            this.nudBeds.Location = new System.Drawing.Point(238, 47);
            this.nudBeds.Name = "nudBeds";
            this.nudBeds.Size = new System.Drawing.Size(67, 20);
            this.nudBeds.TabIndex = 26;
            // 
            // nudBedrooms
            // 
            this.nudBedrooms.Location = new System.Drawing.Point(435, 47);
            this.nudBedrooms.Name = "nudBedrooms";
            this.nudBedrooms.Size = new System.Drawing.Size(67, 20);
            this.nudBedrooms.TabIndex = 25;
            // 
            // txtHostRules
            // 
            this.txtHostRules.Location = new System.Drawing.Point(87, 201);
            this.txtHostRules.Name = "txtHostRules";
            this.txtHostRules.Size = new System.Drawing.Size(565, 20);
            this.txtHostRules.TabIndex = 18;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(89, 166);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(581, 20);
            this.txtDescription.TabIndex = 17;
            // 
            // txtExactAddress
            // 
            this.txtExactAddress.Location = new System.Drawing.Point(105, 127);
            this.txtExactAddress.Name = "txtExactAddress";
            this.txtExactAddress.Size = new System.Drawing.Size(565, 20);
            this.txtExactAddress.TabIndex = 16;
            // 
            // txtApproxAddress
            // 
            this.txtApproxAddress.Location = new System.Drawing.Point(130, 96);
            this.txtApproxAddress.Name = "txtApproxAddress";
            this.txtApproxAddress.Size = new System.Drawing.Size(565, 20);
            this.txtApproxAddress.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(320, 270);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Max:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(205, 270);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Min:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 270);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Reservation Time (Nights):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 204);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Host Rules:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Description:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Exact Address:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Approximate Addres:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(540, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Number of Bathrooms:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Number of Bedrooms:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(146, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Number of Beds:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Capacity:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(379, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Title:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Type:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(415, 7);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(100, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // cmdType
            // 
            this.cmdType.FormattingEnabled = true;
            this.cmdType.Location = new System.Drawing.Point(71, 6);
            this.cmdType.Name = "cmdType";
            this.cmdType.Size = new System.Drawing.Size(121, 21);
            this.cmdType.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.dgvAmenities);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(776, 358);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Amenitiee";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(140, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Choose Available Amenities:";
            // 
            // dgvAmenities
            // 
            this.dgvAmenities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAmenities.Location = new System.Drawing.Point(6, 51);
            this.dgvAmenities.Name = "dgvAmenities";
            this.dgvAmenities.Size = new System.Drawing.Size(442, 252);
            this.dgvAmenities.TabIndex = 0;
            this.dgvAmenities.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAmenities_CellContentClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvAttractions);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(776, 358);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Distance to Attraction";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvAttractions
            // 
            this.dgvAttractions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttractions.Location = new System.Drawing.Point(9, 40);
            this.dgvAttractions.Name = "dgvAttractions";
            this.dgvAttractions.Size = new System.Drawing.Size(548, 291);
            this.dgvAttractions.TabIndex = 1;
            this.dgvAttractions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttractions_CellContentClick);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(411, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Specify the distance from each close by attraction and the time it takes to get t" +
    "o them:";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(490, 415);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(675, 415);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close / Finish";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(585, 415);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 3;
            this.btnFinish.Text = "Cancel";
            this.btnFinish.UseVisualStyleBackColor = true;
            // 
            // AddEditListingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.tabControl1);
            this.Name = "AddEditListingForm";
            this.Text = "AddEditListingForm";
            this.Load += new System.EventHandler(this.AddEditListingForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxNights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinNights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBathrooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBeds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBedrooms)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmenities)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttractions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmdType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHostRules;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtExactAddress;
        private System.Windows.Forms.TextBox txtApproxAddress;
        private System.Windows.Forms.NumericUpDown nudMaxNights;
        private System.Windows.Forms.NumericUpDown nudMinNights;
        private System.Windows.Forms.NumericUpDown nudBathrooms;
        private System.Windows.Forms.NumericUpDown nudCapacity;
        private System.Windows.Forms.NumericUpDown nudBeds;
        private System.Windows.Forms.NumericUpDown nudBedrooms;
        private System.Windows.Forms.DataGridView dgvAmenities;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvAttractions;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnFinish;
    }
}