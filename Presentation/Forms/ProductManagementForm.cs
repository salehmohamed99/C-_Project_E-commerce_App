using System;
using System.Windows.Forms;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Presentation.Forms
{
    public partial class ProductManagementForm : Form
    {
        private ApplicationDbContext _context;
        private IGenericRepository<Product, int> _productRepository;
        private IGenericRepository<Category, int> _categoryRepository;
        private DataGridView dgvProducts;

        public ProductManagementForm(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
            _productRepository = new GenericRepository<Product, int>(_context);
            _categoryRepository = new GenericRepository<Category, int>(_context);
            LoadProducts();
        }

        private void InitializeComponent()
        {
            this.Text = "Product Management";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Title Label
            Label lblTitle = new Label();
            lblTitle.Text = "Manage Products";
            lblTitle.Font = new Font("Arial", 14, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Size = new Size(300, 25);
            this.Controls.Add(lblTitle);

            // Product Name
            Label lblName = new Label();
            lblName.Text = "Product Name:";
            lblName.Location = new Point(20, 60);
            this.Controls.Add(lblName);

            TextBox txtName = new TextBox();
            txtName.Name = "txtName";
            txtName.Location = new Point(130, 60);
            txtName.Size = new Size(150, 25);
            this.Controls.Add(txtName);

            // Price
            Label lblPrice = new Label();
            lblPrice.Text = "Price:";
            lblPrice.Location = new Point(300, 60);
            this.Controls.Add(lblPrice);

            TextBox txtPrice = new TextBox();
            txtPrice.Name = "txtPrice";
            txtPrice.Location = new Point(350, 60);
            txtPrice.Size = new Size(100, 25);
            this.Controls.Add(txtPrice);

            // Category
            Label lblCategory = new Label();
            lblCategory.Text = "Category:";
            lblCategory.Location = new Point(470, 60);
            this.Controls.Add(lblCategory);

            ComboBox cbCategory = new ComboBox();
            cbCategory.Name = "cbCategory";
            cbCategory.Location = new Point(540, 60);
            cbCategory.Size = new Size(150, 25);
            LoadCategories(cbCategory);
            this.Controls.Add(cbCategory);

            // Description
            Label lblDescription = new Label();
            lblDescription.Text = "Description:";
            lblDescription.Location = new Point(20, 100);
            this.Controls.Add(lblDescription);

            TextBox txtDescription = new TextBox();
            txtDescription.Name = "txtDescription";
            txtDescription.Location = new Point(130, 100);
            txtDescription.Size = new Size(560, 50);
            txtDescription.Multiline = true;
            this.Controls.Add(txtDescription);

            // Units in Stock
            Label lblUnits = new Label();
            lblUnits.Text = "Units in Stock:";
            lblUnits.Location = new Point(20, 160);
            this.Controls.Add(lblUnits);

            TextBox txtUnits = new TextBox();
            txtUnits.Name = "txtUnits";
            txtUnits.Location = new Point(130, 160);
            txtUnits.Size = new Size(100, 25);
            this.Controls.Add(txtUnits);

            // Add Button
            Button btnAdd = new Button();
            btnAdd.Text = "Add Product";
            btnAdd.Location = new Point(630, 160);
            btnAdd.Size = new Size(120, 30);
            btnAdd.Click += (s, e) =>
                AddProduct(
                    txtName.Text,
                    decimal.TryParse(txtPrice.Text, out var price) ? price : 0,
                    txtDescription.Text,
                    int.TryParse(txtUnits.Text, out var units) ? units : 0,
                    cbCategory.SelectedIndex > 0 ? (int)cbCategory.SelectedValue : 0
                );
            this.Controls.Add(btnAdd);

            // DataGridView
            dgvProducts = new DataGridView();
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Location = new Point(20, 210);
            dgvProducts.Size = new Size(830, 300);
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Add("ID", "ID");
            dgvProducts.Columns.Add("Name", "Name");
            dgvProducts.Columns.Add("Price", "Price");
            dgvProducts.Columns.Add("Category", "Category");
            dgvProducts.Columns.Add("Stock", "Stock");
            dgvProducts.Columns.Add("Edit", "Edit");
            dgvProducts.Columns.Add("Delete", "Delete");
            this.Controls.Add(dgvProducts);

            // Close Button
            Button btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.Location = new Point(775, 520);
            btnClose.Size = new Size(75, 30);
            btnClose.Click += (s, e) => this.Close();
            this.Controls.Add(btnClose);
        }

        private void LoadCategories(ComboBox cbCategory)
        {
            cbCategory.Items.Clear();
            cbCategory.Items.Add("Select Category");

            var categories = _categoryRepository.GetAllEntitys().Where(c => !c.IsDeleted).ToList();
            foreach (var category in categories)
            {
                cbCategory.Items.Add(category.Name);
            }
            cbCategory.SelectedIndex = 0;
        }

        private void LoadProducts()
        {
            dgvProducts.Rows.Clear();
            var products = _productRepository.GetAllEntitys().Where(p => !p.IsDeleted).ToList();

            foreach (var product in products)
            {
                dgvProducts.Rows.Add(
                    product.ID,
                    product.Name,
                    product.Price,
                    product.category?.Name ?? "N/A",
                    product.UnitsInStock,
                    "Edit",
                    "Delete"
                );
            }
        }

        private void AddProduct(
            string name,
            decimal price,
            string description,
            int units,
            int categoryId
        )
        {
            if (string.IsNullOrWhiteSpace(name) || categoryId == 0)
            {
                MessageBox.Show(
                    "Please fill all required fields!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var product = new Product
            {
                Name = name,
                Price = price,
                Description = description,
                UnitsInStock = units,
                CategoryId = categoryId,
            };

            _productRepository.Add(product);
            _productRepository.SaveChanges();

            MessageBox.Show(
                "Product added successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            LoadProducts();
        }
    }
}
