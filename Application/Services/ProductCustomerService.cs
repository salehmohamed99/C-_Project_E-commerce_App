using Application.DTOs.ProductDTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class ProductCustomerService : IProductCustomerService
    {
        private readonly IGenericRepository<Product, int> _productRepository;

        public ProductCustomerService(IGenericRepository<Product, int> productRepository)
        {
            _productRepository = productRepository;
        }

        public IQueryable<ProductDto> GetAvailableProducts()
        {
            return _productRepository
                .GetAllEntitys()
                .Where(p => p.IsActive && !p.IsDeleted && p.UnitsInStock > 0)
                .Select(p => new ProductDto
                {
                    Id = p.ID,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    UnitsInStock = p.UnitsInStock,
                    Image = p.Image,
                    CategoryId = p.CategoryId,
                    CategoryName = p.category.Name,
                    IsActive = p.IsActive
                });
        }

        public IQueryable<ProductDto> SearchProducts(string searchTerm)
        {
            return _productRepository
                .GetAllEntitys()
                .Where(p => p.IsActive && !p.IsDeleted && p.Name.Contains(searchTerm))
                .Select(p => new ProductDto
                {
                    Id = p.ID,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    UnitsInStock = p.UnitsInStock,
                    Image = p.Image,
                    CategoryId = p.CategoryId,
                    CategoryName = p.category.Name,
                    IsActive = p.IsActive
                });
        }

        public ProductDto GetById(int id)
        {
            var product = _productRepository
                .GetAllEntitys()
                .FirstOrDefault(p => p.ID == id && p.IsActive && !p.IsDeleted);

            if (product == null)
                throw new KeyNotFoundException($"Product with Id {id} not found.");

            return new ProductDto
            {
                Id = product.ID,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                UnitsInStock = product.UnitsInStock,
                Image = product.Image,
                CategoryId = product.CategoryId,
                CategoryName = product.category?.Name,
                IsActive = product.IsActive
            };
        }
    }
}
