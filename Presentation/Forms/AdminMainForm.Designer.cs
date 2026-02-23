namespace Presentation.Forms
{
    partial class AdminMainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle      = new System.Windows.Forms.Label();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnProducts   = new System.Windows.Forms.Button();
            this.btnOrders     = new System.Windows.Forms.Button();
            this.btnLogout     = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text      = "Admin Dashboard";
            this.lblTitle.Font      = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location  = new System.Drawing.Point(50, 20);
            this.lblTitle.Size      = new System.Drawing.Size(300, 35);

            // btnCategories
            this.btnCategories.Text     = "Manage Categories";
            this.btnCategories.Location = new System.Drawing.Point(50, 80);
            this.btnCategories.Size     = new System.Drawing.Size(200, 50);
            this.btnCategories.Click   += new System.EventHandler(this.btnCategories_Click);

            // btnProducts
            this.btnProducts.Text     = "Manage Products";
            this.btnProducts.Location = new System.Drawing.Point(350, 80);
            this.btnProducts.Size     = new System.Drawing.Size(200, 50);
            this.btnProducts.Click   += new System.EventHandler(this.btnProducts_Click);

            // btnOrders
            this.btnOrders.Text     = "Track Orders";
            this.btnOrders.Location = new System.Drawing.Point(50, 160);
            this.btnOrders.Size     = new System.Drawing.Size(200, 50);
            this.btnOrders.Click   += new System.EventHandler(this.btnOrders_Click);

            // btnLogout
            this.btnLogout.Text     = "Logout";
            this.btnLogout.Location = new System.Drawing.Point(350, 160);
            this.btnLogout.Size     = new System.Drawing.Size(200, 50);
            this.btnLogout.Click   += new System.EventHandler(this.btnLogout_Click);

            // AdminMainForm
            this.ClientSize = new System.Drawing.Size(620, 280);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.btnCategories, this.btnProducts,
                this.btnOrders, this.btnLogout
            });
            this.Text            = "Admin Dashboard";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode   = System.Windows.Forms.AutoScaleMode.Font;
            this.ResumeLayout(false);
        }
    }
}
