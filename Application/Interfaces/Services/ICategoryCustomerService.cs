using Application.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Services
{
    public interface ICategoryCustomerService
    {
        IQueryable<CategoryDto> GetAll();
        CategoryDto GetById(int id);
    }
            
}
