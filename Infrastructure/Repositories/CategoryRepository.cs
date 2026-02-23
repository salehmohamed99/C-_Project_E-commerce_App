using Application.DTOs.CategoryDTOs;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class CategoryRepository
     : GenericRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public IQueryable<Category> GetCategoriesWithProducts()
        {
            return _context.Categories
                           .Include(c => c.products);


        }

 
        public Category GetByName(string name)
        {
            return _context.Categories.
                FirstOrDefault(c => c.Name == name);
        }

        public bool HasProducts(int categoryId)
        {
            return _context.Products.Any(p => p.CategoryId == categoryId);
        }

        public Category GetById(int id)
        {
            return _context.Categories
                          .Include(c => c.products)
                          .FirstOrDefault(c => c.ID == id);
        }
    }
}
