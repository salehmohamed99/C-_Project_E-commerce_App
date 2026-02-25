using System;
using Application.DTOs.ProductDTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Mapster;

namespace Application.Services
{
    public class ProductAdminService : IProductAdminService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductAdminService(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository
        )
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IQueryable<ProductDto> GetAll()
        {
            return _productRepository
                .GetAllEntitys()
                .Where(p => p.IsActive)
                .Select(p => new ProductDto
                {
                    ID = p.ID,
                    Name = p.Name,
                    Image = p.Image,
                    Price = p.Price,
                    Description = p.Description,
                    UnitsInStock = p.UnitsInStock,
                    IsActive = p.IsActive,
                    CategoryId = p.CategoryId,
                    CategoryName = p.category != null ? p.category.Name : "N/A",
                });
        }

        public ProductDto Create(CreateProductDto dto)
        {
            var product = dto.Adapt<Product>();
            _productRepository.Add(product);
            _productRepository.SaveChanges();
            return product.Adapt<ProductDto>();
        }

        public ProductDto Update(int id, UpdateProductDto dto)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
                throw new KeyNotFoundException($"Product with Id {id} not found.");

            dto.Adapt(product);
            product.UpdatePrice(dto.Price);
            _productRepository.Update(product);
            _productRepository.SaveChanges();
            return product.Adapt<ProductDto>();
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

        public void Activate(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
                throw new KeyNotFoundException($"Product with Id {id} not found.");

            product.IsDeleted = false;
            _productRepository.Update(product);
            _productRepository.SaveChanges();
        }

        public void Restock(int id, RestockProductDto dto)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
                throw new KeyNotFoundException($"Product with Id {id} not found.");

            product.Restock(dto.Quantity);
            _productRepository.Update(product);
            _productRepository.SaveChanges();
        }

        public IEnumerable<ProductDto> GetByCategory(int categoryId)
        {
            return _productRepository
                .GetAllEntitys()
                .Where(p => p.IsActive && p.CategoryId == categoryId)
                .Select(p => new ProductDto
                {
                    ID = p.ID,
                    Name = p.Name,
                    Image = p.Image,
                    Price = p.Price,
                    Description = p.Description,
                    UnitsInStock = p.UnitsInStock,
                    IsActive = p.IsActive,
                    CategoryId = p.CategoryId,
                    CategoryName = p.category != null ? p.category.Name : "N/A",
                })
                .ToList();
        }

        public ProductDto GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
