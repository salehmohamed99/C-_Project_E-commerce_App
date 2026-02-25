namespace Presentation.Forms
{
    partial class AdminMainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
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
            this.pnlHeader     = new System.Windows.Forms.Panel();
            this.lblTitle      = new System.Windows.Forms.Label();
            this.lblSubtitle   = new System.Windows.Forms.Label();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnProducts   = new System.Windows.Forms.Button();
            this.btnOrders     = new System.Windows.Forms.Button();
            this.btnLogout     = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // ???????????????????????????????????????
            //  Header Panel
            // ???????????????????????????????????????
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 80;
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(45, 62, 80);

            this.lblTitle.Text      = "Admin Dashboard";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(25, 12);
            this.lblTitle.AutoSize  = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;

            this.lblSubtitle.Text      = "Manage your store's products, categories, and orders";
            this.lblSubtitle.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.lblSubtitle.Location  = new System.Drawing.Point(27, 50);
            this.lblSubtitle.AutoSize  = true;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;

            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            // ???????????????????????????????????????
            //  Dashboard Cards
            // ???????????????????????????????????????
            int cardW = 240;
            int cardH = 100;
            int gap   = 25;
            int left1 = 40;
            int left2 = left1 + cardW + gap;
            int top1  = 110;
            int top2  = top1 + cardH + gap;

            // btnCategories
            this.btnCategories.Text      = "Manage Categories";
            this.btnCategories.Location  = new System.Drawing.Point(left1, top1);
            this.btnCategories.Size      = new System.Drawing.Size(cardW, cardH);
            this.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategories.BackColor = System.Drawing.Color.White;
            this.btnCategories.ForeColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.btnCategories.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCategories.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnCategories.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCategories.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.btnCategories.FlatAppearance.BorderSize  = 2;
            this.btnCategories.Click    += new System.EventHandler(this.btnCategories_Click);

            // btnProducts
            this.btnProducts.Text      = "Manage Products";
            this.btnProducts.Location  = new System.Drawing.Point(left2, top1);
            this.btnProducts.Size      = new System.Drawing.Size(cardW, cardH);
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.BackColor = System.Drawing.Color.White;
            this.btnProducts.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnProducts.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnProducts.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnProducts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnProducts.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnProducts.FlatAppearance.BorderSize  = 2;
            this.btnProducts.Click    += new System.EventHandler(this.btnProducts_Click);

            // btnOrders
            this.btnOrders.Text      = "Track Orders";
            this.btnOrders.Location  = new System.Drawing.Point(left1, top2);
            this.btnOrders.Size      = new System.Drawing.Size(cardW, cardH);
            this.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrders.BackColor = System.Drawing.Color.White;
            this.btnOrders.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnOrders.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnOrders.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnOrders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOrders.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnOrders.FlatAppearance.BorderSize  = 2;
            this.btnOrders.Click    += new System.EventHandler(this.btnOrders_Click);

            // btnLogout
            this.btnLogout.Text      = "Logout";
            this.btnLogout.Location  = new System.Drawing.Point(left2, top2);
            this.btnLogout.Size      = new System.Drawing.Size(cardW, cardH);
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnLogout.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnLogout.FlatAppearance.BorderSize  = 2;
            this.btnLogout.Click    += new System.EventHandler(this.btnLogout_Click);

            // ???????????????????????????????????????
            //  AdminMainForm
            // ???????????????????????????????????????
            this.ClientSize      = new System.Drawing.Size(left2 + cardW + 40, top2 + cardH + 35);
            this.BackColor       = System.Drawing.Color.FromArgb(245, 247, 250);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.Controls.Add(this.pnlHeader);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnCategories, this.btnProducts,
                this.btnOrders, this.btnLogout
            });
            this.Text            = "Admin Dashboard";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode   = System.Windows.Forms.AutoScaleMode.Font;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
