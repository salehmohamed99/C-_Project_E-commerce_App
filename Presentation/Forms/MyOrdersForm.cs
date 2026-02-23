using System;
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
        private DataGridView dgvOrders;

        public MyOrdersForm(ApplicationDbContext context, int userId)
        {
            InitializeComponent();
            _context = context;
            _userId = userId;
            _orderRepository = new GenericRepository<Order, int>(_context);
            LoadOrders();
        }

        private void InitializeComponent()
        {
            this.Text = "My Orders";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Title Label
            Label lblTitle = new Label();
            lblTitle.Text = "My Orders";
            lblTitle.Font = new Font("Arial", 14, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Size = new Size(300, 25);
            this.Controls.Add(lblTitle);

            // DataGridView
            dgvOrders = new DataGridView();
            dgvOrders.Name = "dgvOrders";
            dgvOrders.Location = new Point(20, 70);
            dgvOrders.Size = new Size(840, 400);
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.Columns.Add("ID", "Order ID");
            dgvOrders.Columns.Add("Total", "Total Amount");
            dgvOrders.Columns.Add("Status", "Status");
            dgvOrders.Columns.Add("Date", "Order Date");
            dgvOrders.Columns.Add("Address", "Shipping Address");
            dgvOrders.Columns.Add("Details", "Details");
            this.Controls.Add(dgvOrders);

            // Close Button
            Button btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.Location = new Point(785, 520);
            btnClose.Size = new Size(75, 30);
            btnClose.Click += (s, e) => this.Close();
            this.Controls.Add(btnClose);
        }

        private void LoadOrders()
        {
            dgvOrders.Rows.Clear();
            var orders = _orderRepository.GetAllEntitys()
                .Where(o => o.UserId == _userId && !o.IsDeleted)
                .ToList();

            foreach (var order in orders)
            {
                dgvOrders.Rows.Add(
                    order.ID,
                    order.TotalAmount,
                    order.Status.ToString(),
                    order.CreatedAt.ToString("yyyy-MM-dd"),
                    order.ShippingAddress,
                    "View"
                );
            }

            if (orders.Count == 0)
            {
                MessageBox.Show("You have no orders yet!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
