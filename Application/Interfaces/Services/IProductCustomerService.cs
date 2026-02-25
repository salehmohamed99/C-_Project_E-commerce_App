using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.ProductDTOs;

namespace Application.Interfaces.Services
{
    public interface IProductCustomerService
    {
        IQueryable<ProductDto> GetAll();
        ProductDto GetById(int id);

        IEnumerable<ProductDto> SearchByName(string name);
    }
}
