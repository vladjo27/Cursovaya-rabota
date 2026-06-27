using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ScooterAdmin;

public partial class AssignRentalForm : Form
{
    public AssignRentalForm()
    {
        InitializeComponent();
    }

    private void AssignRentalForm_Load(object sender, EventArgs e)
    {
        try
        {
            using OleDbConnection main = DatabaseHelper.GetMainConnection();
            using OleDbConnection auth = DatabaseHelper.GetAuthConnection();

            DataTable scooters = DatabaseHelper.ExecuteQuery(main,
                @"SELECT s.ScooterID,
                         s.InventoryNumber & ' - ' & m.Brand & ' ' & m.ModelName AS FullName
                  FROM Scooters s INNER JOIN ScooterModels m ON s.ModelID = m.ModelID
                  WHERE s.[Status] = 'Available'
                  ORDER BY s.ScooterID");

            DataTable users = DatabaseHelper.ExecuteQuery(auth,
                "SELECT UserID, [Login] & ' - ' & FullName AS FullName FROM Users WHERE IsBlocked = False ORDER BY UserID");

            if (scooters.Rows.Count == 0 || users.Rows.Count == 0)
            {
                MessageBox.Show("Нужен хотя бы один доступный самокат и один активный пользователь.");
                Close();
                return;
            }

            cmbScooter.DataSource = scooters;
            cmbScooter.DisplayMember = "FullName";
            cmbScooter.ValueMember = "ScooterID";

            cmbUser.DataSource = users;
            cmbUser.DisplayMember = "FullName";
            cmbUser.ValueMember = "UserID";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка загрузки данных:\n" + ex.Message);
            Close();
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int userId = Convert.ToInt32(cmbUser.SelectedValue);
            int scooterId = Convert.ToInt32(cmbScooter.SelectedValue);

            using OleDbConnection connection = DatabaseHelper.GetMainConnection();
            connection.Open();

            DatabaseHelper.ExecuteNonQuery(connection,
                "INSERT INTO Rentals (UserID, ScooterID, StartTime, [Status]) VALUES (?, ?, Now(), 'Active')",
                new OleDbParameter("@user", userId),
                new OleDbParameter("@scooter", scooterId));

            DatabaseHelper.ExecuteNonQuery(connection,
                "UPDATE Scooters SET [Status] = 'Rented' WHERE ScooterID = ?",
                new OleDbParameter("@scooter", scooterId));

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Не удалось назначить аренду:\n" + ex.Message);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e) => Close();
}
