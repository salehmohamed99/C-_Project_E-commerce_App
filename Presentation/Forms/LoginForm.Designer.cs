//namespace Presentation.Forms
//{
//    partial class LoginForm
//    {
//        private System.ComponentModel.IContainer components = null;

//        private System.Windows.Forms.Panel pnlLeft;
//        private System.Windows.Forms.Label lblBrand;
//        private System.Windows.Forms.Label lblBrandSub;
//        private System.Windows.Forms.Panel pnlRight;
//        private System.Windows.Forms.Label lblWelcome;
//        private System.Windows.Forms.Label lblWelcomeSub;
//        private System.Windows.Forms.Label lblUsername;
//        private System.Windows.Forms.TextBox txtUsername;
//        private System.Windows.Forms.Label lblPassword;
//        private System.Windows.Forms.TextBox txtPassword;
//        private System.Windows.Forms.Button btnLogin;
//        private System.Windows.Forms.Button btnRegister;
//        private System.Windows.Forms.Label lblDivider;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//                components.Dispose();
//            base.Dispose(disposing);
//        }

//        private void InitializeComponent()
//        {
//            this.pnlLeft       = new System.Windows.Forms.Panel();
//            this.lblBrand      = new System.Windows.Forms.Label();
//            this.lblBrandSub   = new System.Windows.Forms.Label();
//            this.pnlRight      = new System.Windows.Forms.Panel();
//            this.lblWelcome    = new System.Windows.Forms.Label();
//            this.lblWelcomeSub = new System.Windows.Forms.Label();
//            this.lblUsername   = new System.Windows.Forms.Label();
//            this.txtUsername   = new System.Windows.Forms.TextBox();
//            this.lblPassword   = new System.Windows.Forms.Label();
//            this.txtPassword   = new System.Windows.Forms.TextBox();
//            this.btnLogin      = new System.Windows.Forms.Button();
//            this.btnRegister   = new System.Windows.Forms.Button();
//            this.lblDivider    = new System.Windows.Forms.Label();
//            this.SuspendLayout();

//            // ???????????????????????????????????????
//            //  Left Branding Panel
//            // ???????????????????????????????????????
//            this.pnlLeft.Location  = new System.Drawing.Point(0, 0);
//            this.pnlLeft.Size      = new System.Drawing.Size(260, 480);
//            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(45, 62, 80);

//            this.lblBrand.Text      = "SHOP";
//            this.lblBrand.Font      = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
//            this.lblBrand.ForeColor = System.Drawing.Color.White;
//            this.lblBrand.Location  = new System.Drawing.Point(80, 120);
//            this.lblBrand.AutoSize  = true;
//            this.lblBrand.BackColor = System.Drawing.Color.Transparent;

//            this.lblBrandSub.Text      = "E-Commerce\nApplication";
//            this.lblBrandSub.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
//            this.lblBrandSub.ForeColor = System.Drawing.Color.White;
//            this.lblBrandSub.Location  = new System.Drawing.Point(42, 210);
//            this.lblBrandSub.AutoSize  = true;
//            this.lblBrandSub.BackColor = System.Drawing.Color.Transparent;
//            this.lblBrandSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

//            this.pnlLeft.Controls.Add(this.lblBrand);
//            this.pnlLeft.Controls.Add(this.lblBrandSub);

//            // ???????????????????????????????????????
//            //  Right Form Panel
//            // ???????????????????????????????????????
//            this.pnlRight.Location  = new System.Drawing.Point(260, 0);
//            this.pnlRight.Size      = new System.Drawing.Size(400, 480);
//            this.pnlRight.BackColor = System.Drawing.Color.White;

//            // Welcome labels
//            this.lblWelcome.Text      = "Welcome Back!";
//            this.lblWelcome.Font      = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
//            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(45, 62, 80);
//            this.lblWelcome.Location  = new System.Drawing.Point(50, 60);
//            this.lblWelcome.AutoSize  = true;

//            this.lblWelcomeSub.Text      = "Sign in to your account";
//            this.lblWelcomeSub.Font      = new System.Drawing.Font("Segoe UI", 10F);
//            this.lblWelcomeSub.ForeColor = System.Drawing.Color.FromArgb(149, 165, 166);
//            this.lblWelcomeSub.Location  = new System.Drawing.Point(52, 100);
//            this.lblWelcomeSub.AutoSize  = true;

//            // Username
//            this.lblUsername.Text      = "Username";
//            this.lblUsername.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
//            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(45, 62, 80);
//            this.lblUsername.Location  = new System.Drawing.Point(50, 155);
//            this.lblUsername.AutoSize  = true;

//            this.txtUsername.Location    = new System.Drawing.Point(50, 182);
//            this.txtUsername.Size        = new System.Drawing.Size(300, 30);
//            this.txtUsername.Font        = new System.Drawing.Font("Segoe UI", 11F);
//            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

//            // Password
//            this.lblPassword.Text      = "Password";
//            this.lblPassword.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
//            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(45, 62, 80);
//            this.lblPassword.Location  = new System.Drawing.Point(50, 235);
//            this.lblPassword.AutoSize  = true;

//            this.txtPassword.Location            = new System.Drawing.Point(50, 262);
//            this.txtPassword.Size                = new System.Drawing.Size(300, 30);
//            this.txtPassword.Font                = new System.Drawing.Font("Segoe UI", 11F);
//            this.txtPassword.BorderStyle         = System.Windows.Forms.BorderStyle.FixedSingle;
//            this.txtPassword.UseSystemPasswordChar = true;

//            // Login Button
//            this.btnLogin.Text      = "Sign In";
//            this.btnLogin.Location  = new System.Drawing.Point(50, 325);
//            this.btnLogin.Size      = new System.Drawing.Size(300, 45);
//            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
//            this.btnLogin.ForeColor = System.Drawing.Color.White;
//            this.btnLogin.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
//            this.btnLogin.Cursor    = System.Windows.Forms.Cursors.Hand;
//            this.btnLogin.FlatAppearance.BorderSize = 0;
//            this.btnLogin.Click    += new System.EventHandler(this.btnLogin_Click);

//            // Divider
//            this.lblDivider.Text      = "-----------  or  -----------";
//            this.lblDivider.Font      = new System.Drawing.Font("Segoe UI", 9F);
//            this.lblDivider.ForeColor = System.Drawing.Color.FromArgb(189, 195, 199);
//            this.lblDivider.Location  = new System.Drawing.Point(82, 385);
//            this.lblDivider.AutoSize  = true;

//            // Register Button
//            this.btnRegister.Text      = "Create New Account";
//            this.btnRegister.Location  = new System.Drawing.Point(50, 415);
//            this.btnRegister.Size      = new System.Drawing.Size(300, 40);
//            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnRegister.BackColor = System.Drawing.Color.White;
//            this.btnRegister.ForeColor = System.Drawing.Color.FromArgb(45, 62, 80);
//            this.btnRegister.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
//            this.btnRegister.Cursor    = System.Windows.Forms.Cursors.Hand;
//            this.btnRegister.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(45, 62, 80);
//            this.btnRegister.FlatAppearance.BorderSize  = 2;
//            this.btnRegister.Click    += new System.EventHandler(this.btnRegister_Click);

//            this.pnlRight.Controls.AddRange(new System.Windows.Forms.Control[] {
//                this.lblWelcome, this.lblWelcomeSub,
//                this.lblUsername, this.txtUsername,
//                this.lblPassword, this.txtPassword,
//                this.btnLogin, this.lblDivider, this.btnRegister
//            });

//            // ???????????????????????????????????????
//            //  LoginForm
//            // ???????????????????????????????????????
//            this.ClientSize      = new System.Drawing.Size(660, 480);
//            this.BackColor       = System.Drawing.Color.White;
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
//            this.MaximizeBox     = false;
//            this.Controls.Add(this.pnlLeft);
//            this.Controls.Add(this.pnlRight);
//            this.Text            = "E-Commerce - Sign In";
//            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
//            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
//            this.AutoScaleMode   = System.Windows.Forms.AutoScaleMode.Font;
//            this.ResumeLayout(false);
//        }
//    }
//}


namespace Presentation.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        // Left Panel
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblBrandSub;
        private System.Windows.Forms.Label lblBrandIcon;

        // Right Panel
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
        private System.Windows.Forms.Panel pnlUserUnderline;
        private System.Windows.Forms.Panel pnlPassUnderline;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlLeft = new Panel();
            lblBrandIcon = new Label();
            lblBrand = new Label();
            lblBrandSub = new Label();
            pnlRight = new Panel();
            lblWelcome = new Label();
            lblWelcomeSub = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            pnlUserUnderline = new Panel();
            lblPassword = new Label();
            txtPassword = new TextBox();
            pnlPassUnderline = new Panel();
            btnLogin = new Button();
            lblDivider = new Label();
            btnRegister = new Button();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(30, 42, 56);
            pnlLeft.Controls.Add(lblBrandIcon);
            pnlLeft.Controls.Add(lblBrand);
            pnlLeft.Controls.Add(lblBrandSub);
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(260, 500);
            pnlLeft.TabIndex = 0;
            // 
            // lblBrandIcon
            // 
            lblBrandIcon.Location = new Point(0, 0);
            lblBrandIcon.Name = "lblBrandIcon";
            lblBrandIcon.Size = new Size(100, 23);
            lblBrandIcon.TabIndex = 0;
            // 
            // lblBrand
            // 
            lblBrand.BackColor = Color.Transparent;
            lblBrand.Font = new Font("Georgia", 34F, FontStyle.Bold);
            lblBrand.ForeColor = Color.White;
            lblBrand.Location = new Point(70, 155);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(120, 72);
            lblBrand.TabIndex = 1;
            lblBrand.Text = "SC";
            lblBrand.TextAlign = ContentAlignment.MiddleCenter;
            lblBrand.Click += lblBrand_Click;
            // 
            // lblBrandSub
            // 
            lblBrandSub.BackColor = Color.Transparent;
            lblBrandSub.Font = new Font("Segoe UI", 10F);
            lblBrandSub.ForeColor = Color.FromArgb(160, 190, 210);
            lblBrandSub.Location = new Point(28, 227);
            lblBrandSub.Name = "lblBrandSub";
            lblBrandSub.Size = new Size(200, 50);
            lblBrandSub.TabIndex = 2;
            lblBrandSub.Text = "Snap Cart\nE-Commerce Application";
            lblBrandSub.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.White;
            pnlRight.Controls.Add(lblWelcome);
            pnlRight.Controls.Add(lblWelcomeSub);
            pnlRight.Controls.Add(lblUsername);
            pnlRight.Controls.Add(txtUsername);
            pnlRight.Controls.Add(pnlUserUnderline);
            pnlRight.Controls.Add(lblPassword);
            pnlRight.Controls.Add(txtPassword);
            pnlRight.Controls.Add(pnlPassUnderline);
            pnlRight.Controls.Add(btnLogin);
            pnlRight.Controls.Add(lblDivider);
            pnlRight.Controls.Add(btnRegister);
            pnlRight.Location = new Point(260, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(420, 500);
            pnlRight.TabIndex = 1;
            // 
            // lblWelcome
            // 
            lblWelcome.Font = new Font("Georgia", 22F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(30, 42, 56);
            lblWelcome.Location = new Point(50, 60);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(320, 40);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome Back";
            // 
            // lblWelcomeSub
            // 
            lblWelcomeSub.AutoSize = true;
            lblWelcomeSub.Font = new Font("Segoe UI", 9.5F);
            lblWelcomeSub.ForeColor = Color.FromArgb(149, 165, 166);
            lblWelcomeSub.Location = new Point(50, 103);
            lblWelcomeSub.Name = "lblWelcomeSub";
            lblWelcomeSub.Size = new Size(252, 21);
            lblWelcomeSub.TabIndex = 1;
            lblWelcomeSub.Text = "Sign in to your account to continue";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(30, 42, 56);
            lblUsername.Location = new Point(50, 155);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(84, 19);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "USERNAME";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(244, 247, 250);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.ForeColor = Color.FromArgb(30, 42, 56);
            txtUsername.Location = new Point(50, 177);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(320, 25);
            txtUsername.TabIndex = 3;
            // 
            // pnlUserUnderline
            // 
            pnlUserUnderline.BackColor = Color.FromArgb(52, 152, 219);
            pnlUserUnderline.Location = new Point(50, 209);
            pnlUserUnderline.Name = "pnlUserUnderline";
            pnlUserUnderline.Size = new Size(320, 2);
            pnlUserUnderline.TabIndex = 4;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(30, 42, 56);
            lblPassword.Location = new Point(50, 235);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(87, 19);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "PASSWORD";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(244, 247, 250);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.ForeColor = Color.FromArgb(30, 42, 56);
            txtPassword.Location = new Point(50, 257);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(320, 25);
            txtPassword.TabIndex = 6;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // pnlPassUnderline
            // 
            pnlPassUnderline.BackColor = Color.FromArgb(52, 152, 219);
            pnlPassUnderline.Location = new Point(50, 289);
            pnlPassUnderline.Name = "pnlPassUnderline";
            pnlPassUnderline.Size = new Size(320, 2);
            pnlPassUnderline.TabIndex = 7;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(30, 42, 56);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(50, 325);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(320, 48);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "SIGN IN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblDivider
            // 
            lblDivider.AutoSize = true;
            lblDivider.Font = new Font("Segoe UI", 8F);
            lblDivider.ForeColor = Color.FromArgb(200, 205, 210);
            lblDivider.Location = new Point(65, 390);
            lblDivider.Name = "lblDivider";
            lblDivider.Size = new Size(178, 19);
            lblDivider.TabIndex = 9;
            lblDivider.Text = "──────────  or  ──────────";
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.White;
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatAppearance.BorderColor = Color.FromArgb(200, 210, 220);
            btnRegister.FlatAppearance.MouseOverBackColor = Color.FromArgb(244, 247, 250);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 10F);
            btnRegister.ForeColor = Color.FromArgb(30, 42, 56);
            btnRegister.Location = new Point(50, 420);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(320, 44);
            btnRegister.TabIndex = 10;
            btnRegister.Text = "Create New Account";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(680, 500);
            Controls.Add(pnlLeft);
            Controls.Add(pnlRight);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "E-Commerce — Sign In";
            pnlLeft.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ResumeLayout(false);
        }
    }
}
