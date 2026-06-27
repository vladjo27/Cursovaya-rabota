using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ScooterAdmin;

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
                "SELECT UserID, [Login], FullName, [Role], IsBlocked FROM Users WHERE [Login] = ? AND [Password] = ?",
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
                MessageBox.Show("Аккаунт заблокирован.", "Доступ запрещён", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string role = user["Role"].ToString() ?? "";
            if (!role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Вход разрешён только администраторам.", "Доступ запрещён", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            CurrentAdmin.UserID = Convert.ToInt32(user["UserID"]);
            CurrentAdmin.Login = user["Login"].ToString() ?? "";
            CurrentAdmin.FullName = user["FullName"].ToString() ?? "";
            CurrentAdmin.Role = role;

            OpenAdminPanel();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка подключения к базе:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void OpenAdminPanel()
    {
        Hide();

        AdminMainForm mainForm = new();
        mainForm.FormClosed += (_, _) =>
        {
            CurrentAdmin.Clear();
            txtPassword.Clear();
            Show();
        };

        mainForm.Show();
    }

    private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
