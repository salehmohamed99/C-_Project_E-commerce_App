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
            this.pnlHeader      = new System.Windows.Forms.Panel();
            this.lblTitle       = new System.Windows.Forms.Label();
            this.pnlInputs     = new System.Windows.Forms.Panel();
            this.lblName        = new System.Windows.Forms.Label();
            this.txtName        = new System.Windows.Forms.TextBox();
            this.lblPrice       = new System.Windows.Forms.Label();
            this.txtPrice       = new System.Windows.Forms.TextBox();
            this.lblCategory    = new System.Windows.Forms.Label();
            this.cbCategory     = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblUnits       = new System.Windows.Forms.Label();
            this.txtUnits       = new System.Windows.Forms.TextBox();
            this.lblImage       = new System.Windows.Forms.Label();
            this.txtImage       = new System.Windows.Forms.TextBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.btnAdd         = new System.Windows.Forms.Button();
            this.dgvProducts    = new System.Windows.Forms.DataGridView();
            this.btnClose       = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)this.dgvProducts).BeginInit();
            this.SuspendLayout();

            // ???????????????????????????????????????
            //  Header Panel
            // ???????????????????????????????????????
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 60;
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(45, 62, 80);

            this.lblTitle.Text      = "Manage Products";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(25, 12);
            this.lblTitle.AutoSize  = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;

            this.pnlHeader.Controls.Add(this.lblTitle);

            // ???????????????????????????????????????
            //  Inputs Panel (card-style)
            // ???????????????????????????????????????
            this.pnlInputs.Location    = new System.Drawing.Point(25, 75);
            this.pnlInputs.Size        = new System.Drawing.Size(920, 135);
            this.pnlInputs.BackColor   = System.Drawing.Color.White;
            this.pnlInputs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            var inputFont  = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            var fieldFont  = new System.Drawing.Font("Segoe UI", 10F);
            var labelColor = System.Drawing.Color.FromArgb(45, 62, 80);

            // Row 1
            this.lblName.Text      = "Name:";
            this.lblName.Font      = inputFont;
            this.lblName.ForeColor = labelColor;
            this.lblName.Location  = new System.Drawing.Point(12, 14);
            this.lblName.AutoSize  = true;

            this.txtName.Location    = new System.Drawing.Point(70, 11);
            this.txtName.Size        = new System.Drawing.Size(160, 28);
            this.txtName.Font        = fieldFont;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblPrice.Text      = "Price:";
            this.lblPrice.Font      = inputFont;
            this.lblPrice.ForeColor = labelColor;
            this.lblPrice.Location  = new System.Drawing.Point(245, 14);
            this.lblPrice.AutoSize  = true;

            this.txtPrice.Location    = new System.Drawing.Point(298, 11);
            this.txtPrice.Size        = new System.Drawing.Size(100, 28);
            this.txtPrice.Font        = fieldFont;
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblCategory.Text      = "Category:";
            this.lblCategory.Font      = inputFont;
            this.lblCategory.ForeColor = labelColor;
            this.lblCategory.Location  = new System.Drawing.Point(415, 14);
            this.lblCategory.AutoSize  = true;

            this.cbCategory.Location      = new System.Drawing.Point(498, 11);
            this.cbCategory.Size          = new System.Drawing.Size(170, 28);
            this.cbCategory.Font          = fieldFont;
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Row 2
            this.lblDescription.Text      = "Description:";
            this.lblDescription.Font      = inputFont;
            this.lblDescription.ForeColor = labelColor;
            this.lblDescription.Location  = new System.Drawing.Point(12, 50);
            this.lblDescription.AutoSize  = true;

            this.txtDescription.Location    = new System.Drawing.Point(105, 47);
            this.txtDescription.Size        = new System.Drawing.Size(563, 28);
            this.txtDescription.Font        = fieldFont;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Row 3
            this.lblUnits.Text      = "Stock:";
            this.lblUnits.Font      = inputFont;
            this.lblUnits.ForeColor = labelColor;
            this.lblUnits.Location  = new System.Drawing.Point(12, 90);
            this.lblUnits.AutoSize  = true;

            this.txtUnits.Location    = new System.Drawing.Point(65, 87);
            this.txtUnits.Size        = new System.Drawing.Size(80, 28);
            this.txtUnits.Font        = fieldFont;
            this.txtUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblImage.Text      = "Image:";
            this.lblImage.Font      = inputFont;
            this.lblImage.ForeColor = labelColor;
            this.lblImage.Location  = new System.Drawing.Point(165, 90);
            this.lblImage.AutoSize  = true;

            this.txtImage.Location    = new System.Drawing.Point(222, 87);
            this.txtImage.Size        = new System.Drawing.Size(260, 28);
            this.txtImage.Font        = fieldFont;
            this.txtImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImage.ReadOnly    = true;

            this.btnBrowseImage.Text      = "Browse...";
            this.btnBrowseImage.Location  = new System.Drawing.Point(490, 86);
            this.btnBrowseImage.Size      = new System.Drawing.Size(90, 30);
            this.btnBrowseImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseImage.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnBrowseImage.ForeColor = System.Drawing.Color.White;
            this.btnBrowseImage.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBrowseImage.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseImage.FlatAppearance.BorderSize = 0;
            this.btnBrowseImage.Click    += new System.EventHandler(this.btnBrowseImage_Click);

            // Add button inside panel
            this.btnAdd.Text      = "Add Product";
            this.btnAdd.Location  = new System.Drawing.Point(700, 40);
            this.btnAdd.Size      = new System.Drawing.Size(200, 50);
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Click    += new System.EventHandler(this.btnAdd_Click);

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
            this.dgvProducts.Location            = new System.Drawing.Point(25, 225);
            this.dgvProducts.Size                = new System.Drawing.Size(920, 340);
            this.dgvProducts.AutoGenerateColumns = false;
            this.dgvProducts.RowTemplate.Height  = 60;
            this.dgvProducts.AllowUserToAddRows  = false;
            this.dgvProducts.RowHeadersVisible   = false;
            this.dgvProducts.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.MultiSelect         = false;
            this.dgvProducts.BackgroundColor     = System.Drawing.Color.White;
            this.dgvProducts.GridColor           = System.Drawing.Color.FromArgb(230, 230, 230);
            this.dgvProducts.BorderStyle         = System.Windows.Forms.BorderStyle.None;
            this.dgvProducts.CellBorderStyle     = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProducts.EnableHeadersVisualStyles = false;
            this.dgvProducts.ColumnHeadersHeight      = 42;
            this.dgvProducts.ColumnHeadersBorderStyle  = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProducts.ColumnHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(45, 62, 80),
                ForeColor = System.Drawing.Color.White,
                Font      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold),
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter,
                Padding   = new System.Windows.Forms.Padding(0)
            };
            this.dgvProducts.DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
            {
                Font               = new System.Drawing.Font("Segoe UI", 9.75F),
                Padding            = new System.Windows.Forms.Padding(4),
                Alignment          = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = System.Drawing.Color.FromArgb(214, 234, 248),
                SelectionForeColor = System.Drawing.Color.FromArgb(45, 62, 80)
            };
            this.dgvProducts.AlternatingRowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
            {
                BackColor          = System.Drawing.Color.FromArgb(245, 247, 250),
                SelectionBackColor = System.Drawing.Color.FromArgb(214, 234, 248),
                SelectionForeColor = System.Drawing.Color.FromArgb(45, 62, 80)
            };

            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentClick);

            // ???????????????????????????????????????
            //  Close Button
            // ???????????????????????????????????????
            this.btnClose.Text      = "Close";
            this.btnClose.Location  = new System.Drawing.Point(825, 580);
            this.btnClose.Size      = new System.Drawing.Size(120, 40);
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(45, 62, 80);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Click    += new System.EventHandler(this.btnClose_Click);

            // ???????????????????????????????????????
            //  ProductManagementForm
            // ???????????????????????????????????????
            this.ClientSize      = new System.Drawing.Size(970, 635);
            this.BackColor       = System.Drawing.Color.FromArgb(245, 247, 250);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlInputs);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.btnClose);
            this.Text          = "Product Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ((System.ComponentModel.ISupportInitialize)this.dgvProducts).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}


