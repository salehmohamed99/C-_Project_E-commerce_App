using System.Windows.Forms;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using System.IO;
using System.Drawing;

namespace Presentation.Forms
{
    public partial class ProductManagementForm : Form
    {
        private ApplicationDbContext _context;
        private IGenericRepository<Product, int> _productRepository;
        private IGenericRepository<Category, int> _categoryRepository;

        public ProductManagementForm(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
            _productRepository  = new GenericRepository<Product, int>(_context);
            _categoryRepository = new GenericRepository<Category, int>(_context);
            LoadCategoryCombo();
            LoadProducts();
        }

        private void LoadCategoryCombo()
        {
            cbCategory.Items.Clear();
            cbCategory.Items.Add("-- Select Category --");
            var categories = _categoryRepository.GetAllEntitys().Where(c => !c.IsDeleted).ToList();
            foreach (var cat in categories)
                cbCategory.Items.Add(cat.Name);
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
                    LoadProductImage(product.Image),
                    product.Name,
                    product.Price,
                    product.category?.Name ?? "N/A",
                    product.UnitsInStock,
                    "Edit",
                    "Delete");
            }
        }

        private Image? LoadProductImage(string? imagePath)
        {
            if (!string.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath))
            {
                try
                {
                    using var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
                    using var ms = new MemoryStream();
                    fs.CopyTo(ms);
                    ms.Position = 0;
                    using var img = Image.FromStream(ms);
                    return (Image)img.Clone();
                }
                catch { }
            }
            return CreatePlaceholder();
        }

        private static Image CreatePlaceholder()
        {
            var bmp = new Bitmap(60, 50);
            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.WhiteSmoke);
            using var pen = new Pen(Color.LightGray, 1);
            g.DrawRectangle(pen, 0, 0, 59, 49);
            using var font = new Font("Arial", 6f);
            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString("No Image", font, Brushes.Gray, new RectangleF(0, 0, 60, 50), sf);
            return bmp;
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title  = "Select Product Image",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
                txtImage.Text = dlg.FileName;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || cbCategory.SelectedIndex == 0)
            {
                MessageBox.Show("Please fill required fields!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var categories = _categoryRepository.GetAllEntitys()
                .Where(c => !c.IsDeleted).ToList();
            var selectedCategory = categories.ElementAtOrDefault(cbCategory.SelectedIndex - 1);
            if (selectedCategory == null) return;

            var product = new Product
            {
                Name         = txtName.Text,
                Price        = decimal.TryParse(txtPrice.Text, out var p) ? p : 0,
                Description  = txtDescription.Text,
                UnitsInStock = int.TryParse(txtUnits.Text, out var u) ? u : 0,
                Image        = txtImage.Text,
                CategoryId   = selectedCategory.ID
            };

            _productRepository.Add(product);
            _productRepository.SaveChanges();
            ClearInputs();
            MessageBox.Show("Product added successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadProducts();
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtPrice.Clear();
            txtDescription.Clear();
            txtUnits.Clear();
            txtImage.Clear();
            cbCategory.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
