using System.Windows.Forms;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Presentation.Forms
{
    public partial class CategoryManagementForm : Form
    {
        private ApplicationDbContext _context;
        private IGenericRepository<Category, int> _categoryRepository;
        private int _editingCategoryId = 0;

        public CategoryManagementForm(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
            _categoryRepository = new GenericRepository<Category, int>(_context);
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
            var categories = _categoryRepository.GetAllEntitys().Where(c => !c.IsDeleted).ToList();
            foreach (var category in categories)
                dgvCategories.Rows.Add(category.ID, category.Name);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a category name!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_editingCategoryId > 0)
            {
                // Update mode
                var category = _categoryRepository.GetAllEntitys().FirstOrDefault(c => c.ID == _editingCategoryId);
                if (category != null)
                {
                    category.Name = txtName.Text;
                    _categoryRepository.Update(category);
                    _categoryRepository.SaveChanges();
                    MessageBox.Show("Category updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                _editingCategoryId = 0;
                btnAdd.Text = "Add Category";
            }
            else
            {
                // Add mode
                _categoryRepository.Add(new Category { Name = txtName.Text });
                _categoryRepository.SaveChanges();
                MessageBox.Show("Category added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            txtName.Clear();
            LoadCategories();
        }

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int categoryId   = Convert.ToInt32(dgvCategories.Rows[e.RowIndex].Cells["ID"].Value);
            string categoryName = dgvCategories.Rows[e.RowIndex].Cells["Name"].Value?.ToString() ?? "";

            if (e.ColumnIndex == dgvCategories.Columns["Edit"].Index)
            {
                // Edit mode - populate txtName
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

                var category = _categoryRepository.GetAllEntitys().FirstOrDefault(c => c.ID == categoryId);
                if (category == null) return;

                _categoryRepository.Delete(category);
                _categoryRepository.SaveChanges();
                MessageBox.Show("Category deleted successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}

