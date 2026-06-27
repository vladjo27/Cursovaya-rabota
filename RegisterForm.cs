using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ScooterRental;

public partial class RegisterForm : Form
{
    public RegisterForm()
    {
        InitializeComponent();
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        string fullName = txtFullName.Text.Trim();
        string login = txtLogin.Text.Trim();
        string password = txtPassword.Text;
        string confirmPassword = txtPasswordConfirm.Text;

        if (!ValidateInput(fullName, login, password, confirmPassword))
            return;

        try
        {
            if (LoginExists(login))
            {
                MessageBox.Show("Логин уже занят.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CreateUser(fullName, login, password, txtPhone.Text.Trim(), txtEmail.Text.Trim());
            MessageBox.Show("Регистрация успешна. Теперь можно войти.",
                "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка регистрации:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Проверяем только очевидные ошибки ввода до обращения к базе.
    /// </summary>
    private static bool ValidateInput(string fullName, string login, string password, string confirmPassword)
    {
        if (fullName == "" || login == "" || password == "")
        {
            MessageBox.Show("Заполните ФИО, логин и пароль.");
            return false;
        }

        if (login.Length < 3)
        {
            MessageBox.Show("Логин должен содержать минимум 3 символа.");
            return false;
        }

        if (password.Length < 4)
        {
            MessageBox.Show("Пароль должен содержать минимум 4 символа.");
            return false;
        }

        if (password != confirmPassword)
        {
            MessageBox.Show("Пароли не совпадают.");
            return false;
        }

        return true;
    }

    private static bool LoginExists(string login)
    {
        using OleDbConnection connection = DatabaseHelper.GetAuthConnection();
        object? count = DatabaseHelper.ExecuteScalar(connection,
            "SELECT COUNT(*) FROM Users WHERE [Login] = ?",
            new OleDbParameter("@login", login));

        return Convert.ToInt32(count) > 0;
    }

    private static void CreateUser(string fullName, string login, string password, string phone, string email)
    {
        using OleDbConnection connection = DatabaseHelper.GetAuthConnection();
        DatabaseHelper.ExecuteNonQuery(connection,
            @"INSERT INTO Users ([Login], [Password], FullName, Phone, Email, [Role], RegisterDate, IsBlocked)
              VALUES (?, ?, ?, ?, ?, 'User', Now(), False)",
            new OleDbParameter("@login", login),
            new OleDbParameter("@password", password),
            new OleDbParameter("@fullName", fullName),
            new OleDbParameter("@phone", phone),
            new OleDbParameter("@email", email));
    }

    private void btnBack_Click(object sender, EventArgs e) => Close();
}
