using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Application.DTOs.CategoryDTOs;
using Application.Interfaces.Services;
using Presentation.Utilities;

namespace Presentation.Forms
{
    public partial class CategoryManagementForm : Form
    {
        private readonly ICategoryAdminService _categoryService;
        private int _editingCategoryId = 0;

        public CategoryManagementForm(ICategoryAdminService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            
            InitializeComponent();
            
            // Apply Modern Design
            ModernDesignSystem.Forms.ApplyModernFormStyle(this, "Category Management", 900, 700);
            ApplyModernStyling();
            SetupColumns();
            LoadCategories();
        }

        private void ApplyModernStyling()
        {
            // Style buttons
            ModernDesignSystem.Buttons.ApplyPrimaryStyle(btnAdd, "+ Add Category", 160, 44);
            
            // Make sure text input looks good
            if (this.Controls.Find("txtName", true).FirstOrDefault() is TextBox txt)
            {
                ModernDesignSystem.Inputs.ApplyModernStyle(txt);
            }
        }

        private void SetupColumns()
        {
            ModernDesignSystem.Grids.ApplyModernStyle(dgvCategories);
            
            dgvCategories.AutoGenerateColumns = false;
            dgvCategories.Columns.Clear();

            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID",
                HeaderText = "#",
                ReadOnly = true,
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = ModernDesignSystem.Typography.GridHeader,
                    ForeColor = ModernDesignSystem.Colors.Primary,
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Category Name",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                    ForeColor = ModernDesignSystem.Colors.TextPrimary
                }
            });

            dgvCategories.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "",
                Text = "✏️ Edit",
                UseColumnTextForButtonValue = true,
                Width = 110,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = ModernDesignSystem.Colors.InfoLight,
                    ForeColor = ModernDesignSystem.Colors.Primary,
                    Font = ModernDesignSystem.Typography.Button,
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    SelectionBackColor = Color.FromArgb(224, 231, 255),
                    SelectionForeColor = ModernDesignSystem.Colors.PrimaryDark
                }
            });

            dgvCategories.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "",
                Text = "🗑️ Delete",
                UseColumnTextForButtonValue = true,
                Width = 120,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = ModernDesignSystem.Colors.DangerLight,
                    ForeColor = ModernDesignSystem.Colors.Danger,
                    Font = ModernDesignSystem.Typography.Button,
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    SelectionBackColor = Color.FromArgb(254, 202, 202),
                    SelectionForeColor = Color.FromArgb(220, 38, 38)
                }
            });
        }

        private void LoadCategories()
        {
            dgvCategories.Rows.Clear();
            var list = _categoryService.GetAll().ToList();

            foreach (var cat in list)
                dgvCategories.Rows.Add(cat.Id, cat.Name);

            UpdateRecordCount(list.Count);
        }

        private void UpdateRecordCount(int count)
        {
            // Find and update record count label if it exists
            var lblCount = this.Controls.Find("lblRecordCount", true).FirstOrDefault() as Label;
            if (lblCount != null)
            {
                lblCount.Text = count == 1 ? "1 category" : $"{count} categories";
                lblCount.ForeColor = ModernDesignSystem.Colors.TextSecondary;
                lblCount.Font = ModernDesignSystem.Typography.BodySmall;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) => CommitInput();

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                CommitInput();
            }
            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                ResetEditState();
            }
        }

        private void CommitInput()
        {
            var txtName = this.Controls.Find("txtName", true).FirstOrDefault() as TextBox;
            if (txtName == null) return;

            string name = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                ModernDesignSystem.Messages.ShowWarning("Please enter a category name.", "Validation Error");
                txtName.Focus();
                return;
            }

            try
            {
                if (_editingCategoryId > 0)
                {
                    _categoryService.Update(_editingCategoryId, new UpdateCategoryDto { Name = name });
                    ModernDesignSystem.Messages.ShowSuccess("Category updated successfully!");
                    ResetEditState();
                }
                else
                {
                    _categoryService.Create(new CreateCategoryDto { Name = name });
                    ModernDesignSystem.Messages.ShowSuccess("Category added successfully!");
                    txtName.Clear();
                }

                LoadCategories();
                txtName.Focus();
            }
            catch (Exception ex)
            {
                ModernDesignSystem.Messages.ShowError($"Error: {ex.Message}");
            }
        }

        private void EnterEditMode(int id, string name)
        {
            var txtName = this.Controls.Find("txtName", true).FirstOrDefault() as TextBox;
            var btnCancelEdit = this.Controls.Find("btnCancelEdit", true).FirstOrDefault() as Button;
            var lblInputCardTitle = this.Controls.Find("lblInputCardTitle", true).FirstOrDefault() as Label;

            if (txtName == null) return;

            _editingCategoryId = id;
            txtName.Text = name;
            
            // Change button to update mode
            ModernDesignSystem.Buttons.ApplySuccessStyle(btnAdd, "✓ Update Category", 170, 44);

            if (btnCancelEdit != null)
            {
                btnCancelEdit.Visible = true;
                ModernDesignSystem.Buttons.ApplySecondaryStyle(btnCancelEdit, "Cancel", 90, 44);
            }

            if (lblInputCardTitle != null)
            {
                lblInputCardTitle.Text = "EDITING CATEGORY";
                lblInputCardTitle.ForeColor = ModernDesignSystem.Colors.Success;
            }

            txtName.BackColor = ModernDesignSystem.Colors.SuccessLight;
            txtName.Focus();
            txtName.SelectAll();
        }

        private void ResetEditState()
        {
            var txtName = this.Controls.Find("txtName", true).FirstOrDefault() as TextBox;
            var btnCancelEdit = this.Controls.Find("btnCancelEdit", true).FirstOrDefault() as Button;
            var lblInputCardTitle = this.Controls.Find("lblInputCardTitle", true).FirstOrDefault() as Label;

            if (txtName == null) return;

            _editingCategoryId = 0;
            txtName.Clear();
            txtName.BackColor = ModernDesignSystem.Colors.CardBackground;
            
            ModernDesignSystem.Buttons.ApplyPrimaryStyle(btnAdd, "+ Add Category", 160, 44);

            if (btnCancelEdit != null)
                btnCancelEdit.Visible = false;

            if (lblInputCardTitle != null)
            {
                lblInputCardTitle.Text = "ADD NEW CATEGORY";
                lblInputCardTitle.ForeColor = ModernDesignSystem.Colors.TextSecondary;
            }

            txtName.Focus();
        }

        private void btnCancelEdit_Click(object sender, EventArgs e) => ResetEditState();

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvCategories.Rows[e.RowIndex].Cells["ID"].Value);
            string name = dgvCategories.Rows[e.RowIndex].Cells["Name"].Value?.ToString() ?? "";

            if (e.ColumnIndex == dgvCategories.Columns["Edit"].Index)
            {
                EnterEditMode(id, name);
            }
            else if (e.ColumnIndex == dgvCategories.Columns["Delete"].Index)
            {
                ConfirmDelete(id, name);
            }
        }

        // Keep this method to satisfy Designer event handler
        private void dgvCategories_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // No custom painting needed with modern design system
            // Designer still references this, so we keep it empty
        }

        private void ConfirmDelete(int id, string name)
        {
            var result = ModernDesignSystem.Messages.ShowConfirmation(
                $"Are you sure you want to delete '{name}'?\n\nThis action cannot be undone.",
                "Confirm Delete");

            if (result != DialogResult.Yes) return;

            try
            {
                _categoryService.Delete(id);
                ModernDesignSystem.Messages.ShowSuccess($"Category '{name}' deleted successfully!");
                
                if (_editingCategoryId == id)
                    ResetEditState();
                
                LoadCategories();
            }
            catch (Exception ex)
            {
                ModernDesignSystem.Messages.ShowError($"Error: {ex.Message}");
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            // Apply rounded corners to cards
            var pnlInputCard = this.Controls.Find("pnlInputCard", true).FirstOrDefault() as Panel;
            var pnlGridCard = this.Controls.Find("pnlGridCard", true).FirstOrDefault() as Panel;

            if (pnlInputCard != null)
                ModernDesignSystem.Panels.ApplyCardStyle(pnlInputCard, 12);
            if (pnlGridCard != null)
                ModernDesignSystem.Panels.ApplyCardStyle(pnlGridCard, 12);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}