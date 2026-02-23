namespace Presentation.Forms
{
    partial class CustomerMainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
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
            lblTitle = new Label();
            btnBrowse = new Button();
            btnCart = new Button();
            btnOrders = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Arial", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(50, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Customer Dashboard";
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(50, 80);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(200, 50);
            btnBrowse.TabIndex = 1;
            btnBrowse.Text = "Browse Products";
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnCart
            // 
            btnCart.Location = new Point(350, 80);
            btnCart.Name = "btnCart";
            btnCart.Size = new Size(200, 50);
            btnCart.TabIndex = 2;
            btnCart.Text = "View Cart";
            btnCart.Click += btnCart_Click;
            // 
            // btnOrders
            // 
            btnOrders.Location = new Point(50, 160);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(200, 50);
            btnOrders.TabIndex = 3;
            btnOrders.Text = "My Orders";
            btnOrders.Click += btnOrders_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(350, 160);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(200, 50);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.Click += btnLogout_Click;
            // 
            // CustomerMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 280);
            Controls.Add(lblTitle);
            Controls.Add(btnBrowse);
            Controls.Add(btnCart);
            Controls.Add(btnOrders);
            Controls.Add(btnLogout);
            Name = "CustomerMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customer Dashboard";
            Load += CustomerMainForm_Load;
            ResumeLayout(false);
        }
    }
}
