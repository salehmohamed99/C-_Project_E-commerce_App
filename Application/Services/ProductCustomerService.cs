using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.ProductDTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Mapster;

namespace Application.Services
{
    public class ProductCustomerService : IProductCustomerService
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;

        public ProductCustomerService(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository
        )
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IQueryable<ProductDto> GetAll()
        {
            return _productRepository.GetAllEntitys().ToList().Adapt<List<ProductDto>>().AsQueryable();
        }

        public ProductDto GetById(int id)
        {
            var product = _productRepository.GetById(id);
            return product.Adapt<ProductDto>();
        }

        public IEnumerable<ProductDto> SearchByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Search name cannot be empty.");

            return _productRepository.SearchByName(name.Trim()).Adapt<IEnumerable<ProductDto>>();
        }
    }
}
