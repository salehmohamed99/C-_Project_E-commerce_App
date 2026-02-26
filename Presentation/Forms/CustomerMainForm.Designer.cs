//namespace Presentation.Forms
//{
//    partial class CustomerMainForm
//    {
//        private System.ComponentModel.IContainer components = null;

//        private System.Windows.Forms.Panel pnlTopBar;
//        private System.Windows.Forms.Panel pnlTopAccent;
//        private System.Windows.Forms.Panel pnlContent;
//        private System.Windows.Forms.Label lblTitleIcon;
//        private System.Windows.Forms.Label lblTitle;
//        private System.Windows.Forms.Label lblSubtitle;
//        private System.Windows.Forms.Button btnBrowse;
//        private System.Windows.Forms.Button btnCart;
//        private System.Windows.Forms.Button btnOrders;
//        private System.Windows.Forms.Button btnLogout;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//                components.Dispose();
//            base.Dispose(disposing);
//        }

//        private void InitializeComponent()
//        {
//            this.pnlTopBar = new System.Windows.Forms.Panel();
//            this.pnlTopAccent = new System.Windows.Forms.Panel();
//            this.pnlContent = new System.Windows.Forms.Panel();
//            this.lblTitleIcon = new System.Windows.Forms.Label();
//            this.lblTitle = new System.Windows.Forms.Label();
//            this.lblSubtitle = new System.Windows.Forms.Label();
//            this.btnBrowse = new System.Windows.Forms.Button();
//            this.btnCart = new System.Windows.Forms.Button();
//            this.btnOrders = new System.Windows.Forms.Button();
//            this.btnLogout = new System.Windows.Forms.Button();
//            this.pnlTopBar.SuspendLayout();
//            this.pnlContent.SuspendLayout();
//            this.SuspendLayout();

//            // ??????????????????????????????????????????????????????????????????
//            //  PALETTE
//            // ??????????????????????????????????????????????????????????????????
//            var clrDark = System.Drawing.Color.FromArgb(15, 17, 26);
//            var clrAccent = System.Drawing.Color.FromArgb(99, 102, 241); // Indigo
//            var clrContent = System.Drawing.Color.FromArgb(243, 245, 250);
//            var clrWhite = System.Drawing.Color.White;
//            var clrTextPrimary = System.Drawing.Color.FromArgb(17, 24, 39);
//            var clrTextMuted = System.Drawing.Color.FromArgb(107, 114, 128);

//            // ??????????????????????????????????????????????????????????????????
//            //  TOP BAR
//            // ??????????????????????????????????????????????????????????????????
//            this.pnlTopBar.BackColor = clrDark;
//            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
//            this.pnlTopBar.Height = 72;
//            this.pnlTopBar.Name = "pnlTopBar";

//            this.pnlTopAccent.BackColor = clrAccent;
//            this.pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Bottom;
//            this.pnlTopAccent.Height = 3;
//            this.pnlTopAccent.Name = "pnlTopAccent";
//            this.pnlTopBar.Controls.Add(this.pnlTopAccent);

//            this.lblTitleIcon.AutoSize = true;
//            this.lblTitleIcon.BackColor = System.Drawing.Color.Transparent;
//            this.lblTitleIcon.Font = new System.Drawing.Font("Segoe UI Symbol", 20F);
//            this.lblTitleIcon.ForeColor = clrAccent;
//            this.lblTitleIcon.Location = new System.Drawing.Point(24, 16);
//            this.lblTitleIcon.Name = "lblTitleIcon";
//            this.lblTitleIcon.Text = "";

//            this.lblTitle.AutoSize = true;
//            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
//            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
//            this.lblTitle.ForeColor = clrWhite;
//            this.lblTitle.Location = new System.Drawing.Point(66, 16);
//            this.lblTitle.Name = "lblTitle";
//            this.lblTitle.Text = "Customer Dashboard";

//            this.lblSubtitle.AutoSize = true;
//            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
//            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
//            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
//            this.lblSubtitle.Location = new System.Drawing.Point(68, 42);
//            this.lblSubtitle.Name = "lblSubtitle";
//            this.lblSubtitle.Text = "Welcome! What would you like to do today?";

//            this.pnlTopBar.Controls.Add(this.lblTitleIcon);
//            this.pnlTopBar.Controls.Add(this.lblTitle);
//            this.pnlTopBar.Controls.Add(this.lblSubtitle);

//            // ??????????????????????????????????????????????????????????????????
//            //  CONTENT PANEL
//            // ??????????????????????????????????????????????????????????????????
//            this.pnlContent.BackColor = clrContent;
//            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.pnlContent.Name = "pnlContent";

//            // Helper to create modern buttons
//            System.Windows.Forms.Button MakeBtn(string text, System.Drawing.Color color, int x, int y)
//            {
//                var btn = new System.Windows.Forms.Button();
//                btn.Text = text;
//                btn.Location = new System.Drawing.Point(x, y);
//                btn.Size = new System.Drawing.Size(240, 120);
//                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//                btn.BackColor = clrWhite;
//                btn.ForeColor = color;
//                btn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
//                btn.Cursor = System.Windows.Forms.Cursors.Hand;
//                btn.FlatAppearance.BorderColor = color;
//                btn.FlatAppearance.BorderSize = 2;
//                btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(249, 250, 251);
//                return btn;
//            }

//            this.btnBrowse = MakeBtn("Browse Products", System.Drawing.Color.FromArgb(52, 152, 219), 60, 60);
//            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);

//            this.btnCart = MakeBtn("View Cart", System.Drawing.Color.FromArgb(243, 156, 18), 340, 60);
//            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);

//            this.btnOrders = MakeBtn("My Orders", System.Drawing.Color.FromArgb(39, 174, 96), 60, 220);
//            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);

//            this.btnLogout = MakeBtn("Logout", System.Drawing.Color.FromArgb(231, 76, 60), 340, 220);
//            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

//            this.pnlContent.Controls.Add(this.btnBrowse);
//            this.pnlContent.Controls.Add(this.btnCart);
//            this.pnlContent.Controls.Add(this.btnOrders);
//            this.pnlContent.Controls.Add(this.btnLogout);

//            // ??????????????????????????????????????????????????????????????????
//            //  FORM
//            // ??????????????????????????????????????????????????????????????????
//            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(640, 480);
//            this.Controls.Add(this.pnlContent);
//            this.Controls.Add(this.pnlTopBar);
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
//            this.MaximizeBox = false;
//            this.Name = "CustomerMainForm";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
//            this.Text = "NexShop — Customer Dashboard";
//            this.Load += new System.EventHandler(this.CustomerMainForm_Load);
//            this.pnlTopBar.ResumeLayout(false);
//            this.pnlTopBar.PerformLayout();
//            this.pnlContent.ResumeLayout(false);
//            this.ResumeLayout(false);
//        }
//    }
//}


namespace Presentation.Forms
{
    partial class CustomerMainForm
    {
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlMainContainer;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblUserGreeting;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnLogout;

        private void InitializeComponent()
        {
            this.pnlSidebar = new Panel();
            this.pnlMainContainer = new Panel();
            this.pnlHeader = new Panel();
            this.lblLogo = new Label();
            this.lblUserGreeting = new Label();

            // Colors
            var clrSidebar = Color.FromArgb(15, 17, 26);
            var clrIndigo = Color.FromArgb(99, 102, 241);

            // Sidebar
            this.pnlSidebar.Dock = DockStyle.Left;
            this.pnlSidebar.Width = 220;
            this.pnlSidebar.BackColor = clrSidebar;

            // Logo Section
            this.lblLogo.Text = "NEXSHOP";
            this.lblLogo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblLogo.ForeColor = clrIndigo;
            this.lblLogo.Location = new Point(20, 20);
            this.pnlSidebar.Controls.Add(lblLogo);

            // Create Sidebar Buttons
            this.btnBrowse = CreateNavBtn("  Browse", 100);
            this.btnCart = CreateNavBtn("  My Cart", 155);
            this.btnOrders = CreateNavBtn("  Orders", 210);
            this.btnLogout = CreateNavBtn("  Logout", 600); // Anchored bottom

            this.pnlSidebar.Controls.AddRange(new Control[] { btnBrowse, btnCart, btnOrders, btnLogout });

            // Header
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Height = 60;
            this.pnlHeader.BackColor = Color.White;

            this.lblUserGreeting.Location = new Point(20, 20);
            this.lblUserGreeting.Font = new Font("Segoe UI Semibold", 10);
            this.pnlHeader.Controls.Add(lblUserGreeting);

            // Main Container (Where your sub-forms/user controls will go)
            this.pnlMainContainer.Dock = DockStyle.Fill;
            this.pnlMainContainer.BackColor = Color.FromArgb(243, 245, 250);

            // Form Setup
            this.Controls.Add(pnlMainContainer);
            this.Controls.Add(pnlHeader);
            this.Controls.Add(pnlSidebar);
            this.Text = "Customer Dashboard";

            // Inside InitializeComponent or the Constructor
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
        }

        private Button CreateNavBtn(string text, int y)
        {
            return new Button
            {
                Text = text,
                Location = new Point(10, y),
                Size = new Size(200, 45),
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0),
                Font = new Font("Segoe UI Semibold", 10),
                ForeColor = Color.Silver,
                Cursor = Cursors.Hand,
                FlatAppearance = { BorderSize = 0 }
            };
        }
    }
}