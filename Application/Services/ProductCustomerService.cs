using Application.DTOs.ProductDTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class ProductCustomerService : IProductCustomerService
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;

        public ProductCustomerService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IQueryable<ProductDto> GetAll()
        {
            return _productRepository.GetAllEntitys()
                .Adapt<IQueryable<ProductDto>>();
        }

       
        public ProductDto GetById(int id)
        {
            var product = _productRepository.GetById(id);
            return product.Adapt<ProductDto>();
        }

        public IEnumerable<ProductDto> SearchByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
