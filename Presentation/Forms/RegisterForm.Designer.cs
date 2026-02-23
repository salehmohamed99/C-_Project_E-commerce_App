namespace Presentation.Forms
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle    = new System.Windows.Forms.Label();
            this.lblName     = new System.Windows.Forms.Label();
            this.txtName     = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblEmail    = new System.Windows.Forms.Label();
            this.txtEmail    = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPhone    = new System.Windows.Forms.Label();
            this.txtPhone    = new System.Windows.Forms.TextBox();
            this.lblAddress  = new System.Windows.Forms.Label();
            this.txtAddress  = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCancel   = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text     = "Create Account";
            this.lblTitle.Font     = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(50, 20);
            this.lblTitle.Size     = new System.Drawing.Size(200, 25);

            // lblName / txtName
            this.lblName.Text     = "Full Name:";
            this.lblName.Location = new System.Drawing.Point(50, 60);
            this.lblName.Size     = new System.Drawing.Size(80, 20);
            this.txtName.Location = new System.Drawing.Point(50, 82);
            this.txtName.Size     = new System.Drawing.Size(350, 25);

            // lblUsername / txtUsername
            this.lblUsername.Text     = "Username:";
            this.lblUsername.Location = new System.Drawing.Point(50, 118);
            this.lblUsername.Size     = new System.Drawing.Size(80, 20);
            this.txtUsername.Location = new System.Drawing.Point(50, 140);
            this.txtUsername.Size     = new System.Drawing.Size(350, 25);

            // lblEmail / txtEmail
            this.lblEmail.Text     = "Email:";
            this.lblEmail.Location = new System.Drawing.Point(50, 176);
            this.lblEmail.Size     = new System.Drawing.Size(50, 20);
            this.txtEmail.Location = new System.Drawing.Point(50, 198);
            this.txtEmail.Size     = new System.Drawing.Size(350, 25);

            // lblPassword / txtPassword
            this.lblPassword.Text                    = "Password:";
            this.lblPassword.Location                = new System.Drawing.Point(50, 234);
            this.lblPassword.Size                    = new System.Drawing.Size(70, 20);
            this.txtPassword.Location                = new System.Drawing.Point(50, 256);
            this.txtPassword.Size                    = new System.Drawing.Size(350, 25);
            this.txtPassword.UseSystemPasswordChar   = true;

            // lblPhone / txtPhone
            this.lblPhone.Text     = "Phone:";
            this.lblPhone.Location = new System.Drawing.Point(50, 292);
            this.lblPhone.Size     = new System.Drawing.Size(50, 20);
            this.txtPhone.Location = new System.Drawing.Point(50, 314);
            this.txtPhone.Size     = new System.Drawing.Size(350, 25);

            // lblAddress / txtAddress
            this.lblAddress.Text     = "Address:";
            this.lblAddress.Location = new System.Drawing.Point(50, 350);
            this.lblAddress.Size     = new System.Drawing.Size(60, 20);
            this.txtAddress.Location = new System.Drawing.Point(50, 372);
            this.txtAddress.Size     = new System.Drawing.Size(350, 25);

            // btnRegister
            this.btnRegister.Text     = "Register";
            this.btnRegister.Location = new System.Drawing.Point(130, 415);
            this.btnRegister.Size     = new System.Drawing.Size(100, 30);
            this.btnRegister.Click   += new System.EventHandler(this.btnRegister_Click);

            // btnCancel
            this.btnCancel.Text     = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(240, 415);
            this.btnCancel.Size     = new System.Drawing.Size(100, 30);
            this.btnCancel.Click   += new System.EventHandler(this.btnCancel_Click);

            // RegisterForm
            this.ClientSize     = new System.Drawing.Size(480, 475);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle,
                this.lblName, this.txtName, this.lblUsername, this.txtUsername,
                this.lblEmail, this.txtEmail, this.lblPassword, this.txtPassword,
                this.lblPhone, this.txtPhone, this.lblAddress, this.txtAddress,
                this.btnRegister, this.btnCancel
            });
            this.Text            = "Register";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode   = System.Windows.Forms.AutoScaleMode.Font;
            this.ResumeLayout(false);
        }
    }
}
