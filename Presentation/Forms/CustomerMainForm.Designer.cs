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