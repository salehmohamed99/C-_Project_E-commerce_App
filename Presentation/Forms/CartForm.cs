using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private DataGridView dgvCart;
        private Label lblTotal;

        public CartForm(ApplicationDbContext context, int userId)
        {
            InitializeComponent();
            _context = context;
            _userId = userId;
            _cartRepository = new GenericRepository<Cart, int>(_context);
            _cartItemRepository = new GenericRepository<CartItem, int>(_context);
            _productRepository = new GenericRepository<Product, int>(_context);
            _cartServices = new CartServices(_cartRepository);
            LoadCart();
        }

        private void InitializeComponent()
        {
            this.Text = "Shopping Cart";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Title Label
            Label lblTitle = new Label();
            lblTitle.Text = "Your Shopping Cart";
            lblTitle.Font = new Font("Arial", 14, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Size = new Size(300, 25);
            this.Controls.Add(lblTitle);

            // DataGridView
            dgvCart = new DataGridView();
            dgvCart.Name = "dgvCart";
            dgvCart.Location = new Point(20, 70);
            dgvCart.Size = new Size(840, 350);
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Add("ProductID", "Product ID");
            dgvCart.Columns.Add("ProductName", "Product Name");
            dgvCart.Columns.Add("Price", "Unit Price");
            dgvCart.Columns.Add("Quantity", "Quantity");
            dgvCart.Columns.Add("Subtotal", "Subtotal");
            dgvCart.Columns.Add("Update", "Update");
            dgvCart.Columns.Add("Remove", "Remove");
            this.Controls.Add(dgvCart);

            // Total Price Label
            lblTotal = new Label();
            lblTotal.Text = "Total: $0.00";
            lblTotal.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTotal.Location = new Point(20, 440);
            lblTotal.Size = new Size(200, 25);
            this.Controls.Add(lblTotal);

            // Clear Cart Button
            Button btnClear = new Button();
            btnClear.Text = "Clear Cart";
            btnClear.Location = new Point(20, 480);
            btnClear.Size = new Size(100, 30);
            btnClear.Click += (s, e) => ClearCart();
            this.Controls.Add(btnClear);

            // Checkout Button
            Button btnCheckout = new Button();
            btnCheckout.Text = "Proceed to Checkout";
            btnCheckout.Location = new Point(130, 480);
            btnCheckout.Size = new Size(150, 30);
            btnCheckout.Click += (s, e) => Checkout();
            this.Controls.Add(btnCheckout);

            // Continue Shopping Button
            Button btnContinue = new Button();
            btnContinue.Text = "Continue Shopping";
            btnContinue.Location = new Point(290, 480);
            btnContinue.Size = new Size(130, 30);
            btnContinue.Click += (s, e) => this.Close();
            this.Controls.Add(btnContinue);

            // Close Button
            Button btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.Location = new Point(785, 520);
            btnClose.Size = new Size(75, 30);
            btnClose.Click += (s, e) => this.Close();
            this.Controls.Add(btnClose);
        }

        private void LoadCart()
        {
            dgvCart.Rows.Clear();

            var user = _context.Users.FirstOrDefault(u => u.ID == _userId);
            if (user == null || user.CartID == 0) return;

            var cart = _cartRepository.GetAllEntitys()
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefault(c => c.ID == user.CartID);

            if (cart == null) return;

            decimal total = 0;
            foreach (var item in cart.CartItems)
            {
                decimal subtotal = item.Quantity * item.Product.Price;
                total += subtotal;

                dgvCart.Rows.Add(
                    item.ProductId,
                    item.Product.Name,
                    item.Product.Price,
                    item.Quantity,
                    subtotal,
                    "Update",
                    "Remove"
                );
            }

            lblTotal.Text = $"Total: ${total:F2}";
        }

        private void ClearCart()
        {
            var user = _context.Users.FirstOrDefault(u => u.ID == _userId);
            if (user != null && user.CartID > 0)
            {
                var cart = _cartRepository.GetAllEntitys().FirstOrDefault(c => c.ID == user.CartID);
                if (cart != null)
                {
                    _cartServices.ClearCart(cart);
                    LoadCart();
                    MessageBox.Show("Cart cleared successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Checkout()
        {
            var user = _context.Users.FirstOrDefault(u => u.ID == _userId);
            if (user?.CartID == 0 || dgvCart.Rows.Count == 0)
            {
                MessageBox.Show("Your cart is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OrderPlacementForm form = new OrderPlacementForm(_context, _userId);
            form.ShowDialog();
            LoadCart();
        }
    }
}
