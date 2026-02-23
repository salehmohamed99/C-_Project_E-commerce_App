using System.Windows.Forms;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Presentation.Forms
{
    public partial class MyOrdersForm : Form
    {
        private ApplicationDbContext _context;
        private IGenericRepository<Order, int> _orderRepository;
        private int _userId;

        public MyOrdersForm(ApplicationDbContext context, int userId)
        {
            InitializeComponent();
            _context = context;
            _userId = userId;
            _orderRepository = new GenericRepository<Order, int>(_context);
            LoadOrders();
        }

        private void LoadOrders()
        {
            dgvOrders.Rows.Clear();
            var orders = _orderRepository.GetAllEntitys()
                .Where(o => o.UserId == _userId && !o.IsDeleted).ToList();

            foreach (var order in orders)
            {
                dgvOrders.Rows.Add(order.ID, order.TotalAmount,
                    order.Status.ToString(), order.CreatedAt.ToString("yyyy-MM-dd"),
                    order.ShippingAddress, "View");
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
