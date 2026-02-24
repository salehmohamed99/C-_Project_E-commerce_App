using Application.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Services
{
    public interface IProductCustomerService
    {
        IQueryable<ProductDto> GetAll();              
        ProductDto GetById(int id);                   
       
        IEnumerable<ProductDto> SearchByName(string name);
    }
}
