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
    
    public class ProductAdminService : IProductAdminService
    {
        
        IProductRepository _IProductRepository;

        public ProductAdminService(IProductRepository iProductRepository)
        {
            _IProductRepository = iProductRepository;
        }

        public void Activate(int id)
        {
            var product = _IProductRepository.GetById(id);
            product.Activate();
            _IProductRepository.Update(product);
            _IProductRepository.SaveChanges();

        }

        public ProductDto create(ProductDto productDTO)
        {
            var productName = _IProductRepository.GetById(productDTO.Id);
            if (productName.Name != null)
                throw new InvalidOperationException($"A product named '{productName.Name}' already exists.");

            var product = productDTO.Adapt<Product>();
            _IProductRepository.Add(product);
            _IProductRepository.SaveChanges();

            return product.Adapt<ProductDto>();

        }

        public ProductDto Create(CreateProductDto dto)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var product = _IProductRepository.GetById(id);
            product.Deactivate();

            _IProductRepository.Update(product);
            _IProductRepository.SaveChanges();
        }

        public void Restock(int id, RestockProductDto dto)
        {
            var product = _IProductRepository.GetById(id);
            
            product.Restock(dto.Quantity);

            _IProductRepository.Update(product);
            _IProductRepository.SaveChanges();
        }
        public ProductDto Update(int id, UpdateProductDto dto)
        {
            var product = _IProductRepository.GetById(id);
            dto.Adapt(product);

           
            product.UpdatePrice(dto.Price);


            _IProductRepository.Update(product);
            _IProductRepository.SaveChanges();
            return product.Adapt<ProductDto>();


        }
    }
}
