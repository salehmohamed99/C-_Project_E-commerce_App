using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Presentation.Forms
{
    public partial class ProductBrowsingForm : Form
    {
        private ApplicationDbContext _context;
        private IGenericRepository<Product, int> _productRepository;
        private IGenericRepository<Cart, int> _cartRepository;
        private int _userId;

        public ProductBrowsingForm(ApplicationDbContext context, int userId)
        {
            InitializeComponent();
            _context = context;
            _userId = userId;
            _productRepository = new GenericRepository<Product, int>(_context);
            _cartRepository    = new GenericRepository<Cart, int>(_context);
            LoadProducts();
        }

        private void LoadProducts()
        {
            dgvProducts.Rows.Clear();
            var products = _productRepository.GetAllEntitys()
                .Where(p => p.IsActive && !p.IsDeleted && p.UnitsInStock > 0).ToList();
            foreach (var product in products)
                dgvProducts.Rows.Add(product.ID, LoadProductImage(product.Image), product.Name, product.Price, product.UnitsInStock, "View", "Add");
        }

        private Image? LoadProductImage(string? imagePath)
        {
            if (!string.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath))
            {
                try
                {
                    using var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
                    using var ms = new MemoryStream();
                    fs.CopyTo(ms);
                    ms.Position = 0;
                    using var img = Image.FromStream(ms);
                    return (Image)img.Clone();
                }
                catch { }
            }
            return CreatePlaceholder();
        }

        private static Image CreatePlaceholder()
        {
            var bmp = new Bitmap(60, 50);
            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.WhiteSmoke);
            using var pen = new Pen(Color.LightGray, 1);
            g.DrawRectangle(pen, 0, 0, 59, 49);
            using var font = new Font("Arial", 6f);
            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString("No Image", font, Brushes.Gray, new RectangleF(0, 0, 60, 50), sf);
            return bmp;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvProducts.Rows.Clear();
            var term = txtSearch.Text;
            var products = _productRepository.GetAllEntitys()
                .Where(p => p.IsActive && !p.IsDeleted && p.Name.Contains(term)).ToList();
            foreach (var product in products)
                dgvProducts.Rows.Add(product.ID, LoadProductImage(product.Image), product.Name, product.Price, product.UnitsInStock, "View", "Add");
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
