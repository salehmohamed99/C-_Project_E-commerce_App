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
            _context        = context;
            _userRepository = new GenericRepository<User, int>(_context);
            _cartRepository = new GenericRepository<Cart, int>(_context);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill all required fields!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_userRepository.GetAllEntitys().Any(u => u.UserName == txtUsername.Text))
            {
                MessageBox.Show("Username already exists!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var cart = new Cart { TotalPrice = 0 };
            _cartRepository.Add(cart);
            _cartRepository.SaveChanges();

            var user = new User
            {
                Name        = txtName.Text,
                UserName    = txtUsername.Text,
                Email       = txtEmail.Text,
                Password    = txtPassword.Text,
                PhoneNumber = txtPhone.Text,
                Address     = txtAddress.Text,
                CartID      = cart.ID,
                Role        = Role.Customer
            };

            _userRepository.Add(user);
            _userRepository.SaveChanges();

            MessageBox.Show("Registration successful! You can now login.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();
    }
}
