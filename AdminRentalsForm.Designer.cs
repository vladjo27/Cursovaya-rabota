namespace ScooterAdmin;

partial class AdminRentalsForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel panelTop;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Panel panelButtons;
    private System.Windows.Forms.Button btnAssign;
    private System.Windows.Forms.Button btnComplete;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnRefresh;
    private System.Windows.Forms.DataGridView dgvRentals;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        panelTop = new System.Windows.Forms.Panel();
        lblTitle = new System.Windows.Forms.Label();
        panelButtons = new System.Windows.Forms.Panel();
        btnAssign = new System.Windows.Forms.Button();
        btnComplete = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        btnRefresh = new System.Windows.Forms.Button();
        dgvRentals = new System.Windows.Forms.DataGridView();
        panelTop.SuspendLayout();
        panelButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvRentals).BeginInit();
        SuspendLayout();

        panelTop.BackColor = System.Drawing.Color.White;
        panelTop.Dock = System.Windows.Forms.DockStyle.Top;
        panelTop.Height = 55;
        lblTitle.AutoSize = true;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = System.Drawing.Color.FromArgb(27, 38, 44);
        lblTitle.Location = new System.Drawing.Point(15, 12);
        lblTitle.Text = "Аренды";
        panelTop.Controls.Add(lblTitle);

        panelButtons.BackColor = System.Drawing.Color.FromArgb(236, 239, 241);
        panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelButtons.Height = 60;

        btnAssign = CreateButton("Назначить", 12, System.Drawing.Color.FromArgb(76, 175, 80), btnAssign_Click);
        btnComplete = CreateButton("Завершить", 202, System.Drawing.Color.FromArgb(63, 81, 181), btnComplete_Click);
        btnCancel = CreateButton("Отменить", 392, System.Drawing.Color.FromArgb(198, 40, 40), btnCancel_Click);
        btnRefresh = CreateButton("Обновить", 582, System.Drawing.Color.FromArgb(100, 100, 100), btnRefresh_Click);
        panelButtons.Controls.AddRange(new System.Windows.Forms.Control[] { btnAssign, btnComplete, btnCancel, btnRefresh });

        SetupGrid(dgvRentals);
        dgvRentals.Dock = System.Windows.Forms.DockStyle.Fill;

        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(980, 560);
        Controls.Add(dgvRentals);
        Controls.Add(panelButtons);
        Controls.Add(panelTop);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Аренды";
        Load += AdminRentalsForm_Load;

        panelTop.ResumeLayout(false);
        panelTop.PerformLayout();
        panelButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvRentals).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button CreateButton(string text, int left, System.Drawing.Color color, System.EventHandler click)
    {
        var button = new System.Windows.Forms.Button();
        button.BackColor = color;
        button.Cursor = System.Windows.Forms.Cursors.Hand;
        button.FlatAppearance.BorderSize = 0;
        button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        button.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        button.ForeColor = System.Drawing.Color.White;
        button.Location = new System.Drawing.Point(left, 10);
        button.Size = new System.Drawing.Size(178, 40);
        button.Text = text;
        button.Click += click;
        return button;
    }

    private void SetupGrid(System.Windows.Forms.DataGridView grid)
    {
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        grid.BackgroundColor = System.Drawing.Color.White;
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
        grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(27, 38, 44);
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
