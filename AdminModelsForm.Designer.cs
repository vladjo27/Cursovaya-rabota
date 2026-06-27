namespace ScooterAdmin;

partial class AdminModelsForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel panelTop;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Panel panelButtons;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.DataGridView dgvModels;

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
        btnAdd = new System.Windows.Forms.Button();
        btnDelete = new System.Windows.Forms.Button();
        dgvModels = new System.Windows.Forms.DataGridView();
        panelTop.SuspendLayout();
        panelButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvModels).BeginInit();
        SuspendLayout();

        panelTop.BackColor = System.Drawing.Color.White;
        panelTop.Dock = System.Windows.Forms.DockStyle.Top;
        panelTop.Height = 55;
        lblTitle.AutoSize = true;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = System.Drawing.Color.FromArgb(27, 38, 44);
        lblTitle.Location = new System.Drawing.Point(15, 12);
        lblTitle.Text = "Модели самокатов";
        panelTop.Controls.Add(lblTitle);

        panelButtons.BackColor = System.Drawing.Color.FromArgb(236, 239, 241);
        panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelButtons.Height = 60;

        btnAdd.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
        btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
        btnAdd.FlatAppearance.BorderSize = 0;
        btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btnAdd.ForeColor = System.Drawing.Color.White;
        btnAdd.Location = new System.Drawing.Point(15, 10);
        btnAdd.Size = new System.Drawing.Size(200, 40);
        btnAdd.Text = "Добавить";
        btnAdd.Click += btnAdd_Click;

        btnDelete.BackColor = System.Drawing.Color.FromArgb(198, 40, 40);
        btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
        btnDelete.FlatAppearance.BorderSize = 0;
        btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btnDelete.ForeColor = System.Drawing.Color.White;
        btnDelete.Location = new System.Drawing.Point(230, 10);
        btnDelete.Size = new System.Drawing.Size(200, 40);
        btnDelete.Text = "Удалить";
        btnDelete.Click += btnDelete_Click;
        panelButtons.Controls.AddRange(new System.Windows.Forms.Control[] { btnAdd, btnDelete });

        SetupGrid(dgvModels);
        dgvModels.Dock = System.Windows.Forms.DockStyle.Fill;

        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(720, 460);
        Controls.Add(dgvModels);
        Controls.Add(panelButtons);
        Controls.Add(panelTop);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Модели";
        Load += AdminModelsForm_Load;

        panelTop.ResumeLayout(false);
        panelTop.PerformLayout();
        panelButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvModels).EndInit();
        ResumeLayout(false);
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
