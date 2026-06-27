using System;
using System.Windows.Forms;

namespace ScooterRental;

public partial class RentConfirmForm : Form
{
    private readonly string _scooterName;
    private readonly string _inventory;
    private readonly int _battery;
    private readonly string _location;
    private readonly decimal _pricePerHour;
    private readonly decimal _pricePerMinute;

    public int SelectedMinutes { get; private set; } = 30;

    public RentConfirmForm(string scooterName, string inventory, int battery, string location, decimal pricePerHour)
    {
        InitializeComponent();
        _scooterName = scooterName;
        _inventory = inventory;
        _battery = battery;
        _location = location;
        _pricePerHour = pricePerHour;
        _pricePerMinute = pricePerHour / 60m;
    }

    private void RentConfirmForm_Load(object sender, EventArgs e)
    {
        lblScooterName.Text = _scooterName;
        lblScooterDetails.Text = $"Инв: {_inventory}  |  Заряд: {_battery}%  |  {_location}\n" +
                                 $"Тариф: {_pricePerHour:N0} руб/час ({_pricePerMinute:N1} руб/мин)";
        RecalculateCost();
    }

    private void time_ValueChanged(object sender, EventArgs e) => RecalculateCost();

    private void SetTime(int hours, int minutes)
    {
        numHours.Value = hours;
        numMinutes.Value = minutes;
        RecalculateCost();
    }

    private void RecalculateCost()
    {
        int minutes = (int)numHours.Value * 60 + (int)numMinutes.Value;
        if (minutes < 5) minutes = 5;

        decimal cost = Math.Ceiling(_pricePerMinute * minutes);
        lblCostAmount.Text = $"{cost:N0} руб";
        lblCostCalc.Text = $"{minutes} мин × {_pricePerMinute:N1} руб/мин";
    }

    private void btn15_Click(object sender, EventArgs e) => SetTime(0, 15);
    private void btn30_Click(object sender, EventArgs e) => SetTime(0, 30);
    private void btn60_Click(object sender, EventArgs e) => SetTime(1, 0);
    private void btn120_Click(object sender, EventArgs e) => SetTime(2, 0);

    private void btnConfirm_Click(object sender, EventArgs e)
    {
        SelectedMinutes = (int)numHours.Value * 60 + (int)numMinutes.Value;

        if (SelectedMinutes < 5)
        {
            MessageBox.Show("Минимальное время аренды — 5 минут.");
            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e) => Close();
}
