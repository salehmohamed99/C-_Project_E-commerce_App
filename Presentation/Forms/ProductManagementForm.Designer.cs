namespace Presentation.Forms
{
    partial class ProductManagementForm
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
        private System.Windows.Forms.DataGridView dgvProducts;

        // ?? Footer ?????????????????????????????????????????????????????????????
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
            this.dgvProducts = new System.Windows.Forms.DataGridView();

            this.btnClose = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();

            // ??????????????????????????????????????????????????????????????????
            //  PALETTE
            // ??????????????????????????????????????????????????????????????????
            var clrDark = System.Drawing.Color.FromArgb(15, 17, 26);
            var clrAccent = System.Drawing.Color.FromArgb(20, 184, 166); // Teal for products
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
            this.lblTitleIcon.Text = "";
            this.lblTitleIcon.Font = new System.Drawing.Font("Segoe UI Symbol", 20F);
            this.lblTitleIcon.ForeColor = clrAccent;
            this.lblTitleIcon.Location = new System.Drawing.Point(24, 16);
            this.lblTitleIcon.Size = new System.Drawing.Size(36, 36);
            this.lblTitleIcon.BackColor = System.Drawing.Color.Transparent;

            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Product Management";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = clrWhite;
            this.lblTitle.Location = new System.Drawing.Point(66, 16);
            this.lblTitle.Size = new System.Drawing.Size(360, 26);
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;

            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Text = "Create, configure and manage your product catalogue";
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
            this.pnlGridCard.Location = new System.Drawing.Point(24, 80);
            this.pnlGridCard.Size = new System.Drawing.Size(1050, 550);
            this.pnlGridCard.BackColor = clrWhite;
            this.pnlGridCard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Text = "ALL PRODUCTS";
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = clrTextMuted;
            this.lblGridTitle.Location = new System.Drawing.Point(18, 14);
            this.lblGridTitle.Size = new System.Drawing.Size(200, 16);
            this.lblGridTitle.BackColor = System.Drawing.Color.Transparent;

            // ?? DataGridView ???????????????????????????????????????????????????
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Location = new System.Drawing.Point(0, 36);
            this.dgvProducts.Size = new System.Drawing.Size(1050, 514);
            this.dgvProducts.AutoGenerateColumns = false;
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.BackgroundColor = clrWhite;
            this.dgvProducts.GridColor = clrBorder;
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProducts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvProducts.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvProducts.EnableHeadersVisualStyles = false;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProducts.ColumnHeadersHeight = 44;
            this.dgvProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProducts.RowTemplate.Height = 60;
            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentClick);

            var pnlGridDivider = new System.Windows.Forms.Panel();
            pnlGridDivider.Location = new System.Drawing.Point(0, 34);
            pnlGridDivider.Size = new System.Drawing.Size(1050, 1);
            pnlGridDivider.BackColor = clrBorder;
            pnlGridDivider.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.pnlGridCard.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblGridTitle, pnlGridDivider, this.dgvProducts
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

            this.btnClose.Name = "btnClose";
            this.btnClose.Text = "Close";
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = clrTextPrimary;
            this.btnClose.BackColor = clrWhite;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderColor = clrBorder;
            this.btnClose.FlatAppearance.BorderSize = 1;
            this.btnClose.Location = new System.Drawing.Point(954, 14);
            this.btnClose.Size = new System.Drawing.Size(120, 36);
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.pnlFooter.Controls.Add(this.btnClose);

            // ??????????????????????????????????????????????????????????????????
            //  FORM
            // ??????????????????????????????????????????????????????????????????
            this.ClientSize = new System.Drawing.Size(1100, 750);
            this.BackColor = clrContent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.MaximizeBox = true;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlTopBar);
            this.Text = "NexAdmin — Product Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}