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
            SetupGrid();
            _context = context;
            IProductRepository productRepository = new ProductRepository(_context);
            _categoryRepository = new CategoryRepository(_context);
            _productService = new ProductAdminService(productRepository, _categoryRepository);

            // Replace inline inputs with a single "Add Product" button
            pnlInputs.Controls.Clear();
            var btnAddNew = new Button
            {
                Text = "+ Add New Product",
                Location = new Point(12, 12),
                Size = new Size(200, 45),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(39, 174, 96),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Cursor = Cursors.Hand,
            };
            btnAddNew.FlatAppearance.BorderSize = 0;
            btnAddNew.Click += (s, e) =>
            {
                using var form = new AddEditProductForm(_productService, _categoryRepository);
                if (form.ShowDialog() == DialogResult.OK)
                    LoadProducts();
            };
            pnlInputs.Size = new Size(pnlInputs.Width, 70);
            pnlInputs.Controls.Add(btnAddNew);

            // Adjust grid position and anchor to fill space
            dgvProducts.Location = new Point(25, 160);
            dgvProducts.Size = new Size(1050, 520);
            dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducts.ScrollBars = ScrollBars.Both;

            LoadProducts();
        }

        private void SetupGrid()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(45, 62, 80),
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Padding = new Padding(0),
            };
            dgvProducts.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 9.75F),
                Padding = new Padding(4),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(214, 234, 248),
                SelectionForeColor = Color.FromArgb(45, 62, 80),
            };
            dgvProducts.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(245, 247, 250),
                SelectionBackColor = Color.FromArgb(214, 234, 248),
                SelectionForeColor = Color.FromArgb(45, 62, 80),
            };

            dgvProducts.Columns.Clear();
            dgvProducts.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "ID",
                    HeaderText = "ID",
                    Width = 50,
                }
            );
            dgvProducts.Columns.Add(
                new DataGridViewImageColumn
                {
                    Name = "Image",
                    HeaderText = "Image",
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Width = 70,
                }
            );
            dgvProducts.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Name",
                    HeaderText = "Name",
                    Width = 170,
                }
            );
            dgvProducts.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Price",
                    HeaderText = "Price",
                    Width = 100,
                }
            );
            dgvProducts.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Category",
                    HeaderText = "Category",
                    Width = 130,
                }
            );
            dgvProducts.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Stock",
                    HeaderText = "Stock",
                    Width = 80,
                }
            );
            dgvProducts.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Status",
                    HeaderText = "Status",
                    Width = 80,
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
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = Color.FromArgb(243, 156, 18),
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                        SelectionBackColor = Color.FromArgb(211, 133, 9),
                        SelectionForeColor = Color.White,
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
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = Color.FromArgb(52, 152, 219),
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                        SelectionBackColor = Color.FromArgb(41, 128, 185),
                        SelectionForeColor = Color.White,
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
                    FlatStyle = FlatStyle.Flat,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = Color.FromArgb(231, 76, 60),
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                        SelectionBackColor = Color.FromArgb(192, 57, 43),
                        SelectionForeColor = Color.White,
                    },
                }
            );
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
                    ? Color.FromArgb(39, 174, 96)
                    : Color.FromArgb(231, 76, 60);
                row.Cells["Status"].Style.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);

                if (!product.IsActive)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(240, 230, 230);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 160);
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
            g.Clear(Color.WhiteSmoke);
            using var pen = new Pen(Color.LightGray, 1);
            g.DrawRectangle(pen, 0, 0, 59, 49);
            using var font = new Font("Arial", 6f);
            var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };
            g.DrawString("No Image", font, Brushes.Gray, new RectangleF(0, 0, 60, 50), sf);
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
                using var form = new AddEditProductForm(_productService, _categoryRepository, product);
                if (form.ShowDialog() == DialogResult.OK)
                    LoadProducts();
            }
            else if (e.ColumnIndex == dgvProducts.Columns["ToggleStatus"].Index)
            {
                var name = dgvProducts.Rows[e.RowIndex].Cells["Name"].Value?.ToString() ?? "";
                var statusText = dgvProducts.Rows[e.RowIndex].Cells["Status"].Value?.ToString();
                bool isActive = statusText == "Active";
                var action = isActive ? "deactivate" : "activate";

                var result = MessageBox.Show(
                    $"Are you sure you want to {action} '{name}'?",
                    "Confirm Status Change",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result != DialogResult.Yes)
                    return;

                try
                {
                    if (isActive)
                        _productService.Deactivate(productId);
                    else
                        _productService.Activate(productId);

                    MessageBox.Show(
                        $"Product {action}d successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            else if (e.ColumnIndex == dgvProducts.Columns["Delete"].Index)
            {
                var name = dgvProducts.Rows[e.RowIndex].Cells["Name"].Value?.ToString() ?? "";
                var result = MessageBox.Show(
                    $"Are you sure you want to delete '{name}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result != DialogResult.Yes)
                    return;

                try
                {
                    _productService.Delete(productId);
                    MessageBox.Show(
                        "Product deleted successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
