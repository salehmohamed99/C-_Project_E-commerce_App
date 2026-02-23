namespace Presentation.Forms
{
    partial class ProductManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
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
            this.lblTitle      = new System.Windows.Forms.Label();
            this.lblName       = new System.Windows.Forms.Label();
            this.txtName       = new System.Windows.Forms.TextBox();
            this.lblPrice      = new System.Windows.Forms.Label();
            this.txtPrice      = new System.Windows.Forms.TextBox();
            this.lblCategory   = new System.Windows.Forms.Label();
            this.cbCategory    = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblUnits      = new System.Windows.Forms.Label();
            this.txtUnits      = new System.Windows.Forms.TextBox();
            this.lblImage       = new System.Windows.Forms.Label();
            this.txtImage       = new System.Windows.Forms.TextBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.btnAdd         = new System.Windows.Forms.Button();
            this.dgvProducts   = new System.Windows.Forms.DataGridView();
            this.btnClose      = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)this.dgvProducts).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text     = "Manage Products";
            this.lblTitle.Font     = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size     = new System.Drawing.Size(250, 25);

            // lblName
            this.lblName.Text     = "Name:";
            this.lblName.Location = new System.Drawing.Point(20, 55);
            this.lblName.Size     = new System.Drawing.Size(50, 20);

            // txtName
            this.txtName.Location = new System.Drawing.Point(75, 52);
            this.txtName.Size     = new System.Drawing.Size(150, 25);

            // lblPrice
            this.lblPrice.Text     = "Price:";
            this.lblPrice.Location = new System.Drawing.Point(240, 55);
            this.lblPrice.Size     = new System.Drawing.Size(45, 20);

            // txtPrice
            this.txtPrice.Location = new System.Drawing.Point(290, 52);
            this.txtPrice.Size     = new System.Drawing.Size(100, 25);

            // lblCategory
            this.lblCategory.Text     = "Category:";
            this.lblCategory.Location = new System.Drawing.Point(405, 55);
            this.lblCategory.Size     = new System.Drawing.Size(70, 20);

            // cbCategory
            this.cbCategory.Location     = new System.Drawing.Point(480, 52);
            this.cbCategory.Size         = new System.Drawing.Size(160, 25);
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // lblDescription
            this.lblDescription.Text     = "Description:";
            this.lblDescription.Location = new System.Drawing.Point(20, 95);
            this.lblDescription.Size     = new System.Drawing.Size(80, 20);

            // txtDescription
            this.txtDescription.Location  = new System.Drawing.Point(105, 92);
            this.txtDescription.Size      = new System.Drawing.Size(535, 50);
            this.txtDescription.Multiline = true;

            // lblUnits
            this.lblUnits.Text     = "Units in Stock:";
            this.lblUnits.Location = new System.Drawing.Point(20, 158);
            this.lblUnits.Size     = new System.Drawing.Size(95, 20);

            // txtUnits
            this.txtUnits.Location = new System.Drawing.Point(120, 155);
            this.txtUnits.Size     = new System.Drawing.Size(80, 25);

            // lblImage
            this.lblImage.Text     = "Image Path:";
            this.lblImage.Location = new System.Drawing.Point(220, 158);
            this.lblImage.Size     = new System.Drawing.Size(85, 20);

            // txtImage
            this.txtImage.Location = new System.Drawing.Point(310, 155);
            this.txtImage.Size     = new System.Drawing.Size(230, 25);
            this.txtImage.ReadOnly = true;

            // btnBrowseImage
            this.btnBrowseImage.Text     = "Browse...";
            this.btnBrowseImage.Location = new System.Drawing.Point(548, 155);
            this.btnBrowseImage.Size     = new System.Drawing.Size(80, 25);
            this.btnBrowseImage.Click   += new System.EventHandler(this.btnBrowseImage_Click);

            // btnAdd
            this.btnAdd.Text     = "Add Product";
            this.btnAdd.Location = new System.Drawing.Point(660, 155);
            this.btnAdd.Size     = new System.Drawing.Size(120, 30);
            this.btnAdd.Click   += new System.EventHandler(this.btnAdd_Click);

            // dgvProducts
            this.dgvProducts.Location            = new System.Drawing.Point(20, 200);
            this.dgvProducts.Size                = new System.Drawing.Size(880, 330);
            this.dgvProducts.AutoGenerateColumns = false;
            this.dgvProducts.RowTemplate.Height  = 60;
            this.dgvProducts.Columns.Add("ID",       "ID");
            this.dgvProducts.Columns.Add(new System.Windows.Forms.DataGridViewImageColumn {
                Name = "Image",
                HeaderText = "Image",
                ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom,
                Width = 70
            });
            this.dgvProducts.Columns.Add("Name",     "Name");
            this.dgvProducts.Columns.Add("Price",    "Price");
            this.dgvProducts.Columns.Add("Category", "Category");
            this.dgvProducts.Columns.Add("Stock",    "Stock");
            this.dgvProducts.Columns.Add("Edit",     "Edit");
            this.dgvProducts.Columns.Add("Delete",   "Delete");

            // btnClose
            this.btnClose.Text     = "Close";
            this.btnClose.Location = new System.Drawing.Point(825, 548);
            this.btnClose.Size     = new System.Drawing.Size(75, 30);
            this.btnClose.Click   += new System.EventHandler(this.btnClose_Click);

            // ProductManagementForm
            this.ClientSize = new System.Drawing.Size(930, 600);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.lblName, this.txtName,
                this.lblPrice, this.txtPrice, this.lblCategory, this.cbCategory,
                this.lblDescription, this.txtDescription, this.lblUnits, this.txtUnits,
                this.lblImage, this.txtImage, this.btnBrowseImage,
                this.btnAdd, this.dgvProducts, this.btnClose
            });
            this.Text          = "Product Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ((System.ComponentModel.ISupportInitialize)this.dgvProducts).EndInit();
            this.ResumeLayout(false);
        }
    }
}

