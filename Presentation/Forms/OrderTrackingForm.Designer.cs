namespace Presentation.Forms
{
    partial class OrderTrackingForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.DataGridView dgvOrders;
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
            this.pnlHeader  = new System.Windows.Forms.Panel();
            this.lblTitle   = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.dgvOrders  = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose   = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)this.dgvOrders).BeginInit();
            this.SuspendLayout();

            // ???????????????????????????????????????
            //  Header Panel
            // ???????????????????????????????????????
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 80;
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(45, 62, 80);

            this.lblTitle.Text      = "Track & Manage Orders";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(25, 12);
            this.lblTitle.AutoSize  = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;

            this.lblSubtitle.Text      = "View and update order statuses for all customers";
            this.lblSubtitle.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.lblSubtitle.Location  = new System.Drawing.Point(27, 50);
            this.lblSubtitle.AutoSize  = true;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;

            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            // ???????????????????????????????????????
            //  DataGridView — Orders
            // ???????????????????????????????????????
            this.dgvOrders.Location            = new System.Drawing.Point(25, 100);
            this.dgvOrders.Size                = new System.Drawing.Size(980, 420);
            this.dgvOrders.AutoGenerateColumns = false;
            this.dgvOrders.ReadOnly            = true;
            this.dgvOrders.AllowUserToAddRows  = false;
            this.dgvOrders.RowHeadersVisible   = false;
            this.dgvOrders.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.MultiSelect         = false;
            this.dgvOrders.BackgroundColor     = System.Drawing.Color.White;
            this.dgvOrders.GridColor           = System.Drawing.Color.FromArgb(230, 230, 230);
            this.dgvOrders.BorderStyle         = System.Windows.Forms.BorderStyle.None;
            this.dgvOrders.CellBorderStyle     = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOrders.EnableHeadersVisualStyles = false;
            this.dgvOrders.ColumnHeadersHeight      = 42;
            this.dgvOrders.ColumnHeadersBorderStyle  = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvOrders.ColumnHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(45, 62, 80),
                ForeColor = System.Drawing.Color.White,
                Font      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold),
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter,
                Padding   = new System.Windows.Forms.Padding(0)
            };
            this.dgvOrders.DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
            {
                Font               = new System.Drawing.Font("Segoe UI", 9.75F),
                Padding            = new System.Windows.Forms.Padding(5),
                Alignment          = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = System.Drawing.Color.FromArgb(214, 234, 248),
                SelectionForeColor = System.Drawing.Color.FromArgb(45, 62, 80)
            };
            this.dgvOrders.AlternatingRowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
            {
                BackColor          = System.Drawing.Color.FromArgb(245, 247, 250),
                SelectionBackColor = System.Drawing.Color.FromArgb(214, 234, 248),
                SelectionForeColor = System.Drawing.Color.FromArgb(45, 62, 80)
            };
            this.dgvOrders.RowTemplate.Height = 42;

            this.dgvOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellContentClick);

            // ???????????????????????????????????????
            //  Buttons
            // ???????????????????????????????????????
            this.btnRefresh.Text      = "Refresh";
            this.btnRefresh.Location  = new System.Drawing.Point(25, 535);
            this.btnRefresh.Size      = new System.Drawing.Size(120, 40);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Click    += new System.EventHandler(this.btnRefresh_Click);

            this.btnClose.Text      = "Close";
            this.btnClose.Location  = new System.Drawing.Point(885, 535);
            this.btnClose.Size      = new System.Drawing.Size(120, 40);
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(45, 62, 80);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Click    += new System.EventHandler(this.btnClose_Click);

            // ???????????????????????????????????????
            //  OrderTrackingForm
            // ???????????????????????????????????????
            this.Load += new System.EventHandler(this.OrderTrackingForm_Load);
            this.ClientSize      = new System.Drawing.Size(1030, 590);
            this.BackColor       = System.Drawing.Color.FromArgb(245, 247, 250);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.Controls.Add(this.pnlHeader);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.dgvOrders, this.btnRefresh, this.btnClose
            });
            this.Text          = "Order Tracking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ((System.ComponentModel.ISupportInitialize)this.dgvOrders).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
