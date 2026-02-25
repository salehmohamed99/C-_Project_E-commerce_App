using Application.DTOs.ProductDTOs;
using System.Collections.Generic;

namespace Application.Interfaces.Services
{
    public interface IProductAdminService
    {
        IQueryable<ProductDto> GetAll();
        ProductDto GetById(int id);
        ProductDto Create(CreateProductDto dto);
        ProductDto Update(int id, UpdateProductDto dto);
        void Delete(int id);
    }
}
