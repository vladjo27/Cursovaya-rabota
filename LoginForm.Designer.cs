namespace ScooterAdmin;

partial class LoginForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel panelMain;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblHint;
    private System.Windows.Forms.Label lblLogin;
    private System.Windows.Forms.TextBox txtLogin;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.CheckBox chkShowPassword;
    private System.Windows.Forms.Button btnLogin;
    private System.Windows.Forms.LinkLabel lnkRegister;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        panelMain = new System.Windows.Forms.Panel();
        lblTitle = new System.Windows.Forms.Label();
        lblHint = new System.Windows.Forms.Label();
        lblLogin = new System.Windows.Forms.Label();
        txtLogin = new System.Windows.Forms.TextBox();
        lblPassword = new System.Windows.Forms.Label();
        txtPassword = new System.Windows.Forms.TextBox();
        chkShowPassword = new System.Windows.Forms.CheckBox();
        btnLogin = new System.Windows.Forms.Button();
        lnkRegister = new System.Windows.Forms.LinkLabel();
        panelMain.SuspendLayout();
        SuspendLayout();

        panelMain.BackColor = System.Drawing.Color.White;
        panelMain.Location = new System.Drawing.Point(50, 35);
        panelMain.Size = new System.Drawing.Size(370, 430);

        lblTitle.AutoSize = true;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = System.Drawing.Color.FromArgb(255, 152, 0);
        lblTitle.Location = new System.Drawing.Point(42, 25);
        lblTitle.Text = "ScooterGo ADMIN";

        lblHint.BackColor = System.Drawing.Color.FromArgb(198, 40, 40);
        lblHint.ForeColor = System.Drawing.Color.White;
        lblHint.Location = new System.Drawing.Point(35, 88);
        lblHint.Size = new System.Drawing.Size(300, 32);
        lblHint.Text = "  Вход только для роли Admin";
        lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        lblLogin.AutoSize = true;
        lblLogin.Font = new System.Drawing.Font("Segoe UI", 10F);
        lblLogin.Location = new System.Drawing.Point(35, 145);
        lblLogin.Text = "Логин";

        txtLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtLogin.Font = new System.Drawing.Font("Segoe UI", 12F);
        txtLogin.Location = new System.Drawing.Point(35, 170);
        txtLogin.Size = new System.Drawing.Size(300, 29);

        lblPassword.AutoSize = true;
        lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
        lblPassword.Location = new System.Drawing.Point(35, 218);
        lblPassword.Text = "Пароль";

        txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
        txtPassword.Location = new System.Drawing.Point(35, 243);
        txtPassword.Size = new System.Drawing.Size(300, 29);
        txtPassword.UseSystemPasswordChar = true;

        chkShowPassword.AutoSize = true;
        chkShowPassword.ForeColor = System.Drawing.Color.Gray;
        chkShowPassword.Location = new System.Drawing.Point(35, 285);
        chkShowPassword.Text = "Показать пароль";
        chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;

        btnLogin.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);
        btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
        btnLogin.FlatAppearance.BorderSize = 0;
        btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        btnLogin.ForeColor = System.Drawing.Color.White;
        btnLogin.Location = new System.Drawing.Point(35, 325);
        btnLogin.Size = new System.Drawing.Size(300, 48);
        btnLogin.Text = "Войти";
        btnLogin.Click += btnLogin_Click;

        lnkRegister.AutoSize = true;
        lnkRegister.Font = new System.Drawing.Font("Segoe UI", 10F);
        lnkRegister.LinkColor = System.Drawing.Color.FromArgb(0, 150, 136);
        lnkRegister.Location = new System.Drawing.Point(35, 388);
        lnkRegister.Text = "Зарегистрировать администратора";
        lnkRegister.LinkClicked += lnkRegister_LinkClicked;

        panelMain.Controls.Add(lblTitle);
        panelMain.Controls.Add(lblHint);
        panelMain.Controls.Add(lblLogin);
        panelMain.Controls.Add(txtLogin);
        panelMain.Controls.Add(lblPassword);
        panelMain.Controls.Add(txtPassword);
        panelMain.Controls.Add(chkShowPassword);
        panelMain.Controls.Add(btnLogin);
        panelMain.Controls.Add(lnkRegister);

        AcceptButton = btnLogin;
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(27, 38, 44);
        ClientSize = new System.Drawing.Size(470, 500);
        Controls.Add(panelMain);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "ScooterAdmin - Вход";
        panelMain.ResumeLayout(false);
        panelMain.PerformLayout();
        ResumeLayout(false);
    }
}
