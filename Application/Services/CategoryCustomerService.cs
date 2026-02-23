using Application.DTOs.CategoryDTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class CategoryCustomerService : ICategoryCustomerService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryCustomerService(ICategoryRepository categoryRepository)
        {
           _categoryRepository = categoryRepository;
        }

        public IQueryable<CategoryDto> GetAll()
        {
            return _categoryRepository.GetAllEntitys()
                                      .Adapt<IQueryable<CategoryDto>>();
        }

        public CategoryDto GetById(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
                throw new KeyNotFoundException($"Category with Id {id} not found.");

            return category.Adapt<CategoryDto>();
        }
    }
}
