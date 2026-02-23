using System.Windows.Forms;
using Infrastructure.Data;

namespace Presentation.Forms
{
    public partial class CustomerMainForm : Form
    {
        private ApplicationDbContext _context;
        private int _userId;

        public CustomerMainForm(ApplicationDbContext context, int userId)
        {
            InitializeComponent();
            _context = context;
            _userId = userId;
        }

        private void btnBrowse_Click(object sender, EventArgs e) =>
            new ProductBrowsingForm(_context, _userId).ShowDialog();

        private void btnCart_Click(object sender, EventArgs e) =>
            new CartForm(_context, _userId).ShowDialog();

        private void btnOrders_Click(object sender, EventArgs e) =>
            new MyOrdersForm(_context, _userId).ShowDialog();

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            new LoginForm().Show();
        }

        private void CustomerMainForm_Load(object sender, EventArgs e) { }
    }
}
