using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;

namespace Application.Interfaces.Repositories
{
    public interface ICartItemService
    {
        IQueryable<CartItemDto> GetCartItems(int cartId);
        CartItemDto AddItem(int cartId, AddCartItemDto dto);
        CartItemDto UpdateItem(int cartId, int productId, UpdateCartItemDto dto);
        bool RemoveItem(int cartId, int productId);
    }
}
