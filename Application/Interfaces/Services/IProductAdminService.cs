using Application.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Services
{
    public interface IProductAdminService
    {
      
        ProductDto Create(CreateProductDto dto);
        ProductDto Update(int id, UpdateProductDto dto);
        void Delete(int id);       
        void Activate(int id);
        void Restock(int id, RestockProductDto dto);
    }
}
