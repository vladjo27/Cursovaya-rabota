using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ScooterRental;

public partial class ReturnScooterForm : Form
{
    private readonly int _scooterId;
    private readonly DateTime _startTime;
    private readonly string _scooterName;

    public decimal TotalCost { get; private set; }

    public ReturnScooterForm(int scooterId, DateTime startTime, string scooterName)
    {
        InitializeComponent();
        _scooterId = scooterId;
        _startTime = startTime;
        _scooterName = scooterName;
    }

    private void ReturnScooterForm_Load(object sender, EventArgs e)
    {
        try
        {
            decimal pricePerHour = GetPricePerHour();
            decimal pricePerMinute = pricePerHour / 60m;
            int totalMinutes = Math.Max((int)Math.Ceiling((DateTime.Now - _startTime).TotalMinutes), 5);
            TotalCost = Math.Ceiling(pricePerMinute * totalMinutes);

            lblTitle.Text = "Возврат самоката";
            lblScooterName.Text = _scooterName;
            lblDetails.Text =
                $"Начало: {_startTime:dd.MM.yyyy HH:mm}\n" +
                $"Сейчас: {DateTime.Now:dd.MM.yyyy HH:mm}\n" +
                $"Время: {totalMinutes / 60} ч {totalMinutes % 60} мин ({totalMinutes} мин)\n" +
                $"Тариф: {pricePerMinute:N1} руб/мин";
            lblTotal.Text = $"{TotalCost:N0} руб";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка расчёта оплаты:\n" + ex.Message);
            Close();
        }
    }

    private decimal GetPricePerHour()
    {
        using OleDbConnection connection = DatabaseHelper.GetMainConnection();

        // qryScooterPricePerHour хранится в ScooterDB.accdb.
        // Запрос принимает ScooterID и возвращает PricePerHour.
        object? value = DatabaseHelper.ExecuteScalarByName(
            connection,
            "qryScooterPricePerHour",
            new OleDbParameter("@pScooterID", _scooterId));

        return Convert.ToDecimal(value);
    }

    private void btnConfirm_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e) => Close();
}
