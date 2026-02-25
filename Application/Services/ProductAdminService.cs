using Application.DTOs.ProductDTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Mapster;

namespace Application.Services
{
    public class ProductAdminService : IProductAdminService
    {
        private readonly IGenericRepository<Product, int> _productRepository;
        private readonly IGenericRepository<Category, int> _categoryRepository;

        public ProductAdminService(
            IGenericRepository<Product, int> productRepository,
            IGenericRepository<Category, int> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IQueryable<ProductDto> GetAll()
        {
            return _productRepository
                .GetAllEntitys()
                .Where(p => !p.IsDeleted)
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
                .FirstOrDefault(p => p.ID == id && !p.IsDeleted);

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

        public ProductDto Create(CreateProductDto dto)
        {
            var category = _categoryRepository.GetAllEntitys()
                .FirstOrDefault(c => c.ID == dto.CategoryId && !c.IsDeleted);

            if (category == null)
                throw new KeyNotFoundException($"Category with Id {dto.CategoryId} not found.");

            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                UnitsInStock = dto.UnitsInStock,
                Image = dto.Image,
                CategoryId = dto.CategoryId
            };

            _productRepository.Add(product);
            _productRepository.SaveChanges();

            return GetById(product.ID);
        }

        public ProductDto Update(int id, UpdateProductDto dto)
        {
            var product = _productRepository
                .GetAllEntitys()
                .FirstOrDefault(p => p.ID == id && !p.IsDeleted);

            if (product == null)
                throw new KeyNotFoundException($"Product with Id {id} not found.");

            var category = _categoryRepository.GetAllEntitys()
                .FirstOrDefault(c => c.ID == dto.CategoryId && !c.IsDeleted);

            if (category == null)
                throw new KeyNotFoundException($"Category with Id {dto.CategoryId} not found.");

            product.Name = dto.Name ?? product.Name;
            product.Description = dto.Description ?? product.Description;
            product.Price = dto.Price;
            product.UnitsInStock = dto.UnitsInStock;
            product.Image = dto.Image ?? product.Image;
            product.CategoryId = dto.CategoryId;

            _productRepository.Update(product);
            _productRepository.SaveChanges();

            return GetById(id);
        }

        public void Delete(int id)
        {
            var product = _productRepository
                .GetAllEntitys()
                .FirstOrDefault(p => p.ID == id && !p.IsDeleted);

            if (product == null)
                throw new KeyNotFoundException($"Product with Id {id} not found.");

            product.IsDeleted = true;
            _productRepository.Update(product);
            _productRepository.SaveChanges();
        }
    }
}
