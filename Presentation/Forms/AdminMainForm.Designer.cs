//namespace Presentation.Forms
//{
//    partial class AdminMainForm
//    {
//        private System.ComponentModel.IContainer components = null;

//        private System.Windows.Forms.Panel pnlHeader;
//        private System.Windows.Forms.Label lblTitle;
//        private System.Windows.Forms.Label lblSubtitle;
//        private System.Windows.Forms.Button btnCategories;
//        private System.Windows.Forms.Button btnProducts;
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
//            this.pnlHeader     = new System.Windows.Forms.Panel();
//            this.lblTitle      = new System.Windows.Forms.Label();
//            this.lblSubtitle   = new System.Windows.Forms.Label();
//            this.btnCategories = new System.Windows.Forms.Button();
//            this.btnProducts   = new System.Windows.Forms.Button();
//            this.btnOrders     = new System.Windows.Forms.Button();
//            this.btnLogout     = new System.Windows.Forms.Button();
//            this.SuspendLayout();

//            // ???????????????????????????????????????
//            //  Header Panel
//            // ???????????????????????????????????????
//            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
//            this.pnlHeader.Height    = 80;
//            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(45, 62, 80);

//            this.lblTitle.Text      = "Admin Dashboard";
//            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
//            this.lblTitle.ForeColor = System.Drawing.Color.White;
//            this.lblTitle.Location  = new System.Drawing.Point(25, 12);
//            this.lblTitle.AutoSize  = true;
//            this.lblTitle.BackColor = System.Drawing.Color.Transparent;

//            this.lblSubtitle.Text      = "Manage your store's products, categories, and orders";
//            this.lblSubtitle.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
//            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(189, 195, 199);
//            this.lblSubtitle.Location  = new System.Drawing.Point(27, 50);
//            this.lblSubtitle.AutoSize  = true;
//            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;

//            this.pnlHeader.Controls.Add(this.lblTitle);
//            this.pnlHeader.Controls.Add(this.lblSubtitle);

//            // ???????????????????????????????????????
//            //  Dashboard Cards
//            // ???????????????????????????????????????
//            int cardW = 240;
//            int cardH = 100;
//            int gap   = 25;
//            int left1 = 40;
//            int left2 = left1 + cardW + gap;
//            int top1  = 110;
//            int top2  = top1 + cardH + gap;

//            // btnCategories
//            this.btnCategories.Text      = "Manage Categories";
//            this.btnCategories.Location  = new System.Drawing.Point(left1, top1);
//            this.btnCategories.Size      = new System.Drawing.Size(cardW, cardH);
//            this.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnCategories.BackColor = System.Drawing.Color.White;
//            this.btnCategories.ForeColor = System.Drawing.Color.FromArgb(155, 89, 182);
//            this.btnCategories.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
//            this.btnCategories.Cursor    = System.Windows.Forms.Cursors.Hand;
//            this.btnCategories.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            this.btnCategories.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(155, 89, 182);
//            this.btnCategories.FlatAppearance.BorderSize  = 2;
//            this.btnCategories.Click    += new System.EventHandler(this.btnCategories_Click);

//            // btnProducts
//            this.btnProducts.Text      = "Manage Products";
//            this.btnProducts.Location  = new System.Drawing.Point(left2, top1);
//            this.btnProducts.Size      = new System.Drawing.Size(cardW, cardH);
//            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnProducts.BackColor = System.Drawing.Color.White;
//            this.btnProducts.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
//            this.btnProducts.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
//            this.btnProducts.Cursor    = System.Windows.Forms.Cursors.Hand;
//            this.btnProducts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            this.btnProducts.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(52, 152, 219);
//            this.btnProducts.FlatAppearance.BorderSize  = 2;
//            this.btnProducts.Click    += new System.EventHandler(this.btnProducts_Click);

//            // btnOrders
//            this.btnOrders.Text      = "Track Orders";
//            this.btnOrders.Location  = new System.Drawing.Point(left1, top2);
//            this.btnOrders.Size      = new System.Drawing.Size(cardW, cardH);
//            this.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnOrders.BackColor = System.Drawing.Color.White;
//            this.btnOrders.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
//            this.btnOrders.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
//            this.btnOrders.Cursor    = System.Windows.Forms.Cursors.Hand;
//            this.btnOrders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            this.btnOrders.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(39, 174, 96);
//            this.btnOrders.FlatAppearance.BorderSize  = 2;
//            this.btnOrders.Click    += new System.EventHandler(this.btnOrders_Click);

//            // btnLogout
//            this.btnLogout.Text      = "Logout";
//            this.btnLogout.Location  = new System.Drawing.Point(left2, top2);
//            this.btnLogout.Size      = new System.Drawing.Size(cardW, cardH);
//            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnLogout.BackColor = System.Drawing.Color.White;
//            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
//            this.btnLogout.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
//            this.btnLogout.Cursor    = System.Windows.Forms.Cursors.Hand;
//            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(231, 76, 60);
//            this.btnLogout.FlatAppearance.BorderSize  = 2;
//            this.btnLogout.Click    += new System.EventHandler(this.btnLogout_Click);

//            // ???????????????????????????????????????
//            //  AdminMainForm
//            // ???????????????????????????????????????
//            this.ClientSize      = new System.Drawing.Size(left2 + cardW + 40, top2 + cardH + 35);
//            this.BackColor       = System.Drawing.Color.FromArgb(245, 247, 250);
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
//            this.MaximizeBox     = false;
//            this.Controls.Add(this.pnlHeader);
//            this.Controls.AddRange(new System.Windows.Forms.Control[] {
//                this.btnCategories, this.btnProducts,
//                this.btnOrders, this.btnLogout
//            });
//            this.Text            = "Admin Dashboard";
//            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
//            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
//            this.AutoScaleMode   = System.Windows.Forms.AutoScaleMode.Font;
//            this.ResumeLayout(false);
//            this.PerformLayout();
//        }
//    }
//}


namespace Presentation.Forms
{
    partial class AdminMainForm
    {
        private System.ComponentModel.IContainer components = null;

        // ── Layout Panels ──────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlSidebarAccent;

        // ── Sidebar Brand ──────────────────────────────────────────────────────
        private System.Windows.Forms.Label lblBrandIcon;
        private System.Windows.Forms.Label lblBrandName;
        private System.Windows.Forms.Label lblBrandTagline;
        private System.Windows.Forms.Panel pnlBrandDivider;

        // ── Sidebar Nav Buttons ────────────────────────────────────────────────
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Panel pnlNavDivider;
        private System.Windows.Forms.Button btnLogout;

        // ── Sidebar User Info ──────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlUserCard;
        private System.Windows.Forms.Label lblUserAvatar;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserRole;

        // ── Top Bar ────────────────────────────────────────────────────────────
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblPageSubtitle;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label lblStatusDot;
        private System.Windows.Forms.Label lblStatusText;

        // ── Stat Cards ─────────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlCardCategories;
        private System.Windows.Forms.Panel pnlCardProducts;
        private System.Windows.Forms.Panel pnlCardOrders;
        //private System.Windows.Forms.Panel pnlCardRevenue;

        // ── Quick Action Buttons ───────────────────────────────────────────────
        private System.Windows.Forms.Button btnQuickCategories;
        private System.Windows.Forms.Button btnQuickProducts;
        private System.Windows.Forms.Button btnQuickOrders;

        // ── Section Labels ─────────────────────────────────────────────────────
        private System.Windows.Forms.Label lblStatsSection;
        private System.Windows.Forms.Label lblActionsSection;

        // ── Timer ──────────────────────────────────────────────────────────────
        private System.Windows.Forms.Timer tmrClock;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // ── Instantiate all controls ───────────────────────────────────────
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlSidebarAccent = new System.Windows.Forms.Panel();
            this.pnlBrandDivider = new System.Windows.Forms.Panel();
            this.pnlNavDivider = new System.Windows.Forms.Panel();
            this.pnlUserCard = new System.Windows.Forms.Panel();

            this.lblBrandIcon = new System.Windows.Forms.Label();
            this.lblBrandName = new System.Windows.Forms.Label();
            this.lblBrandTagline = new System.Windows.Forms.Label();
            this.lblUserAvatar = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblPageSubtitle = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblStatusDot = new System.Windows.Forms.Label();
            this.lblStatusText = new System.Windows.Forms.Label();
            this.lblStatsSection = new System.Windows.Forms.Label();
            this.lblActionsSection = new System.Windows.Forms.Label();

            this.btnCategories = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnQuickCategories = new System.Windows.Forms.Button();
            this.btnQuickProducts = new System.Windows.Forms.Button();
            this.btnQuickOrders = new System.Windows.Forms.Button();

            this.pnlCardCategories = new System.Windows.Forms.Panel();
            this.pnlCardProducts = new System.Windows.Forms.Panel();
            this.pnlCardOrders = new System.Windows.Forms.Panel();
            //this.pnlCardRevenue = new System.Windows.Forms.Panel();

            this.tmrClock = new System.Windows.Forms.Timer(this.components);

            this.SuspendLayout();

            // ══════════════════════════════════════════════════════════════════
            //  COLOUR PALETTE
            // ══════════════════════════════════════════════════════════════════
            var clrSidebar = System.Drawing.Color.FromArgb(15, 17, 26);
            var clrSidebarHover = System.Drawing.Color.FromArgb(28, 32, 48);
            var clrTopBar = System.Drawing.Color.FromArgb(250, 251, 254);
            var clrContent = System.Drawing.Color.FromArgb(243, 245, 250);
            var clrAccent = System.Drawing.Color.FromArgb(99, 102, 241);   // indigo
            var clrAccentSoft = System.Drawing.Color.FromArgb(238, 242, 255);
            var clrTextPrimary = System.Drawing.Color.FromArgb(17, 24, 39);
            var clrTextMuted = System.Drawing.Color.FromArgb(107, 114, 128);
            var clrSideText = System.Drawing.Color.FromArgb(156, 163, 175);
            var clrWhite = System.Drawing.Color.White;
            var clrBorder = System.Drawing.Color.FromArgb(229, 231, 235);

            // ══════════════════════════════════════════════════════════════════
            //  SIDEBAR  (240 px wide, full height, dark)
            // ══════════════════════════════════════════════════════════════════
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Width = 240;
            this.pnlSidebar.BackColor = clrSidebar;

            // Left accent strip
            this.pnlSidebarAccent.Name = "pnlSidebarAccent";
            this.pnlSidebarAccent.Width = 3;
            this.pnlSidebarAccent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebarAccent.BackColor = clrAccent;
            this.pnlSidebar.Controls.Add(this.pnlSidebarAccent);

            // ── Brand area ────────────────────────────────────────────────────
            this.lblBrandIcon.Name = "lblBrandIcon";
            this.lblBrandIcon.Text = "◈";
            this.lblBrandIcon.Font = new System.Drawing.Font("Segoe UI Symbol", 26F, System.Drawing.FontStyle.Regular);
            this.lblBrandIcon.ForeColor = clrAccent;
            this.lblBrandIcon.Location = new System.Drawing.Point(22, 26);
            this.lblBrandIcon.Size = new System.Drawing.Size(40, 40);
            this.lblBrandIcon.BackColor = System.Drawing.Color.Transparent;

            this.lblBrandName.Name = "lblBrandName";
            this.lblBrandName.Text = "NexAdmin";
            this.lblBrandName.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.lblBrandName.ForeColor = clrWhite;
            this.lblBrandName.Location = new System.Drawing.Point(65, 28);
            this.lblBrandName.Size = new System.Drawing.Size(160, 26);
            this.lblBrandName.BackColor = System.Drawing.Color.Transparent;

            this.lblBrandTagline.Name = "lblBrandTagline";
            this.lblBrandTagline.Text = "Control Centre";
            this.lblBrandTagline.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBrandTagline.ForeColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.lblBrandTagline.Location = new System.Drawing.Point(67, 52);
            this.lblBrandTagline.Size = new System.Drawing.Size(160, 16);
            this.lblBrandTagline.BackColor = System.Drawing.Color.Transparent;

            this.pnlBrandDivider.Name = "pnlBrandDivider";
            this.pnlBrandDivider.Height = 1;
            this.pnlBrandDivider.Width = 196;
            this.pnlBrandDivider.Location = new System.Drawing.Point(22, 84);
            this.pnlBrandDivider.BackColor = System.Drawing.Color.FromArgb(40, 45, 60);

            // Nav section label
            var lblNavSection = new System.Windows.Forms.Label();
            lblNavSection.Text = "NAVIGATION";
            lblNavSection.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            lblNavSection.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            lblNavSection.Location = new System.Drawing.Point(22, 100);
            lblNavSection.Size = new System.Drawing.Size(196, 18);
            lblNavSection.BackColor = System.Drawing.Color.Transparent;

            // ── Nav Buttons (helper lambda) ────────────────────────────────────
            System.Windows.Forms.Button MakeNavBtn(string icon, string label, int top)
            {
                var btn = new System.Windows.Forms.Button();
                btn.Text = $"  {icon}   {label}";
                btn.Font = new System.Drawing.Font("Segoe UI", 10F);
                btn.ForeColor = clrSideText;
                btn.BackColor = System.Drawing.Color.Transparent;
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = clrSidebarHover;
                btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(35, 40, 58);
                btn.Location = new System.Drawing.Point(10, top);
                btn.Size = new System.Drawing.Size(220, 42);
                btn.Cursor = System.Windows.Forms.Cursors.Hand;
                btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btn.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
                btn.BackColor = System.Drawing.Color.Transparent;
                return btn;
            }

            this.btnCategories = MakeNavBtn("▤", "Categories", 128);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);

            this.btnProducts = MakeNavBtn("⊞", "Products", 174);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);

            this.btnOrders = MakeNavBtn("◎", "Orders", 220);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);

            // Nav divider
            this.pnlNavDivider.Name = "pnlNavDivider";
            this.pnlNavDivider.Height = 1;
            this.pnlNavDivider.Width = 196;
            this.pnlNavDivider.Location = new System.Drawing.Point(22, 278);
            this.pnlNavDivider.BackColor = System.Drawing.Color.FromArgb(40, 45, 60);

            // ── User card (bottom of sidebar) ──────────────────────────────────
            this.pnlUserCard.Name = "pnlUserCard";
            this.pnlUserCard.Location = new System.Drawing.Point(12, 440);
            this.pnlUserCard.Size = new System.Drawing.Size(216, 64);
            this.pnlUserCard.BackColor = System.Drawing.Color.FromArgb(22, 27, 40);

            this.lblUserAvatar.Name = "lblUserAvatar";
            this.lblUserAvatar.Text = "A";
            this.lblUserAvatar.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblUserAvatar.ForeColor = clrWhite;
            this.lblUserAvatar.BackColor = clrAccent;
            this.lblUserAvatar.Location = new System.Drawing.Point(10, 12);
            this.lblUserAvatar.Size = new System.Drawing.Size(40, 40);
            this.lblUserAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Text = "Administrator";
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ForeColor = clrWhite;
            this.lblUserName.Location = new System.Drawing.Point(58, 15);
            this.lblUserName.Size = new System.Drawing.Size(150, 18);
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;

            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Text = "Super Admin";
            this.lblUserRole.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblUserRole.ForeColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.lblUserRole.Location = new System.Drawing.Point(58, 35);
            this.lblUserRole.Size = new System.Drawing.Size(150, 16);
            this.lblUserRole.BackColor = System.Drawing.Color.Transparent;

            this.pnlUserCard.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblUserAvatar, this.lblUserName, this.lblUserRole
            });

            // Logout button
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Text = "  Sign Out";
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(35, 20, 20);
            this.btnLogout.Location = new System.Drawing.Point(10, 516);
            this.btnLogout.Size = new System.Drawing.Size(220, 42);
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // ── Add all sidebar controls ───────────────────────────────────────
            this.pnlSidebar.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblBrandIcon,   this.lblBrandName,    this.lblBrandTagline,
                this.pnlBrandDivider, lblNavSection,
                this.btnCategories,  this.btnProducts,     this.btnOrders,
                this.pnlNavDivider,  this.pnlUserCard,     this.btnLogout
            });

            // ══════════════════════════════════════════════════════════════════
            //  TOP BAR  (60 px tall, right of sidebar)
            // ══════════════════════════════════════════════════════════════════
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Height = 64;
            this.pnlTopBar.BackColor = clrTopBar;

            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Text = "Dashboard Overview";
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = clrTextPrimary;
            this.lblPageTitle.Location = new System.Drawing.Point(28, 10);
            this.lblPageTitle.Size = new System.Drawing.Size(340, 26);
            this.lblPageTitle.BackColor = System.Drawing.Color.Transparent;

            this.lblPageSubtitle.Name = "lblPageSubtitle";
            this.lblPageSubtitle.Text = "Welcome back — here's what's happening today.";
            this.lblPageSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPageSubtitle.ForeColor = clrTextMuted;
            this.lblPageSubtitle.Location = new System.Drawing.Point(30, 36);
            this.lblPageSubtitle.Size = new System.Drawing.Size(400, 18);
            this.lblPageSubtitle.BackColor = System.Drawing.Color.Transparent;

            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Text = System.DateTime.Now.ToString("ddd dd MMM yyyy  •  HH:mm");
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDateTime.ForeColor = clrTextMuted;
            this.lblDateTime.Size = new System.Drawing.Size(260, 18);
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDateTime.BackColor = System.Drawing.Color.Transparent;
            // anchored right — positioned after form size is set below

            this.lblStatusDot.Name = "lblStatusDot";
            this.lblStatusDot.Text = "●";
            this.lblStatusDot.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblStatusDot.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.lblStatusDot.Size = new System.Drawing.Size(16, 18);
            this.lblStatusDot.BackColor = System.Drawing.Color.Transparent;

            this.lblStatusText.Name = "lblStatusText";
            this.lblStatusText.Text = "All systems operational";
            this.lblStatusText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatusText.ForeColor = clrTextMuted;
            this.lblStatusText.Size = new System.Drawing.Size(180, 18);
            this.lblStatusText.BackColor = System.Drawing.Color.Transparent;

            this.pnlTopBar.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblPageTitle, this.lblPageSubtitle,
                this.lblDateTime, this.lblStatusDot, this.lblStatusText
            });

            // Top-bar bottom border
            var pnlTopBorder = new System.Windows.Forms.Panel();
            pnlTopBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlTopBorder.Height = 1;
            pnlTopBorder.BackColor = clrBorder;
            this.pnlTopBar.Controls.Add(pnlTopBorder);

            // ══════════════════════════════════════════════════════════════════
            //  CONTENT PANEL  (fills remaining space)
            // ══════════════════════════════════════════════════════════════════
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.BackColor = clrContent;
            this.pnlContent.Padding = new System.Windows.Forms.Padding(28, 24, 28, 20);

            // ── Section label helper ───────────────────────────────────────────
            System.Windows.Forms.Label MakeSectionLabel(string text, int x, int y)
            {
                var lbl = new System.Windows.Forms.Label();
                lbl.Text = text;
                lbl.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
                lbl.ForeColor = clrTextMuted;
                lbl.Location = new System.Drawing.Point(x, y);
                lbl.Size = new System.Drawing.Size(380, 18);
                lbl.BackColor = System.Drawing.Color.Transparent;
                return lbl;
            }

            this.lblStatsSection = MakeSectionLabel("OVERVIEW", 28, 16);
            this.lblActionsSection = MakeSectionLabel("QUICK ACTIONS", 28, 156);

            // ── Stat card helper ───────────────────────────────────────────────
            System.Windows.Forms.Panel MakeStatCard(
                string icon, string title, string value, string sub,
                System.Drawing.Color accent, int x, int y)
            {
                var card = new System.Windows.Forms.Panel();
                card.Location = new System.Drawing.Point(x, y);
                card.Size = new System.Drawing.Size(158, 118);
                card.BackColor = clrWhite;
                card.Cursor = System.Windows.Forms.Cursors.Default;

                var lblIcon = new System.Windows.Forms.Label();
                lblIcon.Text = icon;
                lblIcon.Font = new System.Drawing.Font("Segoe UI Symbol", 16F);
                lblIcon.ForeColor = accent;
                lblIcon.Location = new System.Drawing.Point(14, 14);
                lblIcon.Size = new System.Drawing.Size(36, 32);
                lblIcon.BackColor = System.Drawing.Color.Transparent;

                var lblTitle = new System.Windows.Forms.Label();
                lblTitle.Text = title;
                lblTitle.Font = new System.Drawing.Font("Segoe UI", 8F);
                lblTitle.ForeColor = clrTextMuted;
                lblTitle.Location = new System.Drawing.Point(14, 52);
                lblTitle.Size = new System.Drawing.Size(130, 16);
                lblTitle.BackColor = System.Drawing.Color.Transparent;

                var lblValue = new System.Windows.Forms.Label();
                lblValue.Text = value;
                lblValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
                lblValue.ForeColor = clrTextPrimary;
                lblValue.Location = new System.Drawing.Point(12, 66);
                lblValue.AutoSize = true;
                lblValue.BackColor = System.Drawing.Color.Transparent;

                var pnlAccentBar = new System.Windows.Forms.Panel();
                pnlAccentBar.Dock = System.Windows.Forms.DockStyle.Bottom;
                pnlAccentBar.Height = 3;
                pnlAccentBar.BackColor = accent;

                card.Controls.AddRange(new System.Windows.Forms.Control[] {
                    lblIcon, lblTitle, lblValue, pnlAccentBar
                });
                return card;
            }

            int cardTop = 38;
            int cardGap = 18;
            int cardLeft = 28;
            int cw = 158;

            this.pnlCardCategories = MakeStatCard("▤", "Categories", "—", "", System.Drawing.Color.FromArgb(99, 102, 241), cardLeft, cardTop);
            this.pnlCardProducts = MakeStatCard("⊞", "Products", "—", "", System.Drawing.Color.FromArgb(20, 184, 166), cardLeft + (cw + cardGap), cardTop);
            this.pnlCardOrders = MakeStatCard("◎", "Pending Orders", "—", "", System.Drawing.Color.FromArgb(245, 158, 11), cardLeft + (cw + cardGap) * 2, cardTop);
            //this.pnlCardRevenue = MakeStatCard("$", "Revenue", "—", "", System.Drawing.Color.FromArgb(16, 185, 129), cardLeft + (cw + cardGap) * 3, cardTop);

            // ── Quick-action button helper ─────────────────────────────────────
            System.Windows.Forms.Button MakeActionBtn(
                string icon, string label, string sub,
                System.Drawing.Color accent, int x, int y)
            {
                var btn = new System.Windows.Forms.Button();
                btn.Text = $"{icon}  {label}";
                btn.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
                btn.ForeColor = clrWhite;
                btn.BackColor = accent;
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(
                    Math.Max(accent.R - 18, 0),
                    Math.Max(accent.G - 18, 0),
                    Math.Max(accent.B - 18, 0));
                btn.Location = new System.Drawing.Point(x, y);
                btn.Size = new System.Drawing.Size(210, 54);
                btn.Cursor = System.Windows.Forms.Cursors.Hand;
                btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                return btn;
            }

            int btnTop = 178;
            int btnGap = 22;
            int bw = 210;

            this.btnQuickCategories = MakeActionBtn("▤", "Manage Categories", "", System.Drawing.Color.FromArgb(99, 102, 241), cardLeft, btnTop);
            this.btnQuickProducts = MakeActionBtn("⊞", "Manage Products", "", System.Drawing.Color.FromArgb(20, 184, 166), cardLeft + bw + btnGap, btnTop);
            this.btnQuickOrders = MakeActionBtn("◎", "Track Orders", "", System.Drawing.Color.FromArgb(245, 158, 11), cardLeft + (bw + btnGap) * 2, btnTop);

            this.btnQuickCategories.Click += new System.EventHandler(this.btnCategories_Click);
            this.btnQuickProducts.Click += new System.EventHandler(this.btnProducts_Click);
            this.btnQuickOrders.Click += new System.EventHandler(this.btnOrders_Click);

            this.pnlContent.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblStatsSection,   this.lblActionsSection,
                this.pnlCardCategories, this.pnlCardProducts,
                this.pnlCardOrders,     //.pnlCardRevenue,
                this.btnQuickCategories,this.btnQuickProducts,
                this.btnQuickOrders
            });

            // ══════════════════════════════════════════════════════════════════
            //  CLOCK TIMER
            // ══════════════════════════════════════════════════════════════════
            this.tmrClock.Interval = 30000; // update every 30s
            this.tmrClock.Tick += (s, e) =>
                this.lblDateTime.Text = System.DateTime.Now.ToString("ddd dd MMM yyyy  •  HH:mm");
            this.tmrClock.Start();

            // ══════════════════════════════════════════════════════════════════
            //  FORM
            // ══════════════════════════════════════════════════════════════════
            int formW = 240 + 28 + (cw + cardGap) * 3 + cw + 28 + 16; // ~920
            int formH = 600;

            this.ClientSize = new System.Drawing.Size(920, 600);
            this.BackColor = clrContent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "NexAdmin — Dashboard";
            this.Name = "AdminMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            // Place top-bar INSIDE content flow; sidebar docked left
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlSidebar);

            // Position right-side top-bar labels (after form width known)
            int rightEdge = 920 - 240 - 20; // content width - right margin
            this.lblDateTime.Location = new System.Drawing.Point(rightEdge - 260, 24);
            this.lblStatusDot.Location = new System.Drawing.Point(rightEdge - 204, 46);
            this.lblStatusText.Location = new System.Drawing.Point(rightEdge - 188, 46);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}