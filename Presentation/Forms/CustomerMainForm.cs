using System;
using System.Drawing;
using System.Windows.Forms;
using Infrastructure.Data;
using Presentation.Utilities;

namespace Presentation.Forms
{
    public partial class CustomerMainForm : Form
    {
        private ApplicationDbContext _context;
        private int _userId;
        private Button? _activeNavBtn;

        public CustomerMainForm(ApplicationDbContext context, int userId)
        {
            InitializeComponent();
            _context = context;
            _userId = userId;

            // Apply Modern Design
            ModernDesignSystem.Forms.ApplyModernFormStyle(this, "Customer Dashboard", 1200, 700);
            ApplyModernStyling();
            LoadWelcomeMessage();
        }

        private void ApplyModernStyling()
        {
            // Style navigation buttons
            ModernDesignSystem.Buttons.ApplyPrimaryStyle(btnBrowse, "Browse Products", 200, 50);
            ModernDesignSystem.Buttons.ApplySuccessStyle(btnCart, "My Cart", 200, 50);
            ModernDesignSystem.Buttons.ApplyWarningStyle(btnOrders, "My Orders", 200, 50);
            ModernDesignSystem.Buttons.ApplyDangerStyle(btnLogout, "Logout", 200, 50);

            // Add hover effects
            WireHoverEffects();
        }

        private void WireHoverEffects()
        {
            foreach (Button btn in new[] { btnBrowse, btnCart, btnOrders })
            {
                var originalPadding = btn.Padding;
                btn.MouseEnter += (s, _) =>
                {
                    if (s != _activeNavBtn)
                        ((Button)s!).Padding = new Padding(0, 0, 0, 3);
                };
                btn.MouseLeave += (s, _) =>
                {
                    if (s != _activeNavBtn)
                        ((Button)s!).Padding = originalPadding;
                };
            }
        }

        private void LoadWelcomeMessage()
        {
            try
            {
                var user = _context.Users?.Find(_userId);
                if (user != null && lblSubtitle != null)
                {
                    lblSubtitle.Text = $"Welcome back, {user.Name}! What would you like to do today?";
                    lblSubtitle.ForeColor = ModernDesignSystem.Colors.TextMuted;
                }
            }
            catch { /* Silent - not critical */ }
        }

        private void SetActiveNav(Button btn)
        {
            if (_activeNavBtn != null)
            {
                _activeNavBtn.BackColor = GetOriginalButtonColor(_activeNavBtn);
            }

            var darker = Color.FromArgb(
                Math.Max(0, btn.BackColor.R - 30),
                Math.Max(0, btn.BackColor.G - 30),
                Math.Max(0, btn.BackColor.B - 30)
            );
            btn.BackColor = darker;
            _activeNavBtn = btn;
        }

        private Color GetOriginalButtonColor(Button btn)
        {
            if (btn == btnBrowse) return ModernDesignSystem.Colors.Primary;
            if (btn == btnCart) return ModernDesignSystem.Colors.Success;
            if (btn == btnOrders) return ModernDesignSystem.Colors.Warning;
            return btn.BackColor;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            SetActiveNav(btnBrowse);
            using var form = new ProductBrowsingForm(_context, _userId);
            form.ShowDialog(this);
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            SetActiveNav(btnCart);
            using var form = new CartForm(_context, _userId);
            form.ShowDialog(this);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            SetActiveNav(btnOrders);
            using var form = new MyOrdersForm(_context, _userId);
            form.ShowDialog(this);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (ModernDesignSystem.Messages.ShowConfirmation(
                "Are you sure you want to logout?",
                "Confirm Logout") == DialogResult.Yes)
            {
                this.Close();
                new LoginForm().Show();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Apply rounded corners to welcome card if exists
            var pnlWelcome = this.Controls.Find("pnlWelcome", true).FirstOrDefault() as Panel;
            if (pnlWelcome != null)
                ModernDesignSystem.Panels.ApplyCardStyle(pnlWelcome, 12);
        }

        private void CustomerMainForm_Load(object sender, EventArgs e) { }
    }
}
