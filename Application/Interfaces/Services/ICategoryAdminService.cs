using Application.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Application.Interfaces.Services
{
    public interface ICategoryAdminService
    {
        IQueryable<CategoryDto> GetAll();
        CategoryDto Create(CreateCategoryDto dto);
        CategoryDto Update(int id, UpdateCategoryDto dto);
        void Delete(int id);
    }
}
