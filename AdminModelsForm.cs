using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ScooterAdmin;

public partial class AdminModelsForm : Form
{
    public AdminModelsForm()
    {
        InitializeComponent();
    }

    private void AdminModelsForm_Load(object sender, EventArgs e) => LoadModels();

    private void LoadModels()
    {
        try
        {
            using OleDbConnection connection = DatabaseHelper.GetMainConnection();
            DataTable models = DatabaseHelper.ExecuteQuery(connection,
                "SELECT ModelID, Brand, ModelName, MaxSpeed, BatteryCapacity, PricePerHour FROM ScooterModels ORDER BY Brand, ModelName");

            dgvModels.DataSource = models;
            RenameColumns();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка загрузки моделей:\n" + ex.Message);
        }
    }

    private void RenameColumns()
    {
        if (dgvModels.Columns.Contains("ModelID")) dgvModels.Columns["ModelID"].Visible = false;
        if (dgvModels.Columns.Contains("Brand")) dgvModels.Columns["Brand"].HeaderText = "Бренд";
        if (dgvModels.Columns.Contains("ModelName")) dgvModels.Columns["ModelName"].HeaderText = "Модель";
        if (dgvModels.Columns.Contains("MaxSpeed")) dgvModels.Columns["MaxSpeed"].HeaderText = "Макс. скорость";
        if (dgvModels.Columns.Contains("BatteryCapacity")) dgvModels.Columns["BatteryCapacity"].HeaderText = "Батарея";
        if (dgvModels.Columns.Contains("PricePerHour")) dgvModels.Columns["PricePerHour"].HeaderText = "Цена/час";
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        using AddModelForm form = new();
        if (form.ShowDialog(this) == DialogResult.OK)
            LoadModels();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvModels.SelectedRows.Count == 0)
        {
            MessageBox.Show("Выберите модель.");
            return;
        }

        int modelId = Convert.ToInt32(dgvModels.SelectedRows[0].Cells["ModelID"].Value);

        if (MessageBox.Show("Удалить выбранную модель?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            return;

        try
        {
            using OleDbConnection connection = DatabaseHelper.GetMainConnection();
            DatabaseHelper.ExecuteNonQuery(connection,
                "DELETE FROM ScooterModels WHERE ModelID = ?",
                new OleDbParameter("@id", modelId));

            LoadModels();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Не удалось удалить модель. Возможно, к ней привязаны самокаты.\n" + ex.Message);
        }
    }
}
