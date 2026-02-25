using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ProductRepository : 
        GenericRepository<Product, int>, IProductRepository
        
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }


        IQueryable<Product> IGenericRepository<Product, int>.GetAllEntitys()
        {
            return _context.Products
                           .Include(p => p.category);
        }

        

        Product IProductRepository.GetById(int id)
        {
            return _context.Products.
                FirstOrDefault(p => p.ID == id);
        }

       
        IEnumerable<Product> IProductRepository.SearchByName(string name)
        {
            return _context.Products
                          .Include(p => p.category)
                          .Where(p => p.Name.Contains(name))
                          .ToList();
        }

        
    }
}
