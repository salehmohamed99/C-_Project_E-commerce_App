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

        public async Task<Category> GetByNameAsync(string name)
        {
            return await _context.Categories
                                 .Include(c => c.products)
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<bool> HasProductsAsync(int categoryId)
        {
            return await _context.Products
                                 .AnyAsync(p => p.CategoryId == categoryId);
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
    }
}
