using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Application.DTOs;
using Application.DTOs.ProductDTOs;
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
            //IGenericRepository<Product, int> productRepository = new GenericRepository<
            //    Product,
            //    int
            //>(_context);
            IGenericRepository<CartItem, int> cartItemRepository = new GenericRepository<
                CartItem,
                int
            >(_context);
            ICategoryRepository categoryRepository = new CategoryRepository(_context);
            IProductRepository productRepository = new ProductRepository(_context);
            IGenericRepository<Cart, int> cartRepository = new GenericRepository<Cart, int>(
                _context
            );
            _productService = new ProductCustomerService(productRepository, categoryRepository);
            _cartItemService = new CartItemService(
                cartItemRepository,
                productRepository,
                cartRepository
            );
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
            var products = _productService.GetAll().ToList();
            foreach (var product in products)
                dgvProducts.Rows.Add(
                    product.ID,
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
            var products = _productService.SearchByName(term).ToList();
            foreach (var product in products)
                dgvProducts.Rows.Add(
                    product.ID,
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
                var user = _context.Users.FirstOrDefault(u => u.ID == _userId);
                int cartId = user?.CartID ?? 0;
                using var detailsForm = new ProductDetailsForm(product, _cartItemService, cartId);
                if (detailsForm.ShowDialog() == DialogResult.OK)
                    LoadProducts();
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

                int stock = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["Stock"].Value);
                if (stock <= 0)
                {
                    MessageBox.Show(
                        "This product is out of stock!",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                var input = ShowQuantityDialog(stock);
                if (input == null)
                    return;

                try
                {
                    var dto = new AddCartItemDto { ProductId = productId, Quantity = input.Value };
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

        private static int? ShowQuantityDialog(int maxStock)
        {
            var form = new Form
            {
                Text = "Enter Quantity",
                Width = 320,
                Height = 180,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
            };
            var lbl = new Label
            {
                Text = $"Quantity (max {maxStock}):",
                Left = 10,
                Top = 15,
                Width = 280,
                Font = new Font("Segoe UI", 10F),
            };
            var nud = new NumericUpDown
            {
                Left = 10,
                Top = 45,
                Width = 280,
                Minimum = 1,
                Maximum = maxStock,
                Value = 1,
                Font = new Font("Segoe UI", 10F),
            };
            var btnOk = new Button
            {
                Text = "Add to Cart",
                Left = 100,
                Top = 90,
                Width = 100,
                Height = 35,
                DialogResult = DialogResult.OK,
                BackColor = Color.FromArgb(39, 174, 96),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            };
            btnOk.FlatAppearance.BorderSize = 0;
            var btnCancel = new Button
            {
                Text = "Cancel",
                Left = 210,
                Top = 90,
                Width = 80,
                Height = 35,
                DialogResult = DialogResult.Cancel,
            };
            form.AcceptButton = btnOk;
            form.CancelButton = btnCancel;
            form.Controls.AddRange([lbl, nud, btnOk, btnCancel]);
            return form.ShowDialog() == DialogResult.OK ? (int)nud.Value : null;
        }
    }
}
