using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Presentation.Utilities;

namespace Presentation.Forms
{
    /// <summary>
    /// Professional Admin Dashboard with unified design system
    /// </summary>
    public partial class AdminMainForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly CategoryAdminService _categoryAdminService;
        private Button? _activeNavBtn;

        public AdminMainForm(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            var categoryRepo = new CategoryRepository(_context);
            _categoryAdminService = new CategoryAdminService(categoryRepo);

            InitializeComponent();
            
            // Apply Modern Design System
            ModernDesignSystem.Forms.ApplyModernFormStyle(this, "Admin Dashboard", 1400, 800);
            ApplyModernStyling();
            WireHoverEffects();
            LoadSummaryCountsAsync();
        }

        // ──────────────────────────────────────────────────────────────────────
        //  Apply Modern Styling to All Components
        // ──────────────────────────────────────────────────────────────────────
        private void ApplyModernStyling()
        {
            // Style navigation buttons
            ModernDesignSystem.Buttons.ApplySecondaryStyle(btnCategories, "📦 Categories", 200, 50);
            ModernDesignSystem.Buttons.ApplySecondaryStyle(btnProducts, "🛍️ Products", 200, 50);
            ModernDesignSystem.Buttons.ApplySecondaryStyle(btnOrders, "📋 Orders", 200, 50);
            ModernDesignSystem.Buttons.ApplyDangerStyle(btnLogout, "🚪 Logout", 200, 50);

            // Style quick action buttons
            ModernDesignSystem.Buttons.ApplySuccessStyle(btnQuickCategories, "+ Categories", 180, 44);
            ModernDesignSystem.Buttons.ApplyPrimaryStyle(btnQuickProducts, "+ Products", 180, 44);
            ModernDesignSystem.Buttons.ApplyWarningStyle(btnQuickOrders, "📊 View Orders", 180, 44);

            // Style stat cards
            ModernDesignSystem.Panels.ApplyCardStyle(pnlCardCategories, 12);
            ModernDesignSystem.Panels.ApplyCardStyle(pnlCardProducts, 12);
            ModernDesignSystem.Panels.ApplyCardStyle(pnlCardOrders, 12);
            ModernDesignSystem.Panels.ApplyCardStyle(pnlUserCard, 10);
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
            if (ModernDesignSystem.Messages.ShowConfirmation(
                "Are you sure you want to logout?",
                "Confirm Logout") == DialogResult.Yes)
            {
                tmrClock.Stop();
                this.Close();
                new LoginForm().Show();
            }
        }

        // ──────────────────────────────────────────────────────────────────────
        //  Sidebar Active-State Highlight
        // ──────────────────────────────────────────────────────────────────────
        private void SetActiveNav(Button btn)
        {
            if (_activeNavBtn != null)
            {
                _activeNavBtn.ForeColor = ModernDesignSystem.Colors.TextSecondary;
                _activeNavBtn.BackColor = Color.Transparent;
            }

            btn.ForeColor = ModernDesignSystem.Colors.TextLight;
            btn.BackColor = ModernDesignSystem.Colors.ActiveBackground;
            _activeNavBtn = btn;
        }

        // ──────────────────────────────────────────────────────────────────────
        //  Hover Effects with Modern Design
        // ──────────────────────────────────────────────────────────────────────
        private void WireHoverEffects()
        {
            foreach (Button btn in new[] { btnCategories, btnProducts, btnOrders })
            {
                btn.MouseEnter += (s, _) =>
                {
                    if (s != _activeNavBtn)
                        ((Button)s!).ForeColor = ModernDesignSystem.Colors.TextLight;
                };
                btn.MouseLeave += (s, _) =>
                {
                    if (s != _activeNavBtn)
                        ((Button)s!).ForeColor = ModernDesignSystem.Colors.TextSecondary;
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
                    }));
                });
            }
            catch
            {
                // Non-fatal — cards remain with default values if DB unavailable
            }
        }

        private void RefreshCardCount(Panel card, Func<int> countFn)
        {
            try
            {
                SetCardValue(card, countFn().ToString());
            }
            catch { /* silent */ }
        }

        private static void SetCardValue(Panel card, string value)
        {
            foreach (Control c in card.Controls)
                if (c is Label lbl && lbl.Font.Size >= 18f)
                {
                    lbl.Text = value;
                    lbl.ForeColor = ModernDesignSystem.Colors.Primary;
                    break;
                }
        }

        // ── Count helpers ──────────────────────────────────────────────────────
        private int GetCategoryCount() => _categoryAdminService.GetAll().Count();
        private int GetProductCount() => _context.Products?.Count() ?? 0;
        private int GetPendingOrderCount() => _context.Orders?.Count() ?? 0;

        // ──────────────────────────────────────────────────────────────────────
        //  Rounded corners on components
        // ──────────────────────────────────────────────────────────────────────
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ModernDesignSystem.ApplyRoundedCorners(pnlCardCategories, 12);
            ModernDesignSystem.ApplyRoundedCorners(pnlCardProducts, 12);
            ModernDesignSystem.ApplyRoundedCorners(pnlCardOrders, 12);
            ModernDesignSystem.ApplyRoundedCorners(pnlUserCard, 10);

            foreach (Button btn in new[] { btnQuickCategories, btnQuickProducts, btnQuickOrders })
                ModernDesignSystem.ApplyRoundedCorners(btn, 8);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            tmrClock.Stop();
            base.OnFormClosed(e);
        }
    }
}
