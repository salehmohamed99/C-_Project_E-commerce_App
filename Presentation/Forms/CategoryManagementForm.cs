using System.Windows.Forms;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Application.DTOs.CategoryDTOs;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Presentation.Forms
{
    public partial class CategoryManagementForm : Form
    {
        private ApplicationDbContext _context;
        private ICategoryAdminService _categoryService;
        private int _editingCategoryId = 0;

        public CategoryManagementForm(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
            ICategoryRepository categoryRepository = new Infrastructure.Repositories.CategoryRepository(_context);
            _categoryService = new CategoryAdminService(categoryRepository);
            SetupColumns();
            LoadCategories();
        }

        private void SetupColumns()
        {
            dgvCategories.AutoGenerateColumns = false;
            dgvCategories.Columns.Clear();

            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID",   HeaderText = "ID",   ReadOnly = true, Width = 50 });
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Name", ReadOnly = true, Width = 350 });

            var btnEdit = new DataGridViewButtonColumn { Name = "Edit", HeaderText = "", Text = "Edit", UseColumnTextForButtonValue = true, Width = 80 };
            dgvCategories.Columns.Add(btnEdit);

            var btnDelete = new DataGridViewButtonColumn { Name = "Delete", HeaderText = "", Text = "Delete", UseColumnTextForButtonValue = true, Width = 80 };
            dgvCategories.Columns.Add(btnDelete);
        }

        private void LoadCategories()
        {
            dgvCategories.Rows.Clear();
            var categories = _categoryService.GetAll().ToList();
            foreach (var category in categories)
                dgvCategories.Rows.Add(category.Id, category.Name);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a category name!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_editingCategoryId > 0)
                {
                    var dto = new UpdateCategoryDto { Name = txtName.Text };
                    _categoryService.Update(_editingCategoryId, dto);
                    MessageBox.Show("Category updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _editingCategoryId = 0;
                    btnAdd.Text = "Add Category";
                }
                else
                {
                    var dto = new CreateCategoryDto { Name = txtName.Text };
                    _categoryService.Create(dto);
                    MessageBox.Show("Category added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                txtName.Clear();
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int categoryId   = Convert.ToInt32(dgvCategories.Rows[e.RowIndex].Cells["ID"].Value);
            string categoryName = dgvCategories.Rows[e.RowIndex].Cells["Name"].Value?.ToString() ?? "";

            if (e.ColumnIndex == dgvCategories.Columns["Edit"].Index)
            {
                _editingCategoryId = categoryId;
                txtName.Text       = categoryName;
                btnAdd.Text        = "Update Category";
                txtName.Focus();
            }
            else if (e.ColumnIndex == dgvCategories.Columns["Delete"].Index)
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to delete '{categoryName}'?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                try
                {
                    _categoryService.Delete(categoryId);
                    MessageBox.Show("Category deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories();
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

