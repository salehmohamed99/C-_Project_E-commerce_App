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
    public class CartItemService : ICartItemService
    {
        IGenericRepository<CartItem, int> _cartItemRepository;
        IGenericRepository<Cart, int> _cartRepository;
        IGenericRepository<Product, int> _productRepository;

        public CartItemService(
            IGenericRepository<CartItem, int> cartItemRepository,
            IGenericRepository<Product, int> productRepository,
            IGenericRepository<Cart, int> cartRepository
        )
        {
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
            _cartRepository = cartRepository;
        }

        public IQueryable<CartItemDto> GetCartItems(int cartId)
        {
            return _cartItemRepository
                .GetAllEntitys()
                .Where(ci => ci.CartId == cartId)
                .Select(ci => new CartItemDto
                {
                    CartId = ci.CartId,
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Name,
                    Quantity = ci.Quantity,
                    ProductPrice = ci.Product.Price,
                    ProductImage = ci.Product.Image,
                    AddedAt = ci.CreatedAt,
                });
        }

        public CartItemDto AddItem(int cartId, AddCartItemDto dto)
        {
            var cart = _cartRepository
                .GetAllEntitys()
                .Include(c => c.User)
                .FirstOrDefault(c => c.ID == cartId);
            var product = _productRepository
                .GetAllEntitys()
                .FirstOrDefault(p => p.ID == dto.ProductId);
            if (product == null || !product.IsActive)
                throw new Exception("Product not available");

            var existingItem = _cartItemRepository
                .GetAllEntitys()
                .Include(ci => ci.Product)
                .FirstOrDefault(ci => ci.CartId == cartId && ci.ProductId == dto.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += dto.Quantity;
                existingItem.Product.UnitsInStock -= dto.Quantity;
                existingItem.UpdatedAt = DateTime.UtcNow;
                existingItem.UpdatedBy = cart.User.Name;
                _cartItemRepository.Update(existingItem);
                _cartItemRepository.SaveChanges();
                return MapToDto(existingItem);
            }

            var cartItem = new CartItem
            {
                CartId = cartId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = cart.User.Name,
            };

            product.UnitsInStock -= dto.Quantity;
            _cartItemRepository.Add(cartItem);
            _cartItemRepository.SaveChanges();
            return MapToDto(cartItem);
        }

        public CartItemDto UpdateItem(int cartId, int productId, UpdateCartItemDto dto)
        {
            var cartItem = _cartItemRepository
                .GetAllEntitys()
                .FirstOrDefault(ci => ci.CartId == cartId && ci.ProductId == productId);
            if (cartItem == null)
                return null;
            var product = _productRepository.GetAllEntitys().FirstOrDefault(p => p.ID == productId);
            product.UnitsInStock += cartItem.Quantity;
            product.UnitsInStock -= dto.Quantity;
            cartItem.Quantity = dto.Quantity;
            _cartItemRepository.Update(cartItem);
            _cartItemRepository.SaveChanges();
            return MapToDto(cartItem);
        }

        public bool RemoveItem(int cartId, int productId)
        {
            var cartItem = _cartItemRepository
                .GetAllEntitys()
                .FirstOrDefault(ci => ci.CartId == cartId && ci.ProductId == productId);
            if (cartItem == null)
                return false;
            var product = _productRepository.GetAllEntitys().FirstOrDefault(p => p.ID == productId);
            if (product == null)
                return false;
            product.UnitsInStock += cartItem.Quantity;
            _cartItemRepository.Delete(cartItem);
            _cartItemRepository.SaveChanges();
            return true;
        }

        private CartItemDto MapToDto(CartItem item) =>
            new CartItemDto
            {
                CartId = item.CartId,
                ProductId = item.ProductId,
                ProductName = item.Product.Name,
                Quantity = item.Quantity,
                ProductPrice = item.Product.Price,
                ProductImage = item.Product.Image,
                AddedAt = item.CreatedAt,
            };
    }
}
