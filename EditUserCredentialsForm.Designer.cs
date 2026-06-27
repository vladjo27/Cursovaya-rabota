namespace ScooterAdmin;

partial class EditUserCredentialsForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label lblLogin;
    private System.Windows.Forms.TextBox txtLogin;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Label lblConfirm;
    private System.Windows.Forms.TextBox txtConfirm;
    private System.Windows.Forms.Label lblHint;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblLogin = new System.Windows.Forms.Label();
        txtLogin = new System.Windows.Forms.TextBox();
        lblPassword = new System.Windows.Forms.Label();
        txtPassword = new System.Windows.Forms.TextBox();
        lblConfirm = new System.Windows.Forms.Label();
        txtConfirm = new System.Windows.Forms.TextBox();
        lblHint = new System.Windows.Forms.Label();
        btnSave = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        SuspendLayout();

        lblLogin.AutoSize = true; lblLogin.Location = new System.Drawing.Point(25, 25); lblLogin.Text = "Логин";
        txtLogin.Location = new System.Drawing.Point(25, 48); txtLogin.Size = new System.Drawing.Size(330, 23);
        lblPassword.AutoSize = true; lblPassword.Location = new System.Drawing.Point(25, 90); lblPassword.Text = "Новый пароль";
        txtPassword.Location = new System.Drawing.Point(25, 113); txtPassword.Size = new System.Drawing.Size(330, 23); txtPassword.UseSystemPasswordChar = true;
        lblConfirm.AutoSize = true; lblConfirm.Location = new System.Drawing.Point(25, 155); lblConfirm.Text = "Повтор пароля";
        txtConfirm.Location = new System.Drawing.Point(25, 178); txtConfirm.Size = new System.Drawing.Size(330, 23); txtConfirm.UseSystemPasswordChar = true;
        lblHint.ForeColor = System.Drawing.Color.Gray;
        lblHint.Location = new System.Drawing.Point(25, 215);
        lblHint.Size = new System.Drawing.Size(330, 30);
        lblHint.Text = "Оставьте пароль пустым, если менять его не нужно.";

        btnSave.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnSave.ForeColor = System.Drawing.Color.White;
        btnSave.Location = new System.Drawing.Point(25, 260);
        btnSave.Size = new System.Drawing.Size(155, 38);
        btnSave.Text = "Сохранить";
        btnSave.Click += btnSave_Click;
        btnCancel.Location = new System.Drawing.Point(200, 260);
        btnCancel.Size = new System.Drawing.Size(155, 38);
        btnCancel.Text = "Отмена";
        btnCancel.Click += btnCancel_Click;

        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.White;
        ClientSize = new System.Drawing.Size(380, 320);
        Controls.AddRange(new System.Windows.Forms.Control[] { lblLogin, txtLogin, lblPassword, txtPassword, lblConfirm, txtConfirm, lblHint, btnSave, btnCancel });
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Логин и пароль";
        Load += EditUserCredentialsForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }
}
