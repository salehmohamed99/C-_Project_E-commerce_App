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
            this.components = new System.ComponentModel.Container();

            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.pnlTopAccent = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlGridCard = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();

            this.lblTitleIcon = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();

            this.lblGridTitle = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();

            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();

            // ??????????????????????????????????????????????????????????????????
            //  PALETTE
            // ??????????????????????????????????????????????????????????????????
            var clrDark = System.Drawing.Color.FromArgb(15, 17, 26);
            var clrAccent = System.Drawing.Color.FromArgb(245, 158, 11); // Amber for orders
            var clrContent = System.Drawing.Color.FromArgb(243, 245, 250);
            var clrWhite = System.Drawing.Color.White;
            var clrTextPrimary = System.Drawing.Color.FromArgb(17, 24, 39);
            var clrTextMuted = System.Drawing.Color.FromArgb(107, 114, 128);
            var clrBorder = System.Drawing.Color.FromArgb(229, 231, 235);

            // ??????????????????????????????????????????????????????????????????
            //  TOP BAR
            // ??????????????????????????????????????????????????????????????????
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Height = 72;
            this.pnlTopBar.BackColor = clrDark;

            this.pnlTopAccent.Name = "pnlTopAccent";
            this.pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTopAccent.Height = 3;
            this.pnlTopAccent.BackColor = clrAccent;
            this.pnlTopBar.Controls.Add(this.pnlTopAccent);

            this.lblTitleIcon.Name = "lblTitleIcon";
            this.lblTitleIcon.Text = "?";
            this.lblTitleIcon.Font = new System.Drawing.Font("Segoe UI Symbol", 20F);
            this.lblTitleIcon.ForeColor = clrAccent;
            this.lblTitleIcon.Location = new System.Drawing.Point(24, 16);
            this.lblTitleIcon.Size = new System.Drawing.Size(36, 36);
            this.lblTitleIcon.BackColor = System.Drawing.Color.Transparent;

            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Track & Manage Orders";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = clrWhite;
            this.lblTitle.Location = new System.Drawing.Point(66, 16);
            this.lblTitle.Size = new System.Drawing.Size(360, 26);
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;

            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Text = "View and update order statuses for all customers";
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
            this.lblSubtitle.Location = new System.Drawing.Point(68, 42);
            this.lblSubtitle.Size = new System.Drawing.Size(360, 18);
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;

            this.pnlTopBar.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitleIcon, this.lblTitle, this.lblSubtitle
            });

            // ??????????????????????????????????????????????????????????????????
            //  CONTENT PANEL
            // ??????????????????????????????????????????????????????????????????
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.BackColor = clrContent;

            // ??????????????????????????????????????????????????????????????????
            //  GRID CARD
            // ??????????????????????????????????????????????????????????????????
            this.pnlGridCard.Name = "pnlGridCard";
            this.pnlGridCard.Location = new System.Drawing.Point(24, 20);
            this.pnlGridCard.Size = new System.Drawing.Size(980, 480);
            this.pnlGridCard.BackColor = clrWhite;
            this.pnlGridCard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Text = "ALL ORDERS";
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = clrTextMuted;
            this.lblGridTitle.Location = new System.Drawing.Point(18, 14);
            this.lblGridTitle.Size = new System.Drawing.Size(200, 16);
            this.lblGridTitle.BackColor = System.Drawing.Color.Transparent;

            // ?? DataGridView ???????????????????????????????????????????????????
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.Location = new System.Drawing.Point(0, 36);
            this.dgvOrders.Size = new System.Drawing.Size(980, 444);
            this.dgvOrders.AutoGenerateColumns = false;
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.BackgroundColor = clrWhite;
            this.dgvOrders.GridColor = clrBorder;
            this.dgvOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOrders.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvOrders.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvOrders.EnableHeadersVisualStyles = false;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOrders.ColumnHeadersHeight = 44;
            this.dgvOrders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellContentClick);

            var pnlGridDivider = new System.Windows.Forms.Panel();
            pnlGridDivider.Location = new System.Drawing.Point(0, 34);
            pnlGridDivider.Size = new System.Drawing.Size(980, 1);
            pnlGridDivider.BackColor = clrBorder;
            pnlGridDivider.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.pnlGridCard.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblGridTitle, pnlGridDivider, this.dgvOrders
            });

            this.pnlContent.Controls.Add(this.pnlGridCard);

            // ??????????????????????????????????????????????????????????????????
            //  FOOTER
            // ??????????????????????????????????????????????????????????????????
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Height = 64;
            this.pnlFooter.BackColor = clrContent;
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;

            var pnlFooterBorder = new System.Windows.Forms.Panel();
            pnlFooterBorder.Dock = System.Windows.Forms.DockStyle.Top;
            pnlFooterBorder.Height = 1;
            pnlFooterBorder.BackColor = clrBorder;
            this.pnlFooter.Controls.Add(pnlFooterBorder);

            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Text = "? Refresh";
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = clrWhite;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Location = new System.Drawing.Point(24, 14);
            this.btnRefresh.Size = new System.Drawing.Size(120, 36);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.btnClose.Name = "btnClose";
            this.btnClose.Text = "Close";
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = clrTextPrimary;
            this.btnClose.BackColor = clrWhite;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderColor = clrBorder;
            this.btnClose.FlatAppearance.BorderSize = 1;
            this.btnClose.Location = new System.Drawing.Point(884, 14);
            this.btnClose.Size = new System.Drawing.Size(120, 36);
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.pnlFooter.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnRefresh, this.btnClose
            });

            // ??????????????????????????????????????????????????????????????????
            //  FORM
            // ??????????????????????????????????????????????????????????????????
            this.Load += new System.EventHandler(this.OrderTrackingForm_Load);
            this.ClientSize = new System.Drawing.Size(1030, 650);
            this.BackColor = clrContent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.MaximizeBox = true;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlTopBar);
            this.Text = "NexAdmin — Order Tracking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
