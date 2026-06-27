namespace ScooterRental;

partial class RentConfirmForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label lblScooterName;
    private System.Windows.Forms.Label lblScooterDetails;
    private System.Windows.Forms.Label lblHours;
    private System.Windows.Forms.NumericUpDown numHours;
    private System.Windows.Forms.Label lblMinutes;
    private System.Windows.Forms.NumericUpDown numMinutes;
    private System.Windows.Forms.Button btn15;
    private System.Windows.Forms.Button btn30;
    private System.Windows.Forms.Button btn60;
    private System.Windows.Forms.Button btn120;
    private System.Windows.Forms.Label lblCostTitle;
    private System.Windows.Forms.Label lblCostAmount;
    private System.Windows.Forms.Label lblCostCalc;
    private System.Windows.Forms.Label lblNote;
    private System.Windows.Forms.Button btnConfirm;
    private System.Windows.Forms.Button btnCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblScooterName = new System.Windows.Forms.Label();
        lblScooterDetails = new System.Windows.Forms.Label();
        lblHours = new System.Windows.Forms.Label();
        numHours = new System.Windows.Forms.NumericUpDown();
        lblMinutes = new System.Windows.Forms.Label();
        numMinutes = new System.Windows.Forms.NumericUpDown();
        btn15 = new System.Windows.Forms.Button();
        btn30 = new System.Windows.Forms.Button();
        btn60 = new System.Windows.Forms.Button();
        btn120 = new System.Windows.Forms.Button();
        lblCostTitle = new System.Windows.Forms.Label();
        lblCostAmount = new System.Windows.Forms.Label();
        lblCostCalc = new System.Windows.Forms.Label();
        lblNote = new System.Windows.Forms.Label();
        btnConfirm = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)numHours).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numMinutes).BeginInit();
        SuspendLayout();

        lblScooterName.AutoSize = true;
        lblScooterName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
        lblScooterName.ForeColor = System.Drawing.Color.FromArgb(0, 150, 136);
        lblScooterName.Location = new System.Drawing.Point(20, 15);
        lblScooterName.Text = "Самокат";
        lblScooterDetails.Location = new System.Drawing.Point(20, 50);
        lblScooterDetails.Size = new System.Drawing.Size(370, 50);

        lblHours.AutoSize = true; lblHours.Location = new System.Drawing.Point(20, 118); lblHours.Text = "Часы";
        numHours.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        numHours.Location = new System.Drawing.Point(20, 140); numHours.Maximum = 24; numHours.Size = new System.Drawing.Size(100, 32); numHours.ValueChanged += time_ValueChanged;
        lblMinutes.AutoSize = true; lblMinutes.Location = new System.Drawing.Point(160, 118); lblMinutes.Text = "Минуты";
        numMinutes.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        numMinutes.Location = new System.Drawing.Point(160, 140); numMinutes.Maximum = 59; numMinutes.Increment = 5; numMinutes.Value = 30; numMinutes.Size = new System.Drawing.Size(100, 32); numMinutes.ValueChanged += time_ValueChanged;

        btn15 = CreateQuickButton("15 мин", 20, btn15_Click);
        btn30 = CreateQuickButton("30 мин", 105, btn30_Click);
        btn60 = CreateQuickButton("1 час", 190, btn60_Click);
        btn120 = CreateQuickButton("2 часа", 275, btn120_Click);

        lblCostTitle.AutoSize = true; lblCostTitle.Location = new System.Drawing.Point(20, 230); lblCostTitle.Text = "Предварительная стоимость";
        lblCostAmount.AutoSize = true;
        lblCostAmount.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
        lblCostAmount.ForeColor = System.Drawing.Color.FromArgb(0, 150, 136);
        lblCostAmount.Location = new System.Drawing.Point(20, 252);
        lblCostAmount.Text = "0 руб";
        lblCostCalc.AutoSize = true; lblCostCalc.ForeColor = System.Drawing.Color.Gray; lblCostCalc.Location = new System.Drawing.Point(20, 295);
        lblNote.ForeColor = System.Drawing.Color.Gray;
        lblNote.Location = new System.Drawing.Point(20, 325);
        lblNote.Size = new System.Drawing.Size(370, 35);
        lblNote.Text = "Оплата считается по фактическому времени при возврате.";

        btnConfirm.BackColor = System.Drawing.Color.FromArgb(0, 150, 136);
        btnConfirm.FlatAppearance.BorderSize = 0;
        btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnConfirm.ForeColor = System.Drawing.Color.White;
        btnConfirm.Location = new System.Drawing.Point(20, 380);
        btnConfirm.Size = new System.Drawing.Size(180, 40);
        btnConfirm.Text = "Подтвердить";
        btnConfirm.Click += btnConfirm_Click;
        btnCancel.Location = new System.Drawing.Point(215, 380);
        btnCancel.Size = new System.Drawing.Size(175, 40);
        btnCancel.Text = "Отмена";
        btnCancel.Click += btnCancel_Click;

        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.White;
        ClientSize = new System.Drawing.Size(415, 445);
        Controls.AddRange(new System.Windows.Forms.Control[] { lblScooterName, lblScooterDetails, lblHours, numHours, lblMinutes, numMinutes, btn15, btn30, btn60, btn120, lblCostTitle, lblCostAmount, lblCostCalc, lblNote, btnConfirm, btnCancel });
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Оформление аренды";
        Load += RentConfirmForm_Load;
        ((System.ComponentModel.ISupportInitialize)numHours).EndInit();
        ((System.ComponentModel.ISupportInitialize)numMinutes).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button CreateQuickButton(string text, int left, System.EventHandler click)
    {
        var button = new System.Windows.Forms.Button();
        button.Location = new System.Drawing.Point(left, 190);
        button.Size = new System.Drawing.Size(75, 30);
        button.Text = text;
        button.Click += click;
        return button;
    }
}
