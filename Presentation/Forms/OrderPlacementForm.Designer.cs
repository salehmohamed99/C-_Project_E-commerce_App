namespace Presentation.Forms
{
    partial class OrderPlacementForm
    {
        private System.ComponentModel.IContainer components = null;

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

            // lblTitle
            this.lblTitle.Text     = "Complete Your Order";
            this.lblTitle.Font     = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Size     = new System.Drawing.Size(300, 25);

            // lblAddress
            this.lblAddress.Text     = "Shipping Address:";
            this.lblAddress.Location = new System.Drawing.Point(20, 65);
            this.lblAddress.Size     = new System.Drawing.Size(120, 20);

            // txtAddress
            this.txtAddress.Location  = new System.Drawing.Point(20, 90);
            this.txtAddress.Size      = new System.Drawing.Size(540, 80);
            this.txtAddress.Multiline = true;

            // lblPhone
            this.lblPhone.Text     = "Phone:";
            this.lblPhone.Location = new System.Drawing.Point(20, 185);
            this.lblPhone.Size     = new System.Drawing.Size(50, 20);

            // txtPhone
            this.txtPhone.Location = new System.Drawing.Point(80, 182);
            this.txtPhone.Size     = new System.Drawing.Size(200, 25);

            // lblSummary
            this.lblSummary.Text     = "Order Summary";
            this.lblSummary.Font     = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            this.lblSummary.Location = new System.Drawing.Point(20, 220);
            this.lblSummary.Size     = new System.Drawing.Size(200, 25);

            // txtSummary
            this.txtSummary.Location  = new System.Drawing.Point(20, 250);
            this.txtSummary.Size      = new System.Drawing.Size(540, 120);
            this.txtSummary.Multiline = true;
            this.txtSummary.ReadOnly  = true;
            this.txtSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            // btnPlace
            this.btnPlace.Text     = "Place Order";
            this.btnPlace.Location = new System.Drawing.Point(370, 390);
            this.btnPlace.Size     = new System.Drawing.Size(120, 35);
            this.btnPlace.Font     = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.btnPlace.Click   += new System.EventHandler(this.btnPlace_Click);

            // btnCancel
            this.btnCancel.Text     = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(500, 390);
            this.btnCancel.Size     = new System.Drawing.Size(75, 35);
            this.btnCancel.Click   += new System.EventHandler(this.btnCancel_Click);

            // OrderPlacementForm
            this.ClientSize       = new System.Drawing.Size(600, 460);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.lblAddress, this.txtAddress,
                this.lblPhone, this.txtPhone, this.lblSummary,
                this.txtSummary, this.btnPlace, this.btnCancel
            });
            this.Text             = "Place Order";
            this.StartPosition    = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle  = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox      = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode    = System.Windows.Forms.AutoScaleMode.Font;
            this.ResumeLayout(false);
        }
    }
}
