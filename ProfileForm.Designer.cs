namespace ScooterRental;

partial class ProfileForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel panelMain;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblLogin;
    private System.Windows.Forms.TextBox txtLogin;
    private System.Windows.Forms.Label lblFullName;
    private System.Windows.Forms.TextBox txtFullName;
    private System.Windows.Forms.Label lblPhone;
    private System.Windows.Forms.TextBox txtPhone;
    private System.Windows.Forms.Label lblEmail;
    private System.Windows.Forms.TextBox txtEmail;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.GroupBox grpPassword;
    private System.Windows.Forms.Label lblOldPassword;
    private System.Windows.Forms.TextBox txtOldPassword;
    private System.Windows.Forms.Label lblNewPassword;
    private System.Windows.Forms.TextBox txtNewPassword;
    private System.Windows.Forms.Button btnChangePassword;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        panelMain = new System.Windows.Forms.Panel();
        lblTitle = new System.Windows.Forms.Label();
        lblLogin = new System.Windows.Forms.Label();
        txtLogin = new System.Windows.Forms.TextBox();
        lblFullName = new System.Windows.Forms.Label();
        txtFullName = new System.Windows.Forms.TextBox();
        lblPhone = new System.Windows.Forms.Label();
        txtPhone = new System.Windows.Forms.TextBox();
        lblEmail = new System.Windows.Forms.Label();
        txtEmail = new System.Windows.Forms.TextBox();
        btnSave = new System.Windows.Forms.Button();
        grpPassword = new System.Windows.Forms.GroupBox();
        lblOldPassword = new System.Windows.Forms.Label();
        txtOldPassword = new System.Windows.Forms.TextBox();
        lblNewPassword = new System.Windows.Forms.Label();
        txtNewPassword = new System.Windows.Forms.TextBox();
        btnChangePassword = new System.Windows.Forms.Button();
        panelMain.SuspendLayout();
        grpPassword.SuspendLayout();
        SuspendLayout();

        panelMain.BackColor = System.Drawing.Color.White;
        panelMain.Location = new System.Drawing.Point(30, 15);
        panelMain.Size = new System.Drawing.Size(400, 525);

        lblTitle.AutoSize = true;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 150, 136);
        lblTitle.Location = new System.Drawing.Point(110, 12);
        lblTitle.Text = "Мой профиль";

        lblLogin.AutoSize = true; lblLogin.Location = new System.Drawing.Point(25, 55); lblLogin.Text = "Логин";
        txtLogin.BackColor = System.Drawing.Color.FromArgb(240, 240, 240); txtLogin.Location = new System.Drawing.Point(25, 78); txtLogin.ReadOnly = true; txtLogin.Size = new System.Drawing.Size(350, 23);
        lblFullName.AutoSize = true; lblFullName.Location = new System.Drawing.Point(25, 115); lblFullName.Text = "ФИО";
        txtFullName.Location = new System.Drawing.Point(25, 138); txtFullName.Size = new System.Drawing.Size(350, 23);
        lblPhone.AutoSize = true; lblPhone.Location = new System.Drawing.Point(25, 175); lblPhone.Text = "Телефон";
        txtPhone.Location = new System.Drawing.Point(25, 198); txtPhone.Size = new System.Drawing.Size(350, 23);
        lblEmail.AutoSize = true; lblEmail.Location = new System.Drawing.Point(25, 235); lblEmail.Text = "Email";
        txtEmail.Location = new System.Drawing.Point(25, 258); txtEmail.Size = new System.Drawing.Size(350, 23);

        btnSave.BackColor = System.Drawing.Color.FromArgb(0, 150, 136);
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnSave.ForeColor = System.Drawing.Color.White;
        btnSave.Location = new System.Drawing.Point(25, 300);
        btnSave.Size = new System.Drawing.Size(350, 38);
        btnSave.Text = "Сохранить изменения";
        btnSave.Click += btnSave_Click;

        grpPassword.Location = new System.Drawing.Point(25, 355);
        grpPassword.Size = new System.Drawing.Size(350, 145);
        grpPassword.Text = "Смена пароля";
        lblOldPassword.AutoSize = true; lblOldPassword.Location = new System.Drawing.Point(12, 28); lblOldPassword.Text = "Текущий";
        txtOldPassword.Location = new System.Drawing.Point(12, 52); txtOldPassword.Size = new System.Drawing.Size(150, 23); txtOldPassword.UseSystemPasswordChar = true;
        lblNewPassword.AutoSize = true; lblNewPassword.Location = new System.Drawing.Point(178, 28); lblNewPassword.Text = "Новый";
        txtNewPassword.Location = new System.Drawing.Point(178, 52); txtNewPassword.Size = new System.Drawing.Size(155, 23); txtNewPassword.UseSystemPasswordChar = true;
        btnChangePassword.BackColor = System.Drawing.Color.FromArgb(63, 81, 181);
        btnChangePassword.FlatAppearance.BorderSize = 0;
        btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnChangePassword.ForeColor = System.Drawing.Color.White;
        btnChangePassword.Location = new System.Drawing.Point(12, 92);
        btnChangePassword.Size = new System.Drawing.Size(321, 35);
        btnChangePassword.Text = "Изменить пароль";
        btnChangePassword.Click += btnChangePassword_Click;
        grpPassword.Controls.AddRange(new System.Windows.Forms.Control[] { lblOldPassword, txtOldPassword, lblNewPassword, txtNewPassword, btnChangePassword });

        panelMain.Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, lblLogin, txtLogin, lblFullName, txtFullName, lblPhone, txtPhone, lblEmail, txtEmail, btnSave, grpPassword });

        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(236, 239, 241);
        ClientSize = new System.Drawing.Size(460, 558);
        Controls.Add(panelMain);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Профиль";
        Load += ProfileForm_Load;
        grpPassword.ResumeLayout(false);
        grpPassword.PerformLayout();
        panelMain.ResumeLayout(false);
        panelMain.PerformLayout();
        ResumeLayout(false);
    }
}
