namespace Presentation.Forms
{
    partial class ProductManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlInputs;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblUnits;
        private System.Windows.Forms.TextBox txtUnits;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlInputs = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblUnits = new System.Windows.Forms.Label();
            this.txtUnits = new System.Windows.Forms.TextBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)this.dgvProducts).BeginInit();
            this.SuspendLayout();

            // ???????????????????????????????????????
            //  Header Panel
            // ???????????????????????????????????????
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 60;
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(45, 62, 80);

            this.lblTitle.Text = "Manage Products";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(25, 12);
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;

            this.pnlHeader.Controls.Add(this.lblTitle);

            // ???????????????????????????????????????
            //  Inputs Panel (card-style)
            // ???????????????????????????????????????
            this.pnlInputs.Location = new System.Drawing.Point(25, 75);
            this.pnlInputs.Size = new System.Drawing.Size(920, 135);
            this.pnlInputs.BackColor = System.Drawing.Color.White;
            this.pnlInputs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            var inputFont = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            var fieldFont = new System.Drawing.Font("Segoe UI", 10F);
            var labelColor = System.Drawing.Color.FromArgb(45, 62, 80);

            // Row 1
            this.lblName.Text = "Name:";
            this.lblName.Font = inputFont;
            this.lblName.ForeColor = labelColor;
            this.lblName.Location = new System.Drawing.Point(12, 14);
            this.lblName.AutoSize = true;

            this.txtName.Location = new System.Drawing.Point(70, 11);
            this.txtName.Size = new System.Drawing.Size(160, 28);
            this.txtName.Font = fieldFont;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblPrice.Text = "Price:";
            this.lblPrice.Font = inputFont;
            this.lblPrice.ForeColor = labelColor;
            this.lblPrice.Location = new System.Drawing.Point(245, 14);
            this.lblPrice.AutoSize = true;

            this.txtPrice.Location = new System.Drawing.Point(298, 11);
            this.txtPrice.Size = new System.Drawing.Size(100, 28);
            this.txtPrice.Font = fieldFont;
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblCategory.Text = "Category:";
            this.lblCategory.Font = inputFont;
            this.lblCategory.ForeColor = labelColor;
            this.lblCategory.Location = new System.Drawing.Point(415, 14);
            this.lblCategory.AutoSize = true;

            this.cbCategory.Location = new System.Drawing.Point(498, 11);
            this.cbCategory.Size = new System.Drawing.Size(170, 28);
            this.cbCategory.Font = fieldFont;
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Row 2
            this.lblDescription.Text = "Description:";
            this.lblDescription.Font = inputFont;
            this.lblDescription.ForeColor = labelColor;
            this.lblDescription.Location = new System.Drawing.Point(12, 50);
            this.lblDescription.AutoSize = true;

            this.txtDescription.Location = new System.Drawing.Point(105, 47);
            this.txtDescription.Size = new System.Drawing.Size(563, 28);
            this.txtDescription.Font = fieldFont;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Row 3
            this.lblUnits.Text = "Stock:";
            this.lblUnits.Font = inputFont;
            this.lblUnits.ForeColor = labelColor;
            this.lblUnits.Location = new System.Drawing.Point(12, 90);
            this.lblUnits.AutoSize = true;

            this.txtUnits.Location = new System.Drawing.Point(65, 87);
            this.txtUnits.Size = new System.Drawing.Size(80, 28);
            this.txtUnits.Font = fieldFont;
            this.txtUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblImage.Text = "Image:";
            this.lblImage.Font = inputFont;
            this.lblImage.ForeColor = labelColor;
            this.lblImage.Location = new System.Drawing.Point(165, 90);
            this.lblImage.AutoSize = true;

            this.txtImage.Location = new System.Drawing.Point(222, 87);
            this.txtImage.Size = new System.Drawing.Size(260, 28);
            this.txtImage.Font = fieldFont;
            this.txtImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImage.ReadOnly = true;

            this.btnBrowseImage.Text = "Browse...";
            this.btnBrowseImage.Location = new System.Drawing.Point(490, 86);
            this.btnBrowseImage.Size = new System.Drawing.Size(90, 30);
            this.btnBrowseImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseImage.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnBrowseImage.ForeColor = System.Drawing.Color.White;
            this.btnBrowseImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBrowseImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseImage.FlatAppearance.BorderSize = 0;
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);

            // Add button inside panel
            this.btnAdd.Text = "Add Product";
            this.btnAdd.Location = new System.Drawing.Point(700, 40);
            this.btnAdd.Size = new System.Drawing.Size(200, 50);
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.pnlInputs.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblName, this.txtName,
                this.lblPrice, this.txtPrice,
                this.lblCategory, this.cbCategory,
                this.lblDescription, this.txtDescription,
                this.lblUnits, this.txtUnits,
                this.lblImage, this.txtImage, this.btnBrowseImage,
                this.btnAdd
            });

            // ???????????????????????????????????????
            //  DataGridView — Products
            // ???????????????????????????????????????
            this.dgvProducts.Location = new System.Drawing.Point(25, 225);
            this.dgvProducts.Size = new System.Drawing.Size(920, 340);
            this.dgvProducts.AutoGenerateColumns = false;
            this.dgvProducts.RowTemplate.Height = 60;
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.GridColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProducts.EnableHeadersVisualStyles = false;
            this.dgvProducts.ColumnHeadersHeight = 42;
            this.dgvProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProducts.ColumnHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(45, 62, 80),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold),
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter,
                Padding = new System.Windows.Forms.Padding(0)
            };
            this.dgvProducts.DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
            {
                Font = new System.Drawing.Font("Segoe UI", 9.75F),
                Padding = new System.Windows.Forms.Padding(4),
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = System.Drawing.Color.FromArgb(214, 234, 248),
                SelectionForeColor = System.Drawing.Color.FromArgb(45, 62, 80)
            };
            this.dgvProducts.AlternatingRowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(245, 247, 250),
                SelectionBackColor = System.Drawing.Color.FromArgb(214, 234, 248),
                SelectionForeColor = System.Drawing.Color.FromArgb(45, 62, 80)
            };

            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentClick);

            // ???????????????????????????????????????
            //  Close Button
            // ???????????????????????????????????????
            this.btnClose.Text = "Close";
            this.btnClose.Location = new System.Drawing.Point(825, 580);
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(45, 62, 80);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // ???????????????????????????????????????
            //  ProductManagementForm
            // ???????????????????????????????????????
            this.ClientSize = new System.Drawing.Size(970, 635);
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlInputs);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.btnClose);
            this.Text = "Product Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ((System.ComponentModel.ISupportInitialize)this.dgvProducts).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}


//namespace Presentation.Forms
//{
//    partial class ProductManagementForm
//    {
//        private System.ComponentModel.IContainer components = null;

//        // ?? Layout ?????????????????????????????????????????????????????????????
//        private System.Windows.Forms.Panel pnlTopBar;
//        private System.Windows.Forms.Panel pnlTopAccent;
//        private System.Windows.Forms.Panel pnlContent;
//        private System.Windows.Forms.Panel pnlInputCard;
//        private System.Windows.Forms.Panel pnlGridCard;
//        private System.Windows.Forms.Panel pnlFooter;

//        // ?? Top Bar ????????????????????????????????????????????????????????????
//        private System.Windows.Forms.Label lblTitleIcon;
//        private System.Windows.Forms.Label lblTitle;
//        private System.Windows.Forms.Label lblSubtitle;
//        private System.Windows.Forms.Label lblRecordCount;

//        // ?? Input Card ?????????????????????????????????????????????????????????
//        private System.Windows.Forms.Label lblInputCardTitle;

//        private System.Windows.Forms.Label lblName;
//        private System.Windows.Forms.TextBox txtName;

//        private System.Windows.Forms.Label lblPrice;
//        private System.Windows.Forms.TextBox txtPrice;

//        private System.Windows.Forms.Label lblCategory;
//        private System.Windows.Forms.ComboBox cbCategory;

//        private System.Windows.Forms.Label lblUnits;
//        private System.Windows.Forms.TextBox txtUnits;

//        private System.Windows.Forms.Label lblDescription;
//        private System.Windows.Forms.TextBox txtDescription;

//        private System.Windows.Forms.Label lblImage;
//        private System.Windows.Forms.TextBox txtImage;
//        private System.Windows.Forms.Button btnBrowseImage;
//        private System.Windows.Forms.Label lblImagePreviewIcon;

//        private System.Windows.Forms.Button btnAdd;
//        private System.Windows.Forms.Button btnCancelEdit;

//        // ?? Grid ???????????????????????????????????????????????????????????????
//        private System.Windows.Forms.Label lblGridTitle;
//        private System.Windows.Forms.DataGridView dgvProducts;

//        // ?? Footer ?????????????????????????????????????????????????????????????
//        private System.Windows.Forms.Button btnClose;
//        private System.Windows.Forms.Label lblFooterNote;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//                components.Dispose();
//            base.Dispose(disposing);
//        }

//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();

//            this.pnlTopBar = new System.Windows.Forms.Panel();
//            this.pnlTopAccent = new System.Windows.Forms.Panel();
//            this.pnlContent = new System.Windows.Forms.Panel();
//            this.pnlInputCard = new System.Windows.Forms.Panel();
//            this.pnlGridCard = new System.Windows.Forms.Panel();
//            this.pnlFooter = new System.Windows.Forms.Panel();

//            this.lblTitleIcon = new System.Windows.Forms.Label();
//            this.lblTitle = new System.Windows.Forms.Label();
//            this.lblSubtitle = new System.Windows.Forms.Label();
//            this.lblRecordCount = new System.Windows.Forms.Label();

//            this.lblInputCardTitle = new System.Windows.Forms.Label();
//            this.lblName = new System.Windows.Forms.Label();
//            this.txtName = new System.Windows.Forms.TextBox();
//            this.lblPrice = new System.Windows.Forms.Label();
//            this.txtPrice = new System.Windows.Forms.TextBox();
//            this.lblCategory = new System.Windows.Forms.Label();
//            this.cbCategory = new System.Windows.Forms.ComboBox();
//            this.lblUnits = new System.Windows.Forms.Label();
//            this.txtUnits = new System.Windows.Forms.TextBox();
//            this.lblDescription = new System.Windows.Forms.Label();
//            this.txtDescription = new System.Windows.Forms.TextBox();
//            this.lblImage = new System.Windows.Forms.Label();
//            this.txtImage = new System.Windows.Forms.TextBox();
//            this.btnBrowseImage = new System.Windows.Forms.Button();
//            this.lblImagePreviewIcon = new System.Windows.Forms.Label();
//            this.btnAdd = new System.Windows.Forms.Button();
//            this.btnCancelEdit = new System.Windows.Forms.Button();

//            this.lblGridTitle = new System.Windows.Forms.Label();
//            this.dgvProducts = new System.Windows.Forms.DataGridView();

//            this.btnClose = new System.Windows.Forms.Button();
//            this.lblFooterNote = new System.Windows.Forms.Label();

//            ((System.ComponentModel.ISupportInitialize)this.dgvProducts).BeginInit();
//            this.SuspendLayout();

//            // ??????????????????????????????????????????????????????????????????
//            //  PALETTE
//            // ??????????????????????????????????????????????????????????????????
//            var clrDark = System.Drawing.Color.FromArgb(15, 17, 26);
//            var clrAccent = System.Drawing.Color.FromArgb(99, 102, 241);
//            var clrAccentDark = System.Drawing.Color.FromArgb(79, 82, 200);
//            var clrTeal = System.Drawing.Color.FromArgb(20, 184, 166);
//            var clrContent = System.Drawing.Color.FromArgb(243, 245, 250);
//            var clrWhite = System.Drawing.Color.White;
//            var clrTextPrimary = System.Drawing.Color.FromArgb(17, 24, 39);
//            var clrTextMuted = System.Drawing.Color.FromArgb(107, 114, 128);
//            var clrBorder = System.Drawing.Color.FromArgb(229, 231, 235);
//            var clrFieldBg = System.Drawing.Color.FromArgb(249, 250, 251);
//            var clrGridHeader = System.Drawing.Color.FromArgb(248, 249, 252);
//            var clrGridAlt = System.Drawing.Color.FromArgb(250, 251, 254);
//            var clrGridSelect = System.Drawing.Color.FromArgb(238, 242, 255);
//            var clrDanger = System.Drawing.Color.FromArgb(239, 68, 68);
//            var clrSuccess = System.Drawing.Color.FromArgb(16, 185, 129);

//            // ??????????????????????????????????????????????????????????????????
//            //  TOP BAR
//            // ??????????????????????????????????????????????????????????????????
//            this.pnlTopBar.Name = "pnlTopBar";
//            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
//            this.pnlTopBar.Height = 72;
//            this.pnlTopBar.BackColor = clrDark;

//            this.pnlTopAccent.Name = "pnlTopAccent";
//            this.pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Bottom;
//            this.pnlTopAccent.Height = 3;
//            this.pnlTopAccent.BackColor = clrTeal;
//            this.pnlTopBar.Controls.Add(this.pnlTopAccent);

//            this.lblTitleIcon.Name = "lblTitleIcon";
//            this.lblTitleIcon.Text = "?";
//            this.lblTitleIcon.Font = new System.Drawing.Font("Segoe UI Symbol", 20F);
//            this.lblTitleIcon.ForeColor = clrTeal;
//            this.lblTitleIcon.Location = new System.Drawing.Point(24, 16);
//            this.lblTitleIcon.Size = new System.Drawing.Size(36, 36);
//            this.lblTitleIcon.BackColor = System.Drawing.Color.Transparent;

//            this.lblTitle.Name = "lblTitle";
//            this.lblTitle.Text = "Product Management";
//            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
//            this.lblTitle.ForeColor = clrWhite;
//            this.lblTitle.Location = new System.Drawing.Point(66, 16);
//            this.lblTitle.Size = new System.Drawing.Size(380, 26);
//            this.lblTitle.BackColor = System.Drawing.Color.Transparent;

//            this.lblSubtitle.Name = "lblSubtitle";
//            this.lblSubtitle.Text = "Create, configure and manage your product catalogue";
//            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
//            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
//            this.lblSubtitle.Location = new System.Drawing.Point(68, 42);
//            this.lblSubtitle.Size = new System.Drawing.Size(380, 18);
//            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;

//            this.lblRecordCount.Name = "lblRecordCount";
//            this.lblRecordCount.Text = "0 products";
//            this.lblRecordCount.Font = new System.Drawing.Font("Segoe UI", 9F);
//            this.lblRecordCount.ForeColor = clrTeal;
//            this.lblRecordCount.Size = new System.Drawing.Size(140, 18);
//            this.lblRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//            this.lblRecordCount.BackColor = System.Drawing.Color.Transparent;
//            this.lblRecordCount.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
//            this.lblRecordCount.Location = new System.Drawing.Point(830, 27);

//            this.pnlTopBar.Controls.AddRange(new System.Windows.Forms.Control[] {
//                this.lblTitleIcon, this.lblTitle, this.lblSubtitle, this.lblRecordCount
//            });

//            // ??????????????????????????????????????????????????????????????????
//            //  CONTENT PANEL
//            // ??????????????????????????????????????????????????????????????????
//            this.pnlContent.Name = "pnlContent";
//            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.pnlContent.BackColor = clrContent;

//            // ??????????????????????????????????????????????????????????????????
//            //  INPUT CARD
//            // ??????????????????????????????????????????????????????????????????
//            this.pnlInputCard.Name = "pnlInputCard";
//            this.pnlInputCard.Location = new System.Drawing.Point(24, 20);
//            this.pnlInputCard.Size = new System.Drawing.Size(952, 176);
//            this.pnlInputCard.BackColor = clrWhite;

//            var pnlInputAccent = new System.Windows.Forms.Panel();
//            pnlInputAccent.Dock = System.Windows.Forms.DockStyle.Top;
//            pnlInputAccent.Height = 3;
//            pnlInputAccent.BackColor = clrTeal;
//            this.pnlInputCard.Controls.Add(pnlInputAccent);

//            this.lblInputCardTitle.Name = "lblInputCardTitle";
//            this.lblInputCardTitle.Text = "ADD NEW PRODUCT";
//            this.lblInputCardTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
//            this.lblInputCardTitle.ForeColor = clrTextMuted;
//            this.lblInputCardTitle.Location = new System.Drawing.Point(18, 14);
//            this.lblInputCardTitle.Size = new System.Drawing.Size(220, 16);
//            this.lblInputCardTitle.BackColor = System.Drawing.Color.Transparent;

//            // ?? Helper: field label ????????????????????????????????????????????
//            System.Windows.Forms.Label MakeLabel(string text, int x, int y)
//            {
//                var l = new System.Windows.Forms.Label();
//                l.Text = text;
//                l.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
//                l.ForeColor = clrTextMuted;
//                l.Location = new System.Drawing.Point(x, y);
//                l.AutoSize = true;
//                l.BackColor = System.Drawing.Color.Transparent;
//                return l;
//            }

//            // ?? Helper: text box ???????????????????????????????????????????????
//            System.Windows.Forms.TextBox MakeField(int x, int y, int w, bool readOnly = false)
//            {
//                var t = new System.Windows.Forms.TextBox();
//                t.Location = new System.Drawing.Point(x, y);
//                t.Size = new System.Drawing.Size(w, 30);
//                t.Font = new System.Drawing.Font("Segoe UI", 10F);
//                t.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//                t.BackColor = clrFieldBg;
//                t.ForeColor = clrTextPrimary;
//                t.ReadOnly = readOnly;
//                return t;
//            }

//            // ?? ROW 1: Name | Price | Category | Stock ?????????????????????????
//            int row1y = 34, row1lbl = 18;
//            int col1x = 18, col2x = 256, col3x = 458, col4x = 678;

//            this.lblName = MakeLabel("PRODUCT NAME", col1x, row1lbl);
//            this.txtName = MakeField(col1x, row1y, 220);
//            this.txtName.Name = "txtName";

//            this.lblPrice = MakeLabel("PRICE (EGP)", col2x, row1lbl);
//            this.txtPrice = MakeField(col2x, row1y, 180);
//            this.txtPrice.Name = "txtPrice";

//            this.lblCategory = MakeLabel("CATEGORY", col3x, row1lbl);
//            this.cbCategory.Name = "cbCategory";
//            this.cbCategory.Location = new System.Drawing.Point(col3x, row1y);
//            this.cbCategory.Size = new System.Drawing.Size(200, 30);
//            this.cbCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
//            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cbCategory.BackColor = clrFieldBg;
//            this.cbCategory.ForeColor = clrTextPrimary;
//            this.cbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

//            this.lblUnits = MakeLabel("STOCK QTY", col4x, row1lbl);
//            this.txtUnits = MakeField(col4x, row1y, 112);
//            this.txtUnits.Name = "txtUnits";

//            // ?? ROW 2: Description | Image ?????????????????????????????????????
//            int row2lbl = 82, row2y = 98;

//            this.lblDescription = MakeLabel("DESCRIPTION", col1x, row2lbl);
//            this.txtDescription = MakeField(col1x, row2y, 456);
//            this.txtDescription.Name = "txtDescription";

//            this.lblImage = MakeLabel("IMAGE PATH", col3x, row2lbl);
//            this.txtImage = MakeField(col3x, row2y, 240, readOnly: true);
//            this.txtImage.Name = "txtImage";

//            this.lblImagePreviewIcon.Name = "lblImagePreviewIcon";
//            this.lblImagePreviewIcon.Text = "??";
//            this.lblImagePreviewIcon.Font = new System.Drawing.Font("Segoe UI Symbol", 9F);
//            this.lblImagePreviewIcon.ForeColor = clrTextMuted;
//            this.lblImagePreviewIcon.Location = new System.Drawing.Point(col3x + 244, row2y + 5);
//            this.lblImagePreviewIcon.Size = new System.Drawing.Size(22, 22);
//            this.lblImagePreviewIcon.BackColor = System.Drawing.Color.Transparent;

//            this.btnBrowseImage.Name = "btnBrowseImage";
//            this.btnBrowseImage.Text = "Browse";
//            this.btnBrowseImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
//            this.btnBrowseImage.ForeColor = clrAccent;
//            this.btnBrowseImage.BackColor = System.Drawing.Color.FromArgb(238, 242, 255);
//            this.btnBrowseImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnBrowseImage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(199, 210, 254);
//            this.btnBrowseImage.FlatAppearance.BorderSize = 1;
//            this.btnBrowseImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(224, 231, 255);
//            this.btnBrowseImage.Location = new System.Drawing.Point(col3x + 270, row2y - 2);
//            this.btnBrowseImage.Size = new System.Drawing.Size(78, 34);
//            this.btnBrowseImage.Cursor = System.Windows.Forms.Cursors.Hand;
//            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);

//            // ?? Action Buttons ?????????????????????????????????????????????????
//            this.btnAdd.Name = "btnAdd";
//            this.btnAdd.Text = "+ Add Product";
//            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
//            this.btnAdd.ForeColor = clrWhite;
//            this.btnAdd.BackColor = clrTeal;
//            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnAdd.FlatAppearance.BorderSize = 0;
//            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(5, 150, 105);
//            this.btnAdd.Location = new System.Drawing.Point(808, 38);
//            this.btnAdd.Size = new System.Drawing.Size(126, 40);
//            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
//            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

//            this.btnCancelEdit.Name = "btnCancelEdit";
//            this.btnCancelEdit.Text = "? Cancel";
//            this.btnCancelEdit.Font = new System.Drawing.Font("Segoe UI", 9.5F);
//            this.btnCancelEdit.ForeColor = clrTextMuted;
//            this.btnCancelEdit.BackColor = clrWhite;
//            this.btnCancelEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnCancelEdit.FlatAppearance.BorderColor = clrBorder;
//            this.btnCancelEdit.FlatAppearance.BorderSize = 1;
//            this.btnCancelEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(249, 250, 251);
//            this.btnCancelEdit.Location = new System.Drawing.Point(808, 84);
//            this.btnCancelEdit.Size = new System.Drawing.Size(126, 38);
//            this.btnCancelEdit.Cursor = System.Windows.Forms.Cursors.Hand;
//            this.btnCancelEdit.Visible = false;
//            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);

//            this.pnlInputCard.Controls.AddRange(new System.Windows.Forms.Control[] {
//                this.lblInputCardTitle,
//                this.lblName,        this.txtName,
//                this.lblPrice,       this.txtPrice,
//                this.lblCategory,    this.cbCategory,
//                this.lblUnits,       this.txtUnits,
//                this.lblDescription, this.txtDescription,
//                this.lblImage,       this.txtImage,
//                this.lblImagePreviewIcon, this.btnBrowseImage,
//                this.btnAdd,         this.btnCancelEdit
//            });

//            // ??????????????????????????????????????????????????????????????????
//            //  GRID CARD
//            // ??????????????????????????????????????????????????????????????????
//            this.pnlGridCard.Name = "pnlGridCard";
//            this.pnlGridCard.Location = new System.Drawing.Point(24, 212);
//            this.pnlGridCard.Size = new System.Drawing.Size(952, 372);
//            this.pnlGridCard.BackColor = clrWhite;

//            this.lblGridTitle.Name = "lblGridTitle";
//            this.lblGridTitle.Text = "PRODUCT CATALOGUE";
//            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
//            this.lblGridTitle.ForeColor = clrTextMuted;
//            this.lblGridTitle.Location = new System.Drawing.Point(18, 14);
//            this.lblGridTitle.Size = new System.Drawing.Size(220, 16);
//            this.lblGridTitle.BackColor = System.Drawing.Color.Transparent;

//            var pnlGridDivider = new System.Windows.Forms.Panel();
//            pnlGridDivider.Location = new System.Drawing.Point(0, 34);
//            pnlGridDivider.Size = new System.Drawing.Size(952, 1);
//            pnlGridDivider.BackColor = clrBorder;

//            // DataGridView
//            this.dgvProducts.Name = "dgvProducts";
//            this.dgvProducts.Location = new System.Drawing.Point(0, 36);
//            this.dgvProducts.Size = new System.Drawing.Size(952, 336);
//            this.dgvProducts.AutoGenerateColumns = false;
//            this.dgvProducts.AllowUserToAddRows = false;
//            this.dgvProducts.AllowUserToDeleteRows = false;
//            this.dgvProducts.RowHeadersVisible = false;
//            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
//            this.dgvProducts.MultiSelect = false;
//            this.dgvProducts.BackgroundColor = clrWhite;
//            this.dgvProducts.GridColor = clrBorder;
//            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
//            this.dgvProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
//            this.dgvProducts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
//            this.dgvProducts.Anchor = System.Windows.Forms.AnchorStyles.Top
//                                                   | System.Windows.Forms.AnchorStyles.Bottom
//                                                   | System.Windows.Forms.AnchorStyles.Left
//                                                   | System.Windows.Forms.AnchorStyles.Right;

//            this.dgvProducts.EnableHeadersVisualStyles = false;
//            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
//            this.dgvProducts.ColumnHeadersHeight = 44;
//            this.dgvProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
//            this.dgvProducts.ColumnHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
//            {
//                BackColor = clrGridHeader,
//                ForeColor = clrTextMuted,
//                Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold),
//                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
//                Padding = new System.Windows.Forms.Padding(10, 0, 0, 0),
//                SelectionBackColor = clrGridHeader,
//                SelectionForeColor = clrTextMuted
//            };
//            this.dgvProducts.DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
//            {
//                Font = new System.Drawing.Font("Segoe UI", 9.5F),
//                Padding = new System.Windows.Forms.Padding(10, 0, 10, 0),
//                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
//                SelectionBackColor = clrGridSelect,
//                SelectionForeColor = clrTextPrimary,
//                ForeColor = clrTextPrimary,
//                BackColor = clrWhite
//            };
//            this.dgvProducts.AlternatingRowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
//            {
//                BackColor = clrGridAlt,
//                SelectionBackColor = clrGridSelect,
//                SelectionForeColor = clrTextPrimary,
//                ForeColor = clrTextPrimary
//            };
//            this.dgvProducts.RowTemplate.Height = 58;
//            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentClick);
//            this.dgvProducts.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvProducts_CellPainting);

//            this.pnlGridCard.Controls.AddRange(new System.Windows.Forms.Control[] {
//                this.lblGridTitle, pnlGridDivider, this.dgvProducts
//            });

//            // ??????????????????????????????????????????????????????????????????
//            //  FOOTER
//            // ??????????????????????????????????????????????????????????????????
//            this.pnlFooter.Name = "pnlFooter";
//            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
//            this.pnlFooter.Height = 56;
//            this.pnlFooter.BackColor = clrContent;

//            var pnlFooterBorder = new System.Windows.Forms.Panel();
//            pnlFooterBorder.Dock = System.Windows.Forms.DockStyle.Top;
//            pnlFooterBorder.Height = 1;
//            pnlFooterBorder.BackColor = clrBorder;
//            this.pnlFooter.Controls.Add(pnlFooterBorder);

//            this.lblFooterNote.Name = "lblFooterNote";
//            this.lblFooterNote.Text = "Product images are stored as file paths. Changes are saved immediately.";
//            this.lblFooterNote.Font = new System.Drawing.Font("Segoe UI", 8.5F);
//            this.lblFooterNote.ForeColor = clrTextMuted;
//            this.lblFooterNote.Location = new System.Drawing.Point(24, 18);
//            this.lblFooterNote.Size = new System.Drawing.Size(480, 18);
//            this.lblFooterNote.BackColor = System.Drawing.Color.Transparent;

//            this.btnClose.Name = "btnClose";
//            this.btnClose.Text = "Close";
//            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
//            this.btnClose.ForeColor = clrTextPrimary;
//            this.btnClose.BackColor = clrWhite;
//            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnClose.FlatAppearance.BorderColor = clrBorder;
//            this.btnClose.FlatAppearance.BorderSize = 1;
//            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(249, 250, 251);
//            this.btnClose.Location = new System.Drawing.Point(856, 10);
//            this.btnClose.Size = new System.Drawing.Size(116, 38);
//            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
//            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
//            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

//            this.pnlFooter.Controls.AddRange(new System.Windows.Forms.Control[] {
//                this.lblFooterNote, this.btnClose
//            });

//            // ?? Wire content ???????????????????????????????????????????????????
//            this.pnlContent.Controls.AddRange(new System.Windows.Forms.Control[] {
//                this.pnlInputCard, this.pnlGridCard
//            });

//            // ??????????????????????????????????????????????????????????????????
//            //  FORM
//            // ??????????????????????????????????????????????????????????????????
//            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(1000, 666);
//            this.BackColor = clrContent;
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
//            this.MaximizeBox = false;
//            this.MinimizeBox = false;
//            this.Name = "ProductManagementForm";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
//            this.Text = "Product Management";

//            this.Controls.Add(this.pnlContent);
//            this.Controls.Add(this.pnlFooter);
//            this.Controls.Add(this.pnlTopBar);

//            ((System.ComponentModel.ISupportInitialize)this.dgvProducts).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();
//        }
//    }
//}