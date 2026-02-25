using System.Windows.Forms;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Application.DTOs.UserDto;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Presentation.Forms
{
    public partial class RegisterForm : Form
    {
        private ApplicationDbContext _context;
        private IUserService _userService;
        private ICartService _cartService;
        private IGenericRepository<Cart, int> _cartRepository;

        public RegisterForm(ApplicationDbContext context)
        {
            InitializeComponent();
            _context        = context;
            _cartRepository = new GenericRepository<Cart, int>(_context);
            IGenericRepository<User, int> userRepository = new GenericRepository<User, int>(_context);
            _userService = new UserService(userRepository);
            _cartService = new CartServices(_cartRepository);
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

            try
            {
                var cart = new Cart { TotalPrice = 0 };
                _cartRepository.Add(cart);
                _cartRepository.SaveChanges();

                var dto = new CreateUserDto
                {
                    Name = txtName.Text,
                    UserName = txtUsername.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    Phone_Number = txtPhone.Text,
                    Address = txtAddress.Text,
                };

                _userService.Create(dto);

                MessageBox.Show("Registration successful! You can now login.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();
    }
}
