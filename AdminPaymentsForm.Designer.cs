namespace ScooterAdmin;

partial class AdminPaymentsForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel panelTop;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Panel panelBottom;
    private System.Windows.Forms.Label lblTotal;
    private System.Windows.Forms.DataGridView dgvPayments;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        panelTop = new System.Windows.Forms.Panel();
        lblTitle = new System.Windows.Forms.Label();
        panelBottom = new System.Windows.Forms.Panel();
        lblTotal = new System.Windows.Forms.Label();
        dgvPayments = new System.Windows.Forms.DataGridView();
        panelTop.SuspendLayout();
        panelBottom.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
        SuspendLayout();

        panelTop.BackColor = System.Drawing.Color.White;
        panelTop.Dock = System.Windows.Forms.DockStyle.Top;
        panelTop.Height = 55;
        lblTitle.AutoSize = true;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = System.Drawing.Color.FromArgb(27, 38, 44);
        lblTitle.Location = new System.Drawing.Point(15, 12);
        lblTitle.Text = "Платежи";
        panelTop.Controls.Add(lblTitle);

        panelBottom.BackColor = System.Drawing.Color.White;
        panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelBottom.Height = 55;
        lblTotal.AutoSize = true;
        lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        lblTotal.ForeColor = System.Drawing.Color.FromArgb(123, 31, 162);
        lblTotal.Location = new System.Drawing.Point(15, 14);
        lblTotal.Text = "Общая выручка: 0 руб";
        panelBottom.Controls.Add(lblTotal);

        SetupGrid(dgvPayments);
        dgvPayments.Dock = System.Windows.Forms.DockStyle.Fill;

        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(760, 500);
        Controls.Add(dgvPayments);
        Controls.Add(panelBottom);
        Controls.Add(panelTop);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Платежи";
        Load += AdminPaymentsForm_Load;

        panelTop.ResumeLayout(false);
        panelTop.PerformLayout();
        panelBottom.ResumeLayout(false);
        panelBottom.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
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
