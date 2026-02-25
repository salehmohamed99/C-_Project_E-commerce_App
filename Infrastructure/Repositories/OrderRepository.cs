using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.CategoryDTOs;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order, int>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context)
            : base(context) { }

        public override IQueryable<Order> GetAllEntitys()
        {
            return _context.Orders.Include(o => o.OrderProducts).Include(op => op.User);
        }

        public IQueryable<Order> GetOrdersWithProducts()
        {
            return _context.Orders.Include(o => o.OrderProducts);
        }

        public IQueryable<Order> GetAllOrders()
        {
            return _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.product)
                .Where(o => !o.IsDeleted);
        }

        public IQueryable<Order> GetOrdersByUser(int userId)
        {
            return _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.product)
                .Where(o => o.UserId == userId && !o.IsDeleted);
        }

        public Order GetOrderWithDetails(int id)
        {
            return _context
                .Orders.Include(o => o.OrderProducts)
                    .ThenInclude(op => op.product)
                .Include(o => o.User)
                .FirstOrDefault(o => o.ID == id);
        }

        public Task AddAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
