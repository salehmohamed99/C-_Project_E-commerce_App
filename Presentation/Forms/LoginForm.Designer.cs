namespace Presentation.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblUsername
            this.lblUsername.Text = "Username:";
            this.lblUsername.Location = new System.Drawing.Point(50, 50);
            this.lblUsername.Size = new System.Drawing.Size(80, 20);

            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(150, 50);
            this.txtUsername.Size = new System.Drawing.Size(200, 25);

            // lblPassword
            this.lblPassword.Text = "Password:";
            this.lblPassword.Location = new System.Drawing.Point(50, 100);
            this.lblPassword.Size = new System.Drawing.Size(80, 20);

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(150, 100);
            this.txtPassword.Size = new System.Drawing.Size(200, 25);
            this.txtPassword.UseSystemPasswordChar = true;

            // btnLogin
            this.btnLogin.Text = "Login";
            this.btnLogin.Location = new System.Drawing.Point(150, 170);
            this.btnLogin.Size = new System.Drawing.Size(100, 30);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // btnRegister
            this.btnRegister.Text = "Register";
            this.btnRegister.Location = new System.Drawing.Point(260, 170);
            this.btnRegister.Size = new System.Drawing.Size(100, 30);
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // LoginForm
            this.ClientSize = new System.Drawing.Size(420, 250);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblUsername,
                this.txtUsername,
                this.lblPassword,
                this.txtPassword,
                this.btnLogin,
                this.btnRegister
            });
            this.Text = "E-commerce Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ResumeLayout(false);
        }
    }
}
