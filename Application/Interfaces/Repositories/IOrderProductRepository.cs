using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IOrderProductRepository : IGenericRepository<OrderProduct, int>
    {
        IQueryable<OrderProduct> GetProductsByOrder(int orderId);
        IQueryable<OrderProduct> GetByProductId(int productId);

       

    }
}
