namespace ScooterRental;

partial class RentScooterForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel panelTop;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblInfo;
    private System.Windows.Forms.DataGridView dgvScooters;
    private System.Windows.Forms.Button btnRent;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        panelTop = new System.Windows.Forms.Panel();
        lblTitle = new System.Windows.Forms.Label();
        lblInfo = new System.Windows.Forms.Label();
        dgvScooters = new System.Windows.Forms.DataGridView();
        btnRent = new System.Windows.Forms.Button();
        panelTop.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvScooters).BeginInit();
        SuspendLayout();

        panelTop.BackColor = System.Drawing.Color.White;
        panelTop.Dock = System.Windows.Forms.DockStyle.Top;
        panelTop.Height = 75;
        lblTitle.AutoSize = true;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 150, 136);
        lblTitle.Location = new System.Drawing.Point(15, 10);
        lblTitle.Text = "Доступные самокаты";
        lblInfo.AutoSize = true;
        lblInfo.ForeColor = System.Drawing.Color.Gray;
        lblInfo.Location = new System.Drawing.Point(17, 45);
        lblInfo.Text = "Выберите самокат и нажмите Арендовать";
        panelTop.Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, lblInfo });

        SetupGrid(dgvScooters);
        dgvScooters.Location = new System.Drawing.Point(15, 85);
        dgvScooters.Size = new System.Drawing.Size(740, 325);

        btnRent.BackColor = System.Drawing.Color.FromArgb(0, 150, 136);
        btnRent.Cursor = System.Windows.Forms.Cursors.Hand;
        btnRent.FlatAppearance.BorderSize = 0;
        btnRent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnRent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        btnRent.ForeColor = System.Drawing.Color.White;
        btnRent.Location = new System.Drawing.Point(15, 425);
        btnRent.Size = new System.Drawing.Size(740, 48);
        btnRent.Text = "Арендовать выбранный самокат";
        btnRent.Click += btnRent_Click;

        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(236, 239, 241);
        ClientSize = new System.Drawing.Size(770, 490);
        Controls.Add(btnRent);
        Controls.Add(dgvScooters);
        Controls.Add(panelTop);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Аренда самоката";
        Load += RentScooterForm_Load;
        panelTop.ResumeLayout(false);
        panelTop.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvScooters).EndInit();
        ResumeLayout(false);
    }

    private void SetupGrid(System.Windows.Forms.DataGridView grid)
    {
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        grid.BackgroundColor = System.Drawing.Color.White;
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
        grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 150, 136);
        grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        grid.ColumnHeadersHeight = 40;
        grid.EnableHeadersVisualStyles = false;
        grid.MultiSelect = false;
        grid.ReadOnly = true;
        grid.RowHeadersVisible = false;
        grid.RowTemplate.Height = 35;
        grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
    }
}
