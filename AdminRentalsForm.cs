using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ScooterAdmin;

public partial class AdminRentalsForm : Form
{
    public AdminRentalsForm()
    {
        InitializeComponent();
    }

    private void AdminRentalsForm_Load(object sender, EventArgs e) => LoadRentals();
    private void btnRefresh_Click(object sender, EventArgs e) => LoadRentals();

    private void LoadRentals()
    {
        try
        {
            using OleDbConnection connection = DatabaseHelper.GetMainConnection();

            // qryAdminAllRentals хранится в ScooterDB.accdb.
            // Запрос показывает все аренды всех пользователей.
            DataTable rentals = DatabaseHelper.ExecuteQueryByName(connection, "qryAdminAllRentals");

            dgvRentals.DataSource = rentals;
            RenameColumns();

            if (rentals.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Список аренд пуст. Проверьте запрос qryAdminAllRentals и таблицу Rentals.",
                    "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
        if (dgvRentals.Columns.Contains("TotalCost")) dgvRentals.Columns["TotalCost"].HeaderText = "Сумма";
        if (dgvRentals.Columns.Contains("Status")) dgvRentals.Columns["Status"].HeaderText = "Статус";
    }

    private void btnAssign_Click(object sender, EventArgs e)
    {
        using AssignRentalForm form = new();
        if (form.ShowDialog(this) == DialogResult.OK)
            LoadRentals();
    }

    private void btnComplete_Click(object sender, EventArgs e)
    {
        DataGridViewRow? row = GetSelectedActiveRental();
        if (row == null) return;

        using CompleteRentalForm form = new(
            rentalId: Convert.ToInt32(row.Cells["RentalID"].Value),
            scooterId: Convert.ToInt32(row.Cells["ScooterID"].Value),
            userId: Convert.ToInt32(row.Cells["UserID"].Value),
            startTime: Convert.ToDateTime(row.Cells["StartTime"].Value),
            scooterName: $"{row.Cells["Brand"].Value} {row.Cells["ModelName"].Value} ({row.Cells["InventoryNumber"].Value})");

        if (form.ShowDialog(this) == DialogResult.OK)
            LoadRentals();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DataGridViewRow? row = GetSelectedActiveRental();
        if (row == null) return;

        int rentalId = Convert.ToInt32(row.Cells["RentalID"].Value);
        int scooterId = Convert.ToInt32(row.Cells["ScooterID"].Value);

        if (MessageBox.Show("Отменить активную аренду без оплаты?", "Отмена", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            return;

        try
        {
            using OleDbConnection connection = DatabaseHelper.GetMainConnection();
            connection.Open();

            DatabaseHelper.ExecuteNonQuery(connection,
                "UPDATE Rentals SET EndTime = Now(), TotalCost = 0, [Status] = 'Cancelled' WHERE RentalID = ?",
                new OleDbParameter("@rental", rentalId));

            DatabaseHelper.ExecuteNonQuery(connection,
                "UPDATE Scooters SET [Status] = 'Available' WHERE ScooterID = ?",
                new OleDbParameter("@scooter", scooterId));

            LoadRentals();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Не удалось отменить аренду:\n" + ex.Message);
        }
    }

    private DataGridViewRow? GetSelectedActiveRental()
    {
        if (dgvRentals.SelectedRows.Count == 0)
        {
            MessageBox.Show("Выберите аренду.");
            return null;
        }

        DataGridViewRow row = dgvRentals.SelectedRows[0];
        string status = row.Cells["Status"].Value?.ToString() ?? "";

        if (!status.Equals("Active", StringComparison.OrdinalIgnoreCase))
        {
            MessageBox.Show("Действие доступно только для активной аренды.");
            return null;
        }

        return row;
    }
}
