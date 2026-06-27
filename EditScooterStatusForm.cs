using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ScooterAdmin;

public partial class EditScooterStatusForm : Form
{
    private readonly int _scooterId;
    private readonly string _status;
    private readonly string _location;

    public EditScooterStatusForm(int scooterId, string status, string location)
    {
        InitializeComponent();
        _scooterId = scooterId;
        _status = status;
        _location = location;
    }

    private void EditScooterStatusForm_Load(object sender, EventArgs e)
    {
        cmbStatus.Items.AddRange(new object[] { "Available", "Rented", "InRepair" });
        cmbStatus.SelectedItem = _status;
        if (cmbStatus.SelectedIndex < 0) cmbStatus.SelectedIndex = 0;
        txtLocation.Text = _location;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            using OleDbConnection connection = DatabaseHelper.GetMainConnection();
            DatabaseHelper.ExecuteNonQuery(connection,
                "UPDATE Scooters SET [Status] = ?, [Location] = ? WHERE ScooterID = ?",
                new OleDbParameter("@status", cmbStatus.SelectedItem?.ToString() ?? "Available"),
                new OleDbParameter("@location", txtLocation.Text.Trim()),
                new OleDbParameter("@id", _scooterId));

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Не удалось обновить самокат:\n" + ex.Message);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e) => Close();
}
