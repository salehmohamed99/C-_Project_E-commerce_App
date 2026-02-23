using System;
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
        private DataGridView dgvOrders;

        public OrderTrackingForm(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
            _orderRepository = new GenericRepository<Order, int>(_context);
            LoadOrders();
        }

        private void InitializeComponent()
        {
            this.Text = "Order Tracking";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Title Label
            Label lblTitle = new Label();
            lblTitle.Text = "Track and Manage Orders";
            lblTitle.Font = new Font("Arial", 14, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Size = new Size(300, 25);
            this.Controls.Add(lblTitle);

            // Filter by Status
            Label lblFilter = new Label();
            lblFilter.Text = "Filter by Status:";
            lblFilter.Location = new Point(20, 60);
            this.Controls.Add(lblFilter);

            ComboBox cbStatus = new ComboBox();
            cbStatus.Name = "cbStatus";
            cbStatus.Location = new Point(130, 60);
            cbStatus.Size = new Size(150, 25);
            cbStatus.Items.Add("All");
            cbStatus.Items.Add("Pending");
            cbStatus.Items.Add("Processing");
            cbStatus.Items.Add("Shipped");
            cbStatus.Items.Add("Delivered");
            cbStatus.Items.Add("Cancelled");
            cbStatus.SelectedIndex = 0;
            cbStatus.SelectedIndexChanged += (s, e) => LoadOrders();
            this.Controls.Add(cbStatus);

            // DataGridView
            dgvOrders = new DataGridView();
            dgvOrders.Name = "dgvOrders";
            dgvOrders.Location = new Point(20, 110);
            dgvOrders.Size = new Size(840, 350);
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.Columns.Add("ID", "Order ID");
            dgvOrders.Columns.Add("User", "Customer Name");
            dgvOrders.Columns.Add("Total", "Total Amount");
            dgvOrders.Columns.Add("Status", "Status");
            dgvOrders.Columns.Add("Date", "Created Date");
            dgvOrders.Columns.Add("Address", "Shipping Address");
            dgvOrders.Columns.Add("Update", "Update Status");
            this.Controls.Add(dgvOrders);

            // Status Update
            Label lblNewStatus = new Label();
            lblNewStatus.Text = "Update Status:";
            lblNewStatus.Location = new Point(20, 480);
            this.Controls.Add(lblNewStatus);

            ComboBox cbNewStatus = new ComboBox();
            cbNewStatus.Name = "cbNewStatus";
            cbNewStatus.Location = new Point(120, 480);
            cbNewStatus.Size = new Size(150, 25);
            cbNewStatus.Items.Add("Pending");
            cbNewStatus.Items.Add("Processing");
            cbNewStatus.Items.Add("Shipped");
            cbNewStatus.Items.Add("Delivered");
            cbNewStatus.Items.Add("Cancelled");
            this.Controls.Add(cbNewStatus);

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
                .Where(o => !o.IsDeleted)
                .ToList();

            foreach (var order in orders)
            {
                dgvOrders.Rows.Add(
                    order.ID,
                    order.User?.Name ?? "N/A",
                    order.TotalAmount,
                    order.Status.ToString(),
                    order.CreatedAt.ToString("yyyy-MM-dd"),
                    order.ShippingAddress,
                    "Update"
                );
            }
        }
    }
}
