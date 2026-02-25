using System.Windows.Forms;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Presentation.Forms
{
    public partial class LoginForm : Form
    {
        private ApplicationDbContext _context;
        private IUserService _userService;

        public LoginForm()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            IGenericRepository<User, int> userRepository = new GenericRepository<User, int>(_context);
            _userService = new UserService(userRepository);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = _userService.Authenticate(txtUsername.Text, txtPassword.Text);

            if (user == null)
            {
                MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Need to map from UserDto back to Role for checking
            if (user.Role == Role.Admin.ToString())
                new AdminMainForm(_context).Show();
            else
                new CustomerMainForm(_context, user.Id).Show();

            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            new RegisterForm(_context).ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e) { }
    }
}
