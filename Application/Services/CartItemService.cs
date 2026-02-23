using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Services
{
    public class CartItemService : ICartItemService
    {
        IGenericRepository<CartItem, int> _cartItemRepository;
        IGenericRepository<Product, int> _productRepository;

        public CartItemService(
            IGenericRepository<CartItem, int> cartItemRepository,
            IGenericRepository<Product, int> productRepository
        )
        {
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
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
                    Quantity = ci.Quantity,
                    ProductPrice = ci.Product.Price,
                    ProductImage = ci.Product.Image,
                    AddedAt = ci.CreatedAt,
                });
        }

        public CartItemDto AddItem(int cartId, AddCartItemDto dto)
        {
            var product = _productRepository
                .GetAllEntitys()
                .FirstOrDefault(p => p.ID == dto.ProductId);
            if (product == null || !product.IsActive)
                throw new Exception("Product not available");
            var cartItem = new CartItem
            {
                CartId = cartId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                CreatedAt = DateTime.UtcNow,
            };

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
            _cartItemRepository.Delete(cartItem);
            _cartItemRepository.SaveChanges();
            return true;
        }

        private CartItemDto MapToDto(CartItem item) =>
            new CartItemDto
            {
                CartId = item.CartId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                ProductPrice = item.Product.Price,
                ProductImage = item.Product.Image,
                AddedAt = item.CreatedAt,
            };
    }
}
