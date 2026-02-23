using System.Windows.Forms;
using Infrastructure.Data;

namespace Presentation.Forms
{
    public partial class AdminMainForm : Form
    {
        private ApplicationDbContext _context;

        public AdminMainForm(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void btnCategories_Click(object sender, EventArgs e) =>
            new CategoryManagementForm(_context).ShowDialog();

        private void btnProducts_Click(object sender, EventArgs e) =>
            new ProductManagementForm(_context).ShowDialog();

        private void btnOrders_Click(object sender, EventArgs e) =>
            new OrderTrackingForm(_context).ShowDialog();

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            new LoginForm().Show();
        }
    }
}
