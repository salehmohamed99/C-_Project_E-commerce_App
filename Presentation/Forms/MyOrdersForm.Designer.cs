namespace Presentation.Forms
{
    partial class MyOrdersForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel pnlCardTotal;
        private System.Windows.Forms.Label lblCardTotalCount;
        private System.Windows.Forms.Label lblCardTotalLabel;
        private System.Windows.Forms.Panel pnlCardProcessing;
        private System.Windows.Forms.Label lblCardProcessingCount;
        private System.Windows.Forms.Label lblCardProcessingLabel;
        private System.Windows.Forms.Panel pnlCardShipped;
        private System.Windows.Forms.Label lblCardShippedCount;
        private System.Windows.Forms.Label lblCardShippedLabel;
        private System.Windows.Forms.Panel pnlCardDelivered;
        private System.Windows.Forms.Label lblCardDeliveredCount;
        private System.Windows.Forms.Label lblCardDeliveredLabel;
        private System.Windows.Forms.Panel pnlCardCancelled;
        private System.Windows.Forms.Label lblCardCancelledCount;
        private System.Windows.Forms.Label lblCardCancelledLabel;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblNoOrders;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader             = new System.Windows.Forms.Panel();
            this.lblTitle              = new System.Windows.Forms.Label();
            this.lblSubtitle           = new System.Windows.Forms.Label();
            this.pnlStats             = new System.Windows.Forms.Panel();
            this.pnlCardTotal         = new System.Windows.Forms.Panel();
            this.lblCardTotalCount     = new System.Windows.Forms.Label();
            this.lblCardTotalLabel     = new System.Windows.Forms.Label();
            this.pnlCardProcessing    = new System.Windows.Forms.Panel();
            this.lblCardProcessingCount = new System.Windows.Forms.Label();
            this.lblCardProcessingLabel = new System.Windows.Forms.Label();
            this.pnlCardShipped       = new System.Windows.Forms.Panel();
            this.lblCardShippedCount   = new System.Windows.Forms.Label();
            this.lblCardShippedLabel   = new System.Windows.Forms.Label();
            this.pnlCardDelivered     = new System.Windows.Forms.Panel();
            this.lblCardDeliveredCount = new System.Windows.Forms.Label();
            this.lblCardDeliveredLabel = new System.Windows.Forms.Label();
            this.pnlCardCancelled     = new System.Windows.Forms.Panel();
            this.lblCardCancelledCount = new System.Windows.Forms.Label();
            this.lblCardCancelledLabel = new System.Windows.Forms.Label();
            this.dgvOrders            = new System.Windows.Forms.DataGridView();
            this.btnRefresh           = new System.Windows.Forms.Button();
            this.btnClose             = new System.Windows.Forms.Button();
            this.lblNoOrders          = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)this.dgvOrders).BeginInit();
            this.SuspendLayout();

            // ???????????????????????????????????????
            //  Header Panel
            // ???????????????????????????????????????
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 80;
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(45, 62, 80);
            this.pnlHeader.Padding   = new System.Windows.Forms.Padding(25, 0, 0, 0);

            // lblTitle
            this.lblTitle.Text      = "My Orders";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(25, 12);
            this.lblTitle.AutoSize  = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;

            // lblSubtitle
            this.lblSubtitle.Text      = "Track and manage all your orders";
            this.lblSubtitle.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.lblSubtitle.Location  = new System.Drawing.Point(27, 50);
            this.lblSubtitle.AutoSize  = true;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;

            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            // ???????????????????????????????????????
            //  Stats Cards Panel
            // ???????????????????????????????????????
            this.pnlStats.Location  = new System.Drawing.Point(25, 95);
            this.pnlStats.Size      = new System.Drawing.Size(930, 90);
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);

            int cardWidth  = 166;
            int cardHeight = 70;
            int cardGap    = 12;
            int cardTop    = 10;

            // Card — Total Orders
            this.pnlCardTotal.Location  = new System.Drawing.Point(15, cardTop);
            this.pnlCardTotal.Size      = new System.Drawing.Size(cardWidth, cardHeight);
            this.pnlCardTotal.BackColor = System.Drawing.Color.White;
            this.pnlCardTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblCardTotalCount.Text      = "0";
            this.lblCardTotalCount.Font      = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblCardTotalCount.ForeColor = System.Drawing.Color.FromArgb(45, 62, 80);
            this.lblCardTotalCount.Location  = new System.Drawing.Point(12, 6);
            this.lblCardTotalCount.AutoSize  = true;

            this.lblCardTotalLabel.Text      = "Total Orders";
            this.lblCardTotalLabel.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCardTotalLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblCardTotalLabel.Location  = new System.Drawing.Point(14, 45);
            this.lblCardTotalLabel.AutoSize  = true;

            this.pnlCardTotal.Controls.Add(this.lblCardTotalCount);
            this.pnlCardTotal.Controls.Add(this.lblCardTotalLabel);

            // Card — Processing
            this.pnlCardProcessing.Location  = new System.Drawing.Point(15 + (cardWidth + cardGap), cardTop);
            this.pnlCardProcessing.Size      = new System.Drawing.Size(cardWidth, cardHeight);
            this.pnlCardProcessing.BackColor = System.Drawing.Color.White;
            this.pnlCardProcessing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblCardProcessingCount.Text      = "0";
            this.lblCardProcessingCount.Font      = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblCardProcessingCount.ForeColor = System.Drawing.Color.FromArgb(243, 156, 18);
            this.lblCardProcessingCount.Location  = new System.Drawing.Point(12, 6);
            this.lblCardProcessingCount.AutoSize  = true;

            this.lblCardProcessingLabel.Text      = "Processing";
            this.lblCardProcessingLabel.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCardProcessingLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblCardProcessingLabel.Location  = new System.Drawing.Point(14, 45);
            this.lblCardProcessingLabel.AutoSize  = true;

            this.pnlCardProcessing.Controls.Add(this.lblCardProcessingCount);
            this.pnlCardProcessing.Controls.Add(this.lblCardProcessingLabel);

            // Card — Shipped
            this.pnlCardShipped.Location  = new System.Drawing.Point(15 + 2 * (cardWidth + cardGap), cardTop);
            this.pnlCardShipped.Size      = new System.Drawing.Size(cardWidth, cardHeight);
            this.pnlCardShipped.BackColor = System.Drawing.Color.White;
            this.pnlCardShipped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblCardShippedCount.Text      = "0";
            this.lblCardShippedCount.Font      = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblCardShippedCount.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblCardShippedCount.Location  = new System.Drawing.Point(12, 6);
            this.lblCardShippedCount.AutoSize  = true;

            this.lblCardShippedLabel.Text      = "Shipped";
            this.lblCardShippedLabel.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCardShippedLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblCardShippedLabel.Location  = new System.Drawing.Point(14, 45);
            this.lblCardShippedLabel.AutoSize  = true;

            this.pnlCardShipped.Controls.Add(this.lblCardShippedCount);
            this.pnlCardShipped.Controls.Add(this.lblCardShippedLabel);

            // Card — Delivered
            this.pnlCardDelivered.Location  = new System.Drawing.Point(15 + 3 * (cardWidth + cardGap), cardTop);
            this.pnlCardDelivered.Size      = new System.Drawing.Size(cardWidth, cardHeight);
            this.pnlCardDelivered.BackColor = System.Drawing.Color.White;
            this.pnlCardDelivered.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblCardDeliveredCount.Text      = "0";
            this.lblCardDeliveredCount.Font      = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblCardDeliveredCount.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblCardDeliveredCount.Location  = new System.Drawing.Point(12, 6);
            this.lblCardDeliveredCount.AutoSize  = true;

            this.lblCardDeliveredLabel.Text      = "Delivered";
            this.lblCardDeliveredLabel.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCardDeliveredLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblCardDeliveredLabel.Location  = new System.Drawing.Point(14, 45);
            this.lblCardDeliveredLabel.AutoSize  = true;

            this.pnlCardDelivered.Controls.Add(this.lblCardDeliveredCount);
            this.pnlCardDelivered.Controls.Add(this.lblCardDeliveredLabel);

            // Card — Cancelled
            this.pnlCardCancelled.Location  = new System.Drawing.Point(15 + 4 * (cardWidth + cardGap), cardTop);
            this.pnlCardCancelled.Size      = new System.Drawing.Size(cardWidth, cardHeight);
            this.pnlCardCancelled.BackColor = System.Drawing.Color.White;
            this.pnlCardCancelled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblCardCancelledCount.Text      = "0";
            this.lblCardCancelledCount.Font      = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblCardCancelledCount.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.lblCardCancelledCount.Location  = new System.Drawing.Point(12, 6);
            this.lblCardCancelledCount.AutoSize  = true;

            this.lblCardCancelledLabel.Text      = "Cancelled";
            this.lblCardCancelledLabel.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCardCancelledLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblCardCancelledLabel.Location  = new System.Drawing.Point(14, 45);
            this.lblCardCancelledLabel.AutoSize  = true;

            this.pnlCardCancelled.Controls.Add(this.lblCardCancelledCount);
            this.pnlCardCancelled.Controls.Add(this.lblCardCancelledLabel);

            this.pnlStats.Controls.Add(this.pnlCardTotal);
            this.pnlStats.Controls.Add(this.pnlCardProcessing);
            this.pnlStats.Controls.Add(this.pnlCardShipped);
            this.pnlStats.Controls.Add(this.pnlCardDelivered);
            this.pnlStats.Controls.Add(this.pnlCardCancelled);

            // ???????????????????????????????????????
            //  DataGridView — Orders
            // ???????????????????????????????????????
            this.dgvOrders.Location            = new System.Drawing.Point(25, 200);
            this.dgvOrders.Size                = new System.Drawing.Size(930, 380);
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
                BackColor  = System.Drawing.Color.FromArgb(45, 62, 80),
                ForeColor  = System.Drawing.Color.White,
                Font       = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold),
                Alignment  = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter,
                Padding    = new System.Windows.Forms.Padding(0)
            };
            this.dgvOrders.DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
            {
                Font            = new System.Drawing.Font("Segoe UI", 9.75F),
                Padding         = new System.Windows.Forms.Padding(6, 4, 6, 4),
                Alignment       = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter,
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

            // lblNoOrders — shown when there are no orders
            this.lblNoOrders.Text      = "You don't have any orders yet.\nStart shopping to see your orders here!";
            this.lblNoOrders.Font      = new System.Drawing.Font("Segoe UI", 12F);
            this.lblNoOrders.ForeColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.lblNoOrders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoOrders.Location  = new System.Drawing.Point(250, 350);
            this.lblNoOrders.Size      = new System.Drawing.Size(480, 70);
            this.lblNoOrders.Visible   = false;

            // ???????????????????????????????????????
            //  Buttons
            // ???????????????????????????????????????

            // btnRefresh
            this.btnRefresh.Text      = "Refresh";
            this.btnRefresh.Location  = new System.Drawing.Point(25, 595);
            this.btnRefresh.Size      = new System.Drawing.Size(120, 40);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Click    += new System.EventHandler(this.btnRefresh_Click);

            // btnClose
            this.btnClose.Text      = "Close";
            this.btnClose.Location  = new System.Drawing.Point(835, 595);
            this.btnClose.Size      = new System.Drawing.Size(120, 40);
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(45, 62, 80);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Click    += new System.EventHandler(this.btnClose_Click);

            // ???????????????????????????????????????
            //  MyOrdersForm
            // ???????????????????????????????????????
            this.Load += new System.EventHandler(this.MyOrdersForm_Load);
            this.ClientSize = new System.Drawing.Size(980, 650);
            this.BackColor  = System.Drawing.Color.FromArgb(245, 247, 250);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.lblNoOrders);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Text          = "My Orders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ((System.ComponentModel.ISupportInitialize)this.dgvOrders).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
