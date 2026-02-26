using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Application.DTOs.ProductDTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Presentation.Utilities;

namespace Presentation.Forms
{
    public partial class ProductManagementForm : Form
    {
        private ApplicationDbContext _context;
        private IProductAdminService _productService;
        private ICategoryRepository _categoryRepository;

        public ProductManagementForm(ApplicationDbContext context)
        {
            InitializeComponent();

            _context = context;
            IProductRepository productRepository = new ProductRepository(_context);
            _categoryRepository = new CategoryRepository(_context);
            _productService = new ProductAdminService(productRepository, _categoryRepository);

            // Apply Modern Design
            ModernDesignSystem.Forms.ApplyModernFormStyle(this, "Product Management", 1300, 750);
            SetupGrid();
            AddActionButtons();
            LoadProducts();

            // Handle resize
            this.Resize += ProductManagementForm_Resize;
        }

        private void AddActionButtons()
        {
            var pnlContent = this.Controls.Find("pnlContent", true).FirstOrDefault() as Panel;
            if (pnlContent == null)
                return;

            var btnAddNew = new Button
            {
                Location = new Point(
                    ModernDesignSystem.Spacing.Large,
                    ModernDesignSystem.Spacing.Large
                ),
                Name = "btnAddNew",
            };
            ModernDesignSystem.Buttons.ApplySuccessStyle(btnAddNew, "+ Add New Product", 200, 46);
            btnAddNew.Click += (s, e) =>
            {
                using var form = new AddEditProductForm(_productService, _categoryRepository);
                if (form.ShowDialog() == DialogResult.OK)
                    LoadProducts();
            };

            pnlContent.Controls.Add(btnAddNew);
        }

        private void SetupGrid()
        {
            ModernDesignSystem.Grids.ApplyModernStyle(dgvProducts);

            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvProducts.Columns.Clear();

            dgvProducts.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "ID",
                    HeaderText = "ID",
                    Width = 60,
                    MinimumWidth = 50,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Font = ModernDesignSystem.Typography.GridHeader,
                        ForeColor = ModernDesignSystem.Colors.Primary,
                    },
                }
            );

            dgvProducts.Columns.Add(
                new DataGridViewImageColumn
                {
                    Name = "Image",
                    HeaderText = "Image",
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Width = 80,
                    MinimumWidth = 60,
                }
            );

            dgvProducts.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Name",
                    HeaderText = "Product Name",
                    Width = 200,
                    MinimumWidth = 150,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                        ForeColor = ModernDesignSystem.Colors.TextPrimary,
                    },
                }
            );

            dgvProducts.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Price",
                    HeaderText = "Price",
                    Width = 100,
                    MinimumWidth = 80,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "C2",
                        ForeColor = ModernDesignSystem.Colors.Success,
                    },
                }
            );

            dgvProducts.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Category",
                    HeaderText = "Category",
                    Width = 130,
                    MinimumWidth = 100,
                }
            );

            dgvProducts.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Stock",
                    HeaderText = "Stock",
                    Width = 80,
                    MinimumWidth = 60,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter,
                    },
                }
            );

            dgvProducts.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Status",
                    HeaderText = "Status",
                    Width = 100,
                    MinimumWidth = 80,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Font = ModernDesignSystem.Typography.GridHeader,
                        Alignment = DataGridViewContentAlignment.MiddleCenter,
                    },
                }
            );

            dgvProducts.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "ToggleStatus",
                    HeaderText = "",
                    Text = "Toggle",
                    UseColumnTextForButtonValue = true,
                    Width = 90,
                    MinimumWidth = 70,
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

            dgvProducts.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    HeaderText = "",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true,
                    Width = 100,
                    MinimumWidth = 80,
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = ModernDesignSystem.Colors.Primary,
                        ForeColor = ModernDesignSystem.Colors.TextLight,
                        Font = ModernDesignSystem.Typography.Button,
                        SelectionBackColor = ModernDesignSystem.Colors.PrimaryDark,
                        SelectionForeColor = ModernDesignSystem.Colors.TextLight,
                    },
                }
            );

            dgvProducts.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    HeaderText = "",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true,
                    Width = 110,
                    MinimumWidth = 90,
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = ModernDesignSystem.Colors.Danger,
                        ForeColor = ModernDesignSystem.Colors.TextLight,
                        Font = ModernDesignSystem.Typography.Button,
                        SelectionBackColor = Color.FromArgb(220, 38, 38),
                        SelectionForeColor = ModernDesignSystem.Colors.TextLight,
                    },
                }
            );
        }

        private void ProductManagementForm_Resize(object sender, EventArgs e)
        {
            // Adjust grid to fill available space
            if (dgvProducts != null && dgvProducts.Parent != null)
            {
                dgvProducts.Width = dgvProducts.Parent.Width - 48;
                dgvProducts.Height = dgvProducts.Parent.Height - dgvProducts.Top - 24;
            }
        }

        private void LoadProducts()
        {
            dgvProducts.Rows.Clear();
            var products = _productService.GetAll().ToList();

            foreach (var product in products)
            {
                int rowIdx = dgvProducts.Rows.Add(
                    product.ID,
                    LoadProductImage(product.Image),
                    product.Name,
                    product.Price,
                    product.CategoryName ?? "N/A",
                    product.UnitsInStock,
                    product.IsActive ? "Active" : "Inactive",
                    product.IsActive ? "Deactivate" : "Activate",
                    "Edit",
                    "Delete"
                );

                var row = dgvProducts.Rows[rowIdx];

                row.Cells["Status"].Style.ForeColor = product.IsActive
                    ? ModernDesignSystem.Colors.Success
                    : ModernDesignSystem.Colors.Danger;
                row.Cells["Status"].Style.Font = ModernDesignSystem.Typography.GridHeader;

                if (!product.IsActive)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(250, 245, 245);
                    row.DefaultCellStyle.ForeColor = ModernDesignSystem.Colors.TextSecondary;
                }

                if (product.UnitsInStock < 10)
                {
                    row.Cells["Stock"].Style.ForeColor = ModernDesignSystem.Colors.Danger;
                    row.Cells["Stock"].Style.Font = ModernDesignSystem.Typography.GridHeader;
                }
            }
        }

        private Image? LoadProductImage(string? imagePath)
        {
            if (!string.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath))
            {
                try
                {
                    using var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
                    using var ms = new MemoryStream();
                    fs.CopyTo(ms);
                    ms.Position = 0;
                    using var img = Image.FromStream(ms);
                    return (Image)img.Clone();
                }
                catch { }
            }
            return CreatePlaceholder();
        }

        private static Image CreatePlaceholder()
        {
            var bmp = new Bitmap(60, 50);
            using var g = Graphics.FromImage(bmp);
            g.Clear(ModernDesignSystem.Colors.HoverBackground);
            using var pen = new Pen(ModernDesignSystem.Colors.GridBorder, 2);
            g.DrawRectangle(pen, 1, 1, 58, 48);
            using var font = new Font("Segoe UI", 7f);
            var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };
            g.DrawString(
                "No Image",
                font,
                new SolidBrush(ModernDesignSystem.Colors.TextSecondary),
                new RectangleF(0, 0, 60, 50),
                sf
            );
            return bmp;
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int productId = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["ID"].Value);

            if (e.ColumnIndex == dgvProducts.Columns["Edit"].Index)
            {
                var product = _productService.GetById(productId);
                using var form = new AddEditProductForm(
                    _productService,
                    _categoryRepository,
                    product
                );
                if (form.ShowDialog() == DialogResult.OK)
                    LoadProducts();
            }
            else if (e.ColumnIndex == dgvProducts.Columns["ToggleStatus"].Index)
            {
                var name = dgvProducts.Rows[e.RowIndex].Cells["Name"].Value?.ToString() ?? "";
                var statusText = dgvProducts.Rows[e.RowIndex].Cells["Status"].Value?.ToString();
                bool isActive = statusText?.Contains("Active") == true;
                var action = isActive ? "deactivate" : "activate";

                if (
                    ModernDesignSystem.Messages.ShowConfirmation(
                        $"Are you sure you want to {action} '{name}'?",
                        "Confirm Status Change"
                    ) != DialogResult.Yes
                )
                    return;

                try
                {
                    if (isActive)
                        _productService.Deactivate(productId);
                    else
                        _productService.Activate(productId);

                    ModernDesignSystem.Messages.ShowSuccess($"Product {action}d successfully!");
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    ModernDesignSystem.Messages.ShowError($"Error: {ex.Message}");
                }
            }
            else if (e.ColumnIndex == dgvProducts.Columns["Delete"].Index)
            {
                var name = dgvProducts.Rows[e.RowIndex].Cells["Name"].Value?.ToString() ?? "";

                if (
                    ModernDesignSystem.Messages.ShowConfirmation(
                        $"Are you sure you want to delete '{name}'?\n\nThis action cannot be undone.",
                        "Confirm Delete"
                    ) != DialogResult.Yes
                )
                    return;

                try
                {
                    _productService.Delete(productId);
                    ModernDesignSystem.Messages.ShowSuccess("Product deleted successfully!");
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    ModernDesignSystem.Messages.ShowError($"Error: {ex.Message}");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
