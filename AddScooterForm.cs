using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ScooterAdmin;

public partial class AddScooterForm : Form
{
    public AddScooterForm()
    {
        InitializeComponent();
    }

    private void AddScooterForm_Load(object sender, EventArgs e)
    {
        try
        {
            using OleDbConnection connection = DatabaseHelper.GetMainConnection();
            DataTable models = DatabaseHelper.ExecuteQuery(connection,
                "SELECT ModelID, Brand & ' ' & ModelName AS FullName FROM ScooterModels ORDER BY Brand, ModelName");

            if (models.Rows.Count == 0)
            {
                MessageBox.Show("Сначала добавьте хотя бы одну модель.");
                Close();
                return;
            }

            cmbModel.DataSource = models;
            cmbModel.DisplayMember = "FullName";
            cmbModel.ValueMember = "ModelID";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка загрузки моделей:\n" + ex.Message);
            Close();
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        string inventory = txtInventory.Text.Trim();
        if (inventory == "")
        {
            MessageBox.Show("Введите инвентарный номер.");
            return;
        }

        try
        {
            using OleDbConnection connection = DatabaseHelper.GetMainConnection();
            DatabaseHelper.ExecuteNonQuery(connection,
                "INSERT INTO Scooters (ModelID, InventoryNumber, [Status], [Location], BatteryLevel) VALUES (?, ?, 'Available', ?, ?)",
                new OleDbParameter("@model", Convert.ToInt32(cmbModel.SelectedValue)),
                new OleDbParameter("@inventory", inventory),
                new OleDbParameter("@location", txtLocation.Text.Trim()),
                new OleDbParameter("@battery", (int)numBattery.Value));

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Не удалось добавить самокат:\n" + ex.Message);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e) => Close();
}
