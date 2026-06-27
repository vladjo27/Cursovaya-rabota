namespace ScooterRental;

partial class ReturnScooterForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblScooterName;
    private System.Windows.Forms.Label lblDetails;
    private System.Windows.Forms.Label lblTotalText;
    private System.Windows.Forms.Label lblTotal;
    private System.Windows.Forms.Button btnConfirm;
    private System.Windows.Forms.Button btnCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitle = new System.Windows.Forms.Label();
        lblScooterName = new System.Windows.Forms.Label();
        lblDetails = new System.Windows.Forms.Label();
        lblTotalText = new System.Windows.Forms.Label();
        lblTotal = new System.Windows.Forms.Label();
        btnConfirm = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        SuspendLayout();

        lblTitle.AutoSize = true;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = System.Drawing.Color.FromArgb(255, 152, 0);
        lblTitle.Location = new System.Drawing.Point(20, 15);
        lblTitle.Text = "Возврат самоката";

        lblScooterName.AutoSize = true;
        lblScooterName.Location = new System.Drawing.Point(20, 52);
        lblScooterName.Text = "Самокат";

        lblDetails.Location = new System.Drawing.Point(20, 90);
        lblDetails.Size = new System.Drawing.Size(340, 90);
        lblDetails.Text = "Детали расчёта";

        lblTotalText.AutoSize = true;
        lblTotalText.Location = new System.Drawing.Point(20, 195);
        lblTotalText.Text = "Итого к оплате";
        lblTotal.AutoSize = true;
        lblTotal.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
        lblTotal.ForeColor = System.Drawing.Color.FromArgb(0, 150, 136);
        lblTotal.Location = new System.Drawing.Point(20, 220);
        lblTotal.Text = "0 руб";

        btnConfirm.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);
        btnConfirm.FlatAppearance.BorderSize = 0;
        btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnConfirm.ForeColor = System.Drawing.Color.White;
        btnConfirm.Location = new System.Drawing.Point(20, 290);
        btnConfirm.Size = new System.Drawing.Size(180, 40);
        btnConfirm.Text = "Оплатить и вернуть";
        btnConfirm.Click += btnConfirm_Click;
        btnCancel.Location = new System.Drawing.Point(215, 290);
        btnCancel.Size = new System.Drawing.Size(145, 40);
        btnCancel.Text = "Отмена";
        btnCancel.Click += btnCancel_Click;

        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.White;
        ClientSize = new System.Drawing.Size(385, 355);
        Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, lblScooterName, lblDetails, lblTotalText, lblTotal, btnConfirm, btnCancel });
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Возврат самоката";
        Load += ReturnScooterForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }
}
