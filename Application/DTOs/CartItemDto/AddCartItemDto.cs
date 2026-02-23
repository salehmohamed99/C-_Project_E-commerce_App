using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class AddCartItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
