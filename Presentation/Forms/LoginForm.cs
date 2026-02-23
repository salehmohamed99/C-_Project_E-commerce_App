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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = _userRepository
                .GetAllEntitys()
                .FirstOrDefault(u => u.UserName == txtUsername.Text
                                  && u.Password == txtPassword.Text
                                  && !u.IsDeleted);

            if (user == null)
            {
                MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (user.Role == Role.Admin)
                new AdminMainForm(_context).Show();
            else
                new CustomerMainForm(_context, user.ID).Show();

            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            new RegisterForm(_context).ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e) { }
    }
}
