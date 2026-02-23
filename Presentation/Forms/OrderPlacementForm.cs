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
            _context              = context;
            _userId               = userId;
            _orderRepository      = new GenericRepository<Order, int>(_context);
            _orderProductRepository = new GenericRepository<OrderProduct, int>(_context);
            _cartRepository       = new GenericRepository<Cart, int>(_context);
            LoadOrderSummary();
        }

        private void LoadOrderSummary()
        {
            var user = _context.Users.FirstOrDefault(u => u.ID == _userId);
            if (user == null || user.CartID == 0) return;

            var cart = _cartRepository.GetAllEntitys()
                .Include(c => c.CartItems).ThenInclude(ci => ci.Product)
                .FirstOrDefault(c => c.ID == user.CartID);
            if (cart == null) return;

            string summary = "Items in your order:\n\n";
            decimal total = 0;
            foreach (var item in cart.CartItems)
            {
                decimal subtotal = item.Quantity * item.Product.Price;
                total += subtotal;
                summary += string.Format("{0}\n  Qty: {1} x ${2:F2} = ${3:F2}\n\n",
                    item.Product.Name, item.Quantity, item.Product.Price, subtotal);
            }
            summary += string.Format("--------------------------------\nTotal: ${0:F2}", total);
            txtSummary.Text = summary;
        }

        private void btnPlace_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please enter shipping address!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = _context.Users.FirstOrDefault(u => u.ID == _userId);
            if (user == null || user.CartID == 0)
            {
                MessageBox.Show("No cart found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var cart = _cartRepository.GetAllEntitys()
                .Include(c => c.CartItems).ThenInclude(ci => ci.Product)
                .FirstOrDefault(c => c.ID == user.CartID);
            if (cart == null || cart.CartItems.Count == 0)
            {
                MessageBox.Show("Cart is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var order = new Order
            {
                UserId          = _userId,
                ShippingAddress = txtAddress.Text,
                TotalAmount     = cart.CartItems.Sum(ci => ci.Quantity * ci.Product.Price),
                Status          = OrderStatus.Pending
            };
            _orderRepository.Add(order);
            _orderRepository.SaveChanges();

            foreach (var cartItem in cart.CartItems)
            {
                _orderProductRepository.Add(new OrderProduct
                {
                    OrderId   = order.ID,
                    ProductId = cartItem.ProductId,
                    Quantity  = cartItem.Quantity,
                    UnitPrice = cartItem.Product.Price
                });
            }
            _orderProductRepository.SaveChanges();

            cart.CartItems.Clear();
            cart.TotalPrice = 0;
            _cartRepository.Update(cart);
            _cartRepository.SaveChanges();

            MessageBox.Show(string.Format("Order placed! Order ID: {0}", order.ID),
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();
    }
}
