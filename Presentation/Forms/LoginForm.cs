using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Presentation.Forms
{
    public partial class LoginForm : Form
    {
        private ApplicationDbContext _context;
        private IGenericRepository<User, int> _userRepository;

        public LoginForm()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            _userRepository = new GenericRepository<User, int>(_context);
        }

        private void InitializeComponent()
        {
            this.Text = "E-commerce Login";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Username Label
            Label lblUsername = new Label();
            lblUsername.Text = "Username:";
            lblUsername.Location = new Point(50, 50);
            lblUsername.Size = new Size(80, 20);
            this.Controls.Add(lblUsername);

            // Username TextBox
            TextBox txtUsername = new TextBox();
            txtUsername.Name = "txtUsername";
            txtUsername.Location = new Point(150, 50);
            txtUsername.Size = new Size(200, 25);
            this.Controls.Add(txtUsername);

            // Password Label
            Label lblPassword = new Label();
            lblPassword.Text = "Password:";
            lblPassword.Location = new Point(50, 100);
            lblPassword.Size = new Size(80, 20);
            this.Controls.Add(lblPassword);

            // Password TextBox
            TextBox txtPassword = new TextBox();
            txtPassword.Name = "txtPassword";
            txtPassword.Location = new Point(150, 100);
            txtPassword.Size = new Size(200, 25);
            txtPassword.UseSystemPasswordChar = true;
            this.Controls.Add(txtPassword);

            // Login Button
            Button btnLogin = new Button();
            btnLogin.Text = "Login";
            btnLogin.Location = new Point(150, 170);
            btnLogin.Size = new Size(100, 30);
            btnLogin.Click += (s, e) => LoginButton_Click(txtUsername.Text, txtPassword.Text);
            this.Controls.Add(btnLogin);

            // Register Button
            Button btnRegister = new Button();
            btnRegister.Text = "Register";
            btnRegister.Location = new Point(250, 170);
            btnRegister.Size = new Size(100, 30);
            btnRegister.Click += (s, e) => OpenRegisterForm();
            this.Controls.Add(btnRegister);
        }

        private void LoginButton_Click(string username, string password)
        {
            var user = _userRepository
                .GetAllEntitys()
                .FirstOrDefault(u => u.UserName == username && u.Password == password && !u.IsDeleted);

            if (user == null)
            {
                MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (user.Role == Role.Admin)
            {
                AdminMainForm adminForm = new AdminMainForm(_context);
                adminForm.Show();
            }
            else
            {
                CustomerMainForm customerForm = new CustomerMainForm(_context, user.ID);
                customerForm.Show();
            }

            this.Hide();
        }

        private void OpenRegisterForm()
        {
            RegisterForm registerForm = new RegisterForm(_context);
            registerForm.ShowDialog();
        }
    }
}
