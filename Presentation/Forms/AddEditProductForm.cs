using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Application.DTOs.ProductDTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;

namespace Presentation.Forms
{
    public class AddEditProductForm : Form
    {
        private readonly IProductAdminService _productService;
        private readonly ICategoryRepository _categoryRepository;
        private readonly int _editingProductId;
        private readonly bool _isEditMode;

        private TextBox txtName;
        private TextBox txtPrice;
        private TextBox txtDescription;
        private TextBox txtStock;
        private TextBox txtImage;
        private ComboBox cbCategory;
        private CheckBox chkActive;
        private Button btnSave;
        private Button btnCancel;

        public AddEditProductForm(
            IProductAdminService productService,
            ICategoryRepository categoryRepository,
            ProductDto? existingProduct = null)
        {
            _productService = productService;
            _categoryRepository = categoryRepository;
            _isEditMode = existingProduct != null;
            _editingProductId = existingProduct?.ID ?? 0;

            BuildUI();
            LoadCategories();

            if (_isEditMode && existingProduct != null)
                FillFields(existingProduct);
        }

        private void BuildUI()
        {
            this.Text = _isEditMode ? "Edit Product" : "Add New Product";
            this.ClientSize = new Size(500, _isEditMode ? 480 : 440);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(245, 247, 250);

            var pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(45, 62, 80),
            };
            var lblTitle = new Label
            {
                Text = _isEditMode ? "Edit Product" : "Add New Product",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 14),
                AutoSize = true,
                BackColor = Color.Transparent,
            };
            pnlHeader.Controls.Add(lblTitle);

            var labelFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            var fieldFont = new Font("Segoe UI", 10F);
            var labelColor = Color.FromArgb(45, 62, 80);
            int y = 80;

            // Name
            var lblName = new Label { Text = "Product Name *", Font = labelFont, ForeColor = labelColor, Location = new Point(25, y), AutoSize = true };
            txtName = new TextBox { Location = new Point(25, y + 22), Size = new Size(450, 28), Font = fieldFont, BorderStyle = BorderStyle.FixedSingle };
            y += 55;

            // Price + Stock row
            var lblPrice = new Label { Text = "Price *", Font = labelFont, ForeColor = labelColor, Location = new Point(25, y), AutoSize = true };
            txtPrice = new TextBox { Location = new Point(25, y + 22), Size = new Size(210, 28), Font = fieldFont, BorderStyle = BorderStyle.FixedSingle };
            var lblStock = new Label { Text = "Stock *", Font = labelFont, ForeColor = labelColor, Location = new Point(265, y), AutoSize = true };
            txtStock = new TextBox { Location = new Point(265, y + 22), Size = new Size(210, 28), Font = fieldFont, BorderStyle = BorderStyle.FixedSingle };
            y += 55;

            // Category
            var lblCategory = new Label { Text = "Category *", Font = labelFont, ForeColor = labelColor, Location = new Point(25, y), AutoSize = true };
            cbCategory = new ComboBox { Location = new Point(25, y + 22), Size = new Size(450, 28), Font = fieldFont, DropDownStyle = ComboBoxStyle.DropDownList };
            y += 55;

            // Description
            var lblDesc = new Label { Text = "Description", Font = labelFont, ForeColor = labelColor, Location = new Point(25, y), AutoSize = true };
            txtDescription = new TextBox { Location = new Point(25, y + 22), Size = new Size(450, 28), Font = fieldFont, BorderStyle = BorderStyle.FixedSingle };
            y += 55;

            // Image
            var lblImage = new Label { Text = "Image", Font = labelFont, ForeColor = labelColor, Location = new Point(25, y), AutoSize = true };
            txtImage = new TextBox { Location = new Point(25, y + 22), Size = new Size(340, 28), Font = fieldFont, BorderStyle = BorderStyle.FixedSingle, ReadOnly = true };
            var btnBrowse = new Button
            {
                Text = "Browse...",
                Location = new Point(375, y + 20),
                Size = new Size(100, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand,
            };
            btnBrowse.FlatAppearance.BorderSize = 0;
            btnBrowse.Click += (s, e) =>
            {
                using var dlg = new OpenFileDialog
                {
                    Title = "Select Product Image",
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                };
                if (dlg.ShowDialog() == DialogResult.OK)
                    txtImage.Text = dlg.FileName;
            };
            y += 55;

            // Status toggle (edit mode only)
            chkActive = new CheckBox
            {
                Text = "Active",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(39, 174, 96),
                Location = new Point(25, y),
                AutoSize = true,
                Checked = true,
                Visible = _isEditMode,
            };
            chkActive.CheckedChanged += (s, e) =>
            {
                chkActive.Text = chkActive.Checked ? "Active" : "Inactive";
                chkActive.ForeColor = chkActive.Checked
                    ? Color.FromArgb(39, 174, 96)
                    : Color.FromArgb(231, 76, 60);
            };
            if (_isEditMode) y += 40;

            // Buttons
            btnSave = new Button
            {
                Text = _isEditMode ? "Save Changes" : "Add Product",
                Location = new Point(25, y + 5),
                Size = new Size(220, 42),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(39, 174, 96),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Cursor = Cursors.Hand,
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(255, y + 5),
                Size = new Size(220, 42),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(45, 62, 80),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Cursor = Cursors.Hand,
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.Controls.AddRange([
                pnlHeader,
                lblName, txtName,
                lblPrice, txtPrice, lblStock, txtStock,
                lblCategory, cbCategory,
                lblDesc, txtDescription,
                lblImage, txtImage, btnBrowse,
                chkActive,
                btnSave, btnCancel
            ]);

            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
        }

        private void LoadCategories()
        {
            cbCategory.Items.Clear();
            cbCategory.Items.Add("-- Select Category --");
            var categories = _categoryRepository.GetAllEntitys().Where(c => !c.IsDeleted).ToList();
            foreach (var cat in categories)
                cbCategory.Items.Add(cat.Name);
            cbCategory.SelectedIndex = 0;
        }

        private void FillFields(ProductDto product)
        {
            txtName.Text = product.Name;
            txtPrice.Text = product.Price.ToString();
            txtStock.Text = product.UnitsInStock.ToString();
            txtDescription.Text = product.Description;
            txtImage.Text = product.Image;
            chkActive.Checked = product.IsActive;

            for (int i = 0; i < cbCategory.Items.Count; i++)
            {
                if (cbCategory.Items[i].ToString() == product.CategoryName)
                {
                    cbCategory.SelectedIndex = i;
                    break;
                }
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a product name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (!decimal.TryParse(txtPrice.Text, out var price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }
            if (!int.TryParse(txtStock.Text, out var stock) || stock < 0)
            {
                MessageBox.Show("Please enter a valid stock quantity.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return;
            }
            if (cbCategory.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbCategory.Focus();
                return;
            }

            var categories = _categoryRepository.GetAllEntitys().Where(c => !c.IsDeleted).ToList();
            var selectedCategory = categories.ElementAtOrDefault(cbCategory.SelectedIndex - 1);
            if (selectedCategory == null) return;

            try
            {
                if (_isEditMode)
                {
                    var dto = new UpdateProductDto
                    {
                        Name = txtName.Text.Trim(),
                        Price = price,
                        Description = txtDescription.Text.Trim(),
                        UnitsInStock = stock,
                        Image = txtImage.Text,
                        CategoryId = selectedCategory.ID,
                    };
                    _productService.Update(_editingProductId, dto);

                    if (chkActive.Checked)
                        _productService.Activate(_editingProductId);
                    else
                        _productService.Deactivate(_editingProductId);

                    MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var dto = new CreateProductDto
                    {
                        Name = txtName.Text.Trim(),
                        Price = price,
                        Description = txtDescription.Text.Trim(),
                        UnitsInStock = stock,
                        Image = txtImage.Text,
                        CategoryId = selectedCategory.ID,
                    };
                    _productService.Create(dto);
                    MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
