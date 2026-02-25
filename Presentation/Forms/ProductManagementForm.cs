using System.Windows.Forms;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Application.DTOs.ProductDTOs;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using System.IO;
using System.Drawing;

namespace Presentation.Forms
{
    public partial class ProductManagementForm : Form
    {
        private ApplicationDbContext _context;
        private IProductAdminService _productService;
        private IGenericRepository<Category, int> _categoryRepository;

        public ProductManagementForm(ApplicationDbContext context)
        {
            InitializeComponent();
            SetupGrid();
            _context = context;
            IGenericRepository<Product, int> productRepository = new GenericRepository<Product, int>(_context);
            _categoryRepository = new GenericRepository<Category, int>(_context);
            _productService = new ProductAdminService(productRepository, _categoryRepository);
            LoadCategoryCombo();
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
                Padding = new Padding(0)
            };
            dgvProducts.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 9.75F),
                Padding = new Padding(4),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(214, 234, 248),
                SelectionForeColor = Color.FromArgb(45, 62, 80)
            };
            dgvProducts.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(245, 247, 250),
                SelectionBackColor = Color.FromArgb(214, 234, 248),
                SelectionForeColor = Color.FromArgb(45, 62, 80)
            };

            dgvProducts.Columns.Clear();
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", HeaderText = "ID", Width = 50 });
            dgvProducts.Columns.Add(new DataGridViewImageColumn
            {
                Name = "Image",
                HeaderText = "Image",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 70
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Name", Width = 170 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "Price", Width = 100 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "Category", HeaderText = "Category", Width = 130 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "Stock", HeaderText = "Stock", Width = 80 });
            dgvProducts.Columns.Add(new DataGridViewButtonColumn
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
                    SelectionForeColor = Color.White
                }
            });
            dgvProducts.Columns.Add(new DataGridViewButtonColumn
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
                    SelectionForeColor = Color.White
                }
            });
        }

        private void LoadCategoryCombo()
        {
            cbCategory.Items.Clear();
            cbCategory.Items.Add("-- Select Category --");
            var categories = _categoryRepository.GetAllEntitys().Where(c => !c.IsDeleted).ToList();
            foreach (var cat in categories)
                cbCategory.Items.Add(cat.Name);
            cbCategory.SelectedIndex = 0;
        }

        private void LoadProducts()
        {
            dgvProducts.Rows.Clear();
            var products = _productService.GetAll().ToList();
            foreach (var product in products)
            {
                dgvProducts.Rows.Add(
                    product.Id,
                    LoadProductImage(product.Image),
                    product.Name,
                    product.Price,
                    product.CategoryName ?? "N/A",
                    product.UnitsInStock,
                    "Edit",
                    "Delete");
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
            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString("No Image", font, Brushes.Gray, new RectangleF(0, 0, 60, 50), sf);
            return bmp;
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title = "Select Product Image",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
                txtImage.Text = dlg.FileName;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || cbCategory.SelectedIndex == 0)
            {
                MessageBox.Show("Please fill required fields!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var categories = _categoryRepository.GetAllEntitys()
                .Where(c => !c.IsDeleted).ToList();
            var selectedCategory = categories.ElementAtOrDefault(cbCategory.SelectedIndex - 1);
            if (selectedCategory == null) return;

            try
            {
                if (_editingProductId > 0)
                {
                    var dto = new UpdateProductDto
                    {
                        Name = txtName.Text,
                        Price = decimal.TryParse(txtPrice.Text, out var p2) ? p2 : 0,
                        Description = txtDescription.Text,
                        UnitsInStock = int.TryParse(txtUnits.Text, out var u2) ? u2 : 0,
                        Image = txtImage.Text,
                        CategoryId = selectedCategory.ID
                    };
                    _productService.Update(_editingProductId,  dto);
                    MessageBox.Show("Product updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var dto = new CreateProductDto
                    {
                        Name = txtName.Text,
                        Price = decimal.TryParse(txtPrice.Text, out var p) ? p : 0,
                        Description = txtDescription.Text,
                        UnitsInStock = int.TryParse(txtUnits.Text, out var u) ? u : 0,
                        Image = txtImage.Text,
                        CategoryId = selectedCategory.ID
                    };
                    _productService.Create(dto);
                    MessageBox.Show("Product added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ClearInputs();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int _editingProductId = 0;

        private void ClearInputs()
        {
            _editingProductId = 0;
            txtName.Clear();
            txtPrice.Clear();
            txtDescription.Clear();
            txtUnits.Clear();
            txtImage.Clear();
            cbCategory.SelectedIndex = 0;
            btnAdd.Text = "Add Product";
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int productId = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["ID"].Value);

            if (e.ColumnIndex == dgvProducts.Columns["Edit"].Index)
            {
                _editingProductId = productId;
                txtName.Text = dgvProducts.Rows[e.RowIndex].Cells["Name"].Value?.ToString() ?? "";
                txtPrice.Text = dgvProducts.Rows[e.RowIndex].Cells["Price"].Value?.ToString() ?? "";
                txtUnits.Text = dgvProducts.Rows[e.RowIndex].Cells["Stock"].Value?.ToString() ?? "";

                var catName = dgvProducts.Rows[e.RowIndex].Cells["Category"].Value?.ToString() ?? "";
                for (int i = 0; i < cbCategory.Items.Count; i++)
                {
                    if (cbCategory.Items[i].ToString() == catName)
                    {
                        cbCategory.SelectedIndex = i;
                        break;
                    }
                }

                btnAdd.Text = "Update Product";
                txtName.Focus();
            }
            else if (e.ColumnIndex == dgvProducts.Columns["Delete"].Index)
            {
                var name = dgvProducts.Rows[e.RowIndex].Cells["Name"].Value?.ToString() ?? "";
                var result = MessageBox.Show(
                    $"Are you sure you want to delete '{name}'?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                try
                {
                    _productService.Delete(productId);
                    MessageBox.Show("Product deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
