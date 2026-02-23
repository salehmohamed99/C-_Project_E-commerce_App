using System;
using System.Windows.Forms;
using Infrastructure.Data;

namespace Presentation.Forms
{
    public partial class AdminMainForm : Form
    {
        private ApplicationDbContext _context;

        public AdminMainForm(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void InitializeComponent()
        {
            this.Text = "Admin Dashboard";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            // Title Label
            Label lblTitle = new Label();
            lblTitle.Text = "Admin Dashboard";
            lblTitle.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTitle.Location = new Point(50, 20);
            lblTitle.Size = new Size(300, 30);
            this.Controls.Add(lblTitle);

            // Category Management Button
            Button btnCategories = new Button();
            btnCategories.Text = "Manage Categories";
            btnCategories.Location = new Point(50, 80);
            btnCategories.Size = new Size(200, 50);
            btnCategories.Click += (s, e) => OpenCategoryManagement();
            this.Controls.Add(btnCategories);

            // Product Management Button
            Button btnProducts = new Button();
            btnProducts.Text = "Manage Products";
            btnProducts.Location = new Point(350, 80);
            btnProducts.Size = new Size(200, 50);
            btnProducts.Click += (s, e) => OpenProductManagement();
            this.Controls.Add(btnProducts);

            // Order Tracking Button
            Button btnOrders = new Button();
            btnOrders.Text = "Track Orders";
            btnOrders.Location = new Point(50, 160);
            btnOrders.Size = new Size(200, 50);
            btnOrders.Click += (s, e) => OpenOrderTracking();
            this.Controls.Add(btnOrders);

            // Logout Button
            Button btnLogout = new Button();
            btnLogout.Text = "Logout";
            btnLogout.Location = new Point(350, 160);
            btnLogout.Size = new Size(200, 50);
            btnLogout.Click += (s, e) => Logout();
            this.Controls.Add(btnLogout);
        }

        private void OpenCategoryManagement()
        {
            CategoryManagementForm form = new CategoryManagementForm(_context);
            form.ShowDialog();
        }

        private void OpenProductManagement()
        {
            ProductManagementForm form = new ProductManagementForm(_context);
            form.ShowDialog();
        }

        private void OpenOrderTracking()
        {
            OrderTrackingForm form = new OrderTrackingForm(_context);
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
