namespace ScooterRental;

partial class RegisterForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel panelMain;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblFullName;
    private System.Windows.Forms.TextBox txtFullName;
    private System.Windows.Forms.Label lblLogin;
    private System.Windows.Forms.TextBox txtLogin;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Label lblPasswordConfirm;
    private System.Windows.Forms.TextBox txtPasswordConfirm;
    private System.Windows.Forms.Label lblPhone;
    private System.Windows.Forms.TextBox txtPhone;
    private System.Windows.Forms.Label lblEmail;
    private System.Windows.Forms.TextBox txtEmail;
    private System.Windows.Forms.Button btnRegister;
    private System.Windows.Forms.Button btnBack;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        panelMain = new System.Windows.Forms.Panel();
        lblTitle = new System.Windows.Forms.Label();
        lblFullName = new System.Windows.Forms.Label();
        txtFullName = new System.Windows.Forms.TextBox();
        lblLogin = new System.Windows.Forms.Label();
        txtLogin = new System.Windows.Forms.TextBox();
        lblPassword = new System.Windows.Forms.Label();
        txtPassword = new System.Windows.Forms.TextBox();
        lblPasswordConfirm = new System.Windows.Forms.Label();
        txtPasswordConfirm = new System.Windows.Forms.TextBox();
        lblPhone = new System.Windows.Forms.Label();
        txtPhone = new System.Windows.Forms.TextBox();
        lblEmail = new System.Windows.Forms.Label();
        txtEmail = new System.Windows.Forms.TextBox();
        btnRegister = new System.Windows.Forms.Button();
        btnBack = new System.Windows.Forms.Button();
        panelMain.SuspendLayout();
        SuspendLayout();

        panelMain.BackColor = System.Drawing.Color.White;
        panelMain.Location = new System.Drawing.Point(40, 15);
        panelMain.Size = new System.Drawing.Size(400, 480);

        lblTitle.AutoSize = true;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 150, 136);
        lblTitle.Location = new System.Drawing.Point(105, 12);
        lblTitle.Text = "Регистрация";

        lblFullName.AutoSize = true; lblFullName.Location = new System.Drawing.Point(30, 55); lblFullName.Text = "ФИО *";
        txtFullName.Location = new System.Drawing.Point(30, 78); txtFullName.Size = new System.Drawing.Size(340, 23);
        lblLogin.AutoSize = true; lblLogin.Location = new System.Drawing.Point(30, 112); lblLogin.Text = "Логин *";
        txtLogin.Location = new System.Drawing.Point(30, 135); txtLogin.Size = new System.Drawing.Size(340, 23);
        lblPassword.AutoSize = true; lblPassword.Location = new System.Drawing.Point(30, 170); lblPassword.Text = "Пароль *";
        txtPassword.Location = new System.Drawing.Point(30, 193); txtPassword.Size = new System.Drawing.Size(340, 23); txtPassword.UseSystemPasswordChar = true;
        lblPasswordConfirm.AutoSize = true; lblPasswordConfirm.Location = new System.Drawing.Point(30, 228); lblPasswordConfirm.Text = "Повтор пароля *";
        txtPasswordConfirm.Location = new System.Drawing.Point(30, 251); txtPasswordConfirm.Size = new System.Drawing.Size(340, 23); txtPasswordConfirm.UseSystemPasswordChar = true;
        lblPhone.AutoSize = true; lblPhone.Location = new System.Drawing.Point(30, 286); lblPhone.Text = "Телефон";
        txtPhone.Location = new System.Drawing.Point(30, 309); txtPhone.Size = new System.Drawing.Size(340, 23);
        lblEmail.AutoSize = true; lblEmail.Location = new System.Drawing.Point(30, 344); lblEmail.Text = "Email";
        txtEmail.Location = new System.Drawing.Point(30, 367); txtEmail.Size = new System.Drawing.Size(340, 23);

        btnRegister.BackColor = System.Drawing.Color.FromArgb(0, 150, 136);
        btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
        btnRegister.FlatAppearance.BorderSize = 0;
        btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnRegister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btnRegister.ForeColor = System.Drawing.Color.White;
        btnRegister.Location = new System.Drawing.Point(30, 415);
        btnRegister.Size = new System.Drawing.Size(165, 40);
        btnRegister.Text = "Зарегистрироваться";
        btnRegister.Click += btnRegister_Click;

        btnBack.BackColor = System.Drawing.Color.White;
        btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
        btnBack.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
        btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnBack.ForeColor = System.Drawing.Color.Gray;
        btnBack.Location = new System.Drawing.Point(205, 415);
        btnBack.Size = new System.Drawing.Size(165, 40);
        btnBack.Text = "Назад";
        btnBack.Click += btnBack_Click;

        panelMain.Controls.AddRange(new System.Windows.Forms.Control[]
        {
            lblTitle, lblFullName, txtFullName, lblLogin, txtLogin, lblPassword, txtPassword,
            lblPasswordConfirm, txtPasswordConfirm, lblPhone, txtPhone, lblEmail, txtEmail, btnRegister, btnBack
        });

        AcceptButton = btnRegister;
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(236, 239, 241);
        ClientSize = new System.Drawing.Size(480, 520);
        Controls.Add(panelMain);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "ScooterGo - Регистрация";
        panelMain.ResumeLayout(false);
        panelMain.PerformLayout();
        ResumeLayout(false);
    }
}
