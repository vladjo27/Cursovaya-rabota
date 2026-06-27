namespace ScooterRental;

partial class MyRentalsForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel panelTop;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblInfo;
    private System.Windows.Forms.DataGridView dgvRentals;
    private System.Windows.Forms.Button btnReturn;

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
        dgvRentals = new System.Windows.Forms.DataGridView();
        btnReturn = new System.Windows.Forms.Button();
        panelTop.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvRentals).BeginInit();
        SuspendLayout();

        panelTop.BackColor = System.Drawing.Color.White;
        panelTop.Dock = System.Windows.Forms.DockStyle.Top;
        panelTop.Height = 75;
        lblTitle.AutoSize = true;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 150, 136);
        lblTitle.Location = new System.Drawing.Point(15, 10);
        lblTitle.Text = "Мои аренды";
        lblInfo.AutoSize = true;
        lblInfo.ForeColor = System.Drawing.Color.Gray;
        lblInfo.Location = new System.Drawing.Point(17, 45);
        lblInfo.Text = "Выберите активную аренду и нажмите Вернуть";
        panelTop.Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, lblInfo });

        SetupGrid(dgvRentals);
        dgvRentals.Location = new System.Drawing.Point(15, 85);
        dgvRentals.Size = new System.Drawing.Size(820, 345);

        btnReturn.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);
        btnReturn.Cursor = System.Windows.Forms.Cursors.Hand;
        btnReturn.FlatAppearance.BorderSize = 0;
        btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnReturn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        btnReturn.ForeColor = System.Drawing.Color.White;
        btnReturn.Location = new System.Drawing.Point(15, 445);
        btnReturn.Size = new System.Drawing.Size(820, 48);
        btnReturn.Text = "Вернуть самокат";
        btnReturn.Click += btnReturn_Click;

        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(236, 239, 241);
        ClientSize = new System.Drawing.Size(850, 510);
        Controls.Add(btnReturn);
        Controls.Add(dgvRentals);
        Controls.Add(panelTop);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Мои аренды";
        Load += MyRentalsForm_Load;
        panelTop.ResumeLayout(false);
        panelTop.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvRentals).EndInit();
        ResumeLayout(false);
    }

    private void SetupGrid(System.Windows.Forms.DataGridView grid)
    {
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        grid.BackgroundColor = System.Drawing.Color.White;
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
        grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(63, 81, 181);
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
