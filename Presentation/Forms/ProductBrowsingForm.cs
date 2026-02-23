using System;
using System.Windows.Forms;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Presentation.Forms
{
    public partial class ProductBrowsingForm : Form
    {
        private ApplicationDbContext _context;
        private IGenericRepository<Product, int> _productRepository;
        private IGenericRepository<CartItem, int> _cartItemRepository;
        private IGenericRepository<Cart, int> _cartRepository;
        private int _userId;
        private DataGridView dgvProducts;

        public ProductBrowsingForm(ApplicationDbContext context, int userId)
        {
            InitializeComponent();
            _context = context;
            _userId = userId;
            _productRepository = new GenericRepository<Product, int>(_context);
            _cartItemRepository = new GenericRepository<CartItem, int>(_context);
            _cartRepository = new GenericRepository<Cart, int>(_context);
            LoadProducts();
        }

        private void InitializeComponent()
        {
            this.Text = "Browse Products";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Title Label
            Label lblTitle = new Label();
            lblTitle.Text = "Browse Products";
            lblTitle.Font = new Font("Arial", 14, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Size = new Size(300, 25);
            this.Controls.Add(lblTitle);

            // Search
            Label lblSearch = new Label();
            lblSearch.Text = "Search:";
            lblSearch.Location = new Point(20, 60);
            this.Controls.Add(lblSearch);

            TextBox txtSearch = new TextBox();
            txtSearch.Name = "txtSearch";
            txtSearch.Location = new Point(80, 60);
            txtSearch.Size = new Size(200, 25);
            this.Controls.Add(txtSearch);

            Button btnSearch = new Button();
            btnSearch.Text = "Search";
            btnSearch.Location = new Point(290, 60);
            btnSearch.Size = new Size(80, 30);
            btnSearch.Click += (s, e) => SearchProducts(txtSearch.Text);
            this.Controls.Add(btnSearch);

            // DataGridView
            dgvProducts = new DataGridView();
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Location = new Point(20, 110);
            dgvProducts.Size = new Size(940, 400);
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Add("ID", "ID");
            dgvProducts.Columns.Add("Name", "Product Name");
            dgvProducts.Columns.Add("Price", "Price");
            dgvProducts.Columns.Add("Stock", "Stock");
            dgvProducts.Columns.Add("Details", "Details");
            dgvProducts.Columns.Add("AddCart", "Add to Cart");
            this.Controls.Add(dgvProducts);

            // Quantity Label
            Label lblQuantity = new Label();
            lblQuantity.Text = "Quantity:";
            lblQuantity.Location = new Point(20, 530);
            this.Controls.Add(lblQuantity);

            TextBox txtQuantity = new TextBox();
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Location = new Point(100, 530);
            txtQuantity.Size = new Size(50, 25);
            txtQuantity.Text = "1";
            this.Controls.Add(txtQuantity);

            // Close Button
            Button btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.Location = new Point(885, 600);
            btnClose.Size = new Size(75, 30);
            btnClose.Click += (s, e) => this.Close();
            this.Controls.Add(btnClose);
        }

        private void LoadProducts()
        {
            dgvProducts.Rows.Clear();
            var products = _productRepository.GetAllEntitys()
                .Where(p => p.IsActive && !p.IsDeleted && p.UnitsInStock > 0)
                .ToList();

            foreach (var product in products)
            {
                dgvProducts.Rows.Add(
                    product.ID,
                    product.Name,
                    product.Price,
                    product.UnitsInStock,
                    "View",
                    "Add"
                );
            }
        }

        private void SearchProducts(string searchTerm)
        {
            dgvProducts.Rows.Clear();
            var products = _productRepository.GetAllEntitys()
                .Where(p => p.IsActive && !p.IsDeleted &&
                       p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var product in products)
            {
                dgvProducts.Rows.Add(
                    product.ID,
                    product.Name,
                    product.Price,
                    product.UnitsInStock,
                    "View",
                    "Add"
                );
            }
        }
    }
}
