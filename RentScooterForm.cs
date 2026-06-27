using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ScooterRental;

public partial class RentScooterForm : Form
{
    public RentScooterForm()
    {
        InitializeComponent();
    }

    private void RentScooterForm_Load(object sender, EventArgs e) => LoadAvailableScooters();

    private void LoadAvailableScooters()
    {
        try
        {
            using OleDbConnection connection = DatabaseHelper.GetMainConnection();

            // qryAvailableScooters хранится в ScooterDB.accdb.
            // Запрос возвращает список самокатов, которые сейчас можно арендовать.
            DataTable scooters = DatabaseHelper.ExecuteQueryByName(connection, "qryAvailableScooters");

            dgvScooters.DataSource = scooters;
            RenameColumns();

            if (scooters.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Список доступных самокатов пуст. Проверьте запрос qryAvailableScooters и поле Status = Available в таблице Scooters.",
                    "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка загрузки самокатов:\n" + ex.Message);
        }
    }

    private void RenameColumns()
    {
        if (dgvScooters.Columns.Contains("ScooterID")) dgvScooters.Columns["ScooterID"].Visible = false;
        if (dgvScooters.Columns.Contains("InventoryNumber")) dgvScooters.Columns["InventoryNumber"].HeaderText = "Инв. номер";
        if (dgvScooters.Columns.Contains("Brand")) dgvScooters.Columns["Brand"].HeaderText = "Бренд";
        if (dgvScooters.Columns.Contains("ModelName")) dgvScooters.Columns["ModelName"].HeaderText = "Модель";
        if (dgvScooters.Columns.Contains("MaxSpeed")) dgvScooters.Columns["MaxSpeed"].HeaderText = "Макс. скорость";
        if (dgvScooters.Columns.Contains("BatteryLevel")) dgvScooters.Columns["BatteryLevel"].HeaderText = "Заряд %";
        if (dgvScooters.Columns.Contains("Location")) dgvScooters.Columns["Location"].HeaderText = "Локация";
        if (dgvScooters.Columns.Contains("PricePerHour")) dgvScooters.Columns["PricePerHour"].HeaderText = "Цена/час";
    }

    private void btnRent_Click(object sender, EventArgs e)
    {
        if (dgvScooters.SelectedRows.Count == 0)
        {
            MessageBox.Show("Выберите самокат.");
            return;
        }

        DataGridViewRow row = dgvScooters.SelectedRows[0];
        int scooterId = Convert.ToInt32(row.Cells["ScooterID"].Value);
        string inventory = row.Cells["InventoryNumber"].Value?.ToString() ?? "";
        string scooterName = $"{row.Cells["Brand"].Value} {row.Cells["ModelName"].Value}";
        int battery = Convert.ToInt32(row.Cells["BatteryLevel"].Value);
        string location = row.Cells["Location"].Value?.ToString() ?? "";
        decimal pricePerHour = Convert.ToDecimal(row.Cells["PricePerHour"].Value);

        using RentConfirmForm confirmForm = new(scooterName, inventory, battery, location, pricePerHour);
        if (confirmForm.ShowDialog(this) != DialogResult.OK)
            return;

        CreateRental(scooterId);
        ShowRentalResult(scooterName, pricePerHour, confirmForm.SelectedMinutes);
        LoadAvailableScooters();
    }

    /// <summary>
    /// Создаёт активную аренду и переводит самокат в статус Rented.
    /// Эти действия оставлены в C#, а основные выборки вынесены в Access-запросы.
    /// </summary>
    private static void CreateRental(int scooterId)
    {
        using OleDbConnection connection = DatabaseHelper.GetMainConnection();
        connection.Open();

        DatabaseHelper.ExecuteNonQuery(connection,
            "INSERT INTO Rentals (UserID, ScooterID, StartTime, [Status]) VALUES (?, ?, Now(), 'Active')",
            new OleDbParameter("@user", CurrentUser.UserID),
            new OleDbParameter("@scooter", scooterId));

        DatabaseHelper.ExecuteNonQuery(connection,
            "UPDATE Scooters SET [Status] = 'Rented' WHERE ScooterID = ?",
            new OleDbParameter("@scooter", scooterId));
    }

    private static void ShowRentalResult(string scooterName, decimal pricePerHour, int minutes)
    {
        decimal pricePerMinute = pricePerHour / 60m;
        decimal plannedCost = Math.Ceiling(pricePerMinute * minutes);
        DateTime plannedEnd = DateTime.Now.AddMinutes(minutes);

        MessageBox.Show(
            $"Самокат арендован!\n\n" +
            $"{scooterName}\n" +
            $"План: {minutes / 60} ч {minutes % 60} мин\n" +
            $"Ориентир: {plannedCost:N0} руб\n" +
            $"Вернуть до: {plannedEnd:HH:mm}\n\n" +
            $"Приятной поездки!",
            "Аренда оформлена", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
