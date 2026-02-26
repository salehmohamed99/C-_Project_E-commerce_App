using System.Drawing;
using System.Windows.Forms;
using Application.DTOs.OrderDTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Presentation.Utilities;

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

            _context = context;
            IOrderRepository orderRepository = new OrderRepository(_context);
            IGenericRepository<CartItem, int> cartItemRepository = new GenericRepository<
                CartItem,
                int
            >(_context);
            _orderService = new OrderService(orderRepository, cartItemRepository);

            // Apply Modern Design
            ModernDesignSystem.Forms.ApplyModernFormStyle(this, "Order Tracking", 1300, 750);
            SetupGrid();
            LoadOrders();

            // Handle resize
            this.Resize += OrderTrackingForm_Resize;
        }

        private void SetupGrid()
        {
            ModernDesignSystem.Grids.ApplyModernStyle(dgvOrders);

            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvOrders.Columns.Clear();

            dgvOrders.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "ID",
                    HeaderText = "Order #",
                    Width = 90,
                    MinimumWidth = 70,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Font = ModernDesignSystem.Typography.H4,
                        ForeColor = ModernDesignSystem.Colors.Primary,
                    },
                }
            );

            dgvOrders.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "User",
                    HeaderText = "Customer",
                    Width = 150,
                    MinimumWidth = 100,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                    },
                }
            );

            dgvOrders.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Total",
                    HeaderText = "Total Amount",
                    Width = 120,
                    MinimumWidth = 90,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "C2",
                        ForeColor = ModernDesignSystem.Colors.Success,
                        Font = ModernDesignSystem.Typography.GridHeader,
                    },
                }
            );

            dgvOrders.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Status",
                    HeaderText = "Status",
                    Width = 140,
                    MinimumWidth = 100,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Font = ModernDesignSystem.Typography.GridHeader,
                        Alignment = DataGridViewContentAlignment.MiddleCenter,
                    },
                }
            );

            dgvOrders.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Date",
                    HeaderText = "Order Date",
                    Width = 150,
                    MinimumWidth = 120,
                }
            );

            dgvOrders.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Address",
                    HeaderText = "Shipping Address",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    MinimumWidth = 150,
                }
            );

            dgvOrders.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "ViewBtn",
                    HeaderText = "",
                    Text = "View",
                    UseColumnTextForButtonValue = true,
                    Width = 100,
                    MinimumWidth = 80,
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = ModernDesignSystem.Colors.Info,
                        ForeColor = ModernDesignSystem.Colors.TextLight,
                        Font = ModernDesignSystem.Typography.Button,
                        SelectionBackColor = Color.FromArgb(37, 99, 235),
                        SelectionForeColor = ModernDesignSystem.Colors.TextLight,
                    },
                }
            );

            dgvOrders.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "UpdateBtn",
                    HeaderText = "",
                    Text = "Update",
                    UseColumnTextForButtonValue = true,
                    Width = 100,
                    MinimumWidth = 80,
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = ModernDesignSystem.Colors.Warning,
                        ForeColor = ModernDesignSystem.Colors.TextLight,
                        Font = ModernDesignSystem.Typography.Button,
                        SelectionBackColor = Color.FromArgb(234, 88, 12),
                        SelectionForeColor = ModernDesignSystem.Colors.TextLight,
                    },
                }
            );
        }

        private void OrderTrackingForm_Resize(object sender, EventArgs e)
        {
            // Adjust grid to fill available space
            if (dgvOrders != null && dgvOrders.Parent != null)
            {
                dgvOrders.Width = dgvOrders.Parent.Width - 48;
                dgvOrders.Height = dgvOrders.Parent.Height - dgvOrders.Top - 24;
            }
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
                        OrderStatus.Shipped => "Shipped",
                        OrderStatus.Delivered => "Delivered",
                        OrderStatus.Cancelled => "Cancelled",
                        _ => order.Status.ToString(),
                    };

                    int rowIdx = dgvOrders.Rows.Add(
                        $"#{order.ID}",
                        order.UserName ?? "N/A",
                        order.TotalAmount,
                        statusDisplay,
                        order.CreatedAt.ToString("MMM dd, yyyy hh:mm tt"),
                        order.ShippingAddress
                    );

                    var row = dgvOrders.Rows[rowIdx];
                    var statusColor = order.Status switch
                    {
                        OrderStatus.Processing => ModernDesignSystem.Colors.Warning,
                        OrderStatus.Shipped => ModernDesignSystem.Colors.Info,
                        OrderStatus.Delivered => ModernDesignSystem.Colors.Success,
                        OrderStatus.Cancelled => ModernDesignSystem.Colors.Danger,
                        _ => ModernDesignSystem.Colors.TextPrimary,
                    };

                    row.Cells["Status"].Style.ForeColor = statusColor;
                    row.Cells["Status"].Style.Font = ModernDesignSystem.Typography.GridHeader;

                    // Highlight cancelled orders
                    if (order.Status == OrderStatus.Cancelled)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(254, 242, 242);
                    }
                }
            }
            catch (Exception ex)
            {
                ModernDesignSystem.Messages.ShowError($"Error loading orders: {ex.Message}");
            }
        }

        // Event handler for refresh button from Designer
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var orderIdText = dgvOrders.Rows[e.RowIndex].Cells["ID"].Value?.ToString() ?? "";
            if (!int.TryParse(orderIdText.Replace("#", ""), out int orderId))
                return;

            var order = _loadedOrders.FirstOrDefault(o => o.ID == orderId);
            if (order == null)
                return;

            if (e.ColumnIndex == dgvOrders.Columns["ViewBtn"].Index)
            {
                new OrderDetailsForm(order).ShowDialog();
            }
            else if (e.ColumnIndex == dgvOrders.Columns["UpdateBtn"].Index)
            {
                ShowUpdateStatusDialog(order);
            }
        }

        private void ShowUpdateStatusDialog(OrderDTO order)
        {
            var form = new Form
            {
                Text = $"Update Order #{order.ID} Status",
                ClientSize = new Size(380, 200),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = ModernDesignSystem.Colors.ContentBackground,
            };

            var pnlHeader = ModernDesignSystem.Forms.CreateHeader(
                $"Update Order #{order.ID}",
                "Select new status for this order"
            );
            pnlHeader.Height = 80;
            form.Controls.Add(pnlHeader);

            var lbl = new Label
            {
                Text = "New Status:",
                Location = new Point(ModernDesignSystem.Spacing.Large, 95),
                AutoSize = true,
                Font = ModernDesignSystem.Typography.Label,
                ForeColor = ModernDesignSystem.Colors.TextPrimary,
            };

            var cmb = new ComboBox
            {
                Location = new Point(ModernDesignSystem.Spacing.Large, 120),
                Size = new Size(330, 36),
                Font = ModernDesignSystem.Typography.Body,
                BackColor = ModernDesignSystem.Colors.CardBackground,
                ForeColor = ModernDesignSystem.Colors.TextPrimary,
                FlatStyle = FlatStyle.Flat,
                DropDownStyle = ComboBoxStyle.DropDownList,
            };

            cmb.Items.AddRange(Enum.GetNames<OrderStatus>());
            cmb.SelectedItem = order.Status.ToString();

            var btnSave = new Button
            {
                Location = new Point(ModernDesignSystem.Spacing.Large, 160),
            };
            ModernDesignSystem.Buttons.ApplySuccessStyle(btnSave, "Save Changes", 150, 40);

            btnSave.Click += async (s, e) =>
            {
                try
                {
                    var newStatus = Enum.Parse<OrderStatus>(cmb.SelectedItem.ToString()!);
                    var dto = new UpdateOrderDTO { ID = order.ID, Status = newStatus };
                    await _orderService.UpdateOrderStatusAsync(dto);

                    ModernDesignSystem.Messages.ShowSuccess(
                        $"Order #{order.ID} status updated to {newStatus}!",
                        "Status Updated"
                    );

                    form.DialogResult = DialogResult.OK;
                    form.Close();
                    LoadOrders();
                }
                catch (Exception ex)
                {
                    ModernDesignSystem.Messages.ShowError($"Error updating status: {ex.Message}");
                }
            };

            var btnCancel = new Button { Location = new Point(200, 160) };
            ModernDesignSystem.Buttons.ApplySecondaryStyle(btnCancel, "Cancel", 150, 40);
            btnCancel.Click += (s, e) => form.Close();

            form.AcceptButton = btnSave;
            form.CancelButton = btnCancel;
            form.Controls.AddRange(new Control[] { lbl, cmb, btnSave, btnCancel });

            form.ShowDialog();
        }

        private void OrderTrackingForm_Load(object sender, EventArgs e) { }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
