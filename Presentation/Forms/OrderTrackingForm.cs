using System.Windows.Forms;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Presentation.Forms
{
    public partial class OrderTrackingForm : Form
    {
        private ApplicationDbContext _context;
        private IGenericRepository<Order, int> _orderRepository;

        public OrderTrackingForm(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
            _orderRepository = new GenericRepository<Order, int>(_context);
            LoadOrders();
        }

        private void LoadOrders()
        {
            dgvOrders.Rows.Clear();
            var orders = _orderRepository.GetAllEntitys().Where(o => !o.IsDeleted).ToList();
            foreach (var order in orders)
            {
                dgvOrders.Rows.Add(order.ID, order.User?.Name ?? "N/A",
                    order.TotalAmount, order.Status.ToString(),
                    order.CreatedAt.ToString("yyyy-MM-dd"), order.ShippingAddress, "Update");
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
