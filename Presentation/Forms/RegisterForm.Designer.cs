namespace Presentation.Forms
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
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
            this.pnlHeader   = new System.Windows.Forms.Panel();
            this.lblTitle    = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
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

            // ??????????????????????????????????????????????????????????????????
            //  PALETTE
            // ??????????????????????????????????????????????????????????????????
            var clrDark = System.Drawing.Color.FromArgb(30, 42, 56);
            var clrAccent = System.Drawing.Color.FromArgb(52, 152, 219);
            var clrBg = System.Drawing.Color.White;
            var clrFieldBg = System.Drawing.Color.FromArgb(244, 247, 250);
            var clrTextPrimary = System.Drawing.Color.FromArgb(30, 42, 56);
            var clrTextMuted = System.Drawing.Color.FromArgb(149, 165, 166);

            // ??????????????????????????????????????????????????????????????????
            //  Header Panel
            // ??????????????????????????????????????????????????????????????????
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 100;
            this.pnlHeader.BackColor = clrBg;

            this.lblTitle.Text      = "Create Account";
            this.lblTitle.Font      = new System.Drawing.Font("Georgia", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = clrTextPrimary;
            this.lblTitle.Location  = new System.Drawing.Point(40, 20);
            this.lblTitle.AutoSize  = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;

            this.lblSubtitle.Text      = "Fill in your details to get started";
            this.lblSubtitle.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = clrTextMuted;
            this.lblSubtitle.Location  = new System.Drawing.Point(45, 60);
            this.lblSubtitle.AutoSize  = true;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;

            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            int fieldLeft  = 45;
            int fieldWidth = 380;
            int startY     = 110;
            int rowHeight  = 65;

            // ??????????????????????????????????????????????????????????????????
            //  Form Fields
            // ??????????????????????????????????????????????????????????????????

            // Full Name
            this.lblName.Text      = "FULL NAME *";
            this.lblName.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = clrTextPrimary;
            this.lblName.Location  = new System.Drawing.Point(fieldLeft, startY);
            this.lblName.AutoSize  = true;

            this.txtName.Location    = new System.Drawing.Point(fieldLeft, startY + 20);
            this.txtName.Size        = new System.Drawing.Size(fieldWidth, 32);
            this.txtName.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.BackColor   = clrFieldBg;

            // Username
            this.lblUsername.Text      = "USERNAME *";
            this.lblUsername.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = clrTextPrimary;
            this.lblUsername.Location  = new System.Drawing.Point(fieldLeft, startY + rowHeight);
            this.lblUsername.AutoSize  = true;

            this.txtUsername.Location    = new System.Drawing.Point(fieldLeft, startY + rowHeight + 20);
            this.txtUsername.Size        = new System.Drawing.Size(fieldWidth, 32);
            this.txtUsername.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.BackColor   = clrFieldBg;

            // Email
            this.lblEmail.Text      = "EMAIL *";
            this.lblEmail.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = clrTextPrimary;
            this.lblEmail.Location  = new System.Drawing.Point(fieldLeft, startY + 2 * rowHeight);
            this.lblEmail.AutoSize  = true;

            this.txtEmail.Location    = new System.Drawing.Point(fieldLeft, startY + 2 * rowHeight + 20);
            this.txtEmail.Size        = new System.Drawing.Size(fieldWidth, 32);
            this.txtEmail.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.BackColor   = clrFieldBg;

            // Password
            this.lblPassword.Text      = "PASSWORD *";
            this.lblPassword.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = clrTextPrimary;
            this.lblPassword.Location  = new System.Drawing.Point(fieldLeft, startY + 3 * rowHeight);
            this.lblPassword.AutoSize  = true;

            this.txtPassword.Location            = new System.Drawing.Point(fieldLeft, startY + 3 * rowHeight + 20);
            this.txtPassword.Size                = new System.Drawing.Size(fieldWidth, 32);
            this.txtPassword.Font                = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.BorderStyle         = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.BackColor           = clrFieldBg;
            this.txtPassword.UseSystemPasswordChar = true;

            // Phone
            this.lblPhone.Text      = "PHONE";
            this.lblPhone.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblPhone.ForeColor = clrTextPrimary;
            this.lblPhone.Location  = new System.Drawing.Point(fieldLeft, startY + 4 * rowHeight);
            this.lblPhone.AutoSize  = true;

            this.txtPhone.Location    = new System.Drawing.Point(fieldLeft, startY + 4 * rowHeight + 20);
            this.txtPhone.Size        = new System.Drawing.Size(fieldWidth, 32);
            this.txtPhone.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.BackColor   = clrFieldBg;

            // Address
            this.lblAddress.Text      = "ADDRESS";
            this.lblAddress.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblAddress.ForeColor = clrTextPrimary;
            this.lblAddress.Location  = new System.Drawing.Point(fieldLeft, startY + 5 * rowHeight);
            this.lblAddress.AutoSize  = true;

            this.txtAddress.Location    = new System.Drawing.Point(fieldLeft, startY + 5 * rowHeight + 20);
            this.txtAddress.Size        = new System.Drawing.Size(fieldWidth, 32);
            this.txtAddress.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.BackColor   = clrFieldBg;

            // ??????????????????????????????????????????????????????????????????
            //  Buttons
            // ??????????????????????????????????????????????????????????????????
            int btnY = startY + 6 * rowHeight + 20;

            this.btnRegister.Text      = "CREATE ACCOUNT";
            this.btnRegister.Location  = new System.Drawing.Point(fieldLeft, btnY);
            this.btnRegister.Size      = new System.Drawing.Size(380, 48);
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.BackColor = clrDark;
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegister.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.Click    += new System.EventHandler(this.btnRegister_Click);

            this.btnCancel.Text      = "Cancel";
            this.btnCancel.Location  = new System.Drawing.Point(fieldLeft, btnY + 60);
            this.btnCancel.Size      = new System.Drawing.Size(380, 40);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.BackColor = clrBg;
            this.btnCancel.ForeColor = clrTextPrimary;
            this.btnCancel.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 210, 220);
            this.btnCancel.FlatAppearance.BorderSize  = 1;
            this.btnCancel.Click    += new System.EventHandler(this.btnCancel_Click);

            // ??????????????????????????????????????????????????????????????????
            //  RegisterForm
            // ??????????????????????????????????????????????????????????????????
            this.ClientSize      = new System.Drawing.Size(470, btnY + 130);
            this.BackColor       = clrBg;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.Controls.Add(this.pnlHeader);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblName, this.txtName,
                this.lblUsername, this.txtUsername,
                this.lblEmail, this.txtEmail,
                this.lblPassword, this.txtPassword,
                this.lblPhone, this.txtPhone,
                this.lblAddress, this.txtAddress,
                this.btnRegister, this.btnCancel
            });
            this.Text            = "Create Account";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode   = System.Windows.Forms.AutoScaleMode.Font;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
