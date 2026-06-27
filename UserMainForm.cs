using System;
using System.IO;
using System.Drawing;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ScooterRental;

public partial class UserMainForm : Form
{
    public UserMainForm()
    {
        InitializeComponent();
        LoadMainBackgroundImage();
    }

    private void UserMainForm_Load(object sender, EventArgs e)
    {
        lblWelcome.Text = CurrentUser.FullName;
        lblRole.Text = CurrentUser.IsAdmin ? "Администратор" : "Пользователь";
        LoadDashboardStats();
    }

    /// <summary>
    /// На главной показываем только самые нужные цифры пользователю.
    /// </summary>
    private void LoadDashboardStats()
    {
        try
        {
            using OleDbConnection connection = DatabaseHelper.GetMainConnection();

            lblCard1Value.Text = Count(connection,
                "SELECT COUNT(*) FROM Scooters WHERE [Status] = 'Available'");

            lblCard2Value.Text = Count(connection,
                "SELECT COUNT(*) FROM Rentals WHERE UserID = ? AND [Status] = 'Active'",
                new OleDbParameter("@user", CurrentUser.UserID));

            lblCard3Value.Text = Count(connection,
                "SELECT COUNT(*) FROM Rentals WHERE UserID = ?",
                new OleDbParameter("@user", CurrentUser.UserID));
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка загрузки статистики:\n" + ex.Message);
        }
    }

    private static string Count(OleDbConnection connection, string sql, params OleDbParameter[] parameters)
    {
        return DatabaseHelper.ExecuteScalar(connection, sql, parameters)?.ToString() ?? "0";
    }

    private void btnRentScooter_Click(object sender, EventArgs e)
    {
        using RentScooterForm form = new();
        form.ShowDialog(this);
        LoadDashboardStats();
    }

    private void btnMyRentals_Click(object sender, EventArgs e)
    {
        using MyRentalsForm form = new();
        form.ShowDialog(this);
        LoadDashboardStats();
    }

    private void btnProfile_Click(object sender, EventArgs e)
    {
        using ProfileForm form = new();
        form.ShowDialog(this);
        lblWelcome.Text = CurrentUser.FullName;
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            Close();
    }

    /// <summary>
    /// Загружает тематическую картинку самокатов как фон главной области.
    /// Файл должен лежать рядом с exe по пути Assets\scooter.png.
    /// </summary>
    private void LoadMainBackgroundImage()
    {
        try
        {
            string imagePath = Path.Combine(AppContext.BaseDirectory, "Assets", "scooter.png");

            if (File.Exists(imagePath))
            {
                panelContent.BackgroundImage = Image.FromFile(imagePath);
                panelContent.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }
        catch
        {
            // Если картинка не загрузилась, главная форма всё равно должна открыться.
        }
    }
}

