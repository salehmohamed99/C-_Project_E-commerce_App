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
        Task<OrderDTO> PlaceOrderFromCartAsync(int cartId);

        Task<IEnumerable<OrderDTO>> GetUserOrdersAsync(int userId);
        Task UpdateOrderStatusAsync(UpdateOrderDTO dto);
        Task CancelOrderAsync(int orderId); // soft delete only

    }
}
