using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class CartServices
    {
        public IGenericRepository<Cart, int> _cartRepository;

        public CartServices(IGenericRepository<Cart, int> cartRepository)
        {
            _cartRepository = cartRepository;
        }

        //public void Add(Cart entity) { }

        public void ClearCart(Cart entity)
        {
            var cart = _cartRepository
                .GetAllEntitys()
                .Include(c => c.CartItems)
                .Include(c => c.User)
                .FirstOrDefault(c => c.ID == entity.ID);

            if (cart is null)
                return;

            cart.CartItems.Clear();
            cart.TotalPrice = 0;
            cart.UpdatedAt = DateTime.Now;
            cart.UpdatedBy = cart.User.Name;

            _cartRepository.SaveChanges();
        }

        public IQueryable<CartDTO> GetAllEntitys()
        {
            return _cartRepository
                .GetAllEntitys()
                .Select(c => new CartDTO
                {
                    ID = c.ID,
                    UserID = c.UserID,
                    CartItems = c
                        .CartItems.Select(ci => new CartItemDto
                        {
                            CartId = c.ID,
                            ProductId = ci.ProductId,
                            Quantity = ci.Quantity,
                            ProductImage = ci.Product.Image,
                            ProductPrice = ci.Product.Price,
                        })
                        .ToList(),
                });
        }

        public IQueryable<CartDTO> GetCartByUserId(int userId)
        {
            return _cartRepository
                .GetAllEntitys()
                .Where(c => c.UserID == userId)
                .Select(c => new CartDTO
                {
                    ID = c.ID,
                    UserID = c.UserID,
                    CartItems = c
                        .CartItems.Select(ci => new CartItemDto
                        {
                            CartId = c.ID,
                            ProductId = ci.ProductId,
                            Quantity = ci.Quantity,
                            ProductImage = ci.Product.Image,
                            ProductPrice = ci.Product.Price,
                        })
                        .ToList(),
                });
        }
    }
}
