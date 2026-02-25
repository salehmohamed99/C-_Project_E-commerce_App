namespace Presentation.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblBrandSub;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblWelcomeSub;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblDivider;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlLeft       = new System.Windows.Forms.Panel();
            this.lblBrand      = new System.Windows.Forms.Label();
            this.lblBrandSub   = new System.Windows.Forms.Label();
            this.pnlRight      = new System.Windows.Forms.Panel();
            this.lblWelcome    = new System.Windows.Forms.Label();
            this.lblWelcomeSub = new System.Windows.Forms.Label();
            this.lblUsername   = new System.Windows.Forms.Label();
            this.txtUsername   = new System.Windows.Forms.TextBox();
            this.lblPassword   = new System.Windows.Forms.Label();
            this.txtPassword   = new System.Windows.Forms.TextBox();
            this.btnLogin      = new System.Windows.Forms.Button();
            this.btnRegister   = new System.Windows.Forms.Button();
            this.lblDivider    = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // ???????????????????????????????????????
            //  Left Branding Panel
            // ???????????????????????????????????????
            this.pnlLeft.Location  = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size      = new System.Drawing.Size(260, 480);
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(45, 62, 80);

            this.lblBrand.Text      = "SHOP";
            this.lblBrand.Font      = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location  = new System.Drawing.Point(80, 120);
            this.lblBrand.AutoSize  = true;
            this.lblBrand.BackColor = System.Drawing.Color.Transparent;

            this.lblBrandSub.Text      = "E-Commerce\nApplication";
            this.lblBrandSub.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBrandSub.ForeColor = System.Drawing.Color.White;
            this.lblBrandSub.Location  = new System.Drawing.Point(42, 210);
            this.lblBrandSub.AutoSize  = true;
            this.lblBrandSub.BackColor = System.Drawing.Color.Transparent;
            this.lblBrandSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.pnlLeft.Controls.Add(this.lblBrand);
            this.pnlLeft.Controls.Add(this.lblBrandSub);

            // ???????????????????????????????????????
            //  Right Form Panel
            // ???????????????????????????????????????
            this.pnlRight.Location  = new System.Drawing.Point(260, 0);
            this.pnlRight.Size      = new System.Drawing.Size(400, 480);
            this.pnlRight.BackColor = System.Drawing.Color.White;

            // Welcome labels
            this.lblWelcome.Text      = "Welcome Back!";
            this.lblWelcome.Font      = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(45, 62, 80);
            this.lblWelcome.Location  = new System.Drawing.Point(50, 60);
            this.lblWelcome.AutoSize  = true;

            this.lblWelcomeSub.Text      = "Sign in to your account";
            this.lblWelcomeSub.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.lblWelcomeSub.ForeColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.lblWelcomeSub.Location  = new System.Drawing.Point(52, 100);
            this.lblWelcomeSub.AutoSize  = true;

            // Username
            this.lblUsername.Text      = "Username";
            this.lblUsername.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(45, 62, 80);
            this.lblUsername.Location  = new System.Drawing.Point(50, 155);
            this.lblUsername.AutoSize  = true;

            this.txtUsername.Location    = new System.Drawing.Point(50, 182);
            this.txtUsername.Size        = new System.Drawing.Size(300, 30);
            this.txtUsername.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Password
            this.lblPassword.Text      = "Password";
            this.lblPassword.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(45, 62, 80);
            this.lblPassword.Location  = new System.Drawing.Point(50, 235);
            this.lblPassword.AutoSize  = true;

            this.txtPassword.Location            = new System.Drawing.Point(50, 262);
            this.txtPassword.Size                = new System.Drawing.Size(300, 30);
            this.txtPassword.Font                = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.BorderStyle         = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.UseSystemPasswordChar = true;

            // Login Button
            this.btnLogin.Text      = "Sign In";
            this.btnLogin.Location  = new System.Drawing.Point(50, 325);
            this.btnLogin.Size      = new System.Drawing.Size(300, 45);
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Click    += new System.EventHandler(this.btnLogin_Click);

            // Divider
            this.lblDivider.Text      = "-----------  or  -----------";
            this.lblDivider.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDivider.ForeColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.lblDivider.Location  = new System.Drawing.Point(82, 385);
            this.lblDivider.AutoSize  = true;

            // Register Button
            this.btnRegister.Text      = "Create New Account";
            this.btnRegister.Location  = new System.Drawing.Point(50, 415);
            this.btnRegister.Size      = new System.Drawing.Size(300, 40);
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.BackColor = System.Drawing.Color.White;
            this.btnRegister.ForeColor = System.Drawing.Color.FromArgb(45, 62, 80);
            this.btnRegister.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegister.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(45, 62, 80);
            this.btnRegister.FlatAppearance.BorderSize  = 2;
            this.btnRegister.Click    += new System.EventHandler(this.btnRegister_Click);

            this.pnlRight.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblWelcome, this.lblWelcomeSub,
                this.lblUsername, this.txtUsername,
                this.lblPassword, this.txtPassword,
                this.btnLogin, this.lblDivider, this.btnRegister
            });

            // ???????????????????????????????????????
            //  LoginForm
            // ???????????????????????????????????????
            this.ClientSize      = new System.Drawing.Size(660, 480);
            this.BackColor       = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Text            = "E-Commerce - Sign In";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode   = System.Windows.Forms.AutoScaleMode.Font;
            this.ResumeLayout(false);
        }
    }
}
