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
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            btnBrowse = new Button();
            btnCart = new Button();
            btnOrders = new Button();
            btnLogout = new Button();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(45, 62, 80);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1052, 80);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(25, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(314, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Customer Dashboard";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.BackColor = Color.Transparent;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(189, 195, 199);
            lblSubtitle.Location = new Point(27, 50);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(315, 21);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Welcome! What would you like to do today?";
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.White;
            btnBrowse.Cursor = Cursors.Hand;
            btnBrowse.FlatAppearance.BorderColor = Color.FromArgb(52, 152, 219);
            btnBrowse.FlatAppearance.BorderSize = 2;
            btnBrowse.FlatStyle = FlatStyle.Flat;
            btnBrowse.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBrowse.ForeColor = Color.FromArgb(52, 152, 219);
            btnBrowse.Location = new Point(40, 110);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(240, 100);
            btnBrowse.TabIndex = 1;
            btnBrowse.Text = "Browse Products";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnCart
            // 
            btnCart.BackColor = Color.White;
            btnCart.Cursor = Cursors.Hand;
            btnCart.FlatAppearance.BorderColor = Color.FromArgb(243, 156, 18);
            btnCart.FlatAppearance.BorderSize = 2;
            btnCart.FlatStyle = FlatStyle.Flat;
            btnCart.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCart.ForeColor = Color.FromArgb(243, 156, 18);
            btnCart.Location = new Point(550, 110);
            btnCart.Name = "btnCart";
            btnCart.Size = new Size(240, 100);
            btnCart.TabIndex = 2;
            btnCart.Text = "View Cart";
            btnCart.UseVisualStyleBackColor = false;
            btnCart.Click += btnCart_Click;
            // 
            // btnOrders
            // 
            btnOrders.BackColor = Color.White;
            btnOrders.Cursor = Cursors.Hand;
            btnOrders.FlatAppearance.BorderColor = Color.FromArgb(39, 174, 96);
            btnOrders.FlatAppearance.BorderSize = 2;
            btnOrders.FlatStyle = FlatStyle.Flat;
            btnOrders.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnOrders.ForeColor = Color.FromArgb(39, 174, 96);
            btnOrders.Location = new Point(40, 240);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(240, 100);
            btnOrders.TabIndex = 3;
            btnOrders.Text = "My Orders";
            btnOrders.UseVisualStyleBackColor = false;
            btnOrders.Click += btnOrders_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.White;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderColor = Color.FromArgb(231, 76, 60);
            btnLogout.FlatAppearance.BorderSize = 2;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogout.ForeColor = Color.FromArgb(231, 76, 60);
            btnLogout.Location = new Point(550, 240);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(240, 100);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // CustomerMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1052, 453);
            Controls.Add(pnlHeader);
            Controls.Add(btnBrowse);
            Controls.Add(btnCart);
            Controls.Add(btnOrders);
            Controls.Add(btnLogout);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "CustomerMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customer Dashboard";
            Load += CustomerMainForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }
    }
}
