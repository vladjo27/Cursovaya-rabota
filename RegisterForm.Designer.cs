namespace ScooterAdmin;

partial class RegisterForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel panelTop;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblFullName;
    private System.Windows.Forms.TextBox txtFullName;
    private System.Windows.Forms.Label lblLogin;
    private System.Windows.Forms.TextBox txtLogin;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Label lblConfirm;
    private System.Windows.Forms.TextBox txtConfirm;
    private System.Windows.Forms.Label lblPhone;
    private System.Windows.Forms.TextBox txtPhone;
    private System.Windows.Forms.Label lblEmail;
    private System.Windows.Forms.TextBox txtEmail;
    private System.Windows.Forms.Button btnRegister;
    private System.Windows.Forms.Button btnCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        panelTop = new System.Windows.Forms.Panel();
        lblTitle = new System.Windows.Forms.Label();
        lblFullName = new System.Windows.Forms.Label();
        txtFullName = new System.Windows.Forms.TextBox();
        lblLogin = new System.Windows.Forms.Label();
        txtLogin = new System.Windows.Forms.TextBox();
        lblPassword = new System.Windows.Forms.Label();
        txtPassword = new System.Windows.Forms.TextBox();
        lblConfirm = new System.Windows.Forms.Label();
        txtConfirm = new System.Windows.Forms.TextBox();
        lblPhone = new System.Windows.Forms.Label();
        txtPhone = new System.Windows.Forms.TextBox();
        lblEmail = new System.Windows.Forms.Label();
        txtEmail = new System.Windows.Forms.TextBox();
        btnRegister = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        SuspendLayout();

        panelTop.BackColor = System.Drawing.Color.FromArgb(27, 38, 44);
        panelTop.Dock = System.Windows.Forms.DockStyle.Top;
        panelTop.Height = 60;

        lblTitle.AutoSize = true;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = System.Drawing.Color.FromArgb(255, 152, 0);
        lblTitle.Location = new System.Drawing.Point(20, 17);
        lblTitle.Text = "Регистрация администратора";
        panelTop.Controls.Add(lblTitle);

        int x = 30;
        int y = 82;
        int w = 340;
        int gap = 55;

        lblFullName.AutoSize = true;
        lblFullName.Location = new System.Drawing.Point(x, y);
        lblFullName.Text = "ФИО *";
        txtFullName.Location = new System.Drawing.Point(x, y + 22);
        txtFullName.Size = new System.Drawing.Size(w, 23);
        y += gap;

        lblLogin.AutoSize = true;
        lblLogin.Location = new System.Drawing.Point(x, y);
        lblLogin.Text = "Логин *";
        txtLogin.Location = new System.Drawing.Point(x, y + 22);
        txtLogin.Size = new System.Drawing.Size(w, 23);
        y += gap;

        lblPassword.AutoSize = true;
        lblPassword.Location = new System.Drawing.Point(x, y);
        lblPassword.Text = "Пароль *";
        txtPassword.Location = new System.Drawing.Point(x, y + 22);
        txtPassword.Size = new System.Drawing.Size(160, 23);
        txtPassword.UseSystemPasswordChar = true;

        lblConfirm.AutoSize = true;
        lblConfirm.Location = new System.Drawing.Point(x + 180, y);
        lblConfirm.Text = "Повтор *";
        txtConfirm.Location = new System.Drawing.Point(x + 180, y + 22);
        txtConfirm.Size = new System.Drawing.Size(160, 23);
        txtConfirm.UseSystemPasswordChar = true;
        y += gap;

        lblPhone.AutoSize = true;
        lblPhone.Location = new System.Drawing.Point(x, y);
        lblPhone.Text = "Телефон";
        txtPhone.Location = new System.Drawing.Point(x, y + 22);
        txtPhone.Size = new System.Drawing.Size(w, 23);
        y += gap;

        lblEmail.AutoSize = true;
        lblEmail.Location = new System.Drawing.Point(x, y);
        lblEmail.Text = "Email";
        txtEmail.Location = new System.Drawing.Point(x, y + 22);
        txtEmail.Size = new System.Drawing.Size(w, 23);
        y += gap + 8;

        btnRegister.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
        btnRegister.FlatAppearance.BorderSize = 0;
        btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnRegister.ForeColor = System.Drawing.Color.White;
        btnRegister.Location = new System.Drawing.Point(x, y);
        btnRegister.Size = new System.Drawing.Size(160, 38);
        btnRegister.Text = "Зарегистрировать";
        btnRegister.Click += btnRegister_Click;

        btnCancel.Location = new System.Drawing.Point(x + 180, y);
        btnCancel.Size = new System.Drawing.Size(160, 38);
        btnCancel.Text = "Отмена";
        btnCancel.Click += btnCancel_Click;

        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.White;
        ClientSize = new System.Drawing.Size(400, 440);
        Controls.Add(panelTop);
        Controls.Add(lblFullName);
        Controls.Add(txtFullName);
        Controls.Add(lblLogin);
        Controls.Add(txtLogin);
        Controls.Add(lblPassword);
        Controls.Add(txtPassword);
        Controls.Add(lblConfirm);
        Controls.Add(txtConfirm);
        Controls.Add(lblPhone);
        Controls.Add(txtPhone);
        Controls.Add(lblEmail);
        Controls.Add(txtEmail);
        Controls.Add(btnRegister);
        Controls.Add(btnCancel);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Регистрация администратора";
        ResumeLayout(false);
        PerformLayout();
    }
}
