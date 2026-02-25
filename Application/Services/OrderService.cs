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

       public async Task<OrderDTO> PlaceOrderFromCartAsync(int cartid, int userId, string shippingAddress)
        {
            var cartItems = CartItemRepository.GetAllEntitys()
                .Include(ci => ci.Product)
                .Where(c => c.CartId == cartid)
                .ToList();
            
            if (!cartItems.Any()) 
                throw new Exception("Cart is empty.");

            var order = new Order
            {
                UserId = userId,
                CreatedAt = DateTime.Now,
                Status = OrderStatus.Processing,
                TotalAmount = cartItems.Sum(ci => ci.Product.Price * ci.Quantity),
                ShippingAddress = shippingAddress,
                OrderProducts = cartItems.Select(ci => new OrderProduct
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                    UnitPrice = ci.Product.Price
                }).ToList()
            };

            OrderRepository.Add(order);

            foreach (var item in cartItems)
            {
                CartItemRepository.Delete(item);
            }
            await Task.Run(() => OrderRepository.SaveChanges());

            var orderDto = new OrderDTO
            {
                ID = order.ID,
                Status = order.Status,
                ShippingAddress = order.ShippingAddress,
                TotalAmount = order.TotalAmount,
                UserId = order.UserId,
                CreatedAt = order.CreatedAt,
                OrderProducts = order.OrderProducts.Select(op => new Application.DTOs.OrderProductDTOs.OrderProductDTO
                {
                    Id = op.ID,
                    OrderId = op.OrderId,
                    ProductId = op.ProductId,
                    Quantity = op.Quantity,
                    TotalPrice = op.UnitPrice * op.Quantity
                }).ToList()
            };

            return orderDto;
        }

        //Customer: View Their Orders
        public async Task<IEnumerable<OrderDTO>> GetUserOrdersAsync(int userId)
        {
            var orders = await Task.Run(() => 
                OrderRepository.GetOrdersByUser(userId)
                    .ToList()
            );

            return orders.Select(o => new OrderDTO
            {
                ID = o.ID,
                Status = o.Status,
                ShippingAddress = o.ShippingAddress,
                TotalAmount = o.TotalAmount,
                UserId = o.UserId,
                UserName = o.User?.Name,
                CreatedAt = o.CreatedAt,
                OrderProducts = o.OrderProducts?.Select(op => new Application.DTOs.OrderProductDTOs.OrderProductDTO
                {
                    Id = op.ID,
                    OrderId = op.OrderId,
                    ProductId = op.ProductId,
                    ProductName = op.product?.Name ?? "N/A",
                    Quantity = op.Quantity,
                    UnitPrice = op.UnitPrice,
                    TotalPrice = op.UnitPrice * op.Quantity
                }).ToList() ?? new List<Application.DTOs.OrderProductDTOs.OrderProductDTO>()
            }).ToList();
        }

        //Admin: View All Orders
        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await Task.Run(() => 
                OrderRepository.GetAllOrders()
                    .ToList()
            );

            return orders.Select(o => new OrderDTO
            {
                ID = o.ID,
                Status = o.Status,
                ShippingAddress = o.ShippingAddress,
                TotalAmount = o.TotalAmount,
                UserId = o.UserId,
                UserName = o.User?.Name,
                CreatedAt = o.CreatedAt,
                OrderProducts = o.OrderProducts?.Select(op => new Application.DTOs.OrderProductDTOs.OrderProductDTO
                {
                    Id = op.ID,
                    OrderId = op.OrderId,
                    ProductId = op.ProductId,
                    ProductName = op.product?.Name ?? "N/A",
                    Quantity = op.Quantity,
                    UnitPrice = op.UnitPrice,
                    TotalPrice = op.UnitPrice * op.Quantity
                }).ToList() ?? new List<Application.DTOs.OrderProductDTOs.OrderProductDTO>()
            }).ToList();
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

