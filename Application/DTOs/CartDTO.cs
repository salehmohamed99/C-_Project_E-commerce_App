using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Application.DTOs
{
    public class CartDTO
    {
        public int UserID { get; set; }
        public decimal TotalPrice { get; set; } = 0;
        public List<CartItem> CartItems { get; set; }
    }
}
