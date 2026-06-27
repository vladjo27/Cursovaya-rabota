namespace ScooterAdmin;

partial class AdminUsersForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel panelTop;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Panel panelButtons;
    private System.Windows.Forms.Button btnBlock;
    private System.Windows.Forms.Button btnUnblock;
    private System.Windows.Forms.Button btnMakeAdmin;
    private System.Windows.Forms.Button btnMakeUser;
    private System.Windows.Forms.Button btnEditCredentials;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.DataGridView dgvUsers;

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
        btnBlock = new System.Windows.Forms.Button();
        btnUnblock = new System.Windows.Forms.Button();
        btnMakeAdmin = new System.Windows.Forms.Button();
        btnMakeUser = new System.Windows.Forms.Button();
        btnEditCredentials = new System.Windows.Forms.Button();
        btnDelete = new System.Windows.Forms.Button();
        dgvUsers = new System.Windows.Forms.DataGridView();
        panelTop.SuspendLayout();
        panelButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
        SuspendLayout();

        panelTop.BackColor = System.Drawing.Color.White;
        panelTop.Dock = System.Windows.Forms.DockStyle.Top;
        panelTop.Height = 55;
        lblTitle.AutoSize = true;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = System.Drawing.Color.FromArgb(27, 38, 44);
        lblTitle.Location = new System.Drawing.Point(15, 12);
        lblTitle.Text = "Пользователи";
        panelTop.Controls.Add(lblTitle);

        panelButtons.BackColor = System.Drawing.Color.FromArgb(236, 239, 241);
        panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelButtons.Height = 60;

        btnBlock = CreateButton("Заблокировать", 10, 145, System.Drawing.Color.FromArgb(198, 40, 40), btnBlock_Click);
        btnUnblock = CreateButton("Разблокировать", 165, 145, System.Drawing.Color.FromArgb(76, 175, 80), btnUnblock_Click);
        btnMakeAdmin = CreateButton("Сделать Admin", 320, 145, System.Drawing.Color.FromArgb(255, 152, 0), btnMakeAdmin_Click);
        btnMakeUser = CreateButton("Сделать User", 475, 145, System.Drawing.Color.FromArgb(63, 81, 181), btnMakeUser_Click);
        btnEditCredentials = CreateButton("Логин / Пароль", 630, 170, System.Drawing.Color.FromArgb(0, 150, 136), btnEditCredentials_Click);
        btnDelete = CreateButton("Удалить", 810, 145, System.Drawing.Color.FromArgb(100, 0, 0), btnDelete_Click);
        panelButtons.Controls.AddRange(new System.Windows.Forms.Control[] { btnBlock, btnUnblock, btnMakeAdmin, btnMakeUser, btnEditCredentials, btnDelete });

        SetupGrid(dgvUsers);
        dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;

        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(980, 520);
        Controls.Add(dgvUsers);
        Controls.Add(panelButtons);
        Controls.Add(panelTop);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Пользователи";
        Load += AdminUsersForm_Load;

        panelTop.ResumeLayout(false);
        panelTop.PerformLayout();
        panelButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button CreateButton(string text, int left, int width, System.Drawing.Color color, System.EventHandler click)
    {
        var button = new System.Windows.Forms.Button();
        button.BackColor = color;
        button.Cursor = System.Windows.Forms.Cursors.Hand;
        button.FlatAppearance.BorderSize = 0;
        button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        button.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        button.ForeColor = System.Drawing.Color.White;
        button.Location = new System.Drawing.Point(left, 10);
        button.Size = new System.Drawing.Size(width, 40);
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
