namespace Presentation.Forms
{
    partial class CustomerMainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnCart;
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
            pnlHeader  = new Panel();
            lblTitle    = new Label();
            lblSubtitle = new Label();
            btnBrowse  = new Button();
            btnCart     = new Button();
            btnOrders  = new Button();
            btnLogout  = new Button();
            SuspendLayout();

            // ???????????????????????????????????????
            //  Header Panel
            // ???????????????????????????????????????
            pnlHeader.Dock      = DockStyle.Top;
            pnlHeader.Height    = 80;
            pnlHeader.BackColor = Color.FromArgb(45, 62, 80);

            lblTitle.Text      = "Customer Dashboard";
            lblTitle.Font      = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location  = new Point(25, 12);
            lblTitle.AutoSize  = true;
            lblTitle.BackColor = Color.Transparent;

            lblSubtitle.Text      = "Welcome! What would you like to do today?";
            lblSubtitle.Font      = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(189, 195, 199);
            lblSubtitle.Location  = new Point(27, 50);
            lblSubtitle.AutoSize  = true;
            lblSubtitle.BackColor = Color.Transparent;

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);

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

            // btnBrowse
            btnBrowse.Text      = "Browse Products";
            btnBrowse.Location  = new Point(left1, top1);
            btnBrowse.Size      = new Size(cardW, cardH);
            btnBrowse.FlatStyle = FlatStyle.Flat;
            btnBrowse.BackColor = Color.White;
            btnBrowse.ForeColor = Color.FromArgb(52, 152, 219);
            btnBrowse.Font      = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBrowse.Cursor    = Cursors.Hand;
            btnBrowse.TextAlign = ContentAlignment.MiddleCenter;
            btnBrowse.FlatAppearance.BorderColor = Color.FromArgb(52, 152, 219);
            btnBrowse.FlatAppearance.BorderSize  = 2;
            btnBrowse.Click    += btnBrowse_Click;

            // btnCart
            btnCart.Text      = "View Cart";
            btnCart.Location  = new Point(left2, top1);
            btnCart.Size      = new Size(cardW, cardH);
            btnCart.FlatStyle = FlatStyle.Flat;
            btnCart.BackColor = Color.White;
            btnCart.ForeColor = Color.FromArgb(243, 156, 18);
            btnCart.Font      = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCart.Cursor    = Cursors.Hand;
            btnCart.TextAlign = ContentAlignment.MiddleCenter;
            btnCart.FlatAppearance.BorderColor = Color.FromArgb(243, 156, 18);
            btnCart.FlatAppearance.BorderSize  = 2;
            btnCart.Click    += btnCart_Click;

            // btnOrders
            btnOrders.Text      = "My Orders";
            btnOrders.Location  = new Point(left1, top2);
            btnOrders.Size      = new Size(cardW, cardH);
            btnOrders.FlatStyle = FlatStyle.Flat;
            btnOrders.BackColor = Color.White;
            btnOrders.ForeColor = Color.FromArgb(39, 174, 96);
            btnOrders.Font      = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnOrders.Cursor    = Cursors.Hand;
            btnOrders.TextAlign = ContentAlignment.MiddleCenter;
            btnOrders.FlatAppearance.BorderColor = Color.FromArgb(39, 174, 96);
            btnOrders.FlatAppearance.BorderSize  = 2;
            btnOrders.Click    += btnOrders_Click;

            // btnLogout
            btnLogout.Text      = "Logout";
            btnLogout.Location  = new Point(left2, top2);
            btnLogout.Size      = new Size(cardW, cardH);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.BackColor = Color.White;
            btnLogout.ForeColor = Color.FromArgb(231, 76, 60);
            btnLogout.Font      = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogout.Cursor    = Cursors.Hand;
            btnLogout.TextAlign = ContentAlignment.MiddleCenter;
            btnLogout.FlatAppearance.BorderColor = Color.FromArgb(231, 76, 60);
            btnLogout.FlatAppearance.BorderSize  = 2;
            btnLogout.Click    += btnLogout_Click;

            // ???????????????????????????????????????
            //  CustomerMainForm
            // ???????????????????????????????????????
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode       = AutoScaleMode.Font;
            ClientSize          = new Size(left2 + cardW + 40, top2 + cardH + 35);
            BackColor           = Color.FromArgb(245, 247, 250);
            FormBorderStyle     = FormBorderStyle.FixedDialog;
            MaximizeBox         = false;
            Controls.Add(pnlHeader);
            Controls.Add(btnBrowse);
            Controls.Add(btnCart);
            Controls.Add(btnOrders);
            Controls.Add(btnLogout);
            Name           = "CustomerMainForm";
            StartPosition  = FormStartPosition.CenterScreen;
            Text           = "Customer Dashboard";
            Load          += CustomerMainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
