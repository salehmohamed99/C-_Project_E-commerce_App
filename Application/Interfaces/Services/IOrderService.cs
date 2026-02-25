using Application.DTOs;
using Application.DTOs.OrderDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task<OrderDTO> PlaceOrderFromCartAsync(int cartId, int userId, string shippingAddress);

        Task<IEnumerable<OrderDTO>> GetUserOrdersAsync(int userId);
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
        Task UpdateOrderStatusAsync(UpdateOrderDTO dto);
        Task CancelOrderAsync(int orderId); // soft delete only

    }
}
