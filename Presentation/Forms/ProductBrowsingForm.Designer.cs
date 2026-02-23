namespace Presentation.Forms
{
    partial class ProductBrowsingForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
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
            this.lblTitle   = new System.Windows.Forms.Label();
            this.lblSearch  = new System.Windows.Forms.Label();
            this.txtSearch  = new System.Windows.Forms.TextBox();
            this.btnSearch  = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnClose   = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)this.dgvProducts).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text     = "Browse Products";
            this.lblTitle.Font     = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Size     = new System.Drawing.Size(250, 25);

            // lblSearch
            this.lblSearch.Text     = "Search:";
            this.lblSearch.Location = new System.Drawing.Point(20, 63);
            this.lblSearch.Size     = new System.Drawing.Size(55, 20);

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(80, 60);
            this.txtSearch.Size     = new System.Drawing.Size(200, 25);

            // btnSearch
            this.btnSearch.Text     = "Search";
            this.btnSearch.Location = new System.Drawing.Point(290, 60);
            this.btnSearch.Size     = new System.Drawing.Size(80, 28);
            this.btnSearch.Click   += new System.EventHandler(this.btnSearch_Click);

            // dgvProducts
            this.dgvProducts.Location            = new System.Drawing.Point(20, 105);
            this.dgvProducts.Size                = new System.Drawing.Size(1000, 450);
            this.dgvProducts.AutoGenerateColumns = false;
            this.dgvProducts.RowTemplate.Height  = 60;
            this.dgvProducts.Columns.Add("ID",      "ID");
            this.dgvProducts.Columns.Add(new System.Windows.Forms.DataGridViewImageColumn {
                Name = "Image",
                HeaderText = "Image",
                ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom,
                Width = 70
            });
            this.dgvProducts.Columns.Add("Name",    "Product Name");
            this.dgvProducts.Columns.Add("Price",   "Price");
            this.dgvProducts.Columns.Add("Stock",   "Stock");
            this.dgvProducts.Columns.Add("Details", "Details");
            this.dgvProducts.Columns.Add("AddCart", "Add to Cart");

            // btnClose
            this.btnClose.Text     = "Close";
            this.btnClose.Location = new System.Drawing.Point(945, 580);
            this.btnClose.Size     = new System.Drawing.Size(75, 30);
            this.btnClose.Click   += new System.EventHandler(this.btnClose_Click);

            // ProductBrowsingForm
            this.ClientSize = new System.Drawing.Size(1060, 640);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.lblSearch, this.txtSearch,
                this.btnSearch, this.dgvProducts, this.btnClose
            });
            this.Text          = "Browse Products";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ((System.ComponentModel.ISupportInitialize)this.dgvProducts).EndInit();
            this.ResumeLayout(false);
        }
    }
}

