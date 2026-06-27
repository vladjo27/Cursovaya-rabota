namespace ScooterAdmin;

partial class AssignRentalForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label lblUser;
    private System.Windows.Forms.ComboBox cmbUser;
    private System.Windows.Forms.Label lblScooter;
    private System.Windows.Forms.ComboBox cmbScooter;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblUser = new System.Windows.Forms.Label();
        cmbUser = new System.Windows.Forms.ComboBox();
        lblScooter = new System.Windows.Forms.Label();
        cmbScooter = new System.Windows.Forms.ComboBox();
        btnSave = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        SuspendLayout();

        lblUser.AutoSize = true; lblUser.Location = new System.Drawing.Point(20, 20); lblUser.Text = "Пользователь";
        cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; cmbUser.Location = new System.Drawing.Point(20, 43); cmbUser.Size = new System.Drawing.Size(370, 23);
        lblScooter.AutoSize = true; lblScooter.Location = new System.Drawing.Point(20, 85); lblScooter.Text = "Самокат";
        cmbScooter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; cmbScooter.Location = new System.Drawing.Point(20, 108); cmbScooter.Size = new System.Drawing.Size(370, 23);

        btnSave.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnSave.ForeColor = System.Drawing.Color.White;
        btnSave.Location = new System.Drawing.Point(20, 160);
        btnSave.Size = new System.Drawing.Size(175, 38);
        btnSave.Text = "Назначить";
        btnSave.Click += btnSave_Click;
        btnCancel.Location = new System.Drawing.Point(215, 160);
        btnCancel.Size = new System.Drawing.Size(175, 38);
        btnCancel.Text = "Отмена";
        btnCancel.Click += btnCancel_Click;

        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.White;
        ClientSize = new System.Drawing.Size(415, 220);
        Controls.AddRange(new System.Windows.Forms.Control[] { lblUser, cmbUser, lblScooter, cmbScooter, btnSave, btnCancel });
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Назначить аренду";
        Load += AssignRentalForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }
}
