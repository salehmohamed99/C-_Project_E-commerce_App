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
    public class OrderProductRepository : GenericRepository<OrderProduct, int>, IOrderProductRepository
    {
        public OrderProductRepository(ApplicationDbContext context)
            : base(context)
        {
        }
        public override IQueryable<OrderProduct> GetAllEntitys()
        {
            return _context.OrderProducts
                          .Include(op => op.order)
                          .Include(op => op.product);
        }

        public IQueryable<OrderProduct> GetProductsByOrder(int orderId)
        {
            return _context.OrderProducts
                          .Include(op => op.order)
                          .Include(op => op.product)
                          .Where(op => op.OrderId == orderId);
        }

        public IQueryable<OrderProduct> GetByProductId(int productId)
        {
            return _context.OrderProducts
                          .Include(op => op.order)
                          .Include(op => op.product)
                          .Where(op => op.ProductId == productId);
        }


        public OrderProduct GetByProductAndOrder(int productId, int orderId)
        {
            return _context.OrderProducts
                           .Include(op => op.order)
                           .Include(op => op.product)
                           .FirstOrDefault(op => op.ProductId == productId && op.OrderId == orderId);
        }



    }
}
