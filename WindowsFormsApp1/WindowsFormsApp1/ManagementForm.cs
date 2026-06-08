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
    public partial class ManagementForm : Form
    {
        public ManagementForm()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOwner.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ManagementForm_Load(object sender, EventArgs e)
        {
            
            LoadTravelerData();
            LoadOwnerData();
            UpdateStatusLabel();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void LoadTravelerData(string searchTerm = "")
        {
            using (var conn = Database.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT DISTINCT 
                            i.ID AS [ID],
                            i.Title AS [Title], 
                            i.Capacity AS [Capacity], 
                            a.Name AS [Area], 
                            t.Name AS [Type]
                        FROM Items i
                        JOIN Areas a ON i.AreaID = a.ID
                        JOIN ItemTypes t ON i.ItemTypeID = t.ID
                        LEFT JOIN ItemAttractions ia ON i.ID = ia.ItemID
                        LEFT JOIN Attractions att ON ia.AttractionID = att.ID
                        WHERE i.Title LIKE @search 
                           OR a.Name LIKE @search 
                           OR (att.Name LIKE @search AND ia.Distance <= 1.0)";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView1.DataSource = dt;

                        // Безопасное скрытие системного ID, чтобы избежать NullReferenceException
                        if (dataGridView1.Columns.Contains("ID"))
                        {
                            dataGridView1.Columns["ID"].Visible = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных поиска: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (tabControl1.SelectedIndex == 0)
            {
                UpdateStatusLabel();
            }
        }

        private void LoadOwnerData()
        {
            if (CurrentSession.UserID == null) return;

            using (var conn = Database.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            i.ID AS [ID],
                            i.Title AS [Title], 
                            i.Capacity AS [Capacity], 
                            a.Name AS [Area], 
                            t.Name AS [Type]
                        FROM Items i
                        JOIN Areas a ON i.AreaID = a.ID
                        JOIN ItemTypes t ON i.ItemTypeID = t.ID
                        WHERE i.UserID = @UserID";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", CurrentSession.UserID);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvOwner.DataSource = dt;

                        if (dgvOwner.Columns.Contains("ID"))
                        {
                            dgvOwner.Columns["ID"].Visible = false;
                        }

                        if (!dgvOwner.Columns.Contains("btnEdit"))
                        {
                            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn();
                            editColumn.Name = "btnEdit";
                            editColumn.HeaderText = "Действие";
                            editColumn.Text = "Edit Details";
                            editColumn.UseColumnTextForButtonValue = true; 
                            dgvOwner.Columns.Add(editColumn);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки ваших объявлений: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (tabControl1.SelectedIndex == 1)
            {
                UpdateStatusLabel();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            CurrentSession.UserID = null;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadTravelerData(txtSearch.Text.Trim());
        }

        private void statusLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnAddListing_Click(object sender, EventArgs e)
        {
            AddEditListingForm addForm = new AddEditListingForm(false);
            addForm.ShowDialog();

            LoadOwnerData();
        }

        private void dgvOwner_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex != dgvOwner.NewRowIndex && dgvOwner.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                // Дополнительная защита: проверяем, что ячейка ID не пустая (не DBNull)
                if (dgvOwner.Rows[e.RowIndex].Cells["ID"].Value != DBNull.Value)
                {
                    int listingId = Convert.ToInt32(dgvOwner.Rows[e.RowIndex].Cells["ID"].Value);
                    string listingTitle = dgvOwner.Rows[e.RowIndex].Cells["Title"].Value.ToString();

                    // Открываем форму 1.6 в режиме редактирования
                    AddEditListingForm editForm = new AddEditListingForm(true, listingId, listingTitle);
                    editForm.ShowDialog();

                    // Обновляем список после редактирования
                    LoadOwnerData();
                }
            }
        }

        
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStatusLabel();
        }
        private void UpdateStatusLabel()
        {
            if (tabControl1.SelectedIndex == 0) // Вкладка Traveler
            {
                statusLabel.Text = $"{dataGridView1.Rows.Count} items found.";
            }
            else if (tabControl1.SelectedIndex == 1) // Вкладка Owner
            {
                statusLabel.Text = $"{dgvOwner.Rows.Count} items found.";
            }
        }
    }
}
