using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    internal class AddCartItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
