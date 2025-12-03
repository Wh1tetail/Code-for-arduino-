using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KmgWin
{
    public partial class Employess : Form
    {
        string connString = "Server=FOXPROBOOK\\SQLEXPRESS;Database=Kmg2;Trusted_Connection=True;TrustServerCertificate=True;";

        public Employess()
        {
            InitializeComponent();
        }

        private void advancedDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Employess_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            string sql = @"
        SELECT e.EmployeeId, e.FullName, e.Position,
               e.Email, e.Phone,
               d.Name AS Department
        FROM Employee e
        JOIN Department d ON e.DepartmentId = d.DepartmentId";

            using (var conn = new SqlConnection(connString))
            using (var cmd = new SqlCommand(sql, conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                advancedDataGridView1.DataSource = table;
            }
        }
    }
}
