////using System.Windows.Forms;
////using Application.Interfaces.Repositories;
////using Application.Interfaces.Services;
////using Application.Services;
////using Application.DTOs.CategoryDTOs;
////using Domain.Entities;
////using Infrastructure.Data;
////using Infrastructure.Repositories;

////namespace Presentation.Forms
////{
////    public partial class CategoryManagementForm : Form
////    {
////        private ApplicationDbContext _context;
////        private ICategoryAdminService _categoryService;
////        private int _editingCategoryId = 0;

////        public CategoryManagementForm(ApplicationDbContext context)
////        {
////            InitializeComponent();
////            _context = context;
////            ICategoryRepository categoryRepository = new Infrastructure.Repositories.CategoryRepository(_context);
////            _categoryService = new CategoryAdminService(categoryRepository);
////            SetupColumns();
////            LoadCategories();
////        }

////        private void SetupColumns()
////        {
////            dgvCategories.AutoGenerateColumns = false;
////            dgvCategories.Columns.Clear();

////            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID",   HeaderText = "ID",   ReadOnly = true, Width = 50 });
////            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Name", ReadOnly = true, Width = 350 });

////            var btnEdit = new DataGridViewButtonColumn { Name = "Edit", HeaderText = "", Text = "Edit", UseColumnTextForButtonValue = true, Width = 80 };
////            dgvCategories.Columns.Add(btnEdit);

////            var btnDelete = new DataGridViewButtonColumn { Name = "Delete", HeaderText = "", Text = "Delete", UseColumnTextForButtonValue = true, Width = 80 };
////            dgvCategories.Columns.Add(btnDelete);
////        }

////        private void LoadCategories()
////        {
////            dgvCategories.Rows.Clear();
////            var categories = _categoryService.GetAll().ToList();
////            foreach (var category in categories)
////                dgvCategories.Rows.Add(category.Id, category.Name);
////        }

////        private void btnAdd_Click(object sender, EventArgs e)
////        {
////            if (string.IsNullOrWhiteSpace(txtName.Text))
////            {
////                MessageBox.Show("Please enter a category name!", "Validation Error",
////                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
////                return;
////            }

////            try
////            {
////                if (_editingCategoryId > 0)
////                {
////                    var dto = new UpdateCategoryDto { Name = txtName.Text };
////                    _categoryService.Update(_editingCategoryId, dto);
////                    MessageBox.Show("Category updated successfully!", "Success",
////                        MessageBoxButtons.OK, MessageBoxIcon.Information);
////                    _editingCategoryId = 0;
////                    btnAdd.Text = "Add Category";
////                }
////                else
////                {
////                    var dto = new CreateCategoryDto { Name = txtName.Text };
////                    _categoryService.Create(dto);
////                    MessageBox.Show("Category added successfully!", "Success",
////                        MessageBoxButtons.OK, MessageBoxIcon.Information);
////                }

////                txtName.Clear();
////                LoadCategories();
////            }
////            catch (Exception ex)
////            {
////                MessageBox.Show($"Error: {ex.Message}", "Error",
////                    MessageBoxButtons.OK, MessageBoxIcon.Error);
////            }
////        }

////        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
////        {
////            if (e.RowIndex < 0) return;

////            int categoryId   = Convert.ToInt32(dgvCategories.Rows[e.RowIndex].Cells["ID"].Value);
////            string categoryName = dgvCategories.Rows[e.RowIndex].Cells["Name"].Value?.ToString() ?? "";

////            if (e.ColumnIndex == dgvCategories.Columns["Edit"].Index)
////            {
////                _editingCategoryId = categoryId;
////                txtName.Text       = categoryName;
////                btnAdd.Text        = "Update Category";
////                txtName.Focus();
////            }
////            else if (e.ColumnIndex == dgvCategories.Columns["Delete"].Index)
////            {
////                var result = MessageBox.Show(
////                    $"Are you sure you want to delete '{categoryName}'?",
////                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

////                if (result != DialogResult.Yes) return;

////                try
////                {
////                    _categoryService.Delete(categoryId);
////                    MessageBox.Show("Category deleted successfully!", "Success",
////                        MessageBoxButtons.OK, MessageBoxIcon.Information);
////                    LoadCategories();
////                }
////                catch (Exception ex)
////                {
////                    MessageBox.Show($"Error: {ex.Message}", "Error",
////                        MessageBoxButtons.OK, MessageBoxIcon.Error);
////                }
////            }
////        }

////        private void btnClose_Click(object sender, EventArgs e) => this.Close();
////    }
////}

//using System;
//using System.Drawing;
//using System.Drawing.Drawing2D;
//using System.Linq;
//using System.Windows.Forms;
//using Application.DTOs.CategoryDTOs;
//using Application.Interfaces.Repositories;
//using Application.Interfaces.Services;
//using Application.Services;
//using Infrastructure.Data;
//using Infrastructure.Repositories;

//namespace Presentation.Forms
//{
//    /// <summary>
//    /// Professional Category Management form — dark top bar, white cards,
//    /// refined DataGridView with custom cell painting, and inline edit flow.
//    /// </summary>
//    public partial class CategoryManagementForm : Form
//    {
//        // ── Dependencies ───────────────────────────────────────────────────────
//        private readonly ApplicationDbContext _context;
//        private readonly ICategoryAdminService _categoryService;

//        // ── Edit state ─────────────────────────────────────────────────────────
//        private int _editingCategoryId = 0;

//        // ── Palette shortcuts (keep in sync with designer) ─────────────────────
//        private static readonly Color ClrAccent = Color.FromArgb(99, 102, 241);
//        private static readonly Color ClrAccentDark = Color.FromArgb(79, 82, 200);
//        private static readonly Color ClrDanger = Color.FromArgb(239, 68, 68);
//        private static readonly Color ClrDangerHover = Color.FromArgb(220, 38, 38);
//        private static readonly Color ClrSuccess = Color.FromArgb(16, 185, 129);
//        private static readonly Color ClrBorder = Color.FromArgb(229, 231, 235);
//        private static readonly Color ClrTextMuted = Color.FromArgb(107, 114, 128);
//        private static readonly Color ClrTextPrimary = Color.FromArgb(17, 24, 39);

//        // ──────────────────────────────────────────────────────────────────────
//        //  Constructor
//        // ──────────────────────────────────────────────────────────────────────
//        public CategoryManagementForm(ApplicationDbContext context)
//        {
//            _context = context ?? throw new ArgumentNullException(nameof(context));

//            ICategoryRepository repo = new CategoryRepository(_context);
//            _categoryService = new CategoryAdminService(repo);

//            InitializeComponent();
//            ApplyRoundedCards();
//            SetupColumns();
//            LoadCategories();
//        }

//        // ──────────────────────────────────────────────────────────────────────
//        //  Grid Columns
//        // ──────────────────────────────────────────────────────────────────────
//        private void SetupColumns()
//        {
//            dgvCategories.AutoGenerateColumns = false;
//            dgvCategories.Columns.Clear();

//            // ID
//            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
//            {
//                Name = "ID",
//                HeaderText = "#",
//                ReadOnly = true,
//                Width = 56,
//                DefaultCellStyle = new DataGridViewCellStyle
//                {
//                    Font = new Font("Segoe UI", 9F),
//                    ForeColor = ClrTextMuted,
//                    Alignment = DataGridViewContentAlignment.MiddleCenter,
//                    SelectionBackColor = Color.FromArgb(238, 242, 255),
//                    SelectionForeColor = ClrTextPrimary
//                }
//            });

//            // Name
//            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
//            {
//                Name = "Name",
//                HeaderText = "Category Name",
//                ReadOnly = true,
//                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
//                DefaultCellStyle = new DataGridViewCellStyle
//                {
//                    Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
//                    ForeColor = ClrTextPrimary,
//                    SelectionBackColor = Color.FromArgb(238, 242, 255),
//                    SelectionForeColor = ClrTextPrimary
//                }
//            });

//            // Edit button
//            dgvCategories.Columns.Add(new DataGridViewButtonColumn
//            {
//                Name = "Edit",
//                HeaderText = "",
//                Text = "Edit",
//                UseColumnTextForButtonValue = true,
//                Width = 84,
//                FlatStyle = FlatStyle.Flat,
//                DefaultCellStyle = new DataGridViewCellStyle
//                {
//                    BackColor = Color.FromArgb(238, 242, 255),
//                    ForeColor = ClrAccent,
//                    Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
//                    Alignment = DataGridViewContentAlignment.MiddleCenter,
//                    SelectionBackColor = Color.FromArgb(225, 230, 255),
//                    SelectionForeColor = ClrAccentDark,
//                    Padding = new Padding(0)
//                }
//            });

//            // Delete button
//            dgvCategories.Columns.Add(new DataGridViewButtonColumn
//            {
//                Name = "Delete",
//                HeaderText = "",
//                Text = "Delete",
//                UseColumnTextForButtonValue = true,
//                Width = 84,
//                FlatStyle = FlatStyle.Flat,
//                DefaultCellStyle = new DataGridViewCellStyle
//                {
//                    BackColor = Color.FromArgb(254, 242, 242),
//                    ForeColor = ClrDanger,
//                    Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
//                    Alignment = DataGridViewContentAlignment.MiddleCenter,
//                    SelectionBackColor = Color.FromArgb(254, 226, 226),
//                    SelectionForeColor = ClrDangerHover,
//                    Padding = new Padding(0)
//                }
//            });
//        }

//        // ──────────────────────────────────────────────────────────────────────
//        //  Data
//        // ──────────────────────────────────────────────────────────────────────
//        private void LoadCategories()
//        {
//            dgvCategories.Rows.Clear();
//            var list = _categoryService.GetAll().ToList();

//            foreach (var cat in list)
//                dgvCategories.Rows.Add(cat.Id, cat.Name);

//            UpdateRecordCount(list.Count);
//        }

//        private void UpdateRecordCount(int count)
//        {
//            lblRecordCount.Text = count == 1 ? "1 category" : $"{count} categories";
//        }

//        // ──────────────────────────────────────────────────────────────────────
//        //  Add / Update
//        // ──────────────────────────────────────────────────────────────────────
//        private void btnAdd_Click(object sender, EventArgs e) => CommitInput();

//        private void txtName_KeyDown(object sender, KeyEventArgs e)
//        {
//            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; CommitInput(); }
//            if (e.KeyCode == Keys.Escape) { e.SuppressKeyPress = true; ResetEditState(); }
//        }

//        private void CommitInput()
//        {
//            string name = txtName.Text.Trim();
//            if (string.IsNullOrWhiteSpace(name))
//            {
//                ShakeControl(txtName);
//                ShowInlineError("Please enter a category name.");
//                return;
//            }

//            try
//            {
//                if (_editingCategoryId > 0)
//                {
//                    _categoryService.Update(_editingCategoryId, new UpdateCategoryDto { Name = name });
//                    ShowSuccessToast("Category updated successfully.");
//                    ResetEditState();
//                }
//                else
//                {
//                    _categoryService.Create(new CreateCategoryDto { Name = name });
//                    ShowSuccessToast("Category added successfully.");
//                    txtName.Clear();
//                }

//                LoadCategories();
//                txtName.Focus();
//            }
//            catch (Exception ex)
//            {
//                ShowError(ex.Message);
//            }
//        }

//        // ──────────────────────────────────────────────────────────────────────
//        //  Edit State
//        // ──────────────────────────────────────────────────────────────────────
//        private void EnterEditMode(int id, string name)
//        {
//            _editingCategoryId = id;
//            txtName.Text = name;
//            btnAdd.Text = "✓ Update Category";
//            btnAdd.BackColor = ClrSuccess;
//            btnAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(5, 150, 105);
//            btnCancelEdit.Visible = true;
//            lblInputCardTitle.Text = "EDITING CATEGORY";
//            lblInputCardTitle.ForeColor = ClrSuccess;
//            txtName.BackColor = Color.FromArgb(240, 253, 250);
//            txtName.Focus();
//            txtName.SelectAll();
//        }

//        private void ResetEditState()
//        {
//            _editingCategoryId = 0;
//            txtName.Clear();
//            txtName.BackColor = Color.FromArgb(249, 250, 251);
//            btnAdd.Text = "+ Add Category";
//            btnAdd.BackColor = ClrAccent;
//            btnAdd.FlatAppearance.MouseOverBackColor = ClrAccentDark;
//            btnCancelEdit.Visible = false;
//            lblInputCardTitle.Text = "ADD NEW CATEGORY";
//            lblInputCardTitle.ForeColor = ClrTextMuted;
//            txtName.Focus();
//        }

//        private void btnCancelEdit_Click(object sender, EventArgs e) => ResetEditState();

//        // ──────────────────────────────────────────────────────────────────────
//        //  Grid Events
//        // ──────────────────────────────────────────────────────────────────────
//        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex < 0) return;

//            int id = Convert.ToInt32(dgvCategories.Rows[e.RowIndex].Cells["ID"].Value);
//            string name = dgvCategories.Rows[e.RowIndex].Cells["Name"].Value?.ToString() ?? "";

//            if (e.ColumnIndex == dgvCategories.Columns["Edit"].Index)
//            {
//                EnterEditMode(id, name);
//            }
//            else if (e.ColumnIndex == dgvCategories.Columns["Delete"].Index)
//            {
//                ConfirmDelete(id, name);
//            }
//        }

//        private void ConfirmDelete(int id, string name)
//        {
//            using var dlg = new DeleteConfirmDialog(name);
//            if (dlg.ShowDialog(this) != DialogResult.Yes) return;

//            try
//            {
//                _categoryService.Delete(id);
//                ShowSuccessToast($"'{name}' was deleted.");
//                if (_editingCategoryId == id) ResetEditState();
//                LoadCategories();
//            }
//            catch (Exception ex)
//            {
//                ShowError(ex.Message);
//            }
//        }

//        // ──────────────────────────────────────────────────────────────────────
//        //  Custom Cell Painting — rounded pill buttons in grid
//        // ──────────────────────────────────────────────────────────────────────
//        private void dgvCategories_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
//        {
//            if (e.RowIndex < 0) return;

//            var colEdit = dgvCategories.Columns["Edit"].Index;
//            var colDelete = dgvCategories.Columns["Delete"].Index;

//            if (e.ColumnIndex != colEdit && e.ColumnIndex != colDelete) return;

//            e.PaintBackground(e.ClipBounds, true);

//            bool isEdit = (e.ColumnIndex == colEdit);
//            var btnFore = isEdit ? ClrAccent : ClrDanger;
//            var btnBack = isEdit ? Color.FromArgb(238, 242, 255) : Color.FromArgb(254, 242, 242);
//            string btnText = isEdit ? "Edit" : "Delete";

//            var g = e.Graphics;
//            g.SmoothingMode = SmoothingMode.AntiAlias;

//            // Pill rectangle
//            int pw = 62, ph = 28;
//            int px = e.CellBounds.X + (e.CellBounds.Width - pw) / 2;
//            int py = e.CellBounds.Y + (e.CellBounds.Height - ph) / 2;
//            var rect = new Rectangle(px, py, pw, ph);

//            using var path = RoundedRect(rect, 14);
//            using var fill = new SolidBrush(btnBack);
//            g.FillPath(fill, path);

//            using var pen = new Pen(isEdit ? Color.FromArgb(199, 210, 254) : Color.FromArgb(254, 202, 202), 1f);
//            g.DrawPath(pen, path);

//            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
//            using var font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
//            using var textBrush = new SolidBrush(btnFore);
//            g.DrawString(btnText, font, textBrush, new RectangleF(px, py, pw, ph), sf);

//            e.Handled = true;
//        }

//        private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
//        {
//            int d = radius * 2;
//            var path = new GraphicsPath();
//            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
//            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
//            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
//            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
//            path.CloseFigure();
//            return path;
//        }

//        // ──────────────────────────────────────────────────────────────────────
//        //  Feedback Helpers
//        // ──────────────────────────────────────────────────────────────────────
//        private void ShowSuccessToast(string message)
//        {
//            // Non-blocking toast via a temporary label overlay
//            var toast = new Label
//            {
//                Text = "✓  " + message,
//                Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold),
//                ForeColor = Color.White,
//                BackColor = ClrSuccess,
//                AutoSize = false,
//                Size = new Size(340, 38),
//                TextAlign = ContentAlignment.MiddleCenter,
//                Padding = new Padding(0)
//            };
//            toast.Location = new Point((this.ClientSize.Width - toast.Width) / 2, this.ClientSize.Height - 110);
//            this.Controls.Add(toast);
//            toast.BringToFront();

//            //var t = new Timer { Interval = 2000 };
//            //t.Tick += (s, _) => { t.Stop(); this.Controls.Remove(toast); toast.Dispose(); t.Dispose(); };
//            //t.Start();
//        }

//        private void ShowInlineError(string message)
//        {
//            var toast = new Label
//            {
//                Text = "⚠  " + message,
//                Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold),
//                ForeColor = Color.White,
//                BackColor = ClrDanger,
//                AutoSize = false,
//                Size = new Size(340, 38),
//                TextAlign = ContentAlignment.MiddleCenter
//            };
//            toast.Location = new Point((this.ClientSize.Width - toast.Width) / 2, this.ClientSize.Height - 110);
//            this.Controls.Add(toast);
//            toast.BringToFront();

//            //var t = new Timer { Interval = 2400 };
//            //t.Tick += (s, _) => { t.Stop(); this.Controls.Remove(toast); toast.Dispose(); t.Dispose(); };
//            //t.Start();
//        }

//        private void ShowError(string message) =>
//            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

//        /// <summary>Brief horizontal shake animation to indicate a validation error.</summary>
//        private async void ShakeControl(Control ctrl)
//        {
//            var orig = ctrl.Left;
//            int[] offsets = { -6, 6, -5, 5, -3, 3, 0 };
//            foreach (var dx in offsets)
//            {
//                ctrl.Left = orig + dx;
//                await System.Threading.Tasks.Task.Delay(30);
//            }
//            ctrl.Left = orig;
//        }

//        // ──────────────────────────────────────────────────────────────────────
//        //  Rounded Cards
//        // ──────────────────────────────────────────────────────────────────────
//        protected override void OnLoad(EventArgs e)
//        {
//            base.OnLoad(e);
//            ApplyRoundedCards();
//        }

//        private void ApplyRoundedCards()
//        {
//            ApplyRound(pnlInputCard, 10);
//            ApplyRound(pnlGridCard, 10);
//            ApplyRound(btnAdd, 6);
//            ApplyRound(btnCancelEdit, 6);
//            ApplyRound(btnClose, 6);
//        }

//        private static void ApplyRound(Control ctrl, int r)
//        {
//            if (ctrl.Width == 0 || ctrl.Height == 0) return;
//            var path = new GraphicsPath();
//            int d = r * 2;
//            path.AddArc(0, 0, d, d, 180, 90);
//            path.AddArc(ctrl.Width - d, 0, d, d, 270, 90);
//            path.AddArc(ctrl.Width - d, ctrl.Height - d, d, d, 0, 90);
//            path.AddArc(0, ctrl.Height - d, d, d, 90, 90);
//            path.CloseFigure();
//            ctrl.Region = new Region(path);
//        }

//        // ──────────────────────────────────────────────────────────────────────
//        //  Close
//        // ──────────────────────────────────────────────────────────────────────
//        private void btnClose_Click(object sender, EventArgs e) => this.Close();
//    }

//    // ──────────────────────────────────────────────────────────────────────────
//    //  Lightweight inline delete-confirm dialog (replaces stock MessageBox)
//    // ──────────────────────────────────────────────────────────────────────────
//    internal sealed class DeleteConfirmDialog : Form
//    {
//        private readonly Button _btnYes;
//        private readonly Button _btnNo;

//        internal DeleteConfirmDialog(string categoryName)
//        {
//            this.Text = "Confirm Delete";
//            this.ClientSize = new Size(400, 180);
//            this.FormBorderStyle = FormBorderStyle.FixedDialog;
//            this.MaximizeBox = false;
//            this.MinimizeBox = false;
//            this.StartPosition = FormStartPosition.CenterParent;
//            this.BackColor = Color.FromArgb(250, 251, 254);

//            var icon = new Label
//            {
//                Text = "⚠",
//                Font = new Font("Segoe UI Symbol", 28F),
//                ForeColor = Color.FromArgb(245, 158, 11),
//                Location = new Point(24, 28),
//                Size = new Size(48, 48),
//                BackColor = Color.Transparent
//            };

//            var msg = new Label
//            {
//                Text = $"Delete \"{categoryName}\"?",
//                Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold),
//                ForeColor = Color.FromArgb(17, 24, 39),
//                Location = new Point(82, 30),
//                Size = new Size(300, 22),
//                BackColor = Color.Transparent
//            };

//            var sub = new Label
//            {
//                Text = "This action cannot be undone.",
//                Font = new Font("Segoe UI", 9F),
//                ForeColor = Color.FromArgb(107, 114, 128),
//                Location = new Point(84, 56),
//                Size = new Size(300, 18),
//                BackColor = Color.Transparent
//            };

//            _btnNo = new Button
//            {
//                Text = "Cancel",
//                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
//                ForeColor = Color.FromArgb(17, 24, 39),
//                BackColor = Color.White,
//                FlatStyle = FlatStyle.Flat,
//                Location = new Point(186, 120),
//                Size = new Size(92, 38),
//                Cursor = Cursors.Hand,
//                DialogResult = DialogResult.No
//            };
//            _btnNo.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
//            _btnNo.FlatAppearance.BorderSize = 1;

//            _btnYes = new Button
//            {
//                Text = "Delete",
//                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
//                ForeColor = Color.White,
//                BackColor = Color.FromArgb(239, 68, 68),
//                FlatStyle = FlatStyle.Flat,
//                Location = new Point(288, 120),
//                Size = new Size(92, 38),
//                Cursor = Cursors.Hand,
//                DialogResult = DialogResult.Yes
//            };
//            _btnYes.FlatAppearance.BorderSize = 0;
//            _btnYes.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 38, 38);

//            this.Controls.AddRange(new Control[] { icon, msg, sub, _btnNo, _btnYes });
//            this.AcceptButton = _btnYes;
//            this.CancelButton = _btnNo;
//        }
//    }
//}

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Application.DTOs.CategoryDTOs;
using Application.Services;

namespace Presentation.Forms
{
    /// <summary>
    /// Professional Category Management form — dark top bar, white cards,
    /// refined DataGridView with custom cell painting, and inline edit flow.
    /// </summary>
    public partial class CategoryManagementForm : Form
    {
        // ── Dependencies ───────────────────────────────────────────────────────
        private readonly CategoryAdminService _categoryAdminService;

        // ── Edit state ─────────────────────────────────────────────────────────
        private int _editingCategoryId = 0;

        // ── Palette shortcuts (keep in sync with designer) ─────────────────────
        private static readonly Color ClrAccent = Color.FromArgb(99, 102, 241);
        private static readonly Color ClrAccentDark = Color.FromArgb(79, 82, 200);
        private static readonly Color ClrDanger = Color.FromArgb(239, 68, 68);
        private static readonly Color ClrDangerHover = Color.FromArgb(220, 38, 38);
        private static readonly Color ClrSuccess = Color.FromArgb(16, 185, 129);
        private static readonly Color ClrBorder = Color.FromArgb(229, 231, 235);
        private static readonly Color ClrTextMuted = Color.FromArgb(107, 114, 128);
        private static readonly Color ClrTextPrimary = Color.FromArgb(17, 24, 39);

        // ──────────────────────────────────────────────────────────────────────
        //  Constructor
        // ──────────────────────────────────────────────────────────────────────
        public CategoryManagementForm(CategoryAdminService categoryAdminService)
        {
            _categoryAdminService = categoryAdminService ?? throw new ArgumentNullException(nameof(categoryAdminService));

            InitializeComponent();
            ApplyRoundedCards();
            SetupColumns();
            LoadCategories();
        }

        // ──────────────────────────────────────────────────────────────────────
        //  Grid Columns
        // ──────────────────────────────────────────────────────────────────────
        private void SetupColumns()
        {
            dgvCategories.AutoGenerateColumns = false;
            dgvCategories.Columns.Clear();

            // ID
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID",
                HeaderText = "#",
                ReadOnly = true,
                Width = 56,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = ClrTextMuted,
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    SelectionBackColor = Color.FromArgb(238, 242, 255),
                    SelectionForeColor = ClrTextPrimary
                }
            });

            // Name
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Category Name",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                    ForeColor = ClrTextPrimary,
                    SelectionBackColor = Color.FromArgb(238, 242, 255),
                    SelectionForeColor = ClrTextPrimary
                }
            });

            // Edit button
            dgvCategories.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                Width = 84,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(238, 242, 255),
                    ForeColor = ClrAccent,
                    Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    SelectionBackColor = Color.FromArgb(225, 230, 255),
                    SelectionForeColor = ClrAccentDark,
                    Padding = new Padding(0)
                }
            });

            // Delete button
            dgvCategories.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Width = 84,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(254, 242, 242),
                    ForeColor = ClrDanger,
                    Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    SelectionBackColor = Color.FromArgb(254, 226, 226),
                    SelectionForeColor = ClrDangerHover,
                    Padding = new Padding(0)
                }
            });
        }

        // ──────────────────────────────────────────────────────────────────────
        //  Data
        // ──────────────────────────────────────────────────────────────────────
        private void LoadCategories()
        {
            dgvCategories.Rows.Clear();
            var list = _categoryAdminService.GetAll().ToList();

            foreach (var cat in list)
                dgvCategories.Rows.Add(cat.Id, cat.Name);

            UpdateRecordCount(list.Count);
        }

        private void UpdateRecordCount(int count)
        {
            lblRecordCount.Text = count == 1 ? "1 category" : $"{count} categories";
        }

        // ──────────────────────────────────────────────────────────────────────
        //  Add / Update
        // ──────────────────────────────────────────────────────────────────────
        private void btnAdd_Click(object sender, EventArgs e) => CommitInput();

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; CommitInput(); }
            if (e.KeyCode == Keys.Escape) { e.SuppressKeyPress = true; ResetEditState(); }
        }

        private void CommitInput()
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                ShakeControl(txtName);
                ShowInlineError("Please enter a category name.");
                return;
            }

            try
            {
                if (_editingCategoryId > 0)
                {
                    _categoryAdminService.Update(_editingCategoryId, new UpdateCategoryDto { Name = name });
                    ShowSuccessToast("Category updated successfully.");
                    ResetEditState();
                }
                else
                {
                    _categoryAdminService.Create(new CreateCategoryDto { Name = name });
                    ShowSuccessToast("Category added successfully.");
                    txtName.Clear();
                }

                LoadCategories();
                txtName.Focus();
            }
            catch (InvalidOperationException ex)
            {
                ShowInlineError(ex.Message);   // e.g. duplicate name
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        // ──────────────────────────────────────────────────────────────────────
        //  Edit State
        // ──────────────────────────────────────────────────────────────────────
        private void EnterEditMode(int id, string name)
        {
            _editingCategoryId = id;
            txtName.Text = name;
            btnAdd.Text = "✓ Update Category";
            btnAdd.BackColor = ClrSuccess;
            btnAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(5, 150, 105);
            btnCancelEdit.Visible = true;
            lblInputCardTitle.Text = "EDITING CATEGORY";
            lblInputCardTitle.ForeColor = ClrSuccess;
            txtName.BackColor = Color.FromArgb(240, 253, 250);
            txtName.Focus();
            txtName.SelectAll();
        }

        private void ResetEditState()
        {
            _editingCategoryId = 0;
            txtName.Clear();
            txtName.BackColor = Color.FromArgb(249, 250, 251);
            btnAdd.Text = "+ Add Category";
            btnAdd.BackColor = ClrAccent;
            btnAdd.FlatAppearance.MouseOverBackColor = ClrAccentDark;
            btnCancelEdit.Visible = false;
            lblInputCardTitle.Text = "ADD NEW CATEGORY";
            lblInputCardTitle.ForeColor = ClrTextMuted;
            txtName.Focus();
        }

        private void btnCancelEdit_Click(object sender, EventArgs e) => ResetEditState();

        // ──────────────────────────────────────────────────────────────────────
        //  Grid Events
        // ──────────────────────────────────────────────────────────────────────
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

        private void ConfirmDelete(int id, string name)
        {
            using var dlg = new DeleteConfirmDialog(name);
            if (dlg.ShowDialog(this) != DialogResult.Yes) return;

            try
            {
                _categoryAdminService.Delete(id);
                ShowSuccessToast($"'{name}' was deleted.");
                if (_editingCategoryId == id) ResetEditState();
                LoadCategories();
            }
            catch (KeyNotFoundException ex)
            {
                ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        // ──────────────────────────────────────────────────────────────────────
        //  Custom Cell Painting — rounded pill buttons in grid
        // ──────────────────────────────────────────────────────────────────────
        private void dgvCategories_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var colEdit = dgvCategories.Columns["Edit"].Index;
            var colDelete = dgvCategories.Columns["Delete"].Index;

            if (e.ColumnIndex != colEdit && e.ColumnIndex != colDelete) return;

            e.PaintBackground(e.ClipBounds, true);

            bool isEdit = (e.ColumnIndex == colEdit);
            var btnFore = isEdit ? ClrAccent : ClrDanger;
            var btnBack = isEdit ? Color.FromArgb(238, 242, 255) : Color.FromArgb(254, 242, 242);
            string btnText = isEdit ? "Edit" : "Delete";

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Pill rectangle
            int pw = 62, ph = 28;
            int px = e.CellBounds.X + (e.CellBounds.Width - pw) / 2;
            int py = e.CellBounds.Y + (e.CellBounds.Height - ph) / 2;
            var rect = new Rectangle(px, py, pw, ph);

            using var path = RoundedRect(rect, 14);
            using var fill = new SolidBrush(btnBack);
            g.FillPath(fill, path);

            using var pen = new Pen(isEdit ? Color.FromArgb(199, 210, 254) : Color.FromArgb(254, 202, 202), 1f);
            g.DrawPath(pen, path);

            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            using var font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            using var textBrush = new SolidBrush(btnFore);
            g.DrawString(btnText, font, textBrush, new RectangleF(px, py, pw, ph), sf);

            e.Handled = true;
        }

        private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        // ──────────────────────────────────────────────────────────────────────
        //  Feedback Helpers
        // ──────────────────────────────────────────────────────────────────────
        private void ShowSuccessToast(string message)
        {
            // Non-blocking toast via a temporary label overlay
            var toast = new Label
            {
                Text = "✓  " + message,
                Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = ClrSuccess,
                AutoSize = false,
                Size = new Size(340, 38),
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(0)
            };
            toast.Location = new Point((this.ClientSize.Width - toast.Width) / 2, this.ClientSize.Height - 110);
            this.Controls.Add(toast);
            toast.BringToFront();

            //var t = new Timer { Interval = 2000 };
            //t.Tick += (s, _) => { t.Stop(); this.Controls.Remove(toast); toast.Dispose(); t.Dispose(); };
            //t.Start();
        }

        private void ShowInlineError(string message)
        {
            var toast = new Label
            {
                Text = "⚠  " + message,
                Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = ClrDanger,
                AutoSize = false,
                Size = new Size(340, 38),
                TextAlign = ContentAlignment.MiddleCenter
            };
            toast.Location = new Point((this.ClientSize.Width - toast.Width) / 2, this.ClientSize.Height - 110);
            this.Controls.Add(toast);
            toast.BringToFront();

            //var t = new Timer { Interval = 2400 };
            //t.Tick += (s, _) => { t.Stop(); this.Controls.Remove(toast); toast.Dispose(); t.Dispose(); };
            //t.Start();
        }

        private void ShowError(string message) =>
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        /// <summary>Brief horizontal shake animation to indicate a validation error.</summary>
        private async void ShakeControl(Control ctrl)
        {
            var orig = ctrl.Left;
            int[] offsets = { -6, 6, -5, 5, -3, 3, 0 };
            foreach (var dx in offsets)
            {
                ctrl.Left = orig + dx;
                await System.Threading.Tasks.Task.Delay(30);
            }
            ctrl.Left = orig;
        }

        // ──────────────────────────────────────────────────────────────────────
        //  Rounded Cards
        // ──────────────────────────────────────────────────────────────────────
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyRoundedCards();
        }

        private void ApplyRoundedCards()
        {
            ApplyRound(pnlInputCard, 10);
            ApplyRound(pnlGridCard, 10);
            ApplyRound(btnAdd, 6);
            ApplyRound(btnCancelEdit, 6);
            ApplyRound(btnClose, 6);
        }

        private static void ApplyRound(Control ctrl, int r)
        {
            if (ctrl.Width == 0 || ctrl.Height == 0) return;
            var path = new GraphicsPath();
            int d = r * 2;
            path.AddArc(0, 0, d, d, 180, 90);
            path.AddArc(ctrl.Width - d, 0, d, d, 270, 90);
            path.AddArc(ctrl.Width - d, ctrl.Height - d, d, d, 0, 90);
            path.AddArc(0, ctrl.Height - d, d, d, 90, 90);
            path.CloseFigure();
            ctrl.Region = new Region(path);
        }

        // ──────────────────────────────────────────────────────────────────────
        //  Close
        // ──────────────────────────────────────────────────────────────────────
        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }

    // ──────────────────────────────────────────────────────────────────────────
    //  Lightweight inline delete-confirm dialog (replaces stock MessageBox)
    // ──────────────────────────────────────────────────────────────────────────
    internal sealed class DeleteConfirmDialog : Form
    {
        private readonly Button _btnYes;
        private readonly Button _btnNo;

        internal DeleteConfirmDialog(string categoryName)
        {
            this.Text = "Confirm Delete";
            this.ClientSize = new Size(400, 180);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(250, 251, 254);

            var icon = new Label
            {
                Text = "⚠",
                Font = new Font("Segoe UI Symbol", 28F),
                ForeColor = Color.FromArgb(245, 158, 11),
                Location = new Point(24, 28),
                Size = new Size(48, 48),
                BackColor = Color.Transparent
            };

            var msg = new Label
            {
                Text = $"Delete \"{categoryName}\"?",
                Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                Location = new Point(82, 30),
                Size = new Size(300, 22),
                BackColor = Color.Transparent
            };

            var sub = new Label
            {
                Text = "This action cannot be undone.",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(107, 114, 128),
                Location = new Point(84, 56),
                Size = new Size(300, 18),
                BackColor = Color.Transparent
            };

            _btnNo = new Button
            {
                Text = "Cancel",
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(186, 120),
                Size = new Size(92, 38),
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.No
            };
            _btnNo.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            _btnNo.FlatAppearance.BorderSize = 1;

            _btnYes = new Button
            {
                Text = "Delete",
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(239, 68, 68),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(288, 120),
                Size = new Size(92, 38),
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.Yes
            };
            _btnYes.FlatAppearance.BorderSize = 0;
            _btnYes.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 38, 38);

            this.Controls.AddRange(new Control[] { icon, msg, sub, _btnNo, _btnYes });
            this.AcceptButton = _btnYes;
            this.CancelButton = _btnNo;
        }
    }
}