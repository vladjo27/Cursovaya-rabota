using System;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ScooterAdmin;

public partial class AdminMainForm : Form
{
    public AdminMainForm()
    {
        InitializeComponent();
        LoadMainBackgroundImage();
        LoadScooterImage();
    }

    private void AdminMainForm_Load(object sender, EventArgs e)
    {
        lblWelcome.Text = CurrentAdmin.FullName;
        LoadDashboard();
    }

    /// <summary>
    /// Загружает тематическую картинку самоката на главную форму.
    /// Файл должен лежать рядом с exe по пути Assets\scooter.png.
    /// </summary>
    private void LoadScooterImage()
    {
        try
        {
            string imagePath = Path.Combine(AppContext.BaseDirectory, "Assets", "scooter.png");

            if (File.Exists(imagePath))
                panelContent.BackgroundImage = Image.FromFile(imagePath);
                panelContent.BackgroundImageLayout = ImageLayout.Stretch;
        }
        catch
        {
            // Если картинка не загрузилась, админ-панель всё равно должна открыться.
        }
    }

    /// <summary>
    /// Загружает короткую статистику для главной страницы администратора.
    /// </summary>
    private void LoadDashboard()
    {
        try
        {
            using OleDbConnection main = DatabaseHelper.GetMainConnection();
            using OleDbConnection auth = DatabaseHelper.GetAuthConnection();

            lblScootersTotal.Text = Count(main, "SELECT COUNT(*) FROM Scooters");
            lblScootersAvailable.Text = Count(main, "SELECT COUNT(*) FROM Scooters WHERE [Status] = 'Available'");
            lblScootersRented.Text = Count(main, "SELECT COUNT(*) FROM Scooters WHERE [Status] = 'Rented'");
            lblScootersRepair.Text = Count(main, "SELECT COUNT(*) FROM Scooters WHERE [Status] = 'InRepair'");
            lblUsersTotal.Text = Count(auth, "SELECT COUNT(*) FROM Users");

            object? revenue = DatabaseHelper.ExecuteScalar(main, "SELECT SUM(Amount) FROM Payments");
            lblRevenue.Text = revenue == null || revenue == DBNull.Value ? "0" : $"{Convert.ToDecimal(revenue):N0}";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Не удалось загрузить статистику:\n" + ex.Message);
        }
    }

    private static string Count(OleDbConnection connection, string sql)
    {
        return DatabaseHelper.ExecuteScalar(connection, sql)?.ToString() ?? "0";
    }

    private void OpenModal(Form form)
    {
        using (form)
        {
            form.ShowDialog(this);
        }

        LoadDashboard();
    }

    private void btnDashboard_Click(object sender, EventArgs e) => LoadDashboard();
    private void btnScooters_Click(object sender, EventArgs e) => OpenModal(new AdminScootersForm());
    private void btnModels_Click(object sender, EventArgs e) => OpenModal(new AdminModelsForm());
    private void btnRentals_Click(object sender, EventArgs e) => OpenModal(new AdminRentalsForm());
    private void btnUsers_Click(object sender, EventArgs e) => OpenModal(new AdminUsersForm());
    private void btnPayments_Click(object sender, EventArgs e) => OpenModal(new AdminPaymentsForm());

    private void btnLogout_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Выйти из админ-панели?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            Close();
    }

    /// <summary>
    /// Загружает картинку самокатов как фон главной области.
    /// Файл должен лежать рядом с exe по пути Assets\\scooter.png.
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
            // Если картинка не загрузилась, форма всё равно должна открыться.
        }
    }
}


