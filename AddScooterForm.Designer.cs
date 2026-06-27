namespace ScooterAdmin;

partial class AddScooterForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label lblModel;
    private System.Windows.Forms.ComboBox cmbModel;
    private System.Windows.Forms.Label lblInventory;
    private System.Windows.Forms.TextBox txtInventory;
    private System.Windows.Forms.Label lblLocation;
    private System.Windows.Forms.TextBox txtLocation;
    private System.Windows.Forms.Label lblBattery;
    private System.Windows.Forms.NumericUpDown numBattery;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblModel = new System.Windows.Forms.Label();
        cmbModel = new System.Windows.Forms.ComboBox();
        lblInventory = new System.Windows.Forms.Label();
        txtInventory = new System.Windows.Forms.TextBox();
        lblLocation = new System.Windows.Forms.Label();
        txtLocation = new System.Windows.Forms.TextBox();
        lblBattery = new System.Windows.Forms.Label();
        numBattery = new System.Windows.Forms.NumericUpDown();
        btnSave = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)numBattery).BeginInit();
        SuspendLayout();

        lblModel.AutoSize = true; lblModel.Location = new System.Drawing.Point(20, 20); lblModel.Text = "Модель";
        cmbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; cmbModel.Location = new System.Drawing.Point(20, 43); cmbModel.Size = new System.Drawing.Size(320, 23);
        lblInventory.AutoSize = true; lblInventory.Location = new System.Drawing.Point(20, 82); lblInventory.Text = "Инвентарный номер";
        txtInventory.Location = new System.Drawing.Point(20, 105); txtInventory.Size = new System.Drawing.Size(320, 23);
        lblLocation.AutoSize = true; lblLocation.Location = new System.Drawing.Point(20, 144); lblLocation.Text = "Локация";
        txtLocation.Location = new System.Drawing.Point(20, 167); txtLocation.Size = new System.Drawing.Size(320, 23);
        lblBattery.AutoSize = true; lblBattery.Location = new System.Drawing.Point(20, 206); lblBattery.Text = "Заряд, %";
        numBattery.Location = new System.Drawing.Point(20, 229); numBattery.Minimum = 0; numBattery.Maximum = 100; numBattery.Value = 100;

        btnSave.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnSave.ForeColor = System.Drawing.Color.White;
        btnSave.Location = new System.Drawing.Point(20, 275);
        btnSave.Size = new System.Drawing.Size(150, 36);
        btnSave.Text = "Сохранить";
        btnSave.Click += btnSave_Click;
        btnCancel.Location = new System.Drawing.Point(190, 275);
        btnCancel.Size = new System.Drawing.Size(150, 36);
        btnCancel.Text = "Отмена";
        btnCancel.Click += btnCancel_Click;

        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.White;
        ClientSize = new System.Drawing.Size(365, 330);
        Controls.AddRange(new System.Windows.Forms.Control[] { lblModel, cmbModel, lblInventory, txtInventory, lblLocation, txtLocation, lblBattery, numBattery, btnSave, btnCancel });
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Добавить самокат";
        Load += AddScooterForm_Load;
        ((System.ComponentModel.ISupportInitialize)numBattery).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
