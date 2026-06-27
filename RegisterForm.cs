using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ScooterAdmin;

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
        string confirm = txtConfirm.Text;
        string phone = txtPhone.Text.Trim();
        string email = txtEmail.Text.Trim();

        if (fullName == "" || login == "" || password == "")
        {
            MessageBox.Show("Заполните ФИО, логин и пароль.", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (login.Length < 3)
        {
            MessageBox.Show("Логин должен содержать минимум 3 символа.");
            return;
        }

        if (password.Length < 4)
        {
            MessageBox.Show("Пароль должен содержать минимум 4 символа.");
            return;
        }

        if (password != confirm)
        {
            MessageBox.Show("Пароли не совпадают.");
            return;
        }

        try
        {
            using OleDbConnection connection = DatabaseHelper.GetAuthConnection();

            int exists = Convert.ToInt32(DatabaseHelper.ExecuteScalar(connection,
                "SELECT COUNT(*) FROM Users WHERE [Login] = ?",
                new OleDbParameter("@login", login)));

            if (exists > 0)
            {
                MessageBox.Show("Такой логин уже занят.");
                return;
            }

            DatabaseHelper.ExecuteNonQuery(connection,
                @"INSERT INTO Users ([Login], [Password], FullName, Phone, Email, [Role], RegisterDate, IsBlocked)
                  VALUES (?, ?, ?, ?, ?, 'Admin', Now(), False)",
                new OleDbParameter("@login", login),
                new OleDbParameter("@password", password),
                new OleDbParameter("@fullName", fullName),
                new OleDbParameter("@phone", phone),
                new OleDbParameter("@email", email));

            MessageBox.Show("Администратор зарегистрирован. Теперь можно войти.",
                "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка регистрации:\n" + ex.Message,
                "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        Close();
    }
}
