namespace ScooterAdmin;

partial class AdminMainForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Panel panelSidebar;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblWelcome;
    private System.Windows.Forms.Button btnDashboard;
    private System.Windows.Forms.Button btnScooters;
    private System.Windows.Forms.Button btnModels;
    private System.Windows.Forms.Button btnRentals;
    private System.Windows.Forms.Button btnUsers;
    private System.Windows.Forms.Button btnPayments;
    private System.Windows.Forms.Button btnLogout;

    private System.Windows.Forms.Panel panelHeader;
    private System.Windows.Forms.Label lblPageTitle;
    private System.Windows.Forms.Panel panelContent;
private System.Windows.Forms.Label lblScootersTotal;
    private System.Windows.Forms.Label lblScootersAvailable;
    private System.Windows.Forms.Label lblScootersRented;
    private System.Windows.Forms.Label lblScootersRepair;
    private System.Windows.Forms.Label lblUsersTotal;
    private System.Windows.Forms.Label lblRevenue;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        panelSidebar = new System.Windows.Forms.Panel();
        lblTitle = new System.Windows.Forms.Label();
        lblWelcome = new System.Windows.Forms.Label();
        btnDashboard = new System.Windows.Forms.Button();
        btnScooters = new System.Windows.Forms.Button();
        btnModels = new System.Windows.Forms.Button();
        btnRentals = new System.Windows.Forms.Button();
        btnUsers = new System.Windows.Forms.Button();
        btnPayments = new System.Windows.Forms.Button();
        btnLogout = new System.Windows.Forms.Button();

        panelHeader = new System.Windows.Forms.Panel();
        lblPageTitle = new System.Windows.Forms.Label();
        panelContent = new System.Windows.Forms.Panel();
SuspendLayout();

        // panelSidebar
        panelSidebar.BackColor = System.Drawing.Color.FromArgb(27, 38, 44);
        panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
        panelSidebar.Width = 230;

        lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = System.Drawing.Color.FromArgb(255, 152, 0);
        lblTitle.Location = new System.Drawing.Point(15, 15);
        lblTitle.Size = new System.Drawing.Size(200, 30);
        lblTitle.Text = "ScooterGo ADMIN";

        lblWelcome.ForeColor = System.Drawing.Color.Silver;
        lblWelcome.Location = new System.Drawing.Point(15, 48);
        lblWelcome.Size = new System.Drawing.Size(200, 22);

        btnDashboard = CreateMenuButton("Главная", 85, btnDashboard_Click);
        btnScooters = CreateMenuButton("Самокаты", 132, btnScooters_Click);
        btnModels = CreateMenuButton("Модели", 179, btnModels_Click);
        btnRentals = CreateMenuButton("Аренды", 226, btnRentals_Click);
        btnUsers = CreateMenuButton("Пользователи", 273, btnUsers_Click);
        btnPayments = CreateMenuButton("Платежи", 320, btnPayments_Click);

        btnLogout.BackColor = System.Drawing.Color.FromArgb(198, 40, 40);
        btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
        btnLogout.FlatAppearance.BorderSize = 0;
        btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnLogout.ForeColor = System.Drawing.Color.White;
        btnLogout.Location = new System.Drawing.Point(10, 550);
        btnLogout.Size = new System.Drawing.Size(210, 40);
        btnLogout.Text = "Выйти";
        btnLogout.Click += btnLogout_Click;

        panelSidebar.Controls.AddRange(new System.Windows.Forms.Control[]
        {
            lblTitle, lblWelcome, btnDashboard, btnScooters, btnModels, btnRentals, btnUsers, btnPayments, btnLogout
        });

        // panelHeader
        panelHeader.BackColor = System.Drawing.Color.White;
        panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
        panelHeader.Height = 55;

        lblPageTitle.AutoSize = true;
        lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
        lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(27, 38, 44);
        lblPageTitle.Location = new System.Drawing.Point(15, 13);
        lblPageTitle.Text = "Панель администратора";

        panelHeader.Controls.Add(lblPageTitle);

        // panelContent
        panelContent.BackColor = System.Drawing.Color.FromArgb(236, 239, 241);
        panelContent.Dock = System.Windows.Forms.DockStyle.Fill;

        var card1 = CreateCard("Всего самокатов", "0", 20, 65, System.Drawing.Color.FromArgb(0, 150, 136), out lblScootersTotal);
        var card2 = CreateCard("Доступно", "0", 258, 65, System.Drawing.Color.FromArgb(76, 175, 80), out lblScootersAvailable);
        var card3 = CreateCard("В аренде", "0", 496, 65, System.Drawing.Color.FromArgb(255, 152, 0), out lblScootersRented);
        var card4 = CreateCard("На ремонте", "0", 20, 180, System.Drawing.Color.FromArgb(198, 40, 40), out lblScootersRepair);
        var card5 = CreateCard("Пользователей", "0", 258, 180, System.Drawing.Color.FromArgb(63, 81, 181), out lblUsersTotal);
        var card6 = CreateCard("Выручка, руб", "0", 496, 180, System.Drawing.Color.FromArgb(123, 31, 162), out lblRevenue);
panelContent.Controls.AddRange(new System.Windows.Forms.Control[]
        {
            card1, card2, card3, card4, card5, card6
        });

        // AdminMainForm
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1060, 620);
        Controls.Add(panelContent);
        Controls.Add(panelHeader);
        Controls.Add(panelSidebar);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "ScooterAdmin";
        Load += AdminMainForm_Load;
ResumeLayout(false);
    }

    private System.Windows.Forms.Button CreateMenuButton(string text, int top, System.EventHandler click)
    {
        var button = new System.Windows.Forms.Button();
        button.BackColor = System.Drawing.Color.FromArgb(27, 38, 44);
        button.Cursor = System.Windows.Forms.Cursors.Hand;
        button.FlatAppearance.BorderSize = 0;
        button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(50, 65, 75);
        button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        button.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        button.ForeColor = System.Drawing.Color.White;
        button.Location = new System.Drawing.Point(0, top);
        button.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
        button.Size = new System.Drawing.Size(230, 44);
        button.Text = text;
        button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        button.Click += click;
        return button;
    }

    private System.Windows.Forms.Panel CreateCard(string title, string value, int x, int y, System.Drawing.Color color, out System.Windows.Forms.Label valueLabel)
    {
        var panel = new System.Windows.Forms.Panel();
        panel.BackColor = System.Drawing.Color.White;
        panel.Location = new System.Drawing.Point(x, y);
        panel.Size = new System.Drawing.Size(220, 100);

        var titleLabel = new System.Windows.Forms.Label();
        titleLabel.AutoSize = true;
        titleLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
        titleLabel.ForeColor = System.Drawing.Color.Gray;
        titleLabel.Location = new System.Drawing.Point(12, 10);
        titleLabel.Text = title;

        valueLabel = new System.Windows.Forms.Label();
        valueLabel.AutoSize = true;
        valueLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
        valueLabel.ForeColor = color;
        valueLabel.Location = new System.Drawing.Point(12, 38);
        valueLabel.Text = value;

        panel.Controls.Add(titleLabel);
        panel.Controls.Add(valueLabel);

        return panel;
    }
}

