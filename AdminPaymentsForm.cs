using System;
using System.Data;
using System.Windows.Forms;

namespace ScooterAdmin;

public partial class AdminPaymentsForm : Form
{
    public AdminPaymentsForm()
    {
        InitializeComponent();
    }

    private void AdminPaymentsForm_Load(object sender, EventArgs e) => LoadPayments();

    private void LoadPayments()
    {
        try
        {
            using var connection = DatabaseHelper.GetMainConnection();

            // qryAdminAllPayments хранится в ScooterDB.accdb.
            // Запрос показывает историю всех платежей.
            DataTable payments = DatabaseHelper.ExecuteQueryByName(connection, "qryAdminAllPayments");

            dgvPayments.DataSource = payments;
            RenameColumns();

            object? total = DatabaseHelper.ExecuteScalar(connection, "SELECT SUM(Amount) FROM Payments");
            decimal revenue = total == null || total == DBNull.Value ? 0 : Convert.ToDecimal(total);
            lblTotal.Text = $"Общая выручка: {revenue:N0} руб";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка загрузки платежей:\n" + ex.Message);
        }
    }

    private void RenameColumns()
    {
        if (dgvPayments.Columns.Contains("PaymentID")) dgvPayments.Columns["PaymentID"].Visible = false;
        if (dgvPayments.Columns.Contains("RentalID")) dgvPayments.Columns["RentalID"].HeaderText = "ID аренды";
        if (dgvPayments.Columns.Contains("Amount")) dgvPayments.Columns["Amount"].HeaderText = "Сумма";
        if (dgvPayments.Columns.Contains("PaymentDate")) dgvPayments.Columns["PaymentDate"].HeaderText = "Дата";
        if (dgvPayments.Columns.Contains("PaymentMethod")) dgvPayments.Columns["PaymentMethod"].HeaderText = "Способ";
    }
}
