using System;
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
        private DataGridView dgvCategories;

        public CategoryManagementForm(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
            _categoryRepository = new GenericRepository<Category, int>(_context);
            LoadCategories();
        }

        private void InitializeComponent()
        {
            this.Text = "Category Management";
            this.Size = new Size(700, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Title Label
            Label lblTitle = new Label();
            lblTitle.Text = "Manage Categories";
            lblTitle.Font = new Font("Arial", 14, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Size = new Size(300, 25);
            this.Controls.Add(lblTitle);

            // Name TextBox
            Label lblName = new Label();
            lblName.Text = "Category Name:";
            lblName.Location = new Point(20, 60);
            lblName.Size = new Size(100, 20);
            this.Controls.Add(lblName);

            TextBox txtName = new TextBox();
            txtName.Name = "txtName";
            txtName.Location = new Point(130, 60);
            txtName.Size = new Size(200, 25);
            this.Controls.Add(txtName);

            // Add Button
            Button btnAdd = new Button();
            btnAdd.Text = "Add Category";
            btnAdd.Location = new Point(350, 60);
            btnAdd.Size = new Size(120, 30);
            btnAdd.Click += (s, e) => AddCategory(txtName.Text);
            this.Controls.Add(btnAdd);

            // DataGridView
            dgvCategories = new DataGridView();
            dgvCategories.Name = "dgvCategories";
            dgvCategories.Location = new Point(20, 110);
            dgvCategories.Size = new Size(650, 300);
            dgvCategories.AutoGenerateColumns = false;
            dgvCategories.Columns.Add("ID", "ID");
            dgvCategories.Columns.Add("Name", "Name");
            dgvCategories.Columns.Add("Edit", "Edit");
            dgvCategories.Columns.Add("Delete", "Delete");
            this.Controls.Add(dgvCategories);

            // Close Button
            Button btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.Location = new Point(595, 420);
            btnClose.Size = new Size(75, 30);
            btnClose.Click += (s, e) => this.Close();
            this.Controls.Add(btnClose);
        }

        private void LoadCategories()
        {
            dgvCategories.Rows.Clear();
            var categories = _categoryRepository.GetAllEntitys().Where(c => !c.IsDeleted).ToList();

            foreach (var category in categories)
            {
                dgvCategories.Rows.Add(category.ID, category.Name, "Edit", "Delete");
            }
        }

        private void AddCategory(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a category name!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var category = new Category { Name = name };
            _categoryRepository.Add(category);
            _categoryRepository.SaveChanges();

            MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadCategories();
        }
    }
}
