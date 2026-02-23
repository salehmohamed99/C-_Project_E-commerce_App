namespace Presentation.Forms
{
    partial class CategoryManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblName = new Label();
            txtName = new TextBox();
            btnAdd = new Button();
            dgvCategories = new DataGridView();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Manage Categories";
            // 
            // lblName
            // 
            lblName.Location = new Point(20, 65);
            lblName.Name = "lblName";
            lblName.Size = new Size(105, 20);
            lblName.TabIndex = 1;
            lblName.Text = "Category Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(130, 62);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 27);
            txtName.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(345, 60);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 30);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add Category";
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvCategories
            // 
            dgvCategories.ColumnHeadersHeight = 29;
            dgvCategories.Location = new Point(20, 110);
            dgvCategories.Name = "dgvCategories";
            dgvCategories.RowHeadersWidth = 51;
            dgvCategories.Size = new Size(650, 300);
            dgvCategories.TabIndex = 4;
            dgvCategories.UseWaitCursor = true;
            dgvCategories.CellContentClick += dgvCategories_CellContentClick;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(595, 425);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 30);
            btnClose.TabIndex = 5;
            btnClose.Text = "Close";
            btnClose.Click += btnClose_Click;
            // 
            // CategoryManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 490);
            Controls.Add(lblTitle);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(btnAdd);
            Controls.Add(dgvCategories);
            Controls.Add(btnClose);
            Name = "CategoryManagementForm";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Category Management";
            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
