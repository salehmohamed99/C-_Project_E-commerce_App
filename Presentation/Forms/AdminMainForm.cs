////using System.Windows.Forms;
////using Infrastructure.Data;

////namespace Presentation.Forms
////{
////    public partial class AdminMainForm : Form
////    {
////        private ApplicationDbContext _context;

////        public AdminMainForm(ApplicationDbContext context)
////        {
////            InitializeComponent();
////            _context = context;
////        }

////        private void btnCategories_Click(object sender, EventArgs e) =>
////            new CategoryManagementForm(_context).ShowDialog();

////        private void btnProducts_Click(object sender, EventArgs e) =>
////            new ProductManagementForm(_context).ShowDialog();

////        private void btnOrders_Click(object sender, EventArgs e) =>
////            new OrderTrackingForm(_context).ShowDialog();

////        private void btnLogout_Click(object sender, EventArgs e)
////        {
////            this.Close();
////            new LoginForm().Show();
////        }
////    }
////}
//using System;
//using System.Drawing;
//using System.Drawing.Drawing2D;
//using System.Windows.Forms;
//using Infrastructure.Data;

//namespace Presentation.Forms
//{
//    /// <summary>
//    /// Professional Admin Dashboard — dark sidebar layout with stat cards
//    /// and quick-action buttons. Loads live summary counts on startup.
//    /// </summary>
//    public partial class AdminMainForm : Form
//    {
//        // ── Dependencies ───────────────────────────────────────────────────────
//        private readonly ApplicationDbContext _context;

//        // ── Sidebar active-nav state ───────────────────────────────────────────
//        private Button? _activeNavBtn;

//        // ──────────────────────────────────────────────────────────────────────
//        //  Constructor
//        // ──────────────────────────────────────────────────────────────────────
//        public AdminMainForm(ApplicationDbContext context)
//        {
//            _context = context ?? throw new ArgumentNullException(nameof(context));
//            InitializeComponent();
//            WireHoverEffects();
//            LoadSummaryCountsAsync();
//        }

//        // ──────────────────────────────────────────────────────────────────────
//        //  Sidebar Nav Handlers
//        // ──────────────────────────────────────────────────────────────────────
//        private void btnCategories_Click(object sender, EventArgs e)
//        {
//            SetActiveNav(btnCategories);
//            using var form = new CategoryManagementForm(_context);
//            form.ShowDialog(this);
//            RefreshCardCount(pnlCardCategories, GetCategoryCount);
//        }

//        private void btnProducts_Click(object sender, EventArgs e)
//        {
//            SetActiveNav(btnProducts);
//            using var form = new ProductManagementForm(_context);
//            form.ShowDialog(this);
//            RefreshCardCount(pnlCardProducts, GetProductCount);
//        }

//        private void btnOrders_Click(object sender, EventArgs e)
//        {
//            SetActiveNav(btnOrders);
//            using var form = new OrderTrackingForm(_context);
//            form.ShowDialog(this);
//            RefreshCardCount(pnlCardOrders, GetPendingOrderCount);
//        }

//        private void btnLogout_Click(object sender, EventArgs e)
//        {
//            tmrClock.Stop();
//            this.Close();
//            new LoginForm().Show();
//        }

//        // ──────────────────────────────────────────────────────────────────────
//        //  Sidebar Active-State Highlight
//        // ──────────────────────────────────────────────────────────────────────
//        private void SetActiveNav(Button btn)
//        {
//            var accent = Color.FromArgb(99, 102, 241);
//            var sideText = Color.FromArgb(156, 163, 175);
//            var activeBack = Color.FromArgb(28, 32, 48);

//            // Reset previous
//            if (_activeNavBtn != null)
//            {
//                _activeNavBtn.ForeColor = sideText;
//                _activeNavBtn.BackColor = Color.Transparent;
//            }

//            // Highlight new
//            btn.ForeColor = Color.White;
//            btn.BackColor = activeBack;
//            _activeNavBtn = btn;
//        }

//        // ──────────────────────────────────────────────────────────────────────
//        //  Hover polish — make sidebar buttons show a left accent line
//        // ──────────────────────────────────────────────────────────────────────
//        private void WireHoverEffects()
//        {
//            foreach (Button btn in new[] { btnCategories, btnProducts, btnOrders })
//            {
//                btn.MouseEnter += (s, _) =>
//                {
//                    if (s != _activeNavBtn)
//                        ((Button)s!).ForeColor = Color.White;
//                };
//                btn.MouseLeave += (s, _) =>
//                {
//                    if (s != _activeNavBtn)
//                        ((Button)s!).ForeColor = Color.FromArgb(156, 163, 175);
//                };
//            }

//            // Quick-action buttons: subtle scale illusion via padding swap
//            foreach (Button btn in new[] { btnQuickCategories, btnQuickProducts, btnQuickOrders })
//            {
//                var orig = btn.Padding;
//                btn.MouseEnter += (s, _) => ((Button)s!).Padding = new Padding(0, 0, 0, 3);
//                btn.MouseLeave += (s, _) => ((Button)s!).Padding = orig;
//            }
//        }

//        // ──────────────────────────────────────────────────────────────────────
//        //  Stat Card Live Counts
//        // ──────────────────────────────────────────────────────────────────────
//        private async void LoadSummaryCountsAsync()
//        {
//            try
//            {
//                await System.Threading.Tasks.Task.Run(() =>
//                {
//                    var cats = GetCategoryCount();
//                    var prods = GetProductCount();
//                    var orders = GetPendingOrderCount();

//                    this.Invoke(new Action(() =>
//                    {
//                        SetCardValue(pnlCardCategories, cats.ToString());
//                        SetCardValue(pnlCardProducts, prods.ToString());
//                        SetCardValue(pnlCardOrders, orders.ToString());
//                        SetCardValue(pnlCardRevenue, "—");   // extend as needed
//                    }));
//                });
//            }
//            catch
//            {
//                // If DB is unavailable on load, cards remain "—" — non-fatal.
//            }
//        }

//        private void RefreshCardCount(Panel card, Func<int> countFn)
//        {
//            try { SetCardValue(card, countFn().ToString()); }
//            catch { /* silent — counts are decorative */ }
//        }

//        /// <summary>Finds the value label (largest font) in a stat card and updates it.</summary>
//        private static void SetCardValue(Panel card, string value)
//        {
//            foreach (Control c in card.Controls)
//                if (c is Label lbl && lbl.Font.Size >= 18f)
//                { lbl.Text = value; break; }
//        }

//        // ── DB helpers (replace with your repository calls as needed) ──────────
//        private int GetCategoryCount()
//        {
//            // Example: return _context.Categories.Count();
//            return _context.Categories?.Count() ?? 0;
//        }

//        private int GetProductCount()
//        {
//            return _context.Products?.Count() ?? 0;
//        }

//        private int GetPendingOrderCount()
//        {
//            // Example: return _context.Orders.Count(o => o.Status == "Pending");
//            return _context.Orders?.Count() ?? 0;
//        }

//        // ──────────────────────────────────────────────────────────────────────
//        //  Custom painting — rounded corners on stat cards
//        // ──────────────────────────────────────────────────────────────────────
//        protected override void OnLoad(EventArgs e)
//        {
//            base.OnLoad(e);
//            ApplyRoundedCorners(pnlCardCategories, 10);
//            ApplyRoundedCorners(pnlCardProducts, 10);
//            ApplyRoundedCorners(pnlCardOrders, 10);
//            ApplyRoundedCorners(pnlCardRevenue, 10);
//            ApplyRoundedCorners(pnlUserCard, 8);

//            foreach (Button btn in new[] { btnQuickCategories, btnQuickProducts, btnQuickOrders })
//                ApplyRoundedCorners(btn, 8);
//        }

//        private static void ApplyRoundedCorners(Control ctrl, int radius)
//        {
//            var path = new System.Drawing.Drawing2D.GraphicsPath();
//            int d = radius * 2;
//            path.AddArc(0, 0, d, d, 180, 90);
//            path.AddArc(ctrl.Width - d, 0, d, d, 270, 90);
//            path.AddArc(ctrl.Width - d, ctrl.Height - d, d, d, 0, 90);
//            path.AddArc(0, ctrl.Height - d, d, d, 90, 90);
//            path.CloseFigure();
//            ctrl.Region = new Region(path);
//        }

//        // ──────────────────────────────────────────────────────────────────────
//        //  Clean-up
//        // ──────────────────────────────────────────────────────────────────────
//        protected override void OnFormClosed(FormClosedEventArgs e)
//        {
//            tmrClock.Stop();
//            base.OnFormClosed(e);
//        }
//    }
//}

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Presentation.Forms
{
    /// <summary>
    /// Professional Admin Dashboard — dark sidebar layout with stat cards
    /// and quick-action buttons. Loads live summary counts on startup.
    /// </summary>
    public partial class AdminMainForm : Form
    {
        // ── Dependencies ───────────────────────────────────────────────────────
        private readonly ApplicationDbContext _context;
        private readonly CategoryAdminService _categoryAdminService;

        // ── Sidebar active-nav state ───────────────────────────────────────────
        private Button? _activeNavBtn;

        // ──────────────────────────────────────────────────────────────────────
        //  Constructor
        // ──────────────────────────────────────────────────────────────────────
        public AdminMainForm(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            // Build services once — reused for stat card refreshes
            var categoryRepo = new CategoryRepository(_context);
            _categoryAdminService = new CategoryAdminService(categoryRepo);

            InitializeComponent();
            WireHoverEffects();
            LoadSummaryCountsAsync();
        }

        // ──────────────────────────────────────────────────────────────────────
        //  Sidebar Nav Handlers
        // ──────────────────────────────────────────────────────────────────────
        private void btnCategories_Click(object sender, EventArgs e)
        {
            SetActiveNav(btnCategories);
            using var form = new CategoryManagementForm(_categoryAdminService);
            form.ShowDialog(this);
            RefreshCardCount(pnlCardCategories, GetCategoryCount);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            SetActiveNav(btnProducts);
            using var form = new ProductManagementForm(_context);
            form.ShowDialog(this);
            RefreshCardCount(pnlCardProducts, GetProductCount);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            SetActiveNav(btnOrders);
            using var form = new OrderTrackingForm(_context);
            form.ShowDialog(this);
            RefreshCardCount(pnlCardOrders, GetPendingOrderCount);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            tmrClock.Stop();
            this.Close();
            new LoginForm().Show();
        }

        // ──────────────────────────────────────────────────────────────────────
        //  Sidebar Active-State Highlight
        // ──────────────────────────────────────────────────────────────────────
        private void SetActiveNav(Button btn)
        {
            var sideText = Color.FromArgb(156, 163, 175);
            var activeBack = Color.FromArgb(28, 32, 48);

            if (_activeNavBtn != null)
            {
                _activeNavBtn.ForeColor = sideText;
                _activeNavBtn.BackColor = Color.Transparent;
            }

            btn.ForeColor = Color.White;
            btn.BackColor = activeBack;
            _activeNavBtn = btn;
        }

        // ──────────────────────────────────────────────────────────────────────
        //  Hover polish
        // ──────────────────────────────────────────────────────────────────────
        private void WireHoverEffects()
        {
            foreach (Button btn in new[] { btnCategories, btnProducts, btnOrders })
            {
                btn.MouseEnter += (s, _) =>
                {
                    if (s != _activeNavBtn)
                        ((Button)s!).ForeColor = Color.White;
                };
                btn.MouseLeave += (s, _) =>
                {
                    if (s != _activeNavBtn)
                        ((Button)s!).ForeColor = Color.FromArgb(156, 163, 175);
                };
            }

            foreach (Button btn in new[] { btnQuickCategories, btnQuickProducts, btnQuickOrders })
            {
                var orig = btn.Padding;
                btn.MouseEnter += (s, _) => ((Button)s!).Padding = new Padding(0, 0, 0, 3);
                btn.MouseLeave += (s, _) => ((Button)s!).Padding = orig;
            }
        }

        // ──────────────────────────────────────────────────────────────────────
        //  Stat Card Live Counts
        // ──────────────────────────────────────────────────────────────────────
        private async void LoadSummaryCountsAsync()
        {
            try
            {
                await System.Threading.Tasks.Task.Run(() =>
                {
                    var cats = GetCategoryCount();
                    var prods = GetProductCount();
                    var orders = GetPendingOrderCount();

                    this.Invoke(new Action(() =>
                    {
                        SetCardValue(pnlCardCategories, cats.ToString());
                        SetCardValue(pnlCardProducts, prods.ToString());
                        SetCardValue(pnlCardOrders, orders.ToString());
                        SetCardValue(pnlCardRevenue, "—");
                    }));
                });
            }
            catch
            {
                // Non-fatal — cards remain "—" if DB unavailable
            }
        }

        private void RefreshCardCount(Panel card, Func<int> countFn)
        {
            try { SetCardValue(card, countFn().ToString()); }
            catch { /* silent */ }
        }

        private static void SetCardValue(Panel card, string value)
        {
            foreach (Control c in card.Controls)
                if (c is Label lbl && lbl.Font.Size >= 18f)
                { lbl.Text = value; break; }
        }

        // ── Count helpers ──────────────────────────────────────────────────────
        private int GetCategoryCount() =>
            _categoryAdminService.GetAll().Count();

        private int GetProductCount() =>
            _context.Products?.Count() ?? 0;

        private int GetPendingOrderCount() =>
            _context.Orders?.Count() ?? 0;

        // ──────────────────────────────────────────────────────────────────────
        //  Rounded corners on stat cards
        // ──────────────────────────────────────────────────────────────────────
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyRoundedCorners(pnlCardCategories, 10);
            ApplyRoundedCorners(pnlCardProducts, 10);
            ApplyRoundedCorners(pnlCardOrders, 10);
            ApplyRoundedCorners(pnlCardRevenue, 10);
            ApplyRoundedCorners(pnlUserCard, 8);

            foreach (Button btn in new[] { btnQuickCategories, btnQuickProducts, btnQuickOrders })
                ApplyRoundedCorners(btn, 8);
        }

        private static void ApplyRoundedCorners(Control ctrl, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(0, 0, d, d, 180, 90);
            path.AddArc(ctrl.Width - d, 0, d, d, 270, 90);
            path.AddArc(ctrl.Width - d, ctrl.Height - d, d, d, 0, 90);
            path.AddArc(0, ctrl.Height - d, d, d, 90, 90);
            path.CloseFigure();
            ctrl.Region = new Region(path);
        }

        // ──────────────────────────────────────────────────────────────────────
        //  Clean-up
        // ──────────────────────────────────────────────────────────────────────
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            tmrClock.Stop();
            base.OnFormClosed(e);
        }
    }
}
