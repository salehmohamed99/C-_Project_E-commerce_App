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
    public partial class OrderPlacementForm : Form
    {
        private ApplicationDbContext _context;
        private IOrderService _orderService;
        private ICartService _cartService;
        private int _userId;

        public OrderPlacementForm(ApplicationDbContext context, int userId)
        {
            InitializeComponent();
            _context = context;
            _userId = userId;
            IOrderRepository orderRepository = new Infrastructure.Repositories.OrderRepository(_context);
            IGenericRepository<Cart, int> cartRepository = new GenericRepository<Cart, int>(_context);
            IGenericRepository<CartItem, int> cartItemRepository = new GenericRepository<CartItem, int>(_context);
            _orderService = new OrderService(orderRepository, cartItemRepository);
            _cartService = new CartServices(cartRepository);
            LoadOrderSummary();
        }

        private void LoadOrderSummary()
        {
            var user = _context.Users.AsNoTracking().FirstOrDefault(u => u.ID == _userId);
            if (user == null || user.CartID == 0)
                return;

            var cart = _context.Set<Cart>()
                .AsNoTracking()
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Product)
                .FirstOrDefault(c => c.ID == user.CartID);
            if (cart == null)
                return;

            string summary = "Items in your order:\n\n";
            decimal total = 0;
            foreach (var item in cart.CartItems)
            {
                decimal subtotal = item.Quantity * item.Product.Price;
                total += subtotal;
                summary += string.Format(
                    "{0}\n  Qty: {1} x ${2:F2} = ${3:F2}\n\n",
                    item.Product.Name,
                    item.Quantity,
                    item.Product.Price,
                    subtotal
                );
            }
            summary += string.Format("--------------------------------\nTotal: ${0:F2}", total);
            txtSummary.Text = summary;
        }

        private async void btnPlace_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show(
                    "Please enter shipping address!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
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

                btnPlace.Enabled = false;
                btnPlace.Text = "Placing Order...";

                var order = await _orderService.PlaceOrderFromCartAsync(user.CartID, _userId, txtAddress.Text.Trim());

                MessageBox.Show(
                    string.Format("Order placed! Order ID: {0}", order.ID),
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                this.Close();
            }
            catch (Exception ex)
            {
                btnPlace.Enabled = true;
                btnPlace.Text = "Place Order";
                MessageBox.Show(
                    $"Error placing order: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();
    }
}
