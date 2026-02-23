using Application.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Services
{
    public interface ICategoryAdminService
    {
        CategoryDto Create(CreateCategoryDto dto);
        CategoryDto Update(int id, UpdateCategoryDto dto);
        void Delete(int id);
    }
}
