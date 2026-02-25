using System.Linq;
using System.Windows.Forms;
using Application.DTOs.UserDto;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
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
        private IGenericRepository<User, int> _userRepository;

        public RegisterForm(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
            _cartRepository = new GenericRepository<Cart, int>(_context);
            _userRepository = new GenericRepository<User, int>(_context);
            _userService = new UserService(_userRepository);
            _cartService = new CartServices(_cartRepository);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrWhiteSpace(txtName.Text)
                || string.IsNullOrWhiteSpace(txtUsername.Text)
                || string.IsNullOrWhiteSpace(txtEmail.Text)
                || string.IsNullOrWhiteSpace(txtPassword.Text)
            )
            {
                MessageBox.Show(
                    "Please fill all required fields!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show(
                    "Password must be at least 6 characters long!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (
                _userRepository
                    .GetAllEntitys()
                    .Any(u => u.Email == txtEmail.Text || u.UserName == txtUsername.Text)
            )
            {
                MessageBox.Show(
                    "Email or Username already exists!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show(
                    "Please enter a valid email address!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                var dto = new CreateUserDto
                {
                    Name = txtName.Text,
                    UserName = txtUsername.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    Phone_Number = txtPhone.Text,
                    Address = txtAddress.Text,
                };

                var userDto = _userService.Create(dto);

                var cart = new Cart { TotalPrice = 0, UserID = userDto.Id };
                _cartRepository.Add(cart);
                _cartRepository.SaveChanges();

                var user = _userRepository.GetAllEntitys().FirstOrDefault(u => u.ID == userDto.Id);
                if (user != null)
                {
                    user.CartID = cart.ID;
                    _userRepository.Update(user);
                    _userRepository.SaveChanges();
                }

                MessageBox.Show(
                    "Registration successful! You can now login.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();
    }
}
