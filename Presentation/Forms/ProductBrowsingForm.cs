using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Presentation.Forms
{
    public partial class ProductBrowsingForm : Form
    {
        private ApplicationDbContext _context;
        private IProductCustomerService _productService;
        private ICartItemService _cartItemService;
        private int _userId;

        public ProductBrowsingForm(ApplicationDbContext context, int userId)
        {
            InitializeComponent();
            SetupGrid();
            _context = context;
            _userId = userId;
            IGenericRepository<Product, int> productRepository = new GenericRepository<
                Product,
                int
            >(_context);
            IGenericRepository<CartItem, int> cartItemRepository = new GenericRepository<
                CartItem,
                int
            >(_context);
            IGenericRepository<Cart, int> cartRepository = new GenericRepository<Cart, int>(_context);
            _productService = new ProductCustomerService(productRepository);
            _cartItemService = new CartItemService(cartItemRepository, productRepository, cartRepository);
            LoadProducts();
        }

        private void SetupGrid()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(45, 62, 80),
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Padding = new Padding(0),
            };
            dgvProducts.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 9.75F),
                Padding = new Padding(4),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(214, 234, 248),
                SelectionForeColor = Color.FromArgb(45, 62, 80),
            };
            dgvProducts.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(245, 247, 250),
                SelectionBackColor = Color.FromArgb(214, 234, 248),
                SelectionForeColor = Color.FromArgb(45, 62, 80),
            };

            dgvProducts.Columns.Clear();
            dgvProducts.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "ID",
                    HeaderText = "ID",
                    Width = 60,
                }
            );
            dgvProducts.Columns.Add(
                new DataGridViewImageColumn
                {
                    Name = "Image",
                    HeaderText = "Image",
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Width = 70,
                }
            );
            dgvProducts.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Name",
                    HeaderText = "Product Name",
                    Width = 250,
                }
            );
            dgvProducts.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Price",
                    HeaderText = "Price",
                    Width = 120,
                }
            );
            dgvProducts.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Stock",
                    HeaderText = "Stock",
                    Width = 100,
                }
            );
            dgvProducts.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "Details",
                    HeaderText = "",
                    Text = "View",
                    UseColumnTextForButtonValue = true,
                    Width = 110,
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = Color.FromArgb(52, 152, 219),
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                        SelectionBackColor = Color.FromArgb(41, 128, 185),
                        SelectionForeColor = Color.White,
                    },
                }
            );
            dgvProducts.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "AddCart",
                    HeaderText = "",
                    Text = "Add to Cart",
                    UseColumnTextForButtonValue = true,
                    Width = 110,
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = Color.FromArgb(39, 174, 96),
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                        SelectionBackColor = Color.FromArgb(30, 139, 76),
                        SelectionForeColor = Color.White,
                    },
                }
            );
        }

        private void LoadProducts()
        {
            dgvProducts.Rows.Clear();
            var products = _productService.GetAvailableProducts().ToList();
            foreach (var product in products)
                dgvProducts.Rows.Add(
                    product.Id,
                    LoadProductImage(product.Image),
                    product.Name,
                    product.Price,
                    product.UnitsInStock,
                    "View",
                    "Add"
                );
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
            var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };
            g.DrawString("No Image", font, Brushes.Gray, new RectangleF(0, 0, 60, 50), sf);
            return bmp;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvProducts.Rows.Clear();
            var term = txtSearch.Text;
            var products = _productService.SearchProducts(term).ToList();
            foreach (var product in products)
                dgvProducts.Rows.Add(
                    product.Id,
                    LoadProductImage(product.Image),
                    product.Name,
                    product.Price,
                    product.UnitsInStock,
                    "View",
                    "Add"
                );
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int productId = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["ID"].Value);

            if (e.ColumnIndex == dgvProducts.Columns["Details"].Index)
            {
                var product = _productService.GetById(productId);
                MessageBox.Show(
                    $"Name: {product.Name}\nPrice: ${product.Price:F2}\nStock: {product.UnitsInStock}\nCategory: {product.CategoryName}\n\n{product.Description}",
                    "Product Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else if (e.ColumnIndex == dgvProducts.Columns["AddCart"].Index)
            {
                var user = _context.Users.FirstOrDefault(u => u.ID == _userId);
                if (user == null || user.CartID == 0)
                {
                    MessageBox.Show(
                        "No cart found!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                try
                {
                    var dto = new AddCartItemDto { ProductId = productId, Quantity = 1 };
                    _cartItemService.AddItem(user.CartID, dto);
                    MessageBox.Show(
                        "Product added to cart!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadProducts();

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
