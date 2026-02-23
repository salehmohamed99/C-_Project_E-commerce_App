using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface ICartService
    {
        public void ClearCart(Cart entity);

        public IQueryable<CartDTO> GetAllEntitys();

        public IQueryable<CartDTO> GetCartByUserId(int userId);
    }
}
