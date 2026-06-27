namespace ScooterAdmin;

partial class AddModelForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label lblBrand;
    private System.Windows.Forms.TextBox txtBrand;
    private System.Windows.Forms.Label lblModelName;
    private System.Windows.Forms.TextBox txtModelName;
    private System.Windows.Forms.Label lblSpeed;
    private System.Windows.Forms.NumericUpDown numSpeed;
    private System.Windows.Forms.Label lblBattery;
    private System.Windows.Forms.NumericUpDown numBattery;
    private System.Windows.Forms.Label lblPrice;
    private System.Windows.Forms.NumericUpDown numPrice;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblBrand = new System.Windows.Forms.Label();
        txtBrand = new System.Windows.Forms.TextBox();
        lblModelName = new System.Windows.Forms.Label();
        txtModelName = new System.Windows.Forms.TextBox();
        lblSpeed = new System.Windows.Forms.Label();
        numSpeed = new System.Windows.Forms.NumericUpDown();
        lblBattery = new System.Windows.Forms.Label();
        numBattery = new System.Windows.Forms.NumericUpDown();
        lblPrice = new System.Windows.Forms.Label();
        numPrice = new System.Windows.Forms.NumericUpDown();
        btnSave = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)numSpeed).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numBattery).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
        SuspendLayout();

        lblBrand.AutoSize = true; lblBrand.Location = new System.Drawing.Point(20, 20); lblBrand.Text = "Бренд";
        txtBrand.Location = new System.Drawing.Point(20, 43); txtBrand.Size = new System.Drawing.Size(320, 23);
        lblModelName.AutoSize = true; lblModelName.Location = new System.Drawing.Point(20, 80); lblModelName.Text = "Модель";
        txtModelName.Location = new System.Drawing.Point(20, 103); txtModelName.Size = new System.Drawing.Size(320, 23);
        lblSpeed.AutoSize = true; lblSpeed.Location = new System.Drawing.Point(20, 140); lblSpeed.Text = "Макс. скорость";
        numSpeed.Location = new System.Drawing.Point(20, 163); numSpeed.Maximum = 150; numSpeed.Value = 25;
        lblBattery.AutoSize = true; lblBattery.Location = new System.Drawing.Point(180, 140); lblBattery.Text = "Батарея";
        numBattery.Location = new System.Drawing.Point(180, 163); numBattery.Maximum = 100000; numBattery.Value = 7800;
        lblPrice.AutoSize = true; lblPrice.Location = new System.Drawing.Point(20, 202); lblPrice.Text = "Цена за час";
        numPrice.Location = new System.Drawing.Point(20, 225); numPrice.Maximum = 10000; numPrice.Value = 200;

        btnSave.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnSave.ForeColor = System.Drawing.Color.White;
        btnSave.Location = new System.Drawing.Point(20, 270);
        btnSave.Size = new System.Drawing.Size(150, 36);
        btnSave.Text = "Сохранить";
        btnSave.Click += btnSave_Click;

        btnCancel.Location = new System.Drawing.Point(190, 270);
        btnCancel.Size = new System.Drawing.Size(150, 36);
        btnCancel.Text = "Отмена";
        btnCancel.Click += btnCancel_Click;

        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.White;
        ClientSize = new System.Drawing.Size(365, 325);
        Controls.AddRange(new System.Windows.Forms.Control[] { lblBrand, txtBrand, lblModelName, txtModelName, lblSpeed, numSpeed, lblBattery, numBattery, lblPrice, numPrice, btnSave, btnCancel });
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Добавить модель";
        ((System.ComponentModel.ISupportInitialize)numSpeed).EndInit();
        ((System.ComponentModel.ISupportInitialize)numBattery).EndInit();
        ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
