using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ScooterAdmin;

public partial class EditUserCredentialsForm : Form
{
    private readonly int _userId;
    private readonly string _currentLogin;

    public EditUserCredentialsForm(int userId, string currentLogin)
    {
        InitializeComponent();
        _userId = userId;
        _currentLogin = currentLogin;
    }

    private void EditUserCredentialsForm_Load(object sender, EventArgs e)
    {
        txtLogin.Text = _currentLogin;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        string newLogin = txtLogin.Text.Trim();
        string newPassword = txtPassword.Text.Trim();
        string confirmPassword = txtConfirm.Text.Trim();

        if (!ValidateInput(newLogin, newPassword, confirmPassword))
            return;

        try
        {
            if (LoginIsBusy(newLogin))
            {
                MessageBox.Show("Такой логин уже занят.");
                return;
            }

            SaveCredentials(newLogin, newPassword);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Не удалось сохранить данные:\n" + ex.Message);
        }
    }

    private static bool ValidateInput(string login, string password, string confirmPassword)
    {
        if (login.Length < 3)
        {
            MessageBox.Show("Логин должен содержать минимум 3 символа.");
            return false;
        }

        if (password == "")
            return true;

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

    private bool LoginIsBusy(string login)
    {
        if (login.Equals(_currentLogin, StringComparison.OrdinalIgnoreCase))
            return false;

        using OleDbConnection connection = DatabaseHelper.GetAuthConnection();
        object? count = DatabaseHelper.ExecuteScalar(connection,
            "SELECT COUNT(*) FROM Users WHERE [Login] = ? AND UserID <> ?",
            new OleDbParameter("@login", login),
            new OleDbParameter("@id", _userId));

        return Convert.ToInt32(count) > 0;
    }

    private void SaveCredentials(string login, string password)
    {
        using OleDbConnection connection = DatabaseHelper.GetAuthConnection();

        if (password == "")
        {
            DatabaseHelper.ExecuteNonQuery(connection,
                "UPDATE Users SET [Login] = ? WHERE UserID = ?",
                new OleDbParameter("@login", login),
                new OleDbParameter("@id", _userId));
        }
        else
        {
            DatabaseHelper.ExecuteNonQuery(connection,
                "UPDATE Users SET [Login] = ?, [Password] = ? WHERE UserID = ?",
                new OleDbParameter("@login", login),
                new OleDbParameter("@password", password),
                new OleDbParameter("@id", _userId));
        }
    }

    private void btnCancel_Click(object sender, EventArgs e) => Close();
}
