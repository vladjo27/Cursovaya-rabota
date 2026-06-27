using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ScooterAdmin;

public partial class AdminUsersForm : Form
{
    public AdminUsersForm()
    {
        InitializeComponent();
    }

    private void AdminUsersForm_Load(object sender, EventArgs e) => LoadUsers();

    private void LoadUsers()
    {
        try
        {
            using OleDbConnection connection = DatabaseHelper.GetAuthConnection();
            DataTable users = DatabaseHelper.ExecuteQuery(connection,
                "SELECT UserID, [Login], FullName, Phone, Email, [Role], RegisterDate, IsBlocked FROM Users ORDER BY UserID");

            dgvUsers.DataSource = users;
            RenameColumns();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка загрузки пользователей:\n" + ex.Message);
        }
    }

    private void RenameColumns()
    {
        if (dgvUsers.Columns.Contains("UserID")) dgvUsers.Columns["UserID"].Visible = false;
        if (dgvUsers.Columns.Contains("Login")) dgvUsers.Columns["Login"].HeaderText = "Логин";
        if (dgvUsers.Columns.Contains("FullName")) dgvUsers.Columns["FullName"].HeaderText = "ФИО";
        if (dgvUsers.Columns.Contains("Phone")) dgvUsers.Columns["Phone"].HeaderText = "Телефон";
        if (dgvUsers.Columns.Contains("Email")) dgvUsers.Columns["Email"].HeaderText = "Email";
        if (dgvUsers.Columns.Contains("Role")) dgvUsers.Columns["Role"].HeaderText = "Роль";
        if (dgvUsers.Columns.Contains("RegisterDate")) dgvUsers.Columns["RegisterDate"].HeaderText = "Дата регистрации";
        if (dgvUsers.Columns.Contains("IsBlocked")) dgvUsers.Columns["IsBlocked"].HeaderText = "Заблокирован";
    }

    private int GetSelectedUserId()
    {
        if (dgvUsers.SelectedRows.Count == 0)
        {
            MessageBox.Show("Выберите пользователя.");
            return -1;
        }

        int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);
        if (userId == CurrentAdmin.UserID)
        {
            MessageBox.Show("Нельзя изменять свою учётную запись из этого списка.");
            return -1;
        }

        return userId;
    }

    private void UpdateUser(string sql, string successMessage)
    {
        int userId = GetSelectedUserId();
        if (userId < 0) return;

        try
        {
            using OleDbConnection connection = DatabaseHelper.GetAuthConnection();
            DatabaseHelper.ExecuteNonQuery(connection, sql, new OleDbParameter("@id", userId));
            MessageBox.Show(successMessage);
            LoadUsers();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка изменения пользователя:\n" + ex.Message);
        }
    }

    private void btnBlock_Click(object sender, EventArgs e) => UpdateUser("UPDATE Users SET IsBlocked = True WHERE UserID = ?", "Пользователь заблокирован.");
    private void btnUnblock_Click(object sender, EventArgs e) => UpdateUser("UPDATE Users SET IsBlocked = False WHERE UserID = ?", "Пользователь разблокирован.");
    private void btnMakeAdmin_Click(object sender, EventArgs e) => UpdateUser("UPDATE Users SET [Role] = 'Admin' WHERE UserID = ?", "Назначена роль Admin.");
    private void btnMakeUser_Click(object sender, EventArgs e) => UpdateUser("UPDATE Users SET [Role] = 'User' WHERE UserID = ?", "Назначена роль User.");

    private void btnEditCredentials_Click(object sender, EventArgs e)
    {
        int userId = GetSelectedUserId();
        if (userId < 0) return;

        string login = dgvUsers.SelectedRows[0].Cells["Login"].Value?.ToString() ?? "";
        using EditUserCredentialsForm form = new(userId, login);
        if (form.ShowDialog(this) == DialogResult.OK)
            LoadUsers();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        int userId = GetSelectedUserId();
        if (userId < 0) return;

        if (MessageBox.Show("Удалить пользователя?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            return;

        try
        {
            using OleDbConnection connection = DatabaseHelper.GetAuthConnection();
            DatabaseHelper.ExecuteNonQuery(connection,
                "DELETE FROM Users WHERE UserID = ?",
                new OleDbParameter("@id", userId));

            LoadUsers();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Не удалось удалить пользователя:\n" + ex.Message);
        }
    }
}
