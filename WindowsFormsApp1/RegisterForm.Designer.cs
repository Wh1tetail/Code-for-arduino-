namespace WindowsFormsApp1
{
    partial class RegisterForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rdMale = new System.Windows.Forms.RadioButton();
            this.rdFemale = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtRetypePassword = new System.Windows.Forms.TextBox();
            this.chkAgree = new System.Windows.Forms.CheckBox();
            this.linkViewTerms = new System.Windows.Forms.LinkLabel();
            this.btnRegister = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.nudFamilyMembers = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFamilyMembers)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudFamilyMembers);
            this.groupBox1.Controls.Add(this.linkViewTerms);
            this.groupBox1.Controls.Add(this.chkAgree);
            this.groupBox1.Controls.Add(this.txtRetypePassword);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtFullName);
            this.groupBox1.Controls.Add(this.dtpBirthday);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.rdFemale);
            this.groupBox1.Controls.Add(this.rdMale);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 252);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Your Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserName:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Full Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Birthday:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Retype Password:";
            // 
            // rdMale
            // 
            this.rdMale.AutoSize = true;
            this.rdMale.Location = new System.Drawing.Point(364, 41);
            this.rdMale.Name = "rdMale";
            this.rdMale.Size = new System.Drawing.Size(48, 17);
            this.rdMale.TabIndex = 5;
            this.rdMale.TabStop = true;
            this.rdMale.Text = "Male";
            this.rdMale.UseVisualStyleBackColor = true;
            this.rdMale.CheckedChanged += new System.EventHandler(this.rdMale_CheckedChanged);
            // 
            // rdFemale
            // 
            this.rdFemale.AutoSize = true;
            this.rdFemale.Location = new System.Drawing.Point(436, 41);
            this.rdFemale.Name = "rdFemale";
            this.rdFemale.Size = new System.Drawing.Size(59, 17);
            this.rdFemale.TabIndex = 6;
            this.rdFemale.TabStop = true;
            this.rdFemale.Text = "Female";
            this.rdFemale.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(291, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Number of Family Members:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(109, 42);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(134, 20);
            this.txtUsername.TabIndex = 10;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.Location = new System.Drawing.Point(102, 117);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(141, 20);
            this.dtpBirthday.TabIndex = 11;
            this.dtpBirthday.ValueChanged += new System.EventHandler(this.dtpBirthday_ValueChanged);
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(109, 81);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(134, 20);
            this.txtFullName.TabIndex = 12;
            this.txtFullName.TextChanged += new System.EventHandler(this.txtFullName_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(109, 167);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(134, 20);
            this.txtPassword.TabIndex = 13;
            // 
            // txtRetypePassword
            // 
            this.txtRetypePassword.Location = new System.Drawing.Point(390, 167);
            this.txtRetypePassword.Name = "txtRetypePassword";
            this.txtRetypePassword.Size = new System.Drawing.Size(134, 20);
            this.txtRetypePassword.TabIndex = 14;
            // 
            // chkAgree
            // 
            this.chkAgree.AutoSize = true;
            this.chkAgree.Location = new System.Drawing.Point(50, 212);
            this.chkAgree.Name = "chkAgree";
            this.chkAgree.Size = new System.Drawing.Size(197, 17);
            this.chkAgree.TabIndex = 15;
            this.chkAgree.Text = "I agree to the Terms and Conditions.";
            this.chkAgree.UseVisualStyleBackColor = true;
            this.chkAgree.CheckedChanged += new System.EventHandler(this.chkAgree_CheckedChanged);
            // 
            // linkViewTerms
            // 
            this.linkViewTerms.AutoSize = true;
            this.linkViewTerms.Location = new System.Drawing.Point(360, 216);
            this.linkViewTerms.Name = "linkViewTerms";
            this.linkViewTerms.Size = new System.Drawing.Size(135, 13);
            this.linkViewTerms.TabIndex = 16;
            this.linkViewTerms.TabStop = true;
            this.linkViewTerms.Text = "View Terms and Conditions";
            this.linkViewTerms.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkViewTerms_LinkClicked);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(282, 273);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(142, 23);
            this.btnRegister.TabIndex = 1;
            this.btnRegister.Text = "Register & Login";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(448, 273);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Return login form";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // nudFamilyMembers
            // 
            this.nudFamilyMembers.Location = new System.Drawing.Point(434, 85);
            this.nudFamilyMembers.Name = "nudFamilyMembers";
            this.nudFamilyMembers.Size = new System.Drawing.Size(120, 20);
            this.nudFamilyMembers.TabIndex = 17;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(669, 308);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.groupBox1);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFamilyMembers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rdFemale;
        private System.Windows.Forms.RadioButton rdMale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.CheckBox chkAgree;
        private System.Windows.Forms.TextBox txtRetypePassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.LinkLabel linkViewTerms;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown nudFamilyMembers;
    }
}