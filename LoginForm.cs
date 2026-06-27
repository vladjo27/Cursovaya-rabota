using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ScooterRental;

public partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        string login = txtLogin.Text.Trim();
        string password = txtPassword.Text.Trim();

        if (login == "" || password == "")
        {
            MessageBox.Show("Введите логин и пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            using OleDbConnection connection = DatabaseHelper.GetAuthConnection();
            DataTable users = DatabaseHelper.ExecuteQuery(connection,
                "SELECT UserID, [Login], FullName, Phone, Email, [Role], IsBlocked FROM Users WHERE [Login] = ? AND [Password] = ?",
                new OleDbParameter("@login", login),
                new OleDbParameter("@password", password));

            if (users.Rows.Count == 0)
            {
                MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow user = users.Rows[0];
            if (Convert.ToBoolean(user["IsBlocked"]))
            {
                MessageBox.Show("Ваш аккаунт заблокирован. Обратитесь к администратору.",
                    "Доступ запрещён", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            SaveCurrentUser(user);
            OpenMainForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка подключения к базе:\n" + ex.Message,
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// После успешного входа запоминаем пользователя в CurrentUser.
    /// </summary>
    private static void SaveCurrentUser(DataRow user)
    {
        CurrentUser.UserID = Convert.ToInt32(user["UserID"]);
        CurrentUser.Login = user["Login"].ToString() ?? "";
        CurrentUser.FullName = user["FullName"].ToString() ?? "";
        CurrentUser.Phone = user["Phone"]?.ToString() ?? "";
        CurrentUser.Email = user["Email"]?.ToString() ?? "";
        CurrentUser.Role = user["Role"].ToString() ?? "User";
    }

    private void OpenMainForm()
    {
        Hide();

        UserMainForm mainForm = new();
        mainForm.FormClosed += (_, _) =>
        {
            CurrentUser.Clear();
            txtPassword.Clear();
            Show();
        };

        mainForm.Show();
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        Hide();

        RegisterForm form = new();
        form.FormClosed += (_, _) => Show();
        form.Show();
    }

    private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
    {
        txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
    }
}
