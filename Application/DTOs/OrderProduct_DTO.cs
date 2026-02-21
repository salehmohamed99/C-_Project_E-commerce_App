using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class OrderProduct_DTO
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; } = 1;

        public decimal TotalPrice { get; set; }
    }
}
