using System.Drawing;
using System.Windows.Forms;
using Application.DTOs.OrderDTOs;

namespace Presentation.Forms
{
    public partial class OrderDetailsForm : Form
    {
        private OrderDTO _order;

        public OrderDetailsForm(OrderDTO order)
        {
            _order = order;
            InitializeComponent();
            LoadOrderDetails();
        }

        private void InitializeComponent()
        {
            this.Text = $"Order #{_order.ID} - Details";
            this.ClientSize = new Size(650, 520);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 10F);

            // ?? Header Panel ??
            var pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(45, 62, 80)
            };
            var lblHeader = new Label
            {
                Text = $"Order #{_order.ID}",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                AutoSize = false,
                Size = new Size(600, 40),
                Location = new Point(20, 12),
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlHeader.Controls.Add(lblHeader);
            this.Controls.Add(pnlHeader);

            // ?? Info Panel ??
            var pnlInfo = new Panel
            {
                Location = new Point(20, 75),
                Size = new Size(610, 120),
                BackColor = Color.FromArgb(245, 247, 250),
                Padding = new Padding(15)
            };

            var lblStatus = CreateInfoLabel($"Status:  {_order.Status}", 10);
            lblStatus.ForeColor = _order.Status switch
            {
                Domain.Entities.OrderStatus.Processing => Color.FromArgb(243, 156, 18),
                Domain.Entities.OrderStatus.Shipped => Color.FromArgb(52, 152, 219),
                Domain.Entities.OrderStatus.Delivered => Color.FromArgb(39, 174, 96),
                Domain.Entities.OrderStatus.Cancelled => Color.FromArgb(231, 76, 60),
                _ => Color.Black
            };
            lblStatus.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            var lblDate = CreateInfoLabel($"Date:  {_order.CreatedAt:yyyy-MM-dd}", 38);
            var lblAddress = CreateInfoLabel($"Address:  {_order.ShippingAddress ?? "N/A"}", 62);
            var lblTotal = CreateInfoLabel($"Total:  ${_order.TotalAmount:F2}", 86);
            lblTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(39, 174, 96);

            pnlInfo.Controls.AddRange([lblStatus, lblDate, lblAddress, lblTotal]);
            this.Controls.Add(pnlInfo);

            // ?? Products Label ??
            var lblProducts = new Label
            {
                Text = "Order Items",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(20, 210),
                AutoSize = true,
                ForeColor = Color.FromArgb(45, 62, 80)
            };
            this.Controls.Add(lblProducts);

            // ?? Products DataGridView ??
            var dgv = new DataGridView
            {
                Location = new Point(20, 240),
                Size = new Size(610, 220),
                AutoGenerateColumns = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                BackgroundColor = Color.White,
                GridColor = Color.FromArgb(230, 230, 230),
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(45, 62, 80),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Padding = new Padding(0)
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9.75F),
                    Padding = new Padding(5),
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    SelectionBackColor = Color.FromArgb(214, 234, 248),
                    SelectionForeColor = Color.FromArgb(45, 62, 80)
                },
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(245, 247, 250),
                    SelectionBackColor = Color.FromArgb(214, 234, 248),
                    SelectionForeColor = Color.FromArgb(45, 62, 80)
                },
                EnableHeadersVisualStyles = false,
                ColumnHeadersHeight = 42,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            };
            dgv.RowTemplate.Height = 38;

            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Product", HeaderText = "Product", Width = 220 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "UnitPrice", HeaderText = "Unit Price", Width = 120 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Qty", HeaderText = "Qty", Width = 80 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Subtotal", HeaderText = "Subtotal", Width = 140 });

            if (_order.OrderProducts != null)
            {
                foreach (var op in _order.OrderProducts)
                {
                    dgv.Rows.Add(op.ProductName, $"${op.UnitPrice:F2}", op.Quantity, $"${op.TotalPrice:F2}");
                }
            }
            this.Controls.Add(dgv);

            // ?? Close Button ??
            var btnClose = new Button
            {
                Text = "Close",
                Size = new Size(100, 38),
                Location = new Point(530, 470),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(45, 62, 80),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();
            this.Controls.Add(btnClose);
        }

        private static Label CreateInfoLabel(string text, int top)
        {
            return new Label
            {
                Text = text,
                Location = new Point(15, top),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F)
            };
        }

        private void LoadOrderDetails() { }
    }
}
