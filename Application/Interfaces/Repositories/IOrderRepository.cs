using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IOrderRepository :IGenericRepository<Order,int>
    {
        IQueryable<Order> GetOrdersWithProducts();
        IQueryable<Order> GetOrdersByUser(int userId);
        Order GetOrderWithDetails(int id);

    }
}
