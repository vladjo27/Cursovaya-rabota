using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ScooterRental;

public partial class ProfileForm : Form
{
    public ProfileForm()
    {
        InitializeComponent();
    }

    private void ProfileForm_Load(object sender, EventArgs e)
    {
        txtLogin.Text = CurrentUser.Login;
        txtFullName.Text = CurrentUser.FullName;
        txtPhone.Text = CurrentUser.Phone;
        txtEmail.Text = CurrentUser.Email;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        string fullName = txtFullName.Text.Trim();
        if (fullName == "")
        {
            MessageBox.Show("ФИО обязательно для заполнения.");
            return;
        }

        try
        {
            using OleDbConnection connection = DatabaseHelper.GetAuthConnection();
            DatabaseHelper.ExecuteNonQuery(connection,
                "UPDATE Users SET FullName = ?, Phone = ?, Email = ? WHERE UserID = ?",
                new OleDbParameter("@name", fullName),
                new OleDbParameter("@phone", txtPhone.Text.Trim()),
                new OleDbParameter("@email", txtEmail.Text.Trim()),
                new OleDbParameter("@id", CurrentUser.UserID));

            CurrentUser.FullName = fullName;
            CurrentUser.Phone = txtPhone.Text.Trim();
            CurrentUser.Email = txtEmail.Text.Trim();

            MessageBox.Show("Данные сохранены.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка сохранения профиля:\n" + ex.Message);
        }
    }

    private void btnChangePassword_Click(object sender, EventArgs e)
    {
        string oldPassword = txtOldPassword.Text;
        string newPassword = txtNewPassword.Text;

        if (oldPassword == "" || newPassword == "")
        {
            MessageBox.Show("Введите текущий и новый пароль.");
            return;
        }

        if (newPassword.Length < 4)
        {
            MessageBox.Show("Новый пароль должен содержать минимум 4 символа.");
            return;
        }

        try
        {
            if (!OldPasswordIsCorrect(oldPassword))
            {
                MessageBox.Show("Текущий пароль указан неверно.");
                return;
            }

            using OleDbConnection connection = DatabaseHelper.GetAuthConnection();
            DatabaseHelper.ExecuteNonQuery(connection,
                "UPDATE Users SET [Password] = ? WHERE UserID = ?",
                new OleDbParameter("@password", newPassword),
                new OleDbParameter("@id", CurrentUser.UserID));

            txtOldPassword.Clear();
            txtNewPassword.Clear();
            MessageBox.Show("Пароль изменён.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка изменения пароля:\n" + ex.Message);
        }
    }

    private static bool OldPasswordIsCorrect(string oldPassword)
    {
        using OleDbConnection connection = DatabaseHelper.GetAuthConnection();
        object? count = DatabaseHelper.ExecuteScalar(connection,
            "SELECT COUNT(*) FROM Users WHERE UserID = ? AND [Password] = ?",
            new OleDbParameter("@id", CurrentUser.UserID),
            new OleDbParameter("@password", oldPassword));

        return Convert.ToInt32(count) > 0;
    }
}
