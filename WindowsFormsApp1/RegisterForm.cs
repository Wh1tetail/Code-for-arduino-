using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class RegisterForm : Form

    {
        private bool termsViewed = false;
        public RegisterForm()
        {
            InitializeComponent();
            dtpBirthday.CustomFormat = "yyyy-MM-dd"; // Стандарт ISO 
            dtpBirthday.Format = DateTimePickerFormat.Custom;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // [cite: 178]
                return;
            }

            if (txtPassword.Text.Length < 5)
            {
                MessageBox.Show("Длина пароля должна составлять не менее пяти символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // 
                return;
            }

            if (txtPassword.Text != txtRetypePassword.Text)
            {
                MessageBox.Show("Пароли не совпадают.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // 
                return;
            }

            if (!chkAgree.Checked)
            {
                MessageBox.Show("Вы должны согласиться с условиями.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // [cite: 179]
                return;
            }

            using(var conn = Database.GetConnection())
{
                conn.Open();

                int newId = 1; // Значение по умолчанию, если таблица вдруг пустая
                string getIdQuery = "SELECT ISNULL(MAX(ID), 0) + 1 FROM Users";
                using (var idCmd = new SqlCommand(getIdQuery, conn))
                {
                    newId = Convert.ToInt32(idCmd.ExecuteScalar());
                }

                // 2. Обновленный запрос INSERT, куда мы явно передаем вычисленный ID
                string insertQuery = @"INSERT INTO Users (GUID, UserTypeID, Username, Password, FullName, Gender, BirthDate, FamilyCount) 
                       VALUES (NEWID(), 2, @Username, @Password, @FullName, @Gender, @BirthDate, @FamilyCount)";

                using (var cmd = new SqlCommand(insertQuery, conn))
                {
                    // Обрати внимание: параметра @ID здесь больше нет

                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gender", rdMale.Checked ? 1 : 0); // 1 - Male, 0 - Female
                    cmd.Parameters.AddWithValue("@BirthDate", dtpBirthday.Value.Date);
                    cmd.Parameters.AddWithValue("@FamilyCount", (int)nudFamilyMembers.Value);

                    cmd.ExecuteNonQuery(); // Теперь база сама сгенерирует ID и запишет строку
                }

                MessageBox.Show("Учетная запись успешно создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Возвращаемся на LoginForm
            }
        }

        private void linkViewTerms_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filePath = Path.Combine(Application.StartupPath, "Terms.txt");

            // Всегда проверяй, существует ли файл, чтобы программа не вылетела с ошибкой (крашем)
            if (File.Exists(filePath))
            {
                // Создаем параметры запуска
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true // Это скажет ОС открыть файл в приложении по умолчанию (Блокноте)
                };

                Process.Start(psi);

                // Отмечаем флаг, что клиент просмотрел условия (нужно для валидации кнопки регистрации)
                termsViewed = true;
            }
            else
            {
                MessageBox.Show("Файл Terms.txt не найден в папке с программой!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chkAgree_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAgree.Checked && !termsViewed)
            {
                MessageBox.Show("Сначала необходимо просмотреть Условия (Terms and Conditions).", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkAgree.Checked = false;
            }
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }

        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void nudFamilyMembers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
