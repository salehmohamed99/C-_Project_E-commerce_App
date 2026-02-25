using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class CartServices : ICartService
    {
        public IGenericRepository<Cart, int> _cartRepository;
        public IGenericRepository<CartItem, int> _cartItemRepository;

        public CartServices(
            IGenericRepository<Cart, int> cartRepository,
            IGenericRepository<CartItem, int> cartItemRepository = null
        )
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
        }

        //public void Add(Cart entity) { }

        public void ClearCart(Cart entity)
        {
            var cart = _cartRepository
                .GetAllEntitys()
                .Include(c => c.User)
                .FirstOrDefault(c => c.ID == entity.ID);

            if (cart is null)
                return;

            var cartItems = _cartItemRepository
                .GetAllEntitys()
                .Where(ci => ci.CartId == cart.ID)
                .ToList();

            foreach (var item in cartItems)
            {
                item.Product.UnitsInStock += item.Quantity;
                _cartItemRepository.Delete(item);
            }

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
                            ProductName = ci.Product.Name,
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
                            ProductName = ci.Product.Name,
                            Quantity = ci.Quantity,
                            ProductImage = ci.Product.Image,
                            ProductPrice = ci.Product.Price,
                        })
                        .ToList(),
                });
        }
    }
}
