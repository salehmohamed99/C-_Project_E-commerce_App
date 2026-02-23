using System;
using System.Windows.Forms;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Presentation.Forms
{
    public partial class RegisterForm : Form
    {
        private ApplicationDbContext _context;
        private IGenericRepository<User, int> _userRepository;
        private IGenericRepository<Cart, int> _cartRepository;

        public RegisterForm(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
            _userRepository = new GenericRepository<User, int>(_context);
            _cartRepository = new GenericRepository<Cart, int>(_context);
        }

        private void InitializeComponent()
        {
            this.Text = "Register";
            this.Size = new Size(500, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Title Label
            Label lblTitle = new Label();
            lblTitle.Text = "Create Account";
            lblTitle.Font = new Font("Arial", 14, FontStyle.Bold);
            lblTitle.Location = new Point(50, 20);
            lblTitle.Size = new Size(200, 25);
            this.Controls.Add(lblTitle);

            int yPosition = 70;

            // Full Name
            Label lblName = new Label();
            lblName.Text = "Full Name:";
            lblName.Location = new Point(50, yPosition);
            this.Controls.Add(lblName);

            TextBox txtName = new TextBox();
            txtName.Name = "txtName";
            txtName.Location = new Point(50, yPosition + 25);
            txtName.Size = new Size(350, 25);
            this.Controls.Add(txtName);
            yPosition += 60;

            // Username
            Label lblUsername = new Label();
            lblUsername.Text = "Username:";
            lblUsername.Location = new Point(50, yPosition);
            this.Controls.Add(lblUsername);

            TextBox txtUsername = new TextBox();
            txtUsername.Name = "txtUsername";
            txtUsername.Location = new Point(50, yPosition + 25);
            txtUsername.Size = new Size(350, 25);
            this.Controls.Add(txtUsername);
            yPosition += 60;

            // Email
            Label lblEmail = new Label();
            lblEmail.Text = "Email:";
            lblEmail.Location = new Point(50, yPosition);
            this.Controls.Add(lblEmail);

            TextBox txtEmail = new TextBox();
            txtEmail.Name = "txtEmail";
            txtEmail.Location = new Point(50, yPosition + 25);
            txtEmail.Size = new Size(350, 25);
            this.Controls.Add(txtEmail);
            yPosition += 60;

            // Password
            Label lblPassword = new Label();
            lblPassword.Text = "Password:";
            lblPassword.Location = new Point(50, yPosition);
            this.Controls.Add(lblPassword);

            TextBox txtPassword = new TextBox();
            txtPassword.Name = "txtPassword";
            txtPassword.Location = new Point(50, yPosition + 25);
            txtPassword.Size = new Size(350, 25);
            txtPassword.UseSystemPasswordChar = true;
            this.Controls.Add(txtPassword);
            yPosition += 60;

            // Phone
            Label lblPhone = new Label();
            lblPhone.Text = "Phone:";
            lblPhone.Location = new Point(50, yPosition);
            this.Controls.Add(lblPhone);

            TextBox txtPhone = new TextBox();
            txtPhone.Name = "txtPhone";
            txtPhone.Location = new Point(50, yPosition + 25);
            txtPhone.Size = new Size(350, 25);
            this.Controls.Add(txtPhone);
            yPosition += 60;

            // Address
            Label lblAddress = new Label();
            lblAddress.Text = "Address:";
            lblAddress.Location = new Point(50, yPosition);
            this.Controls.Add(lblAddress);

            TextBox txtAddress = new TextBox();
            txtAddress.Name = "txtAddress";
            txtAddress.Location = new Point(50, yPosition + 25);
            txtAddress.Size = new Size(350, 25);
            this.Controls.Add(txtAddress);
            yPosition += 60;

            // Register Button
            Button btnRegister = new Button();
            btnRegister.Text = "Register";
            btnRegister.Location = new Point(150, yPosition);
            btnRegister.Size = new Size(100, 30);
            btnRegister.Click += (s, e) => RegisterUser(
                txtName.Text,
                txtUsername.Text,
                txtEmail.Text,
                txtPassword.Text,
                txtPhone.Text,
                txtAddress.Text
            );
            this.Controls.Add(btnRegister);

            // Cancel Button
            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(260, yPosition);
            btnCancel.Size = new Size(100, 30);
            btnCancel.Click += (s, e) => this.Close();
            this.Controls.Add(btnCancel);
        }

        private void RegisterUser(string name, string username, string email, string password, string phone, string address)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill all required fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if username exists
            if (_userRepository.GetAllEntitys().Any(u => u.UserName == username))
            {
                MessageBox.Show("Username already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create cart for customer
            var cart = new Cart { TotalPrice = 0 };
            _cartRepository.Add(cart);
            _cartRepository.SaveChanges();

            // Create user
            var user = new User
            {
                Name = name,
                UserName = username,
                Email = email,
                Password = password,
                PhoneNumber = phone,
                Address = address,
                CartID = cart.ID,
                Role = Role.Customer
            };

            _userRepository.Add(user);
            _userRepository.SaveChanges();

            MessageBox.Show("Registration successful!\nYou can now login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
