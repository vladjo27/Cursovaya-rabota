namespace ScooterAdmin;

partial class CompleteRentalForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label lblInfo;
    private System.Windows.Forms.Label lblAmount;
    private System.Windows.Forms.NumericUpDown numAmount;
    private System.Windows.Forms.Label lblPaymentMethod;
    private System.Windows.Forms.ComboBox cmbPaymentMethod;
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
        lblInfo = new System.Windows.Forms.Label();
        lblAmount = new System.Windows.Forms.Label();
        numAmount = new System.Windows.Forms.NumericUpDown();
        lblPaymentMethod = new System.Windows.Forms.Label();
        cmbPaymentMethod = new System.Windows.Forms.ComboBox();
        lblHint = new System.Windows.Forms.Label();
        btnSave = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)numAmount).BeginInit();
        SuspendLayout();

        lblInfo.Location = new System.Drawing.Point(20, 20);
        lblInfo.Size = new System.Drawing.Size(360, 95);
        lblInfo.Text = "Информация об аренде";

        lblAmount.AutoSize = true;
        lblAmount.Location = new System.Drawing.Point(20, 130);
        lblAmount.Text = "Итоговая сумма";
        numAmount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        numAmount.Location = new System.Drawing.Point(20, 153);
        numAmount.Maximum = 999999;
        numAmount.Size = new System.Drawing.Size(160, 32);

        lblPaymentMethod.AutoSize = true;
        lblPaymentMethod.Location = new System.Drawing.Point(20, 205);
        lblPaymentMethod.Text = "Способ оплаты";
        cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbPaymentMethod.Items.AddRange(new object[] { "Карта", "Наличные", "СБП", "Бонусы", "Бесплатно" });
        cmbPaymentMethod.Location = new System.Drawing.Point(20, 228);
        cmbPaymentMethod.Size = new System.Drawing.Size(200, 23);

        lblHint.ForeColor = System.Drawing.Color.Gray;
        lblHint.Location = new System.Drawing.Point(20, 265);
        lblHint.Size = new System.Drawing.Size(360, 35);
        lblHint.Text = "Сумму можно изменить вручную. Если сумма 0, платёж не создаётся.";

        btnSave.BackColor = System.Drawing.Color.FromArgb(63, 81, 181);
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnSave.ForeColor = System.Drawing.Color.White;
        btnSave.Location = new System.Drawing.Point(20, 315);
        btnSave.Size = new System.Drawing.Size(175, 40);
        btnSave.Text = "Завершить";
        btnSave.Click += btnSave_Click;
        btnCancel.Location = new System.Drawing.Point(215, 315);
        btnCancel.Size = new System.Drawing.Size(165, 40);
        btnCancel.Text = "Отмена";
        btnCancel.Click += btnCancel_Click;

        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.White;
        ClientSize = new System.Drawing.Size(405, 375);
        Controls.AddRange(new System.Windows.Forms.Control[] { lblInfo, lblAmount, numAmount, lblPaymentMethod, cmbPaymentMethod, lblHint, btnSave, btnCancel });
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Завершить аренду";
        Load += CompleteRentalForm_Load;
        ((System.ComponentModel.ISupportInitialize)numAmount).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
