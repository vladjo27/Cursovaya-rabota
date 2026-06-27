namespace ScooterRental;

partial class UserMainForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel panelSidebar;
    private System.Windows.Forms.Label lblSidebarTitle;
    private System.Windows.Forms.Label lblWelcome;
    private System.Windows.Forms.Label lblRole;
    private System.Windows.Forms.Button btnRentScooter;
    private System.Windows.Forms.Button btnMyRentals;
    private System.Windows.Forms.Button btnProfile;
    private System.Windows.Forms.Button btnLogout;
    private System.Windows.Forms.Panel panelHeader;
    private System.Windows.Forms.Label lblPageTitle;
    private System.Windows.Forms.Panel panelContent;
    private System.Windows.Forms.Label lblCard1Value;
    private System.Windows.Forms.Label lblCard2Value;
    private System.Windows.Forms.Label lblCard3Value;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        panelSidebar = new System.Windows.Forms.Panel();
        lblSidebarTitle = new System.Windows.Forms.Label();
        lblWelcome = new System.Windows.Forms.Label();
        lblRole = new System.Windows.Forms.Label();
        btnRentScooter = new System.Windows.Forms.Button();
        btnMyRentals = new System.Windows.Forms.Button();
        btnProfile = new System.Windows.Forms.Button();
        btnLogout = new System.Windows.Forms.Button();
        panelHeader = new System.Windows.Forms.Panel();
        lblPageTitle = new System.Windows.Forms.Label();
        panelContent = new System.Windows.Forms.Panel();
        SuspendLayout();

        panelSidebar.BackColor = System.Drawing.Color.FromArgb(38, 50, 56);
        panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
        panelSidebar.Width = 220;

        lblSidebarTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lblSidebarTitle.ForeColor = System.Drawing.Color.FromArgb(0, 200, 180);
        lblSidebarTitle.Location = new System.Drawing.Point(15, 15);
        lblSidebarTitle.Size = new System.Drawing.Size(190, 35);
        lblSidebarTitle.Text = "ScooterGo";

        lblWelcome.ForeColor = System.Drawing.Color.White;
        lblWelcome.Location = new System.Drawing.Point(15, 55);
        lblWelcome.Size = new System.Drawing.Size(190, 20);
        lblRole.ForeColor = System.Drawing.Color.Silver;
        lblRole.Location = new System.Drawing.Point(15, 75);
        lblRole.Size = new System.Drawing.Size(190, 18);

        btnRentScooter = CreateMenuButton("Арендовать", 120, btnRentScooter_Click);
        btnMyRentals = CreateMenuButton("Мои аренды", 170, btnMyRentals_Click);
        btnProfile = CreateMenuButton("Профиль", 220, btnProfile_Click);

        btnLogout.BackColor = System.Drawing.Color.FromArgb(198, 40, 40);
        btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
        btnLogout.FlatAppearance.BorderSize = 0;
        btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnLogout.ForeColor = System.Drawing.Color.White;
        btnLogout.Location = new System.Drawing.Point(10, 520);
        btnLogout.Size = new System.Drawing.Size(200, 40);
        btnLogout.Text = "Выйти";
        btnLogout.Click += btnLogout_Click;

        panelSidebar.Controls.AddRange(new System.Windows.Forms.Control[]
        {
            lblSidebarTitle, lblWelcome, lblRole, btnRentScooter, btnMyRentals, btnProfile, btnLogout
        });

        panelHeader.BackColor = System.Drawing.Color.White;
        panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
        panelHeader.Height = 60;
        lblPageTitle.AutoSize = true;
        lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(38, 50, 56);
        lblPageTitle.Location = new System.Drawing.Point(15, 15);
        lblPageTitle.Text = "Главная";
        panelHeader.Controls.Add(lblPageTitle);

        panelContent.BackColor = System.Drawing.Color.FromArgb(236, 239, 241);
        panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
        panelContent.Controls.Add(CreateCard("Доступно самокатов", "0", 25, 85, System.Drawing.Color.FromArgb(0, 150, 136), out lblCard1Value));
        panelContent.Controls.Add(CreateCard("Активных аренд", "0", 260, 85, System.Drawing.Color.FromArgb(255, 152, 0), out lblCard2Value));
        panelContent.Controls.Add(CreateCard("Всего поездок", "0", 495, 85, System.Drawing.Color.FromArgb(63, 81, 181), out lblCard3Value));

        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(950, 580);
        Controls.Add(panelContent);
        Controls.Add(panelHeader);
        Controls.Add(panelSidebar);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "ScooterGo - Главная";
        Load += UserMainForm_Load;
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button CreateMenuButton(string text, int top, System.EventHandler click)
    {
        var button = new System.Windows.Forms.Button();
        button.BackColor = System.Drawing.Color.FromArgb(38, 50, 56);
        button.Cursor = System.Windows.Forms.Cursors.Hand;
        button.FlatAppearance.BorderSize = 0;
        button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(55, 71, 79);
        button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        button.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        button.ForeColor = System.Drawing.Color.White;
        button.Location = new System.Drawing.Point(0, top);
        button.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
        button.Size = new System.Drawing.Size(220, 45);
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
        panel.Size = new System.Drawing.Size(210, 110);

        var titleLabel = new System.Windows.Forms.Label();
        titleLabel.AutoSize = true;
        titleLabel.ForeColor = System.Drawing.Color.Gray;
        titleLabel.Location = new System.Drawing.Point(15, 12);
        titleLabel.Text = title;

        valueLabel = new System.Windows.Forms.Label();
        valueLabel.AutoSize = true;
        valueLabel.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
        valueLabel.ForeColor = color;
        valueLabel.Location = new System.Drawing.Point(15, 45);
        valueLabel.Text = value;

        panel.Controls.Add(titleLabel);
        panel.Controls.Add(valueLabel);
        return panel;
    }
}

