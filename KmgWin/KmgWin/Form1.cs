using Microsoft.Data.SqlClient;
namespace KmgWin
{
    public partial class Form1 : Form
    {
        string connString = "Server=FOXPROBOOK\\SQLEXPRESS;Database=Kmg2;Trusted_Connection=True;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (login == "" || password == "")
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }

            string sql = @"
        SELECT FullName, Role
        FROM UserAccounts
        WHERE Login = @login AND PasswordHash = @password
    ";

            using (var conn = new SqlConnection(connString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        MessageBox.Show("Неверный логин или пароль!");
                        return;
                    }

                    string fullName = reader["FullName"].ToString() ?? string.Empty;
                    string role = reader["Role"].ToString() ?? string.Empty;

                    MessageBox.Show("Добро пожаловать, " + fullName);

                    // открыть главное окно
                    MainForm main = new MainForm(fullName, role);
                    this.Hide();
                    main.ShowDialog();
                    this.Close();
                }
            }
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
