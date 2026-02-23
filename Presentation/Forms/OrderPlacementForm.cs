using System;
using System.Windows.Forms;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Forms
{
    public partial class OrderPlacementForm : Form
    {
        private ApplicationDbContext _context;
        private IGenericRepository<Order, int> _orderRepository;
        private IGenericRepository<OrderProduct, int> _orderProductRepository;
        private IGenericRepository<Cart, int> _cartRepository;
        private int _userId;

        public OrderPlacementForm(ApplicationDbContext context, int userId)
        {
            InitializeComponent();
            _context = context;
            _userId = userId;
            _orderRepository = new GenericRepository<Order, int>(_context);
            _orderProductRepository = new GenericRepository<OrderProduct, int>(_context);
            _cartRepository = new GenericRepository<Cart, int>(_context);
        }

        private void InitializeComponent()
        {
            this.Text = "Place Order";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Title Label
            Label lblTitle = new Label();
            lblTitle.Text = "Complete Your Order";
            lblTitle.Font = new Font("Arial", 14, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Size = new Size(300, 25);
            this.Controls.Add(lblTitle);

            // Shipping Address
            Label lblAddress = new Label();
            lblAddress.Text = "Shipping Address:";
            lblAddress.Location = new Point(20, 70);
            this.Controls.Add(lblAddress);

            TextBox txtAddress = new TextBox();
            txtAddress.Name = "txtAddress";
            txtAddress.Location = new Point(20, 100);
            txtAddress.Size = new Size(540, 80);
            txtAddress.Multiline = true;
            this.Controls.Add(txtAddress);

            // Phone
            Label lblPhone = new Label();
            lblPhone.Text = "Phone:";
            lblPhone.Location = new Point(20, 190);
            this.Controls.Add(lblPhone);

            TextBox txtPhone = new TextBox();
            txtPhone.Name = "txtPhone";
            txtPhone.Location = new Point(120, 190);
            txtPhone.Size = new Size(200, 25);
            this.Controls.Add(txtPhone);

            // Order Summary
            Label lblSummary = new Label();
            lblSummary.Text = "Order Summary";
            lblSummary.Font = new Font("Arial", 12, FontStyle.Bold);
            lblSummary.Location = new Point(20, 230);
            this.Controls.Add(lblSummary);

            TextBox txtSummary = new TextBox();
            txtSummary.Name = "txtSummary";
            txtSummary.Location = new Point(20, 260);
            txtSummary.Size = new Size(540, 100);
            txtSummary.Multiline = true;
            txtSummary.ReadOnly = true;
            LoadOrderSummary(txtSummary);
            this.Controls.Add(txtSummary);

            // Place Order Button
            Button btnPlace = new Button();
            btnPlace.Text = "Place Order";
            btnPlace.Location = new Point(400, 380);
            btnPlace.Size = new Size(160, 35);
            btnPlace.Font = new Font("Arial", 11, FontStyle.Bold);
            btnPlace.Click += (s, e) => PlaceOrder(txtAddress.Text, txtPhone.Text);
            this.Controls.Add(btnPlace);

            // Cancel Button
            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(485, 380);
            btnCancel.Size = new Size(75, 35);
            btnCancel.Click += (s, e) => this.Close();
            this.Controls.Add(btnCancel);
        }

        private void LoadOrderSummary(TextBox txtSummary)
        {
            var user = _context.Users.FirstOrDefault(u => u.ID == _userId);
            if (user == null || user.CartID == 0) return;

            var cart = _cartRepository.GetAllEntitys()
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefault(c => c.ID == user.CartID);

            if (cart == null) return;

            string summary = "Items in your order:\n\n";
            decimal total = 0;

            foreach (var item in cart.CartItems)
            {
                decimal subtotal = item.Quantity * item.Product.Price;
                total += subtotal;
                summary += $"{item.Product.Name}\n  Quantity: {item.Quantity} x ${item.Product.Price:F2} = ${subtotal:F2}\n\n";
            }

            summary += $"????????????????????????????\n";
            summary += $"Total: ${total:F2}";

            txtSummary.Text = summary;
        }

        private void PlaceOrder(string address, string phone)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Please enter shipping address!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = _context.Users.FirstOrDefault(u => u.ID == _userId);
            if (user == null || user.CartID == 0)
            {
                MessageBox.Show("No cart found for this user!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var cart = _cartRepository.GetAllEntitys()
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefault(c => c.ID == user.CartID);

            if (cart == null || cart.CartItems.Count == 0)
            {
                MessageBox.Show("Cart is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create order
            var order = new Order
            {
                UserId = _userId,
                ShippingAddress = address,
                TotalAmount = cart.CartItems.Sum(ci => ci.Quantity * ci.Product.Price),
                Status = OrderStatus.Pending
            };

            _orderRepository.Add(order);
            _orderRepository.SaveChanges();

            // Add order items
            foreach (var cartItem in cart.CartItems)
            {
                var orderProduct = new OrderProduct
                {
                    OrderId = order.ID,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.Product.Price
                };

                _orderProductRepository.Add(orderProduct);
            }

            _orderProductRepository.SaveChanges();

            // Clear cart
            cart.CartItems.Clear();
            cart.TotalPrice = 0;
            _cartRepository.Update(cart);
            _cartRepository.SaveChanges();

            MessageBox.Show($"Order placed successfully!\nOrder ID: {order.ID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
