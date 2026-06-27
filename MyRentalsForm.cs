using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ScooterRental;

public partial class MyRentalsForm : Form
{
    public MyRentalsForm()
    {
        InitializeComponent();
    }

    private void MyRentalsForm_Load(object sender, EventArgs e) => LoadRentals();

    private void LoadRentals()
    {
        try
        {
            using OleDbConnection connection = DatabaseHelper.GetMainConnection();

            // qryUserRentals хранится в ScooterDB.accdb.
            // Запрос принимает UserID и возвращает аренды только текущего пользователя.
            DataTable rentals = DatabaseHelper.ExecuteQueryByName(
                connection,
                "qryUserRentals",
                new OleDbParameter("@pUserID", CurrentUser.UserID));

            dgvRentals.DataSource = rentals;
            RenameColumns();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка загрузки аренд:\n" + ex.Message);
        }
    }

    private void RenameColumns()
    {
        if (dgvRentals.Columns.Contains("RentalID")) dgvRentals.Columns["RentalID"].Visible = false;
        if (dgvRentals.Columns.Contains("ScooterID")) dgvRentals.Columns["ScooterID"].Visible = false;
        if (dgvRentals.Columns.Contains("InventoryNumber")) dgvRentals.Columns["InventoryNumber"].HeaderText = "Инв. номер";
        if (dgvRentals.Columns.Contains("Brand")) dgvRentals.Columns["Brand"].HeaderText = "Бренд";
        if (dgvRentals.Columns.Contains("ModelName")) dgvRentals.Columns["ModelName"].HeaderText = "Модель";
        if (dgvRentals.Columns.Contains("StartTime")) dgvRentals.Columns["StartTime"].HeaderText = "Начало";
        if (dgvRentals.Columns.Contains("EndTime")) dgvRentals.Columns["EndTime"].HeaderText = "Конец";
        if (dgvRentals.Columns.Contains("TotalCost")) dgvRentals.Columns["TotalCost"].HeaderText = "Стоимость";
        if (dgvRentals.Columns.Contains("Status")) dgvRentals.Columns["Status"].HeaderText = "Статус";
    }

    private void btnReturn_Click(object sender, EventArgs e)
    {
        if (dgvRentals.SelectedRows.Count == 0)
        {
            MessageBox.Show("Выберите аренду.");
            return;
        }

        DataGridViewRow row = dgvRentals.SelectedRows[0];
        string status = row.Cells["Status"].Value?.ToString() ?? "";

        if (!status.Equals("Active", StringComparison.OrdinalIgnoreCase))
        {
            MessageBox.Show("Вернуть можно только активную аренду.");
            return;
        }

        int rentalId = Convert.ToInt32(row.Cells["RentalID"].Value);
        int scooterId = Convert.ToInt32(row.Cells["ScooterID"].Value);
        DateTime startTime = Convert.ToDateTime(row.Cells["StartTime"].Value);
        string scooterName = $"{row.Cells["Brand"].Value} {row.Cells["ModelName"].Value}";

        using ReturnScooterForm form = new(scooterId, startTime, scooterName);
        if (form.ShowDialog(this) != DialogResult.OK)
            return;

        CompleteRental(rentalId, scooterId, form.TotalCost);
        MessageBox.Show($"Самокат возвращён.\nСписано: {form.TotalCost:N0} руб.",
            "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        LoadRentals();
    }

    private static void CompleteRental(int rentalId, int scooterId, decimal totalCost)
    {
        using OleDbConnection connection = DatabaseHelper.GetMainConnection();
        connection.Open();

        DatabaseHelper.ExecuteNonQuery(connection,
            "UPDATE Rentals SET EndTime = Now(), TotalCost = ?, [Status] = 'Completed' WHERE RentalID = ?",
            new OleDbParameter("@cost", totalCost),
            new OleDbParameter("@rental", rentalId));

        DatabaseHelper.ExecuteNonQuery(connection,
            "INSERT INTO Payments (RentalID, Amount, PaymentDate, PaymentMethod) VALUES (?, ?, Now(), 'Карта')",
            new OleDbParameter("@rental", rentalId),
            new OleDbParameter("@amount", totalCost));

        DatabaseHelper.ExecuteNonQuery(connection,
            "UPDATE Scooters SET [Status] = 'Available' WHERE ScooterID = ?",
            new OleDbParameter("@scooter", scooterId));
    }
}
