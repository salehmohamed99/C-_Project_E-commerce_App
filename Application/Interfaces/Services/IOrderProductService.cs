using Application.DTOs.OrderProductDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Services
{
    public interface IOrderProductService
    {
        Task<IEnumerable<OrderProductDTO>> ViewProductsByOrdersAsync(int orderId);
        Task UpdateOrderProductAsync(UpdateOrderProductDTO dto);
        Task AddOrderProductAsync(CreateOrderProductDTO dto, int orderId);
        Task CancelOrderProductAsync(int productId, int orderId);
    }
}
