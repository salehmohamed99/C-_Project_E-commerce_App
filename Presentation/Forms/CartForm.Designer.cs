namespace Presentation.Forms
{
    partial class CartForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle    = new System.Windows.Forms.Label();
            this.dgvCart     = new System.Windows.Forms.DataGridView();
            this.lblTotal    = new System.Windows.Forms.Label();
            this.btnClear    = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnClose    = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)this.dgvCart).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text     = "Your Shopping Cart";
            this.lblTitle.Font     = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Size     = new System.Drawing.Size(300, 25);

            // dgvCart
            this.dgvCart.Location            = new System.Drawing.Point(20, 70);
            this.dgvCart.Size                = new System.Drawing.Size(920, 350);
            this.dgvCart.AutoGenerateColumns = false;
            this.dgvCart.RowTemplate.Height  = 60;
            this.dgvCart.Columns.Add(new System.Windows.Forms.DataGridViewImageColumn {
                Name        = "Image",
                HeaderText  = "Image",
                ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom,
                Width       = 70
            });
            this.dgvCart.Columns.Add("ProductID",   "Product ID");
            this.dgvCart.Columns.Add("ProductName", "Product Name");
            this.dgvCart.Columns.Add("Price",       "Unit Price");
            this.dgvCart.Columns.Add("Quantity",    "Quantity");
            this.dgvCart.Columns.Add("Subtotal",    "Subtotal");
            this.dgvCart.Columns.Add("Update",      "Update");
            this.dgvCart.Columns.Add("Remove",      "Remove");

            // lblTotal
            this.lblTotal.Text     = "Total: $0.00";
            this.lblTotal.Font     = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(20, 440);
            this.lblTotal.Size     = new System.Drawing.Size(200, 25);

            // btnClear
            this.btnClear.Text     = "Clear Cart";
            this.btnClear.Location = new System.Drawing.Point(20, 480);
            this.btnClear.Size     = new System.Drawing.Size(100, 30);
            this.btnClear.Click   += new System.EventHandler(this.btnClear_Click);

            // btnCheckout
            this.btnCheckout.Text     = "Proceed to Checkout";
            this.btnCheckout.Location = new System.Drawing.Point(130, 480);
            this.btnCheckout.Size     = new System.Drawing.Size(150, 30);
            this.btnCheckout.Click   += new System.EventHandler(this.btnCheckout_Click);

            // btnContinue
            this.btnContinue.Text     = "Continue Shopping";
            this.btnContinue.Location = new System.Drawing.Point(290, 480);
            this.btnContinue.Size     = new System.Drawing.Size(130, 30);
            this.btnContinue.Click   += new System.EventHandler(this.btnContinue_Click);

            // btnClose
            this.btnClose.Text     = "Close";
            this.btnClose.Location = new System.Drawing.Point(785, 520);
            this.btnClose.Size     = new System.Drawing.Size(75, 30);
            this.btnClose.Click   += new System.EventHandler(this.btnClose_Click);

            // CartForm
            this.ClientSize = new System.Drawing.Size(980, 580);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.dgvCart, this.lblTotal,
                this.btnClear, this.btnCheckout, this.btnContinue, this.btnClose
            });
            this.Text          = "Shopping Cart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ((System.ComponentModel.ISupportInitialize)this.dgvCart).EndInit();
            this.ResumeLayout(false);
        }
    }
}
