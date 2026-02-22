using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.CartItemDto
{
    internal class AddCartItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
