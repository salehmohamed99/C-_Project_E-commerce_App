namespace Presentation.Forms
{
    partial class OrderPlacementForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.Button btnPlace;
        private System.Windows.Forms.Button btnCancel;

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
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblPhone   = new System.Windows.Forms.Label();
            this.txtPhone   = new System.Windows.Forms.TextBox();
            this.lblSummary = new System.Windows.Forms.Label();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.btnPlace   = new System.Windows.Forms.Button();
            this.btnCancel  = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // ???????????????????????????????????????
            //  Header Panel
            // ???????????????????????????????????????
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 65;
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(45, 62, 80);

            this.lblTitle.Text      = "Complete Your Order";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(25, 14);
            this.lblTitle.AutoSize  = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;

            this.pnlHeader.Controls.Add(this.lblTitle);

            int fieldLeft = 30;

            // ???????????????????????????????????????
            //  Shipping Address
            // ???????????????????????????????????????
            this.lblAddress.Text      = "Shipping Address *";
            this.lblAddress.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(45, 62, 80);
            this.lblAddress.Location  = new System.Drawing.Point(fieldLeft, 85);
            this.lblAddress.AutoSize  = true;

            this.txtAddress.Location    = new System.Drawing.Point(fieldLeft, 112);
            this.txtAddress.Size        = new System.Drawing.Size(540, 80);
            this.txtAddress.Font        = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Multiline   = true;

            // ???????????????????????????????????????
            //  Phone
            // ???????????????????????????????????????
            this.lblPhone.Text      = "Phone";
            this.lblPhone.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(45, 62, 80);
            this.lblPhone.Location  = new System.Drawing.Point(fieldLeft, 205);
            this.lblPhone.AutoSize  = true;

            this.txtPhone.Location    = new System.Drawing.Point(fieldLeft, 232);
            this.txtPhone.Size        = new System.Drawing.Size(250, 30);
            this.txtPhone.Font        = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // ???????????????????????????????????????
            //  Order Summary
            // ???????????????????????????????????????
            this.lblSummary.Text      = "Order Summary";
            this.lblSummary.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSummary.ForeColor = System.Drawing.Color.FromArgb(45, 62, 80);
            this.lblSummary.Location  = new System.Drawing.Point(fieldLeft, 280);
            this.lblSummary.AutoSize  = true;

            this.txtSummary.Location    = new System.Drawing.Point(fieldLeft, 310);
            this.txtSummary.Size        = new System.Drawing.Size(540, 140);
            this.txtSummary.Font        = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSummary.Multiline   = true;
            this.txtSummary.ReadOnly    = true;
            this.txtSummary.BackColor   = System.Drawing.Color.FromArgb(245, 247, 250);
            this.txtSummary.ScrollBars  = System.Windows.Forms.ScrollBars.Vertical;

            // ???????????????????????????????????????
            //  Buttons
            // ???????????????????????????????????????
            this.btnPlace.Text      = "Place Order";
            this.btnPlace.Location  = new System.Drawing.Point(330, 470);
            this.btnPlace.Size      = new System.Drawing.Size(155, 45);
            this.btnPlace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlace.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnPlace.ForeColor = System.Drawing.Color.White;
            this.btnPlace.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPlace.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnPlace.FlatAppearance.BorderSize = 0;
            this.btnPlace.Click    += new System.EventHandler(this.btnPlace_Click);

            this.btnCancel.Text      = "Cancel";
            this.btnCancel.Location  = new System.Drawing.Point(495, 470);
            this.btnCancel.Size      = new System.Drawing.Size(80, 45);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnCancel.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.btnCancel.FlatAppearance.BorderSize  = 2;
            this.btnCancel.Click    += new System.EventHandler(this.btnCancel_Click);

            // ???????????????????????????????????????
            //  OrderPlacementForm
            // ???????????????????????????????????????
            this.ClientSize      = new System.Drawing.Size(600, 535);
            this.BackColor       = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.Controls.Add(this.pnlHeader);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblAddress, this.txtAddress,
                this.lblPhone, this.txtPhone,
                this.lblSummary, this.txtSummary,
                this.btnPlace, this.btnCancel
            });
            this.Text            = "Place Order";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode   = System.Windows.Forms.AutoScaleMode.Font;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
