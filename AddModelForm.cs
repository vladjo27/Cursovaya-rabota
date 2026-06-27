using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ScooterAdmin;

public partial class AddModelForm : Form
{
    public AddModelForm()
    {
        InitializeComponent();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        string brand = txtBrand.Text.Trim();
        string modelName = txtModelName.Text.Trim();

        if (brand == "" || modelName == "")
        {
            MessageBox.Show("Заполните бренд и название модели.");
            return;
        }

        try
        {
            using OleDbConnection connection = DatabaseHelper.GetMainConnection();
            DatabaseHelper.ExecuteNonQuery(connection,
                "INSERT INTO ScooterModels (Brand, ModelName, MaxSpeed, BatteryCapacity, PricePerHour) VALUES (?, ?, ?, ?, ?)",
                new OleDbParameter("@brand", brand),
                new OleDbParameter("@name", modelName),
                new OleDbParameter("@speed", (int)numSpeed.Value),
                new OleDbParameter("@battery", (int)numBattery.Value),
                new OleDbParameter("@price", numPrice.Value));

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Не удалось добавить модель:\n" + ex.Message);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e) => Close();
}
