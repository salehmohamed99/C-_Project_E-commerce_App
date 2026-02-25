namespace Presentation.Forms
{
    partial class CartForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader   = new System.Windows.Forms.Panel();
            this.lblTitle    = new System.Windows.Forms.Label();
            this.dgvCart     = new System.Windows.Forms.DataGridView();
            this.pnlFooter   = new System.Windows.Forms.Panel();
            this.lblTotal    = new System.Windows.Forms.Label();
            this.btnClear    = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnClose    = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)this.dgvCart).BeginInit();
            this.SuspendLayout();

            // ???????????????????????????????????????
            //  Header Panel
            // ???????????????????????????????????????
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 60;
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(45, 62, 80);

            this.lblTitle.Text      = "Your Shopping Cart";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(25, 12);
            this.lblTitle.AutoSize  = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;

            this.pnlHeader.Controls.Add(this.lblTitle);

            // ???????????????????????????????????????
            //  DataGridView — Cart
            // ???????????????????????????????????????
            this.dgvCart.Location            = new System.Drawing.Point(25, 80);
            this.dgvCart.Size                = new System.Drawing.Size(930, 380);
            this.dgvCart.AutoGenerateColumns = false;
            this.dgvCart.RowTemplate.Height  = 60;
            this.dgvCart.AllowUserToAddRows  = false;
            this.dgvCart.RowHeadersVisible   = false;
            this.dgvCart.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.MultiSelect         = false;
            this.dgvCart.BackgroundColor     = System.Drawing.Color.White;
            this.dgvCart.GridColor           = System.Drawing.Color.FromArgb(230, 230, 230);
            this.dgvCart.BorderStyle         = System.Windows.Forms.BorderStyle.None;
            this.dgvCart.CellBorderStyle     = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCart.EnableHeadersVisualStyles = false;
            this.dgvCart.ColumnHeadersHeight      = 42;
            this.dgvCart.ColumnHeadersBorderStyle  = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCart.ColumnHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(45, 62, 80),
                ForeColor = System.Drawing.Color.White,
                Font      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold),
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter,
                Padding   = new System.Windows.Forms.Padding(0)
            };
            this.dgvCart.DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
            {
                Font               = new System.Drawing.Font("Segoe UI", 9.75F),
                Padding            = new System.Windows.Forms.Padding(4),
                Alignment          = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = System.Drawing.Color.FromArgb(214, 234, 248),
                SelectionForeColor = System.Drawing.Color.FromArgb(45, 62, 80)
            };
            this.dgvCart.AlternatingRowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
            {
                BackColor          = System.Drawing.Color.FromArgb(245, 247, 250),
                SelectionBackColor = System.Drawing.Color.FromArgb(214, 234, 248),
                SelectionForeColor = System.Drawing.Color.FromArgb(45, 62, 80)
            };

            this.dgvCart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCart_CellContentClick);

            // ???????????????????????????????????????
            //  Footer Panel — Total + Buttons
            // ???????????????????????????????????????
            this.pnlFooter.Location  = new System.Drawing.Point(25, 475);
            this.pnlFooter.Size      = new System.Drawing.Size(930, 85);
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // lblTotal
            this.lblTotal.Text      = "Total: $0.00";
            this.lblTotal.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblTotal.Location  = new System.Drawing.Point(20, 22);
            this.lblTotal.AutoSize  = true;

            // btnClear
            this.btnClear.Text      = "Clear Cart";
            this.btnClear.Location  = new System.Drawing.Point(420, 18);
            this.btnClear.Size      = new System.Drawing.Size(110, 42);
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnClear.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnClear.FlatAppearance.BorderSize  = 2;
            this.btnClear.Click    += new System.EventHandler(this.btnClear_Click);

            // btnContinue
            this.btnContinue.Text      = "Back";
            this.btnContinue.Location  = new System.Drawing.Point(540, 18);
            this.btnContinue.Size      = new System.Drawing.Size(140, 42);
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.BackColor = System.Drawing.Color.White;
            this.btnContinue.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnContinue.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnContinue.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnContinue.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnContinue.FlatAppearance.BorderSize  = 2;
            this.btnContinue.Click    += new System.EventHandler(this.btnContinue_Click);

            // btnCheckout
            this.btnCheckout.Text      = "Proceed to Checkout";
            this.btnCheckout.Location  = new System.Drawing.Point(690, 18);
            this.btnCheckout.Size      = new System.Drawing.Size(220, 42);
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnCheckout.FlatAppearance.BorderSize = 0;
            this.btnCheckout.Click    += new System.EventHandler(this.btnCheckout_Click);

            this.pnlFooter.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTotal, this.btnClear, this.btnContinue, this.btnCheckout
            });

            // btnClose
            this.btnClose.Text      = "Close";
            this.btnClose.Location  = new System.Drawing.Point(835, 575);
            this.btnClose.Size      = new System.Drawing.Size(120, 40);
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(45, 62, 80);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Click    += new System.EventHandler(this.btnClose_Click);

            // btnRefresh
            this.btnRefresh          = new System.Windows.Forms.Button();
            this.btnRefresh.Text     = "Refresh";
            this.btnRefresh.Location = new System.Drawing.Point(25, 575);
            this.btnRefresh.Size     = new System.Drawing.Size(120, 40);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Click    += new System.EventHandler(this.btnRefresh_Click);

            // ???????????????????????????????????????
            //  CartForm
            // ???????????????????????????????????????
            this.ClientSize      = new System.Drawing.Size(980, 630);
            this.BackColor       = System.Drawing.Color.FromArgb(245, 247, 250);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Text          = "Shopping Cart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ((System.ComponentModel.ISupportInitialize)this.dgvCart).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
