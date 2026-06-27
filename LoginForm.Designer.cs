namespace ScooterRental;

partial class LoginForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel panelMain;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblSubtitle;
    private System.Windows.Forms.Label lblLogin;
    private System.Windows.Forms.TextBox txtLogin;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.CheckBox chkShowPassword;
    private System.Windows.Forms.Button btnLogin;
    private System.Windows.Forms.Button btnRegister;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        panelMain = new System.Windows.Forms.Panel();
        lblTitle = new System.Windows.Forms.Label();
        lblSubtitle = new System.Windows.Forms.Label();
        lblLogin = new System.Windows.Forms.Label();
        txtLogin = new System.Windows.Forms.TextBox();
        lblPassword = new System.Windows.Forms.Label();
        txtPassword = new System.Windows.Forms.TextBox();
        chkShowPassword = new System.Windows.Forms.CheckBox();
        btnLogin = new System.Windows.Forms.Button();
        btnRegister = new System.Windows.Forms.Button();
        panelMain.SuspendLayout();
        SuspendLayout();

        panelMain.BackColor = System.Drawing.Color.White;
        panelMain.Location = new System.Drawing.Point(60, 40);
        panelMain.Size = new System.Drawing.Size(360, 430);

        lblTitle.AutoSize = true;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 150, 136);
        lblTitle.Location = new System.Drawing.Point(85, 25);
        lblTitle.Text = "ScooterGo";

        lblSubtitle.AutoSize = true;
        lblSubtitle.ForeColor = System.Drawing.Color.Gray;
        lblSubtitle.Location = new System.Drawing.Point(86, 72);
        lblSubtitle.Text = "Войдите в свой аккаунт";

        lblLogin.AutoSize = true;
        lblLogin.Location = new System.Drawing.Point(30, 120);
        lblLogin.Text = "Логин";
        txtLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtLogin.Font = new System.Drawing.Font("Segoe UI", 12F);
        txtLogin.Location = new System.Drawing.Point(30, 145);
        txtLogin.Size = new System.Drawing.Size(300, 29);

        lblPassword.AutoSize = true;
        lblPassword.Location = new System.Drawing.Point(30, 195);
        lblPassword.Text = "Пароль";
        txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
        txtPassword.Location = new System.Drawing.Point(30, 220);
        txtPassword.Size = new System.Drawing.Size(300, 29);
        txtPassword.UseSystemPasswordChar = true;

        chkShowPassword.AutoSize = true;
        chkShowPassword.ForeColor = System.Drawing.Color.Gray;
        chkShowPassword.Location = new System.Drawing.Point(30, 262);
        chkShowPassword.Text = "Показать пароль";
        chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;

        btnLogin.BackColor = System.Drawing.Color.FromArgb(0, 150, 136);
        btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
        btnLogin.FlatAppearance.BorderSize = 0;
        btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        btnLogin.ForeColor = System.Drawing.Color.White;
        btnLogin.Location = new System.Drawing.Point(30, 305);
        btnLogin.Size = new System.Drawing.Size(300, 48);
        btnLogin.Text = "Войти";
        btnLogin.Click += btnLogin_Click;

        btnRegister.BackColor = System.Drawing.Color.White;
        btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
        btnRegister.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 150, 136);
        btnRegister.FlatAppearance.BorderSize = 2;
        btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnRegister.ForeColor = System.Drawing.Color.FromArgb(0, 150, 136);
        btnRegister.Location = new System.Drawing.Point(30, 368);
        btnRegister.Size = new System.Drawing.Size(300, 42);
        btnRegister.Text = "Нет аккаунта? Зарегистрироваться";
        btnRegister.Click += btnRegister_Click;

        panelMain.Controls.AddRange(new System.Windows.Forms.Control[]
        {
            lblTitle, lblSubtitle, lblLogin, txtLogin, lblPassword, txtPassword, chkShowPassword, btnLogin, btnRegister
        });

        AcceptButton = btnLogin;
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(236, 239, 241);
        ClientSize = new System.Drawing.Size(480, 520);
        Controls.Add(panelMain);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "ScooterGo - Вход";
        panelMain.ResumeLayout(false);
        panelMain.PerformLayout();
        ResumeLayout(false);
    }
}
