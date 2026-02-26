namespace Presentation.Forms
{
    partial class OrderTrackingForm
    {
        private System.ComponentModel.IContainer components = null;

        // ?? Layout ?????????????????????????????????????????????????????????????
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Panel pnlTopAccent;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlGridCard;
        private System.Windows.Forms.Panel pnlFooter;

        // ?? Top Bar ????????????????????????????????????????????????????????????
        private System.Windows.Forms.Label lblTitleIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;

        // ?? Grid ???????????????????????????????????????????????????????????????
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.DataGridView dgvOrders;

        // ?? Footer ?????????????????????????????????????????????????????????????
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlTopBar = new Panel();
            pnlTopAccent = new Panel();
            lblTitleIcon = new Label();
            lblTitle = new Label();
            lblSubtitle = new Label();
            pnlContent = new Panel();
            pnlGridCard = new Panel();
            lblGridTitle = new Label();
            pnlGridDivider = new Panel();
            dgvOrders = new DataGridView();
            pnlFooter = new Panel();
            pnlFooterBorder = new Panel();
            btnRefresh = new Button();
            btnClose = new Button();
            pnlTopBar.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlGridCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTopBar
            // 
            pnlTopBar.BackColor = Color.FromArgb(15, 17, 26);
            pnlTopBar.Controls.Add(pnlTopAccent);
            pnlTopBar.Controls.Add(lblTitleIcon);
            pnlTopBar.Controls.Add(lblTitle);
            pnlTopBar.Controls.Add(lblSubtitle);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(0, 0);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(1030, 72);
            pnlTopBar.TabIndex = 2;
            // 
            // pnlTopAccent
            // 
            pnlTopAccent.BackColor = Color.FromArgb(245, 158, 11);
            pnlTopAccent.Dock = DockStyle.Bottom;
            pnlTopAccent.Location = new Point(0, 69);
            pnlTopAccent.Name = "pnlTopAccent";
            pnlTopAccent.Size = new Size(1030, 3);
            pnlTopAccent.TabIndex = 0;
            // 
            // lblTitleIcon
            // 
            lblTitleIcon.BackColor = Color.Transparent;
            lblTitleIcon.Font = new Font("Segoe UI Symbol", 20F);
            lblTitleIcon.ForeColor = Color.FromArgb(245, 158, 11);
            lblTitleIcon.Location = new Point(24, 16);
            lblTitleIcon.Name = "lblTitleIcon";
            lblTitleIcon.Size = new Size(36, 36);
            lblTitleIcon.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(66, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(360, 26);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Track & Manage Orders";
            // 
            // lblSubtitle
            // 
            lblSubtitle.BackColor = Color.Transparent;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(156, 163, 175);
            lblSubtitle.Location = new Point(68, 42);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(360, 18);
            lblSubtitle.TabIndex = 3;
            lblSubtitle.Text = "View and update order statuses for all customers";
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(243, 245, 250);
            pnlContent.Controls.Add(pnlGridCard);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 72);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1030, 514);
            pnlContent.TabIndex = 0;
            // 
            // pnlGridCard
            // 
            pnlGridCard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGridCard.BackColor = Color.White;
            pnlGridCard.Controls.Add(lblGridTitle);
            pnlGridCard.Controls.Add(pnlGridDivider);
            pnlGridCard.Controls.Add(dgvOrders);
            pnlGridCard.Location = new Point(24, 20);
            pnlGridCard.Name = "pnlGridCard";
            pnlGridCard.Size = new Size(1810, 894);
            pnlGridCard.TabIndex = 0;
            // 
            // lblGridTitle
            // 
            lblGridTitle.BackColor = Color.Transparent;
            lblGridTitle.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblGridTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblGridTitle.Location = new Point(18, 14);
            lblGridTitle.Name = "lblGridTitle";
            lblGridTitle.Size = new Size(200, 16);
            lblGridTitle.TabIndex = 0;
            lblGridTitle.Text = "ALL ORDERS";
            // 
            // pnlGridDivider
            // 
            pnlGridDivider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlGridDivider.BackColor = Color.FromArgb(229, 231, 235);
            pnlGridDivider.Location = new Point(0, 34);
            pnlGridDivider.Name = "pnlGridDivider";
            pnlGridDivider.Size = new Size(1810, 1);
            pnlGridDivider.TabIndex = 1;
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOrders.BackgroundColor = Color.White;
            dgvOrders.BorderStyle = BorderStyle.None;
            dgvOrders.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvOrders.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvOrders.ColumnHeadersHeight = 44;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvOrders.EnableHeadersVisualStyles = false;
            dgvOrders.GridColor = Color.FromArgb(229, 231, 235);
            dgvOrders.Location = new Point(16, 50);
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.ScrollBars = ScrollBars.Vertical;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(978, 858);
            dgvOrders.TabIndex = 2;
            dgvOrders.CellContentClick += dgvOrders_CellContentClick;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(243, 245, 250);
            pnlFooter.Controls.Add(pnlFooterBorder);
            pnlFooter.Controls.Add(btnRefresh);
            pnlFooter.Controls.Add(btnClose);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 586);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1030, 64);
            pnlFooter.TabIndex = 1;
            // 
            // pnlFooterBorder
            // 
            pnlFooterBorder.BackColor = Color.FromArgb(229, 231, 235);
            pnlFooterBorder.Dock = DockStyle.Top;
            pnlFooterBorder.Location = new Point(0, 0);
            pnlFooterBorder.Name = "pnlFooterBorder";
            pnlFooterBorder.Size = new Size(1030, 1);
            pnlFooterBorder.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(24, 14);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 36);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.White;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(17, 24, 39);
            btnClose.Location = new Point(1714, 14);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 36);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // OrderTrackingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 245, 250);
            ClientSize = new Size(1030, 650);
            Controls.Add(pnlContent);
            Controls.Add(pnlFooter);
            Controls.Add(pnlTopBar);
            MinimumSize = new Size(800, 500);
            Name = "OrderTrackingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NexAdmin — Order Tracking";
            Load += OrderTrackingForm_Load;
            pnlTopBar.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlGridCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel pnlGridDivider;
        private Panel pnlFooterBorder;
    }
}
