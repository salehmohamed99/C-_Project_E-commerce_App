namespace Presentation.Forms
{
    partial class CategoryManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader     = new Panel();
            lblTitle      = new Label();
            lblName       = new Label();
            txtName       = new TextBox();
            btnAdd        = new Button();
            dgvCategories = new DataGridView();
            btnClose      = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
            SuspendLayout();

            // ???????????????????????????????????????
            //  Header Panel
            // ???????????????????????????????????????
            pnlHeader.Dock      = DockStyle.Top;
            pnlHeader.Height    = 60;
            pnlHeader.BackColor = Color.FromArgb(45, 62, 80);

            lblTitle.Text      = "Manage Categories";
            lblTitle.Font      = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location  = new Point(25, 12);
            lblTitle.AutoSize  = true;
            lblTitle.BackColor = Color.Transparent;

            pnlHeader.Controls.Add(lblTitle);

            // ???????????????????????????????????????
            //  Input Area
            // ???????????????????????????????????????
            lblName.Text      = "Category Name:";
            lblName.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(45, 62, 80);
            lblName.Location  = new Point(25, 78);
            lblName.AutoSize  = true;

            txtName.Location    = new Point(160, 75);
            txtName.Size        = new Size(300, 30);
            txtName.Font        = new Font("Segoe UI", 10.5F);
            txtName.BorderStyle = BorderStyle.FixedSingle;

            btnAdd.Text      = "Add Category";
            btnAdd.Location  = new Point(475, 72);
            btnAdd.Size      = new Size(170, 38);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.BackColor = Color.FromArgb(39, 174, 96);
            btnAdd.ForeColor = Color.White;
            btnAdd.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.Cursor    = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Click    += btnAdd_Click;

            // ???????????????????????????????????????
            //  DataGridView — Categories
            // ???????????????????????????????????????
            dgvCategories.Location            = new Point(25, 125);
            dgvCategories.Size                = new Size(660, 330);
            dgvCategories.AutoGenerateColumns = false;
            dgvCategories.AllowUserToAddRows  = false;
            dgvCategories.RowHeadersVisible   = false;
            dgvCategories.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.MultiSelect         = false;
            dgvCategories.BackgroundColor     = Color.White;
            dgvCategories.GridColor           = Color.FromArgb(230, 230, 230);
            dgvCategories.BorderStyle         = BorderStyle.None;
            dgvCategories.CellBorderStyle     = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCategories.EnableHeadersVisualStyles = false;
            dgvCategories.ColumnHeadersHeight      = 42;
            dgvCategories.ColumnHeadersBorderStyle  = DataGridViewHeaderBorderStyle.None;
            dgvCategories.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(45, 62, 80),
                ForeColor = Color.White,
                Font      = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Padding   = new Padding(0)
            };
            dgvCategories.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font               = new Font("Segoe UI", 9.75F),
                Padding            = new Padding(6, 4, 6, 4),
                Alignment          = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(214, 234, 248),
                SelectionForeColor = Color.FromArgb(45, 62, 80)
            };
            dgvCategories.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor          = Color.FromArgb(245, 247, 250),
                SelectionBackColor = Color.FromArgb(214, 234, 248),
                SelectionForeColor = Color.FromArgb(45, 62, 80)
            };
            dgvCategories.RowTemplate.Height = 40;
            dgvCategories.CellContentClick  += dgvCategories_CellContentClick;

            // ???????????????????????????????????????
            //  Close Button
            // ???????????????????????????????????????
            btnClose.Text      = "Close";
            btnClose.Location  = new Point(565, 470);
            btnClose.Size      = new Size(120, 40);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.BackColor = Color.FromArgb(45, 62, 80);
            btnClose.ForeColor = Color.White;
            btnClose.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.Cursor    = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click    += btnClose_Click;

            // ???????????????????????????????????????
            //  CategoryManagementForm
            // ???????????????????????????????????????
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode       = AutoScaleMode.Font;
            ClientSize          = new Size(710, 525);
            BackColor           = Color.FromArgb(245, 247, 250);
            FormBorderStyle     = FormBorderStyle.FixedDialog;
            MaximizeBox         = false;
            Controls.Add(pnlHeader);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(btnAdd);
            Controls.Add(dgvCategories);
            Controls.Add(btnClose);
            Name          = "CategoryManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text          = "Category Management";
            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
