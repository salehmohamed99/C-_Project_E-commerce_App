using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Forms
{
    public partial class CartForm : Form
    {
        private ApplicationDbContext _context;
        private CartServices _cartService;
        private ICartItemService _cartItemService;
        private IGenericRepository<Cart, int> _cartRepository;
        private IGenericRepository<Product, int> _productRepository;
        private int _userId;

        public CartForm(ApplicationDbContext context, int userId)
        {
            InitializeComponent();
            SetupGrid();
            _context = context;
            _userId = userId;
            _cartRepository = new GenericRepository<Cart, int>(_context);
            _productRepository = new GenericRepository<Product, int>(_context);
            IGenericRepository<CartItem, int> cartItemRepository = new GenericRepository<
                CartItem,
                int
            >(_context);
            _cartService = new CartServices(_cartRepository, cartItemRepository);
            _cartItemService = new CartItemService(cartItemRepository, _productRepository, _cartRepository);
            LoadCart();
        }

        private void SetupGrid()
        {
            dgvCart.AutoGenerateColumns = false;
            dgvCart.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(45, 62, 80),
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Padding = new Padding(0),
            };
            dgvCart.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 9.75F),
                Padding = new Padding(4),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(214, 234, 248),
                SelectionForeColor = Color.FromArgb(45, 62, 80),
            };
            dgvCart.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(245, 247, 250),
                SelectionBackColor = Color.FromArgb(214, 234, 248),
                SelectionForeColor = Color.FromArgb(45, 62, 80),
            };

            dgvCart.Columns.Clear();
            dgvCart.Columns.Add(
                new DataGridViewImageColumn
                {
                    Name = "Image",
                    HeaderText = "Image",
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Width = 70,
                }
            );
            dgvCart.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductID",
                    HeaderText = "ProductID",
                    Width = 70,
                    Visible = false,
                }
            );
            dgvCart.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductName",
                    HeaderText = "Product Name",
                    Width = 180,
                }
            );
            dgvCart.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Price",
                    HeaderText = "Unit Price",
                    Width = 110,
                }
            );
            dgvCart.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Quantity",
                    HeaderText = "Qty",
                    Width = 70,
                }
            );
            dgvCart.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Subtotal",
                    HeaderText = "Subtotal",
                    Width = 100,
                }
            );
            dgvCart.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "Update",
                    HeaderText = "",
                    Text = "Update",
                    UseColumnTextForButtonValue = true,
                    Width = 100,
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
            dgvCart.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "Remove",
                    HeaderText = "",
                    Text = "Remove",
                    UseColumnTextForButtonValue = true,
                    Width = 100,
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = Color.FromArgb(231, 76, 60),
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                        SelectionBackColor = Color.FromArgb(192, 57, 43),
                        SelectionForeColor = Color.White,
                    },
                }
            );
        }

        private void LoadCart()
        {
            dgvCart.Rows.Clear();
            var user = _context.Users.FirstOrDefault(u => u.ID == _userId);
            if (user == null || user.CartID == 0)
                return;

            var cartItems = _cartItemService.GetCartItems(user.CartID).ToList();
            decimal total = 0;
            foreach (var item in cartItems)
            {
                decimal subtotal = item.Quantity * item.ProductPrice;
                total += subtotal;
                dgvCart.Rows.Add(
                    LoadProductImage(item.ProductImage),
                    item.ProductId,
                    item.ProductName,
                    item.ProductPrice,
                    item.Quantity,
                    subtotal,
                    "Update",
                    "Remove"
                );
            }
            lblTotal.Text = string.Format("Total: ${0:F2}", total);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            var user = _context.Users.FirstOrDefault(u => u.ID == _userId);
            if (user != null && user.CartID > 0)
            {
                var cart = _cartRepository.GetAllEntitys().FirstOrDefault(c => c.ID == user.CartID);
                if (cart != null)
                {
                    _cartService.ClearCart(cart);
                    LoadCart();
                    MessageBox.Show(
                        "Cart cleared successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            var user = _context.Users.FirstOrDefault(u => u.ID == _userId);
            if (user?.CartID == 0 || dgvCart.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Your cart is empty!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            new OrderPlacementForm(_context, _userId).ShowDialog();
            LoadCart();
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var user = _context.Users.FirstOrDefault(u => u.ID == _userId);
            if (user == null || user.CartID == 0)
                return;

            int productId = Convert.ToInt32(dgvCart.Rows[e.RowIndex].Cells["ProductID"].Value);

            if (e.ColumnIndex == dgvCart.Columns["Update"].Index)
            {
                var currentQty = Convert.ToInt32(dgvCart.Rows[e.RowIndex].Cells["Quantity"].Value);
                var product = _productRepository.GetAllEntitys().FirstOrDefault(p => p.ID == productId);
                int maxQty = (product?.UnitsInStock ?? 0) + currentQty;

                var input = ShowInputDialog(
                    $"Enter new quantity (max {maxQty}):",
                    "Update Quantity",
                    currentQty.ToString()
                );

                if (input == null)
                    return;
                if (!int.TryParse(input, out var newQty) || newQty < 1)
                {
                    MessageBox.Show(
                        "Please enter a valid quantity (minimum 1).",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                if (newQty > maxQty)
                {
                    MessageBox.Show(
                        $"Quantity exceeds available stock. Maximum allowed: {maxQty}.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                var dto = new Application.DTOs.UpdateCartItemDto { Quantity = newQty };
                _cartItemService.UpdateItem(user.CartID, productId, dto);
                LoadCart();
                MessageBox.Show(
                    "Quantity updated!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else if (e.ColumnIndex == dgvCart.Columns["Remove"].Index)
            {
                var result = MessageBox.Show(
                    "Remove this item from cart?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result != DialogResult.Yes)
                    return;

                _cartItemService.RemoveItem(user.CartID, productId);
                LoadCart();
                MessageBox.Show(
                    "Item removed!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private static string? ShowInputDialog(string prompt, string title, string defaultValue)
        {
            var form = new Form
            {
                Text = title,
                Width = 320,
                Height = 160,
                StartPosition = FormStartPosition.CenterParent,
            };
            var lbl = new Label
            {
                Text = prompt,
                Left = 10,
                Top = 10,
                Width = 280,
            };
            var txt = new TextBox
            {
                Left = 10,
                Top = 35,
                Width = 280,
                Text = defaultValue,
            };
            var btnOk = new Button
            {
                Text = "OK",
                Left = 130,
                Top = 70,
                Width = 75,
                DialogResult = DialogResult.OK,
            };
            var btnCancel = new Button
            {
                Text = "Cancel",
                Left = 215,
                Top = 70,
                Width = 75,
                DialogResult = DialogResult.Cancel,
            };
            form.AcceptButton = btnOk;
            form.CancelButton = btnCancel;
            form.Controls.AddRange([lbl, txt, btnOk, btnCancel]);
            return form.ShowDialog() == DialogResult.OK ? txt.Text : null;
        }

        private void btnContinue_Click(object sender, EventArgs e) => this.Close();

        private void btnRefresh_Click(object sender, EventArgs e) => LoadCart();

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void CartForm_Load(object sender, EventArgs e) { }
    }
}
