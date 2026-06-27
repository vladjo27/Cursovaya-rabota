namespace ScooterAdmin;

partial class EditScooterStatusForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label lblStatus;
    private System.Windows.Forms.ComboBox cmbStatus;
    private System.Windows.Forms.Label lblLocation;
    private System.Windows.Forms.TextBox txtLocation;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblStatus = new System.Windows.Forms.Label();
        cmbStatus = new System.Windows.Forms.ComboBox();
        lblLocation = new System.Windows.Forms.Label();
        txtLocation = new System.Windows.Forms.TextBox();
        btnSave = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        SuspendLayout();

        lblStatus.AutoSize = true; lblStatus.Location = new System.Drawing.Point(20, 20); lblStatus.Text = "Статус";
        cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; cmbStatus.Location = new System.Drawing.Point(20, 43); cmbStatus.Size = new System.Drawing.Size(280, 23);
        lblLocation.AutoSize = true; lblLocation.Location = new System.Drawing.Point(20, 85); lblLocation.Text = "Локация";
        txtLocation.Location = new System.Drawing.Point(20, 108); txtLocation.Size = new System.Drawing.Size(280, 23);

        btnSave.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnSave.ForeColor = System.Drawing.Color.White;
        btnSave.Location = new System.Drawing.Point(20, 155);
        btnSave.Size = new System.Drawing.Size(130, 35);
        btnSave.Text = "Сохранить";
        btnSave.Click += btnSave_Click;
        btnCancel.Location = new System.Drawing.Point(170, 155);
        btnCancel.Size = new System.Drawing.Size(130, 35);
        btnCancel.Text = "Отмена";
        btnCancel.Click += btnCancel_Click;

        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.White;
        ClientSize = new System.Drawing.Size(325, 210);
        Controls.AddRange(new System.Windows.Forms.Control[] { lblStatus, cmbStatus, lblLocation, txtLocation, btnSave, btnCancel });
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Статус самоката";
        Load += EditScooterStatusForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }
}
