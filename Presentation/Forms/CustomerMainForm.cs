using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Infrastructure.Data;
using Presentation.Utilities;

namespace Presentation.Forms
{
    public partial class CustomerMainForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly int _userId;
        private Button? _activeNavBtn;

        public CustomerMainForm(ApplicationDbContext context, int userId)
        {
            InitializeComponent();
            _context = context;
            _userId = userId;

            // Apply global modern styles
            ModernDesignSystem.Forms.ApplyModernFormStyle(this, "NexShop", 1100, 700);

            // Setup visual interactions (hover, etc.)
            SetupVisuals();
            LoadWelcomeMessage();

            // Default view on load: Browse Products
            ShowBrowseProducts();
        }

        #region Navigation Logic

        private void OpenChildForm(Form childForm, Button navButton, string title, string subtitle)
        {
            // 1. Update Sidebar Highlight
            SetActiveNav(navButton);

            // 2. Update Header Text
            //lblTitle.Text = title;
            //lblSubtitle.Text = subtitle;

            // 3. Clean and Load Container
            pnlMainContainer.Controls.Clear();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlMainContainer.Controls.Add(childForm);
            childForm.Show();
            childForm.BringToFront();
        }

        private void SetActiveNav(Button btn)
        {
            // Reset previous button style
            if (_activeNavBtn != null)
            {
                _activeNavBtn.BackColor = Color.Transparent;
                _activeNavBtn.ForeColor = Color.Silver;
            }

            // Highlight new active button
            btn.BackColor = Color.FromArgb(99, 102, 241); // Modern Indigo
            btn.ForeColor = Color.White;
            _activeNavBtn = btn;
        }

        #endregion

        #region Action Methods

        private void ShowBrowseProducts()
        {
            OpenChildForm(
                new ProductBrowsingForm(_context, _userId),
                btnBrowse,
                "Marketplace",
                "Explore our latest collection and find what you love today."
            );
        }

        private void btnBrowse_Click(object sender, EventArgs e) => ShowBrowseProducts();

        private void btnCart_Click(object sender, EventArgs e)
        {
            OpenChildForm(
                new CartForm(_context, _userId),
                btnCart,
                "My Shopping Cart",
                "Review your items and proceed to secure checkout."
            );
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OpenChildForm(
                new MyOrdersForm(_context, _userId),
                btnOrders,
                "Order History",
                "Track your current shipments and view past purchases."
            );
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (
                ModernDesignSystem.Messages.ShowConfirmation(
                    "Are you sure you want to logout?",
                    "Confirm Logout"
                ) == DialogResult.Yes
            )
            {
                //tmrClock.Stop();
                this.Close();
                new LoginForm().Show();
            }
        }

        #endregion

        #region Visual Setup

        private void SetupVisuals()
        {
            // Set hover effects for all buttons in the sidebar
            foreach (var btn in pnlSidebar.Controls.OfType<Button>())
            {
                btn.MouseEnter += (s, e) =>
                {
                    if (btn != _activeNavBtn)
                        btn.BackColor = Color.FromArgb(30, 35, 45);
                };
                btn.MouseLeave += (s, e) =>
                {
                    if (btn != _activeNavBtn)
                        btn.BackColor = Color.Transparent;
                };
            }
        }

        private void LoadWelcomeMessage()
        {
            var user = _context.Users?.Find(_userId);
            lblUserGreeting.Text = user != null ? $"Hello, {user.Name}!" : "Hello, Guest!";
        }

        #endregion
    }
}
