using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Application.DTOs;
using Application.DTOs.ProductDTOs;
using Application.Interfaces.Services;

namespace Presentation.Forms
{
    public partial class ProductDetailsForm : Form
    {
        private readonly ProductDto _product;
        private readonly ICartItemService _cartItemService;
        private readonly int _cartId;

        private PictureBox picProduct;
        private Label lblName;
        private Label lblPrice;
        private Label lblStock;
        private Label lblCategory;
        private Label lblDescription;
        private NumericUpDown nudQuantity;
        private Button btnAddToCart;
        private Button btnBack;

        public ProductDetailsForm(ProductDto product, ICartItemService cartItemService, int cartId)
        {
            _product = product;
            _cartItemService = cartItemService;
            _cartId = cartId;
            InitializeFormComponents();
            LoadProductData();
        }

        private void InitializeFormComponents()
        {
            this.Text = "Product Details";
            this.ClientSize = new Size(500, 520);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(245, 247, 250);

            var pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(45, 62, 80),
            };
            var lblTitle = new Label
            {
                Text = "Product Details",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(25, 12),
                AutoSize = true,
                BackColor = Color.Transparent,
            };
            pnlHeader.Controls.Add(lblTitle);

            picProduct = new PictureBox
            {
                Location = new Point(25, 80),
                Size = new Size(180, 150),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
            };

            lblName = new Label
            {
                Location = new Point(220, 80),
                Size = new Size(260, 30),
                Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 62, 80),
            };

            lblPrice = new Label
            {
                Location = new Point(220, 115),
                Size = new Size(260, 25),
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(39, 174, 96),
            };

            lblStock = new Label
            {
                Location = new Point(220, 145),
                Size = new Size(260, 25),
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(127, 140, 141),
            };

            lblCategory = new Label
            {
                Location = new Point(220, 170),
                Size = new Size(260, 25),
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(127, 140, 141),
            };

            var lblDescTitle = new Label
            {
                Text = "Description:",
                Location = new Point(25, 250),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 62, 80),
            };

            lblDescription = new Label
            {
                Location = new Point(25, 275),
                Size = new Size(450, 100),
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(80, 80, 80),
            };

            var pnlCart = new Panel
            {
                Location = new Point(25, 390),
                Size = new Size(450, 50),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
            };

            var lblQty = new Label
            {
                Text = "Quantity:",
                Location = new Point(10, 14),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 62, 80),
            };

            nudQuantity = new NumericUpDown
            {
                Location = new Point(100, 10),
                Size = new Size(80, 30),
                Minimum = 1,
                Maximum = 9999,
                Value = 1,
                Font = new Font("Segoe UI", 10F),
            };

            btnAddToCart = new Button
            {
                Text = "Add to Cart",
                Location = new Point(200, 6),
                Size = new Size(230, 38),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(39, 174, 96),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Cursor = Cursors.Hand,
            };
            btnAddToCart.FlatAppearance.BorderSize = 0;
            btnAddToCart.Click += BtnAddToCart_Click;

            pnlCart.Controls.AddRange([lblQty, nudQuantity, btnAddToCart]);

            btnBack = new Button
            {
                Text = "Back",
                Location = new Point(355, 460),
                Size = new Size(120, 40),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(45, 62, 80),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Click += (s, e) => this.Close();

            this.Controls.AddRange([
                pnlHeader,
                picProduct,
                lblName,
                lblPrice,
                lblStock,
                lblCategory,
                lblDescTitle,
                lblDescription,
                pnlCart,
                btnBack,
            ]);
        }

        private void LoadProductData()
        {
            lblName.Text = _product.Name;
            lblPrice.Text = $"${_product.Price:F2}";
            lblStock.Text = $"In Stock: {_product.UnitsInStock}";
            lblCategory.Text = $"Category: {_product.CategoryName}";
            lblDescription.Text = _product.Description;

            nudQuantity.Maximum = _product.UnitsInStock > 0 ? _product.UnitsInStock : 1;
            btnAddToCart.Enabled = _product.UnitsInStock > 0;

            if (_product.UnitsInStock <= 0)
            {
                lblStock.ForeColor = Color.FromArgb(231, 76, 60);
                lblStock.Text = "Out of Stock";
                btnAddToCart.BackColor = Color.Gray;
            }

            picProduct.Image = LoadProductImage(_product.Image);
        }

        private void BtnAddToCart_Click(object? sender, EventArgs e)
        {
            if (_cartId <= 0)
            {
                MessageBox.Show(
                    "No cart found!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            int quantity = (int)nudQuantity.Value;

            if (quantity <= 0)
            {
                MessageBox.Show(
                    "Quantity must be at least 1.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (quantity > _product.UnitsInStock)
            {
                MessageBox.Show(
                    $"Requested quantity ({quantity}) exceeds available stock ({_product.UnitsInStock}).",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                var dto = new AddCartItemDto { ProductId = _product.ID, Quantity = quantity };
                _cartItemService.AddItem(_cartId, dto);
                MessageBox.Show(
                    "Product added to cart!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                this.DialogResult = DialogResult.OK;
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

        private static Image LoadProductImage(string? imagePath)
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

            var bmp = new Bitmap(180, 150);
            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.WhiteSmoke);
            using var pen = new Pen(Color.LightGray, 1);
            g.DrawRectangle(pen, 0, 0, 179, 149);
            using var font = new Font("Segoe UI", 10f);
            var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };
            g.DrawString("No Image", font, Brushes.Gray, new RectangleF(0, 0, 180, 150), sf);
            return bmp;
        }
    }
}
