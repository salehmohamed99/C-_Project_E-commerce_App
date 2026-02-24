using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;
using Application.DTOs.OrderProductDTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class OrderProductService : IOrderProductService
    {
        public IOrderProductRepository _orderProductRepository { get; set; }

        public OrderProductService(IOrderProductRepository orderProductRepository)
        {
            _orderProductRepository = orderProductRepository;
        }


        public async Task<IEnumerable<OrderProductDTO>> ViewProductsByOrdersAsync(int orderId)
        {
            var Products = await Task.Run(() => _orderProductRepository.GetProductsByOrder(orderId).ToList());
            return Products.Adapt<List<OrderProductDTO>>();
        }


        public async Task UpdateOrderProductAsync(UpdateOrderProductDTO dto)
        {
            var orderProduct = await Task.Run(() =>
                _orderProductRepository.GetByProductAndOrder(dto.productId, dto.orderId)
            );

            if (orderProduct == null)
                throw new Exception("OrderProduct not found");

            orderProduct.Quantity = dto.Quantity;
            _orderProductRepository.Update(orderProduct);
            await Task.Run(() => _orderProductRepository.SaveChanges());
        }


        public async Task AddOrderProductAsync(CreateOrderProductDTO dto, int orderId)
        {
            var orderProduct = new OrderProduct
            {
                OrderId = orderId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };

            _orderProductRepository.Add(orderProduct);
            await Task.Run(() => _orderProductRepository.SaveChanges());
        }



        public async Task CancelOrderProductAsync(int productId, int orderId)
        {
            var orderProduct = await Task.Run(() =>
                _orderProductRepository.GetByProductAndOrder(productId, orderId)
            );

            if (orderProduct == null)
                throw new Exception("OrderProduct not found");

            orderProduct.IsDeleted = true; // soft delete
            _orderProductRepository.Update(orderProduct);
            await Task.Run(() => _orderProductRepository.SaveChanges());
        }



    }
}
