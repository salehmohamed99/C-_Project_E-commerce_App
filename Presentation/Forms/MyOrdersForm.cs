using System.Drawing;
using System.Windows.Forms;
using Application.DTOs.OrderDTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Presentation.Forms
{
    public partial class MyOrdersForm : Form
    {
        private ApplicationDbContext _context;
        private IOrderService _orderService;
        private int _userId;
        private List<OrderDTO> _loadedOrders = new();

        public MyOrdersForm(ApplicationDbContext context, int userId)
        {
            InitializeComponent();
            SetupGrid();
            _context = context;
            _userId = userId;
            IOrderRepository orderRepository = new Infrastructure.Repositories.OrderRepository(
                _context
            );
            IGenericRepository<CartItem, int> cartItemRepository = new GenericRepository<
                CartItem,
                int
            >(_context);
            _orderService = new OrderService(orderRepository, cartItemRepository);
        }

        private void SetupGrid()
        {
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(45, 62, 80),
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Padding = new Padding(0),
            };
            dgvOrders.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 9.75F),
                Padding = new Padding(6, 4, 6, 4),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(214, 234, 248),
                SelectionForeColor = Color.FromArgb(45, 62, 80),
            };
            dgvOrders.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(245, 247, 250),
                SelectionBackColor = Color.FromArgb(214, 234, 248),
                SelectionForeColor = Color.FromArgb(45, 62, 80),
            };

            dgvOrders.Columns.Clear();
            dgvOrders.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "ID",
                    HeaderText = "Order #",
                    Width = 90,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                        ForeColor = Color.FromArgb(45, 62, 80),
                    },
                }
            );
            dgvOrders.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Total",
                    HeaderText = "Total",
                    Width = 130,
                }
            );
            dgvOrders.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Status",
                    HeaderText = "Status",
                    Width = 130,
                }
            );
            dgvOrders.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Date",
                    HeaderText = "Date",
                    Width = 130,
                }
            );
            dgvOrders.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Address",
                    HeaderText = "Shipping Address",
                    Width = 240,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleLeft,
                        Padding = new Padding(12, 0, 0, 0),
                    },
                }
            );
            dgvOrders.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "Details",
                    HeaderText = "",
                    Text = "View Details",
                    UseColumnTextForButtonValue = true,
                    Width = 130,
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = Color.FromArgb(52, 152, 219),
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                        Alignment = DataGridViewContentAlignment.MiddleCenter,
                        Padding = new Padding(4),
                        SelectionBackColor = Color.FromArgb(41, 128, 185),
                        SelectionForeColor = Color.White,
                    },
                }
            );
        }

        private async void LoadOrders()
        {
            dgvOrders.Rows.Clear();
            try
            {
                var orders = await _orderService.GetUserOrdersAsync(_userId);
                _loadedOrders = orders.ToList();

                // Update stats cards
                lblCardTotalCount.Text = _loadedOrders.Count.ToString();
                lblCardProcessingCount.Text = _loadedOrders
                    .Count(o => o.Status == OrderStatus.Processing)
                    .ToString();
                lblCardShippedCount.Text = _loadedOrders
                    .Count(o => o.Status == OrderStatus.Shipped)
                    .ToString();
                lblCardDeliveredCount.Text = _loadedOrders
                    .Count(o => o.Status == OrderStatus.Delivered)
                    .ToString();
                lblCardCancelledCount.Text = _loadedOrders
                    .Count(o => o.Status == OrderStatus.Cancelled)
                    .ToString();

                // Show/hide empty state
                lblNoOrders.Visible = _loadedOrders.Count == 0;
                dgvOrders.Visible = _loadedOrders.Count > 0;

                foreach (var order in _loadedOrders)
                {
                    string statusDisplay = order.Status switch
                    {
                        OrderStatus.Processing => "Processing",
                        OrderStatus.Shipped => "Shipped",
                        OrderStatus.Delivered => "Delivered",
                        OrderStatus.Cancelled => "Cancelled",
                        _ => order.Status.ToString(),
                    };

                    int rowIdx = dgvOrders.Rows.Add(
                        $"#{order.ID}",
                        $"${order.TotalAmount:F2}",
                        statusDisplay,
                        order.CreatedAt.ToString("MMM dd, yyyy"),
                        order.ShippingAddress
                    );

                    var row = dgvOrders.Rows[rowIdx];
                    var statusColor = order.Status switch
                    {
                        OrderStatus.Processing => Color.FromArgb(243, 156, 18),
                        OrderStatus.Shipped => Color.FromArgb(52, 152, 219),
                        OrderStatus.Delivered => Color.FromArgb(39, 174, 96),
                        OrderStatus.Cancelled => Color.FromArgb(231, 76, 60),
                        _ => Color.Black,
                    };
                    row.Cells["Status"].Style.ForeColor = statusColor;
                    row.Cells["Status"].Style.Font = new Font(
                        "Segoe UI Semibold",
                        9.5F,
                        FontStyle.Bold
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error loading orders: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex != dgvOrders.Columns["Details"].Index)
                return;

            int orderId = Convert.ToInt32(
                dgvOrders.Rows[e.RowIndex].Cells["ID"].Value?.ToString()?.Replace("#", "")
            );
            var order = _loadedOrders.FirstOrDefault(o => o.ID == orderId);
            if (order == null)
                return;

            new OrderDetailsForm(order).ShowDialog();
        }

        private void MyOrdersForm_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
