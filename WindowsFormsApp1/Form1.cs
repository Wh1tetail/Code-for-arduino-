using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true; 
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string employee = txtEmployee.Text.Trim();
            string user = txtUser.Text.Trim();
            string password = txtPassword.Text;

            if (!string.IsNullOrEmpty(employee))
            { 
                MessageBox.Show("Вход под сотрудником. Проверка пароля...");
            }
            else
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT ID, UserTypeID FROM Users WHERE Username = @Username AND Password = @Password";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", user);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                CurrentSession.UserID = Convert.ToInt32(reader["ID"]);

                                ManagementForm mgmtForm = new ManagementForm();
                                this.Hide();
                                mgmtForm.ShowDialog(); // Остановка операций с другими формами 
                                this.Show();
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked) {
                txtPassword.UseSystemPasswordChar = false; 
            } else {
                txtPassword.UseSystemPasswordChar = true;
            }

            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void linkCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm regForm = new RegisterForm();
            regForm.ShowDialog(); 
        }
    }
}
