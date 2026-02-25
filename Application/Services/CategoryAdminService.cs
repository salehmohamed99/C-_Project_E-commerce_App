//using Application.DTOs.CategoryDTOs;
//using Application.Interfaces.Repositories;
//using Application.Interfaces.Services;
//using Domain.Entities;
//using Mapster;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Application.Services
//{
//    public class CategoryAdminService : ICategoryAdminService
//    {
//        private readonly ICategoryRepository _categoryRepository;

//        public CategoryAdminService(ICategoryRepository categoryRepository)
//        {
//            _categoryRepository = categoryRepository;
//        }

//        public IQueryable<CategoryDto> GetAll()
//        {
//            return _categoryRepository.GetAllEntitys()
//                .Where(c => !c.IsDeleted)
//                .Select(c => new CategoryDto
//                {
//                    Id = c.ID,
//                    Name = c.Name,
//                    ProductCount = c.products != null ? c.products.Count : 0,
//                    Created_At = c.CreatedAt
//                });
//        }

//        public CategoryDto Create(CreateCategoryDto dto)
//        {
//            var categoryName = _categoryRepository.GetByName(dto.Name);
//            if(categoryName != null)
//                throw new InvalidOperationException($"A category named '{dto.Name}' already exists.");

//            var category = dto.Adapt<Category>();

//            _categoryRepository.Add(category);
//            _categoryRepository.SaveChanges();

//            return category.Adapt<CategoryDto>();

//        }

//        public void Delete(int id)
//        {
//            var category = _categoryRepository.GetById(id);
//            if (category == null)
//                throw new KeyNotFoundException($"Category with Id {id} not found.");


//            if (_categoryRepository.HasProducts(id))
//                throw new InvalidOperationException($"Cannot delete '{category.Name}' — it still has products.");

//            _categoryRepository.Delete(category);
//            _categoryRepository.SaveChanges();
//        }

//        public CategoryDto Update(int id, UpdateCategoryDto dto)
//        {
//            var category = _categoryRepository.GetById(id);
//            if (category == null)
//                throw new KeyNotFoundException($"Category with Id {id} not found.");

//            var existing = _categoryRepository.GetByName(dto.Name);
//            if (existing != null && existing.ID != id)
//                throw new InvalidOperationException($"A category named '{dto.Name}' already exists.");

//            category.Rename(dto.Name);

//            _categoryRepository.Update(category);
//            _categoryRepository.SaveChanges();

//            return category.Adapt<CategoryDto>();
//        }
//    }
//}

using Application.DTOs.CategoryDTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Mapster;
using System;

namespace Application.Services
{
    public class CategoryAdminService : ICategoryAdminService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryAdminService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IQueryable<CategoryDto> GetAll()
        {
            return _categoryRepository.GetAllEntitys()
                           .Where(c => c.IsActive)
                           .Select(c => new CategoryDto
                           {
                               Id = c.ID,
                               Name = c.Name,
                               IsActive = c.IsActive
                           });
        }

        public CategoryDto Create(CreateCategoryDto dto)
        {
            var existing = _categoryRepository.GetByName(dto.Name);
            if (existing != null)
                throw new InvalidOperationException($"A category named '{dto.Name}' already exists.");

            var category = dto.Adapt<Category>();
            _categoryRepository.Add(category);
            _categoryRepository.SaveChanges();
            return category.Adapt<CategoryDto>();
        }

        public void Delete(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
                throw new KeyNotFoundException($"Category with Id {id} not found.");

            category.Deactivate();
            _categoryRepository.SaveChanges();
        }

        public CategoryDto Update(int id, UpdateCategoryDto dto)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
                throw new KeyNotFoundException($"Category with Id {id} not found.");

            var existing = _categoryRepository.GetByName(dto.Name);
            if (existing != null && existing.ID != id)
                throw new InvalidOperationException($"A category named '{dto.Name}' already exists.");

            category.Rename(dto.Name);
            _categoryRepository.Update(category);
            _categoryRepository.SaveChanges();
            return category.Adapt<CategoryDto>();
        }
    }
}