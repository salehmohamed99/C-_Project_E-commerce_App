using Application.DTOs;
using Application.DTOs.OrderDTOs;
using Application.DTOs.OrderProductDTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;



namespace Application.Services
{
    public class OrderService : IOrderService
    {
        public IOrderRepository OrderRepository { get; set; }
        public IGenericRepository<CartItem, int> CartItemRepository { get; set; }
        public OrderService(IOrderRepository orderRepo, IGenericRepository<CartItem, int> cartItemRepo)
        {
            OrderRepository = orderRepo;
            CartItemRepository = cartItemRepo;
        }

       public async Task<OrderDTO> PlaceOrderFromCartAsync(int cartid)
        {
            var CartItems = CartItemRepository.GetAllEntitys().Where(c => c.CartId == cartid).ToList();
            if (!CartItems.Any()) 
                throw new Exception("Cart is empty.");

            var order = new Order
            {
                UserId = CartItems.FirstOrDefault().Cart.UserID,
                CreatedAt = DateTime.Now,
                Status = OrderStatus.Processing,
                TotalAmount = CartItems.Sum(ci => ci.Product.Price * ci.Quantity), // optional if Product has Price
                OrderProducts = CartItems.Select(ci => new OrderProduct
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity
                }).ToList()
            };


            OrderRepository.Add(order);
            await Task.Run(() => OrderRepository.SaveChanges());

            foreach (var item in CartItems)
            {
                CartItemRepository.Delete(item);
            }
            await Task.Run(() => CartItemRepository.SaveChanges());

            return order.Adapt<OrderDTO>();

        }

        //Admin: View All Customer's Orders
        public async Task<IEnumerable<OrderDTO>> GetUserOrdersAsync(int userId)
        {
            var orders =await Task.Run(() => OrderRepository.GetOrdersByUser(userId).ToList());
            return orders.Adapt<List<OrderDTO>>();
        }

        //Admin: Update Order Status

        public async Task UpdateOrderStatusAsync(UpdateOrderDTO dto)
        {
            var order = await Task.Run(() => OrderRepository.GetOrderWithDetails(dto.ID));
            if (order == null)
                throw new Exception("Order not found");

            order.Status = dto.Status;
            OrderRepository.Update(order);
            await Task.Run(() => OrderRepository.SaveChanges());
        }

        //Customer: Cancel Order (if not shipped)
        public async Task CancelOrderAsync(int orderId)
        {
            var order = await Task.Run(() => OrderRepository.GetOrderWithDetails(orderId));
            if (order == null)
                throw new Exception("Order not found");

            if (order.Status == OrderStatus.Shipped)
                throw new InvalidOperationException("Order Already Shipped.");

            order.Status = OrderStatus.Cancelled;
            OrderRepository.Update(order);
            await Task.Run(() => OrderRepository.SaveChanges());
        }
    }



}

