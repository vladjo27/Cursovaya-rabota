using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ScooterAdmin;

public partial class AdminScootersForm : Form
{
    public AdminScootersForm()
    {
        InitializeComponent();
    }

    private void AdminScootersForm_Load(object sender, EventArgs e) => LoadScooters();
    private void btnRefresh_Click(object sender, EventArgs e) => LoadScooters();

    private void LoadScooters()
    {
        try
        {
            using OleDbConnection connection = DatabaseHelper.GetMainConnection();

            // qryAdminAllScooters хранится в ScooterDB.accdb.
            // Запрос показывает все самокаты для администратора.
            DataTable scooters = DatabaseHelper.ExecuteQueryByName(connection, "qryAdminAllScooters");

            dgvScooters.DataSource = scooters;
            RenameColumns();

            if (scooters.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Список самокатов пуст. Проверьте запрос qryAdminAllScooters и таблицу Scooters.",
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
        if (dgvScooters.Columns.Contains("Status")) dgvScooters.Columns["Status"].HeaderText = "Статус";
        if (dgvScooters.Columns.Contains("Location")) dgvScooters.Columns["Location"].HeaderText = "Локация";
        if (dgvScooters.Columns.Contains("BatteryLevel")) dgvScooters.Columns["BatteryLevel"].HeaderText = "Заряд %";
        if (dgvScooters.Columns.Contains("PricePerHour")) dgvScooters.Columns["PricePerHour"].HeaderText = "Цена/час";
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        using AddScooterForm form = new();
        if (form.ShowDialog(this) == DialogResult.OK)
            LoadScooters();
    }

    private void btnEditStatus_Click(object sender, EventArgs e)
    {
        if (dgvScooters.SelectedRows.Count == 0)
        {
            MessageBox.Show("Выберите самокат.");
            return;
        }

        DataGridViewRow row = dgvScooters.SelectedRows[0];
        int scooterId = Convert.ToInt32(row.Cells["ScooterID"].Value);
        string status = row.Cells["Status"].Value?.ToString() ?? "Available";
        string location = row.Cells["Location"].Value?.ToString() ?? "";

        using EditScooterStatusForm form = new(scooterId, status, location);
        if (form.ShowDialog(this) == DialogResult.OK)
            LoadScooters();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvScooters.SelectedRows.Count == 0)
        {
            MessageBox.Show("Выберите самокат.");
            return;
        }

        DataGridViewRow row = dgvScooters.SelectedRows[0];
        int scooterId = Convert.ToInt32(row.Cells["ScooterID"].Value);
        string inventory = row.Cells["InventoryNumber"].Value?.ToString() ?? "";

        if (MessageBox.Show($"Удалить самокат {inventory}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            return;

        try
        {
            using OleDbConnection connection = DatabaseHelper.GetMainConnection();
            DatabaseHelper.ExecuteNonQuery(connection,
                "DELETE FROM Scooters WHERE ScooterID = ?",
                new OleDbParameter("@id", scooterId));

            LoadScooters();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Не удалось удалить самокат:\n" + ex.Message);
        }
    }
}
