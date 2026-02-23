using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Application.Interfaces.Repositories;
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
        private IGenericRepository<Cart, int> _cartRepository;
        private IGenericRepository<CartItem, int> _cartItemRepository;
        private IGenericRepository<Product, int> _productRepository;
        private CartServices _cartServices;
        private int _userId;

        public CartForm(ApplicationDbContext context, int userId)
        {
            InitializeComponent();
            _context            = context;
            _userId             = userId;
            _cartRepository     = new GenericRepository<Cart, int>(_context);
            _cartItemRepository = new GenericRepository<CartItem, int>(_context);
            _productRepository  = new GenericRepository<Product, int>(_context);
            _cartServices       = new CartServices(_cartRepository);
            LoadCart();
        }

        private void LoadCart()
        {
            dgvCart.Rows.Clear();
            var user = _context.Users.FirstOrDefault(u => u.ID == _userId);
            if (user == null || user.CartID == 0) return;

            var cart = _cartRepository.GetAllEntitys()
                .Include(c => c.CartItems).ThenInclude(ci => ci.Product)
                .FirstOrDefault(c => c.ID == user.CartID);
            if (cart == null) return;

            decimal total = 0;
            foreach (var item in cart.CartItems)
            {
                decimal subtotal = item.Quantity * item.Product.Price;
                total += subtotal;
                dgvCart.Rows.Add(
                    LoadProductImage(item.Product.Image),
                    item.ProductId,
                    item.Product.Name,
                    item.Product.Price,
                    item.Quantity,
                    subtotal,
                    "Update",
                    "Remove");
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
            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
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
                    _cartServices.ClearCart(cart);
                    LoadCart();
                    MessageBox.Show("Cart cleared successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            var user = _context.Users.FirstOrDefault(u => u.ID == _userId);
            if (user?.CartID == 0 || dgvCart.Rows.Count == 0)
            {
                MessageBox.Show("Your cart is empty!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            new OrderPlacementForm(_context, _userId).ShowDialog();
            LoadCart();
        }

        private void btnContinue_Click(object sender, EventArgs e) => this.Close();
        private void btnClose_Click(object sender, EventArgs e)     => this.Close();
        private void CartForm_Load(object sender, EventArgs e)      { }
    }
}
