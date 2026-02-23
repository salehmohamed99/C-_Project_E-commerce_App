namespace Presentation.Forms
{
    partial class MyOrdersForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle  = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.btnClose  = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)this.dgvOrders).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text     = "My Orders";
            this.lblTitle.Font     = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Size     = new System.Drawing.Size(200, 25);

            // dgvOrders
            this.dgvOrders.Location            = new System.Drawing.Point(20, 65);
            this.dgvOrders.Size                = new System.Drawing.Size(840, 400);
            this.dgvOrders.AutoGenerateColumns = false;
            this.dgvOrders.Columns.Add("ID",      "Order ID");
            this.dgvOrders.Columns.Add("Total",   "Total");
            this.dgvOrders.Columns.Add("Status",  "Status");
            this.dgvOrders.Columns.Add("Date",    "Date");
            this.dgvOrders.Columns.Add("Address", "Address");
            this.dgvOrders.Columns.Add("Details", "Details");

            // btnClose
            this.btnClose.Text     = "Close";
            this.btnClose.Location = new System.Drawing.Point(785, 490);
            this.btnClose.Size     = new System.Drawing.Size(75, 30);
            this.btnClose.Click   += new System.EventHandler(this.btnClose_Click);

            // MyOrdersForm
            this.ClientSize = new System.Drawing.Size(900, 545);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.dgvOrders, this.btnClose
            });
            this.Text          = "My Orders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ((System.ComponentModel.ISupportInitialize)this.dgvOrders).EndInit();
            this.ResumeLayout(false);
        }
    }
}
