using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ScooterAdmin;

public partial class CompleteRentalForm : Form
{
    private readonly int _rentalId;
    private readonly int _scooterId;
    private readonly int _userId;
    private readonly DateTime _startTime;
    private readonly string _scooterName;

    private int _totalMinutes;
    private decimal _pricePerMinute;

    public CompleteRentalForm(int rentalId, int scooterId, int userId, DateTime startTime, string scooterName)
    {
        InitializeComponent();
        _rentalId = rentalId;
        _scooterId = scooterId;
        _userId = userId;
        _startTime = startTime;
        _scooterName = scooterName;
    }

    private void CompleteRentalForm_Load(object sender, EventArgs e)
    {
        try
        {
            using OleDbConnection connection = DatabaseHelper.GetMainConnection();
            object? price = DatabaseHelper.ExecuteScalar(connection,
                @"SELECT m.PricePerHour
                  FROM Scooters s INNER JOIN ScooterModels m ON s.ModelID = m.ModelID
                  WHERE s.ScooterID = ?",
                new OleDbParameter("@scooter", _scooterId));

            decimal pricePerHour = Convert.ToDecimal(price);
            _pricePerMinute = pricePerHour / 60m;
            _totalMinutes = Math.Max((int)Math.Ceiling((DateTime.Now - _startTime).TotalMinutes), 5);

            decimal amount = Math.Ceiling(_pricePerMinute * _totalMinutes);
            numAmount.Value = Math.Min(numAmount.Maximum, amount);

            lblInfo.Text =
                $"Самокат: {_scooterName}\n" +
                $"UserID: {_userId}\n" +
                $"Время: {_totalMinutes / 60} ч {_totalMinutes % 60} мин\n" +
                $"Тариф: {_pricePerMinute:N1} руб/мин";

            cmbPaymentMethod.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка расчёта аренды:\n" + ex.Message);
            Close();
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        decimal finalAmount = numAmount.Value;
        string method = cmbPaymentMethod.SelectedItem?.ToString() ?? "Карта";

        try
        {
            using OleDbConnection connection = DatabaseHelper.GetMainConnection();
            connection.Open();

            DatabaseHelper.ExecuteNonQuery(connection,
                "UPDATE Rentals SET EndTime = Now(), TotalCost = ?, [Status] = 'Completed' WHERE RentalID = ?",
                new OleDbParameter("@amount", finalAmount),
                new OleDbParameter("@rental", _rentalId));

            if (finalAmount > 0)
            {
                DatabaseHelper.ExecuteNonQuery(connection,
                    "INSERT INTO Payments (RentalID, Amount, PaymentDate, PaymentMethod) VALUES (?, ?, Now(), ?)",
                    new OleDbParameter("@rental", _rentalId),
                    new OleDbParameter("@amount", finalAmount),
                    new OleDbParameter("@method", method));
            }

            DatabaseHelper.ExecuteNonQuery(connection,
                "UPDATE Scooters SET [Status] = 'Available' WHERE ScooterID = ?",
                new OleDbParameter("@scooter", _scooterId));

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Не удалось завершить аренду:\n" + ex.Message);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e) => Close();
}
