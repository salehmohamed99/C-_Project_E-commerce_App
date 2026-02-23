using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class CartDTO
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public decimal TotalPrice { get; set; } = 0;
        public List<CartItemDto> CartItems { get; set; }
    }
}
