using System.Drawing;
using System.Windows.Forms;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Application.DTOs.OrderDTOs;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Presentation.Forms
{
    public partial class OrderTrackingForm : Form
    {
        private ApplicationDbContext _context;
        private IOrderService _orderService;
        private List<OrderDTO> _loadedOrders = new();

        public OrderTrackingForm(ApplicationDbContext context)
        {
            InitializeComponent();
            SetupGrid();
            _context = context;
            IOrderRepository orderRepository = new Infrastructure.Repositories.OrderRepository(_context);
            IGenericRepository<CartItem, int> cartItemRepository = new GenericRepository<CartItem, int>(_context);
            _orderService = new OrderService(orderRepository, cartItemRepository);
        }

        private void SetupGrid()
        {
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(45, 62, 80),
                ForeColor = Color.White,
                Font      = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Padding   = new Padding(0)
            };
            dgvOrders.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font               = new Font("Segoe UI", 9.75F),
                Padding            = new Padding(5),
                Alignment          = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(214, 234, 248),
                SelectionForeColor = Color.FromArgb(45, 62, 80)
            };
            dgvOrders.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor          = Color.FromArgb(245, 247, 250),
                SelectionBackColor = Color.FromArgb(214, 234, 248),
                SelectionForeColor = Color.FromArgb(45, 62, 80)
            };

            dgvOrders.Columns.Clear();
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID", HeaderText = "Order #", Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(45, 62, 80)
                }
            });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { Name = "User", HeaderText = "Customer", Width = 140 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total", HeaderText = "Total", Width = 110 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", Width = 130 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date", HeaderText = "Date", Width = 120 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { Name = "Address", HeaderText = "Address", Width = 160 });
            dgvOrders.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "ViewBtn", HeaderText = "", Text = "View",
                UseColumnTextForButtonValue = true, Width = 100,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(52, 152, 219), ForeColor = Color.White,
                    Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                    SelectionBackColor = Color.FromArgb(41, 128, 185), SelectionForeColor = Color.White
                }
            });
            dgvOrders.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "UpdateBtn", HeaderText = "", Text = "Update Status",
                UseColumnTextForButtonValue = true, Width = 110,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(243, 156, 18), ForeColor = Color.White,
                    Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                    SelectionBackColor = Color.FromArgb(211, 132, 0), SelectionForeColor = Color.White
                }
            });
        }

        private async void LoadOrders()
        {
            dgvOrders.Rows.Clear();
            try
            {
                var orders = await _orderService.GetAllOrdersAsync();
                _loadedOrders = orders.ToList();

                foreach (var order in _loadedOrders)
                {
                    string statusDisplay = order.Status switch
                    {
                        OrderStatus.Processing => "Processing",
                        OrderStatus.Shipped    => "Shipped",
                        OrderStatus.Delivered  => "Delivered",
                        OrderStatus.Cancelled  => "Cancelled",
                        _ => order.Status.ToString()
                    };

                    int rowIdx = dgvOrders.Rows.Add(
                        order.ID,
                        order.UserName ?? "N/A",
                        $"${order.TotalAmount:F2}",
                        statusDisplay,
                        order.CreatedAt.ToString("MMM dd, yyyy"),
                        order.ShippingAddress);

                    var row = dgvOrders.Rows[rowIdx];
                    var statusColor = order.Status switch
                    {
                        OrderStatus.Processing => Color.FromArgb(243, 156, 18),
                        OrderStatus.Shipped    => Color.FromArgb(52, 152, 219),
                        OrderStatus.Delivered  => Color.FromArgb(39, 174, 96),
                        OrderStatus.Cancelled  => Color.FromArgb(231, 76, 60),
                        _ => Color.Black
                    };
                    row.Cells["Status"].Style.ForeColor = statusColor;
                    row.Cells["Status"].Style.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int orderId = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["ID"].Value);
            var order = _loadedOrders.FirstOrDefault(o => o.ID == orderId);
            if (order == null) return;

            if (e.ColumnIndex == dgvOrders.Columns["ViewBtn"].Index)
            {
                new OrderDetailsForm(order).ShowDialog();
            }
            else if (e.ColumnIndex == dgvOrders.Columns["UpdateBtn"].Index)
            {
                var form = new Form
                {
                    Text = $"Update Order #{orderId} Status",
                    ClientSize = new Size(320, 160),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    BackColor = Color.White
                };

                var lbl = new Label { Text = "Select new status:", Location = new Point(15, 15), AutoSize = true, Font = new Font("Segoe UI", 10F) };
                var cmb = new ComboBox
                {
                    Location = new Point(15, 45),
                    Size = new Size(280, 30),
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Font = new Font("Segoe UI", 10F)
                };
                cmb.Items.AddRange(Enum.GetNames<OrderStatus>());
                cmb.SelectedItem = order.Status.ToString();

                var btnSave = new Button
                {
                    Text = "Save",
                    Location = new Point(110, 100),
                    Size = new Size(90, 35),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(39, 174, 96),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    DialogResult = DialogResult.OK
                };
                btnSave.FlatAppearance.BorderSize = 0;
                var btnCancel = new Button
                {
                    Text = "Cancel",
                    Location = new Point(210, 100),
                    Size = new Size(85, 35),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(149, 165, 166),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    DialogResult = DialogResult.Cancel
                };
                btnCancel.FlatAppearance.BorderSize = 0;

                form.AcceptButton = btnSave;
                form.CancelButton = btnCancel;
                form.Controls.AddRange([lbl, cmb, btnSave, btnCancel]);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var newStatus = Enum.Parse<OrderStatus>(cmb.SelectedItem.ToString()!);
                        var dto = new UpdateOrderDTO { ID = orderId, Status = newStatus };
                        await _orderService.UpdateOrderStatusAsync(dto);
                        MessageBox.Show("Status updated!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadOrders();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void OrderTrackingForm_Load(object sender, EventArgs e)
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
