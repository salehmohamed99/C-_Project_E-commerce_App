//namespace Presentation.Forms
//{
//    partial class CategoryManagementForm
//    {
//        private System.ComponentModel.IContainer components = null;

//        private System.Windows.Forms.Panel pnlHeader;
//        private System.Windows.Forms.Label lblTitle;
//        private System.Windows.Forms.Label lblName;
//        private System.Windows.Forms.TextBox txtName;
//        private System.Windows.Forms.Button btnAdd;
//        private System.Windows.Forms.DataGridView dgvCategories;
//        private System.Windows.Forms.Button btnClose;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//                components.Dispose();
//            base.Dispose(disposing);
//        }

//        private void InitializeComponent()
//        {
//            pnlHeader     = new Panel();
//            lblTitle      = new Label();
//            lblName       = new Label();
//            txtName       = new TextBox();
//            btnAdd        = new Button();
//            dgvCategories = new DataGridView();
//            btnClose      = new Button();
//            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
//            SuspendLayout();

//            // ???????????????????????????????????????
//            //  Header Panel
//            // ???????????????????????????????????????
//            pnlHeader.Dock      = DockStyle.Top;
//            pnlHeader.Height    = 60;
//            pnlHeader.BackColor = Color.FromArgb(45, 62, 80);

//            lblTitle.Text      = "Manage Categories";
//            lblTitle.Font      = new Font("Segoe UI", 18F, FontStyle.Bold);
//            lblTitle.ForeColor = Color.White;
//            lblTitle.Location  = new Point(25, 12);
//            lblTitle.AutoSize  = true;
//            lblTitle.BackColor = Color.Transparent;

//            pnlHeader.Controls.Add(lblTitle);

//            // ???????????????????????????????????????
//            //  Input Area
//            // ???????????????????????????????????????
//            lblName.Text      = "Category Name:";
//            lblName.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
//            lblName.ForeColor = Color.FromArgb(45, 62, 80);
//            lblName.Location  = new Point(25, 78);
//            lblName.AutoSize  = true;

//            txtName.Location    = new Point(160, 75);
//            txtName.Size        = new Size(300, 30);
//            txtName.Font        = new Font("Segoe UI", 10.5F);
//            txtName.BorderStyle = BorderStyle.FixedSingle;

//            btnAdd.Text      = "Add Category";
//            btnAdd.Location  = new Point(475, 72);
//            btnAdd.Size      = new Size(170, 38);
//            btnAdd.FlatStyle = FlatStyle.Flat;
//            btnAdd.BackColor = Color.FromArgb(39, 174, 96);
//            btnAdd.ForeColor = Color.White;
//            btnAdd.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
//            btnAdd.Cursor    = Cursors.Hand;
//            btnAdd.FlatAppearance.BorderSize = 0;
//            btnAdd.Click    += btnAdd_Click;

//            // ???????????????????????????????????????
//            //  DataGridView — Categories
//            // ???????????????????????????????????????
//            dgvCategories.Location            = new Point(25, 125);
//            dgvCategories.Size                = new Size(660, 330);
//            dgvCategories.AutoGenerateColumns = false;
//            dgvCategories.AllowUserToAddRows  = false;
//            dgvCategories.RowHeadersVisible   = false;
//            dgvCategories.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
//            dgvCategories.MultiSelect         = false;
//            dgvCategories.BackgroundColor     = Color.White;
//            dgvCategories.GridColor           = Color.FromArgb(230, 230, 230);
//            dgvCategories.BorderStyle         = BorderStyle.None;
//            dgvCategories.CellBorderStyle     = DataGridViewCellBorderStyle.SingleHorizontal;
//            dgvCategories.EnableHeadersVisualStyles = false;
//            dgvCategories.ColumnHeadersHeight      = 42;
//            dgvCategories.ColumnHeadersBorderStyle  = DataGridViewHeaderBorderStyle.None;
//            dgvCategories.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
//            {
//                BackColor = Color.FromArgb(45, 62, 80),
//                ForeColor = Color.White,
//                Font      = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
//                Alignment = DataGridViewContentAlignment.MiddleCenter,
//                Padding   = new Padding(0)
//            };
//            dgvCategories.DefaultCellStyle = new DataGridViewCellStyle
//            {
//                Font               = new Font("Segoe UI", 9.75F),
//                Padding            = new Padding(6, 4, 6, 4),
//                Alignment          = DataGridViewContentAlignment.MiddleCenter,
//                SelectionBackColor = Color.FromArgb(214, 234, 248),
//                SelectionForeColor = Color.FromArgb(45, 62, 80)
//            };
//            dgvCategories.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
//            {
//                BackColor          = Color.FromArgb(245, 247, 250),
//                SelectionBackColor = Color.FromArgb(214, 234, 248),
//                SelectionForeColor = Color.FromArgb(45, 62, 80)
//            };
//            dgvCategories.RowTemplate.Height = 40;
//            dgvCategories.CellContentClick  += dgvCategories_CellContentClick;

//            // ???????????????????????????????????????
//            //  Close Button
//            // ???????????????????????????????????????
//            btnClose.Text      = "Close";
//            btnClose.Location  = new Point(565, 470);
//            btnClose.Size      = new Size(120, 40);
//            btnClose.FlatStyle = FlatStyle.Flat;
//            btnClose.BackColor = Color.FromArgb(45, 62, 80);
//            btnClose.ForeColor = Color.White;
//            btnClose.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
//            btnClose.Cursor    = Cursors.Hand;
//            btnClose.FlatAppearance.BorderSize = 0;
//            btnClose.Click    += btnClose_Click;

//            // ???????????????????????????????????????
//            //  CategoryManagementForm
//            // ???????????????????????????????????????
//            AutoScaleDimensions = new SizeF(8F, 20F);
//            AutoScaleMode       = AutoScaleMode.Font;
//            ClientSize          = new Size(710, 525);
//            BackColor           = Color.FromArgb(245, 247, 250);
//            FormBorderStyle     = FormBorderStyle.FixedDialog;
//            MaximizeBox         = false;
//            Controls.Add(pnlHeader);
//            Controls.Add(lblName);
//            Controls.Add(txtName);
//            Controls.Add(btnAdd);
//            Controls.Add(dgvCategories);
//            Controls.Add(btnClose);
//            Name          = "CategoryManagementForm";
//            StartPosition = FormStartPosition.CenterScreen;
//            Text          = "Category Management";
//            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
//            ResumeLayout(false);
//            PerformLayout();
//        }
//    }
//}


namespace Presentation.Forms
{
    partial class CategoryManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        // ── Layout ─────────────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Panel pnlTopAccent;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlInputCard;
        private System.Windows.Forms.Panel pnlGridCard;
        private System.Windows.Forms.Panel pnlFooter;

        // ── Top Bar ────────────────────────────────────────────────────────────
        private System.Windows.Forms.Label lblTitleIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblRecordCount;

        // ── Input Card ─────────────────────────────────────────────────────────
        private System.Windows.Forms.Label lblInputCardTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancelEdit;
        private System.Windows.Forms.Label lblInputHint;

        // ── Grid ───────────────────────────────────────────────────────────────
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.DataGridView dgvCategories;

        // ── Footer ─────────────────────────────────────────────────────────────
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblFooterNote;

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
            this.pnlInputCard = new System.Windows.Forms.Panel();
            this.pnlGridCard = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();

            this.lblTitleIcon = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblRecordCount = new System.Windows.Forms.Label();

            this.lblInputCardTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.lblInputHint = new System.Windows.Forms.Label();

            this.lblGridTitle = new System.Windows.Forms.Label();
            this.dgvCategories = new System.Windows.Forms.DataGridView();

            this.btnClose = new System.Windows.Forms.Button();
            this.lblFooterNote = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)this.dgvCategories).BeginInit();
            this.SuspendLayout();

            // ══════════════════════════════════════════════════════════════════
            //  PALETTE  (consistent with AdminMainForm)
            // ══════════════════════════════════════════════════════════════════
            var clrDark = System.Drawing.Color.FromArgb(15, 17, 26);
            var clrAccent = System.Drawing.Color.FromArgb(99, 102, 241);
            var clrAccentDark = System.Drawing.Color.FromArgb(79, 82, 200);
            var clrAccentSoft = System.Drawing.Color.FromArgb(238, 242, 255);
            var clrTopBar = System.Drawing.Color.FromArgb(250, 251, 254);
            var clrContent = System.Drawing.Color.FromArgb(243, 245, 250);
            var clrWhite = System.Drawing.Color.White;
            var clrTextPrimary = System.Drawing.Color.FromArgb(17, 24, 39);
            var clrTextMuted = System.Drawing.Color.FromArgb(107, 114, 128);
            var clrBorder = System.Drawing.Color.FromArgb(229, 231, 235);
            var clrSuccess = System.Drawing.Color.FromArgb(16, 185, 129);
            var clrDanger = System.Drawing.Color.FromArgb(239, 68, 68);
            var clrDangerSoft = System.Drawing.Color.FromArgb(254, 242, 242);
            var clrGridHeader = System.Drawing.Color.FromArgb(248, 249, 252);
            var clrGridAlt = System.Drawing.Color.FromArgb(250, 251, 254);
            var clrGridSelect = System.Drawing.Color.FromArgb(238, 242, 255);

            // ══════════════════════════════════════════════════════════════════
            //  TOP BAR
            // ══════════════════════════════════════════════════════════════════
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Height = 72;
            this.pnlTopBar.BackColor = clrDark;

            // 4 px indigo accent strip along bottom of top bar
            this.pnlTopAccent.Name = "pnlTopAccent";
            this.pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTopAccent.Height = 3;
            this.pnlTopAccent.BackColor = clrAccent;
            this.pnlTopBar.Controls.Add(this.pnlTopAccent);

            this.lblTitleIcon.Name = "lblTitleIcon";
            this.lblTitleIcon.Text = "▤";
            this.lblTitleIcon.Font = new System.Drawing.Font("Segoe UI Symbol", 20F);
            this.lblTitleIcon.ForeColor = clrAccent;
            this.lblTitleIcon.Location = new System.Drawing.Point(24, 16);
            this.lblTitleIcon.Size = new System.Drawing.Size(36, 36);
            this.lblTitleIcon.BackColor = System.Drawing.Color.Transparent;

            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Category Management";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = clrWhite;
            this.lblTitle.Location = new System.Drawing.Point(66, 16);
            this.lblTitle.Size = new System.Drawing.Size(360, 26);
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;

            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Text = "Create, edit and remove product categories";
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
            this.lblSubtitle.Location = new System.Drawing.Point(68, 42);
            this.lblSubtitle.Size = new System.Drawing.Size(360, 18);
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;

            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Text = "0 categories";
            this.lblRecordCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRecordCount.ForeColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.lblRecordCount.Size = new System.Drawing.Size(140, 18);
            this.lblRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRecordCount.BackColor = System.Drawing.Color.Transparent;
            this.lblRecordCount.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblRecordCount.Location = new System.Drawing.Point(620, 27);

            this.pnlTopBar.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitleIcon, this.lblTitle, this.lblSubtitle, this.lblRecordCount
            });

            // ══════════════════════════════════════════════════════════════════
            //  CONTENT PANEL
            // ══════════════════════════════════════════════════════════════════
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.BackColor = clrContent;

            // ══════════════════════════════════════════════════════════════════
            //  INPUT CARD
            // ══════════════════════════════════════════════════════════════════
            this.pnlInputCard.Name = "pnlInputCard";
            this.pnlInputCard.Location = new System.Drawing.Point(24, 20);
            this.pnlInputCard.Size = new System.Drawing.Size(736, 100);
            this.pnlInputCard.BackColor = clrWhite;

            // Input card top accent strip
            var pnlInputAccent = new System.Windows.Forms.Panel();
            pnlInputAccent.Dock = System.Windows.Forms.DockStyle.Top;
            pnlInputAccent.Height = 3;
            pnlInputAccent.BackColor = clrAccent;
            this.pnlInputCard.Controls.Add(pnlInputAccent);

            this.lblInputCardTitle.Name = "lblInputCardTitle";
            this.lblInputCardTitle.Text = "ADD NEW CATEGORY";
            this.lblInputCardTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblInputCardTitle.ForeColor = clrTextMuted;
            this.lblInputCardTitle.Location = new System.Drawing.Point(18, 14);
            this.lblInputCardTitle.Size = new System.Drawing.Size(200, 16);
            this.lblInputCardTitle.BackColor = System.Drawing.Color.Transparent;

            this.lblName.Name = "lblName";
            this.lblName.Text = "Name";
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = clrTextPrimary;
            this.lblName.Location = new System.Drawing.Point(18, 38);
            this.lblName.Size = new System.Drawing.Size(50, 18);
            this.lblName.BackColor = System.Drawing.Color.Transparent;

            this.txtName.Name = "txtName";
            this.txtName.Location = new System.Drawing.Point(72, 34);
            this.txtName.Size = new System.Drawing.Size(320, 28);
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.txtName.ForeColor = clrTextPrimary;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);

            this.lblInputHint.Name = "lblInputHint";
            this.lblInputHint.Text = "Press Enter to submit";
            this.lblInputHint.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblInputHint.ForeColor = clrTextMuted;
            this.lblInputHint.Location = new System.Drawing.Point(72, 66);
            this.lblInputHint.Size = new System.Drawing.Size(160, 16);
            this.lblInputHint.BackColor = System.Drawing.Color.Transparent;

            // Add / Update button
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Text = "+ Add Category";
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = clrWhite;
            this.btnAdd.BackColor = clrAccent;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseOverBackColor = clrAccentDark;
            this.btnAdd.Location = new System.Drawing.Point(408, 30);
            this.btnAdd.Size = new System.Drawing.Size(158, 38);
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // Cancel edit button (hidden by default)
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Text = "✕ Cancel";
            this.btnCancelEdit.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelEdit.ForeColor = clrTextMuted;
            this.btnCancelEdit.BackColor = clrWhite;
            this.btnCancelEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelEdit.FlatAppearance.BorderColor = clrBorder;
            this.btnCancelEdit.FlatAppearance.BorderSize = 1;
            this.btnCancelEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.btnCancelEdit.Location = new System.Drawing.Point(574, 30);
            this.btnCancelEdit.Size = new System.Drawing.Size(90, 38);
            this.btnCancelEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelEdit.Visible = false;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);

            this.pnlInputCard.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblInputCardTitle, this.lblName, this.txtName,
                this.lblInputHint, this.btnAdd, this.btnCancelEdit
            });

            // ══════════════════════════════════════════════════════════════════
            //  GRID CARD
            // ══════════════════════════════════════════════════════════════════
            this.pnlGridCard.Name = "pnlGridCard";
            this.pnlGridCard.Location = new System.Drawing.Point(24, 136);
            this.pnlGridCard.Size = new System.Drawing.Size(736, 356);
            this.pnlGridCard.BackColor = clrWhite;

            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Text = "ALL CATEGORIES";
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = clrTextMuted;
            this.lblGridTitle.Location = new System.Drawing.Point(18, 14);
            this.lblGridTitle.Size = new System.Drawing.Size(200, 16);
            this.lblGridTitle.BackColor = System.Drawing.Color.Transparent;

            // ── DataGridView ───────────────────────────────────────────────────
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.Location = new System.Drawing.Point(0, 36);
            this.dgvCategories.Size = new System.Drawing.Size(736, 320);
            this.dgvCategories.AutoGenerateColumns = false;
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.ReadOnly = false;
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.BackgroundColor = clrWhite;
            this.dgvCategories.GridColor = clrBorder;
            this.dgvCategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCategories.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCategories.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCategories.Anchor = System.Windows.Forms.AnchorStyles.Top
                                                     | System.Windows.Forms.AnchorStyles.Bottom
                                                     | System.Windows.Forms.AnchorStyles.Left
                                                     | System.Windows.Forms.AnchorStyles.Right;

            this.dgvCategories.EnableHeadersVisualStyles = false;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCategories.ColumnHeadersHeight = 44;
            this.dgvCategories.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCategories.ColumnHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
            {
                BackColor = clrGridHeader,
                ForeColor = clrTextMuted,
                Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold),
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
                Padding = new System.Windows.Forms.Padding(12, 0, 0, 0),
                SelectionBackColor = clrGridHeader,
                SelectionForeColor = clrTextMuted
            };
            this.dgvCategories.DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
            {
                Font = new System.Drawing.Font("Segoe UI", 9.5F),
                Padding = new System.Windows.Forms.Padding(12, 0, 12, 0),
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
                SelectionBackColor = clrGridSelect,
                SelectionForeColor = clrTextPrimary,
                ForeColor = clrTextPrimary,
                BackColor = clrWhite
            };
            this.dgvCategories.AlternatingRowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
            {
                BackColor = clrGridAlt,
                SelectionBackColor = clrGridSelect,
                SelectionForeColor = clrTextPrimary,
                ForeColor = clrTextPrimary
            };
            this.dgvCategories.RowTemplate.Height = 46;
            this.dgvCategories.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellContentClick);
            this.dgvCategories.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCategories_CellPainting);

            // Top divider line above grid
            var pnlGridDivider = new System.Windows.Forms.Panel();
            pnlGridDivider.Location = new System.Drawing.Point(0, 34);
            pnlGridDivider.Size = new System.Drawing.Size(736, 1);
            pnlGridDivider.BackColor = clrBorder;

            this.pnlGridCard.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblGridTitle, pnlGridDivider, this.dgvCategories
            });

            // ══════════════════════════════════════════════════════════════════
            //  FOOTER
            // ══════════════════════════════════════════════════════════════════
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Location = new System.Drawing.Point(0, 506);
            this.pnlFooter.Size = new System.Drawing.Size(784, 56);
            this.pnlFooter.BackColor = clrContent;
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;

            // Top border
            var pnlFooterBorder = new System.Windows.Forms.Panel();
            pnlFooterBorder.Dock = System.Windows.Forms.DockStyle.Top;
            pnlFooterBorder.Height = 1;
            pnlFooterBorder.BackColor = clrBorder;
            this.pnlFooter.Controls.Add(pnlFooterBorder);

            this.lblFooterNote.Name = "lblFooterNote";
            this.lblFooterNote.Text = "Changes are saved immediately to the database.";
            this.lblFooterNote.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFooterNote.ForeColor = clrTextMuted;
            this.lblFooterNote.Location = new System.Drawing.Point(24, 18);
            this.lblFooterNote.Size = new System.Drawing.Size(380, 18);
            this.lblFooterNote.BackColor = System.Drawing.Color.Transparent;

            this.btnClose.Name = "btnClose";
            this.btnClose.Text = "Close";
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = clrTextPrimary;
            this.btnClose.BackColor = clrWhite;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderColor = clrBorder;
            this.btnClose.FlatAppearance.BorderSize = 1;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.btnClose.Location = new System.Drawing.Point(644, 10);
            this.btnClose.Size = new System.Drawing.Size(116, 38);
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.pnlFooter.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblFooterNote, this.btnClose
            });

            // ── Wire content panel ─────────────────────────────────────────────
            this.pnlContent.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.pnlInputCard, this.pnlGridCard
            });

            // ══════════════════════════════════════════════════════════════════
            //  FORM
            // ══════════════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.BackColor = clrContent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategoryManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Category Management";

            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlTopBar);

            ((System.ComponentModel.ISupportInitialize)this.dgvCategories).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}