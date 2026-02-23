using System;
using System.Windows.Forms;
using Infrastructure.Data;

namespace Presentation.Forms
{
    public partial class CustomerMainForm : Form
    {
        private ApplicationDbContext _context;
        private int _userId;

        public CustomerMainForm(ApplicationDbContext context, int userId)
        {
            InitializeComponent();
            _context = context;
            _userId = userId;
        }

        private void InitializeComponent()
        {
            this.Text = "Customer Dashboard";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            // Title Label
            Label lblTitle = new Label();
            lblTitle.Text = "Customer Dashboard";
            lblTitle.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTitle.Location = new Point(50, 20);
            lblTitle.Size = new Size(300, 30);
            this.Controls.Add(lblTitle);

            // Browse Products Button
            Button btnBrowse = new Button();
            btnBrowse.Text = "Browse Products";
            btnBrowse.Location = new Point(50, 80);
            btnBrowse.Size = new Size(200, 50);
            btnBrowse.Click += (s, e) => OpenProductBrowsing();
            this.Controls.Add(btnBrowse);

            // View Cart Button
            Button btnCart = new Button();
            btnCart.Text = "View Cart";
            btnCart.Location = new Point(350, 80);
            btnCart.Size = new Size(200, 50);
            btnCart.Click += (s, e) => OpenCart();
            this.Controls.Add(btnCart);

            // My Orders Button
            Button btnOrders = new Button();
            btnOrders.Text = "My Orders";
            btnOrders.Location = new Point(50, 160);
            btnOrders.Size = new Size(200, 50);
            btnOrders.Click += (s, e) => OpenMyOrders();
            this.Controls.Add(btnOrders);

            // Logout Button
            Button btnLogout = new Button();
            btnLogout.Text = "Logout";
            btnLogout.Location = new Point(350, 160);
            btnLogout.Size = new Size(200, 50);
            btnLogout.Click += (s, e) => Logout();
            this.Controls.Add(btnLogout);
        }

        private void OpenProductBrowsing()
        {
            ProductBrowsingForm form = new ProductBrowsingForm(_context, _userId);
            form.ShowDialog();
        }

        private void OpenCart()
        {
            CartForm form = new CartForm(_context, _userId);
            form.ShowDialog();
        }

        private void OpenMyOrders()
        {
            MyOrdersForm form = new MyOrdersForm(_context, _userId);
            form.ShowDialog();
        }

        private void Logout()
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
