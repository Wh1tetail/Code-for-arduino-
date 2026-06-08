using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddEditListingForm : Form
    {
        private bool isEditMode;
        private int currentListingId;
        private int currentMaxTabIndex = 0;

        public AddEditListingForm(bool editMode, int listingId = 0, string listingTitle = "")
        {
            InitializeComponent();
            LoadAmenities();
            isEditMode = editMode;
            currentListingId = listingId;
            btnClose.ForeColor = System.Drawing.Color.Red;

            if (isEditMode)
            {
                // Режим редактирования
                this.Text = "Seoul Stay - Edit Listing " + listingTitle;
                btnNext.Visible = false;
                btnClose.Visible = false;
                btnFinish.Text = "Close";
                btnFinish.Visible = true;
            }
            else
            {
                // Режим добавления
                this.Text = "Seoul Stay - Add Listing";
                btnNext.Visible = true;
                btnClose.Visible = true;
                btnFinish.Text = "Finish";
                btnFinish.Visible = false;
            }
        }

        private void LoadComboBoxes()
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT ID, Name FROM ItemTypes";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmdType.DataSource = dt;
                cmdType.DisplayMember = "Name";
                cmdType.ValueMember = "ID";
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (nudCapacity.Value <= 0 || nudBeds.Value <= 0 || nudBedrooms.Value <= 0 || nudBathrooms.Value <= 0)
                {
                    MessageBox.Show("Значения вместимости и комнат должны быть больше нуля.");
                    return;
                }

                if (nudMinNights.Value <= 0 || nudMinNights.Value > nudMinNights.Value)
                {
                    MessageBox.Show("Проверьте правила бронирования (минимум > 0 и <= максимум).");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtExactAddress.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля.");
                    return;
                }

                tabControl1.SelectedIndex = 1;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                tabControl1.SelectedIndex = 2;
                btnNext.Visible = false;
                btnFinish.Visible = true;
            }
        }

        private void LoadAmenities()
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT ID, Name FROM Amenities";
                using (var cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAmenities.DataSource = dt;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            int distancesFilled = 0;
            foreach (DataGridViewRow row in dgvAttractions.Rows)
            {
                if (row.Cells["Distance"].Value != null && !string.IsNullOrWhiteSpace(row.Cells["Distance"].Value.ToString()))
                {
                    distancesFilled++;
                }
            }

            if (distancesFilled < 2)
            {
                MessageBox.Show("Укажите расстояние как минимум до двух достопримечательностей.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. СОХРАНЕНИЕ В БАЗУ ДАННЫХ
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction(); // НАЧАЛО ТРАНЗАКЦИИ

                try // НАЧАЛО БЛОКА TRY (здесь живут переменные)
                {
                    int targetListingId = currentListingId;

                    if (!isEditMode)
                    {
                        // ДОБАВЛЕНИЕ НОВОГО ОБЪЯВЛЕНИЯ
                        string insertItem = @"
                    INSERT INTO Items (GUID, UserID, ItemTypeID, AreaID, Title, Capacity, NumberOfBeds, NumberOfBedrooms, NumberOfBathrooms, ExactAddress, ApproximateAddress, Description, HostRules, MinimumNights, MaximumNights)
                    VALUES (NEWID(), @UserID, @TypeID, 1, @Title, @Capacity, @Beds, @Bedrooms, @Bathrooms, @ExactAddress, @ApproxAddress, @Desc, @Rules, @MinNights, @MaxNights);
                    SELECT SCOPE_IDENTITY();";

                        using (var cmd = new SqlCommand(insertItem, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@UserID", CurrentSession.UserID);
                            cmd.Parameters.AddWithValue("@TypeID", cmdType.SelectedValue);
                            cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                            cmd.Parameters.AddWithValue("@Capacity", nudCapacity.Value);
                            cmd.Parameters.AddWithValue("@Beds", nudBeds.Value);
                            cmd.Parameters.AddWithValue("@Bedrooms", nudBedrooms.Value);
                            cmd.Parameters.AddWithValue("@Bathrooms", nudBathrooms.Value);
                            cmd.Parameters.AddWithValue("@ExactAddress", txtExactAddress.Text.Trim());
                            cmd.Parameters.AddWithValue("@ApproxAddress", txtApproxAddress.Text.Trim());
                            cmd.Parameters.AddWithValue("@Desc", txtDescription.Text.Trim());
                            cmd.Parameters.AddWithValue("@Rules", txtHostRules.Text.Trim());
                            cmd.Parameters.AddWithValue("@MinNights", nudMinNights.Value);
                            cmd.Parameters.AddWithValue("@MaxNights", nudMaxNights.Value);

                            targetListingId = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                    else
                    {
                        // РЕДАКТИРОВАНИЕ
                        string updateItem = @"
                    UPDATE Items SET ItemTypeID=@TypeID, Title=@Title, Capacity=@Capacity, NumberOfBeds=@Beds, 
                    NumberOfBedrooms=@Bedrooms, NumberOfBathrooms=@Bathrooms, ExactAddress=@ExactAddress, 
                    ApproximateAddress=@ApproxAddress, Description=@Desc, HostRules=@Rules, 
                    MinimumNights=@MinNights, MaximumNights=@MaxNights
                    WHERE ID = @ItemID";

                        using (var cmd = new SqlCommand(updateItem, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ItemID", targetListingId);
                            cmd.Parameters.AddWithValue("@TypeID", cmdType.SelectedValue);
                            cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                            cmd.Parameters.AddWithValue("@Capacity", nudCapacity.Value);
                            cmd.Parameters.AddWithValue("@Beds", nudBeds.Value);
                            cmd.Parameters.AddWithValue("@Bedrooms", nudBedrooms.Value);
                            cmd.Parameters.AddWithValue("@Bathrooms", nudBathrooms.Value);
                            cmd.Parameters.AddWithValue("@ExactAddress", txtExactAddress.Text.Trim());
                            cmd.Parameters.AddWithValue("@ApproxAddress", txtApproxAddress.Text.Trim());
                            cmd.Parameters.AddWithValue("@Desc", txtDescription.Text.Trim());
                            cmd.Parameters.AddWithValue("@Rules", txtHostRules.Text.Trim());
                            cmd.Parameters.AddWithValue("@MinNights", nudMinNights.Value);
                            cmd.Parameters.AddWithValue("@MaxNights", nudMaxNights.Value);
                            cmd.ExecuteNonQuery();
                        }

                        // Очищаем старые связи удобств и дистанций перед вставкой новых
                        new SqlCommand($"DELETE FROM ItemAmenities WHERE ItemID = {targetListingId}", conn, transaction).ExecuteNonQuery();
                        new SqlCommand($"DELETE FROM ItemAttractions WHERE ItemID = {targetListingId}", conn, transaction).ExecuteNonQuery();
                    }

                    // СОХРАНЕНИЕ УДОБСТВ (Amenities) через DataRowView
                    foreach (DataGridViewRow row in dgvAmenities.Rows)
                    {
                        if (row.Cells["IsSelected"].Value != null && Convert.ToBoolean(row.Cells["IsSelected"].Value) == true)
                        {
                            DataRowView dataRow = row.DataBoundItem as DataRowView;
                            if (dataRow != null)
                            {
                                int amenityID = Convert.ToInt32(dataRow["ID"]);

                                string insertAmenity = "INSERT INTO ItemAmenities (GUID, ItemID, AmenityID) VALUES (NEWID(), @ItemID, @AmenityID)";
                                using (var cmd = new SqlCommand(insertAmenity, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@ItemID", targetListingId);
                                    cmd.Parameters.AddWithValue("@AmenityID", amenityID);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    // СОХРАНЕНИЕ ДИСТАНЦИЙ (Attractions) через DataRowView
                    foreach (DataGridViewRow row in dgvAttractions.Rows)
                    {
                        if (row.Cells["Distance"].Value != null && !string.IsNullOrWhiteSpace(row.Cells["Distance"].Value.ToString()))
                        {
                            DataRowView dataRow = row.DataBoundItem as DataRowView;
                            if (dataRow != null)
                            {
                                int attractionID = Convert.ToInt32(dataRow["AttractionID"]);

                                decimal.TryParse(row.Cells["Distance"].Value.ToString().Replace(".", ","), out decimal distance);

                                object onFoot = DBNull.Value;
                                if (row.Cells["OnFoot"] != null && row.Cells["OnFoot"].Value != null && int.TryParse(row.Cells["OnFoot"].Value.ToString(), out int footVal))
                                    onFoot = footVal;

                                object byCar = DBNull.Value;
                                if (row.Cells["ByCar"] != null && row.Cells["ByCar"].Value != null && int.TryParse(row.Cells["ByCar"].Value.ToString(), out int carVal))
                                    byCar = carVal;

                                string insertAttract = "INSERT INTO ItemAttractions (GUID, ItemID, AttractionID, Distance, DurationOnFoot, DurationByCar) VALUES (NEWID(), @ItemID, @AttractID, @Dist, @Foot, @Car)";
                                using (var cmd = new SqlCommand(insertAttract, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@ItemID", targetListingId);
                                    cmd.Parameters.AddWithValue("@AttractID", attractionID);
                                    cmd.Parameters.AddWithValue("@Dist", distance);
                                    cmd.Parameters.AddWithValue("@Foot", onFoot);
                                    cmd.Parameters.AddWithValue("@Car", byCar);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    transaction.Commit(); // ПРИМЕНЯЕМ ВСЕ ИЗМЕНЕНИЯ
                    MessageBox.Show("Объявление успешно сохранено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                } // КОНЕЦ БЛОКА TRY
                catch (Exception ex)
                {
                    transaction.Rollback(); // ОТКАТЫВАЕМ, ЕСЛИ ОШИБКА
                    MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Системная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } // КОНЕЦ БЛОКА USING
        }

        private void AddEditListingForm_Load(object sender, EventArgs e)
        {

            LoadComboBoxes();
            SetupAmenitiesGrid();
            SetupAttractionsGrid();

            if (isEditMode)
            {
                LoadExistingData();
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvAttractions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SetupAttractionsGrid()
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT att.ID AS AttractionID, att.Name AS Attraction, a.Name AS Area 
                    FROM Attractions att
                    JOIN Areas a ON att.AreaID = a.ID";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvAttractions.DataSource = dt;
                if (dgvAttractions.Columns.Contains("AttractionID"))
                {
                    dgvAttractions.Columns["AttractionID"].Visible = false;
                }
                dgvAttractions.AllowUserToAddRows = false;

                dgvAttractions.Columns.Add(new DataGridViewTextBoxColumn { Name = "Distance", HeaderText = "Distance (km)" });
                dgvAttractions.Columns.Add(new DataGridViewTextBoxColumn { Name = "OnFoot", HeaderText = "On Foot (min)" });
                dgvAttractions.Columns.Add(new DataGridViewTextBoxColumn { Name = "ByCar", HeaderText = "By Car (min)" });

                if (dgvAttractions.Columns.Contains("Attraction"))
                {
                    dgvAttractions.Columns["Attraction"].ReadOnly = true;
                }
                else if (dgvAttractions.Columns.Contains("attraction")) 
                {
                    dgvAttractions.Columns["attraction"].ReadOnly = true;
                }

                if (dgvAttractions.Columns.Contains("Area"))
                {
                    dgvAttractions.Columns["Area"].ReadOnly = true;
                }
                else if (dgvAttractions.Columns.Contains("area")) 
                {
                    dgvAttractions.Columns["area"].ReadOnly = true;
                }
            }
        }

        private void SetupAmenitiesGrid()
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT ID, Name AS Amenity FROM Amenities";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvAmenities.DataSource = dt;
                if (dgvAmenities.Columns.Contains("ID"))
                {
                    dgvAmenities.Columns["ID"].Visible = false;
                }
                else if (dgvAmenities.Columns.Contains("id")) 
                {
                    dgvAmenities.Columns["id"].Visible = false;
                }
                dgvAmenities.AllowUserToAddRows = false;

                // Добавляем чекбокс для выбора
                DataGridViewCheckBoxColumn chkCol = new DataGridViewCheckBoxColumn();
                chkCol.Name = "IsSelected";
                chkCol.HeaderText = "Choose";
                dgvAmenities.Columns.Insert(0, chkCol);
            }
        }

        private void LoadExistingData()
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();

                string qItem = "SELECT * FROM Items WHERE ID = @ID";
                using (var cmd = new SqlCommand(qItem, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", currentListingId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cmdType.SelectedValue = reader["ItemTypeID"];
                            txtTitle.Text = reader["Title"].ToString();
                            nudCapacity.Value = Convert.ToDecimal(reader["Capacity"]);
                            nudBeds.Value = Convert.ToDecimal(reader["NumberOfBeds"]);
                            nudBedrooms.Value = Convert.ToDecimal(reader["NumberOfBedrooms"]);
                            nudBathrooms.Value = Convert.ToDecimal(reader["NumberOfBathrooms"]);
                            txtExactAddress.Text = reader["ExactAddress"].ToString();
                            txtApproxAddress.Text = reader["ApproximateAddress"].ToString();
                            txtDescription.Text = reader["Description"].ToString();
                            txtHostRules.Text = reader["HostRules"].ToString();
                            nudMinNights.Value = Convert.ToDecimal(reader["MinimumNights"]);
                            nudMaxNights.Value = Convert.ToDecimal(reader["MaximumNights"]);
                        }
                    }
                }

                string qAmenity = "SELECT AmenityID FROM ItemAmenities WHERE ItemID = @ID";
                using (var cmd = new SqlCommand(qAmenity, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", currentListingId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int amID = Convert.ToInt32(reader["AmenityID"]);
                            foreach (DataGridViewRow row in dgvAmenities.Rows)
                            {
                                if (Convert.ToInt32(row.Cells["ID"].Value) == amID)
                                {
                                    row.Cells["IsSelected"].Value = true;
                                    break;
                                }
                            }
                        }
                    }
                }

                string qAttract = "SELECT AttractionID, Distance, DurationOnFoot, DurationByCar FROM ItemAttractions WHERE ItemID = @ID";
                using (var cmd = new SqlCommand(qAttract, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", currentListingId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int attID = Convert.ToInt32(reader["AttractionID"]);
                            foreach (DataGridViewRow row in dgvAttractions.Rows)
                            {
                                if (Convert.ToInt32(row.Cells["AttractionID"].Value) == attID)
                                {
                                    row.Cells["Distance"].Value = reader["Distance"].ToString();
                                    row.Cells["OnFoot"].Value = reader["DurationOnFoot"].ToString();
                                    row.Cells["ByCar"].Value = reader["DurationByCar"].ToString();
                                    break;
                                }
                            }
                        }
                    }
                }
            }

        }

        private void dgvAmenities_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
