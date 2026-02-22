using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.CartItemDto
{
    public class CartItemDto
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
