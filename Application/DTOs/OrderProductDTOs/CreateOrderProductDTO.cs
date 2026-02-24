using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.OrderProductDTOs
{
    public class CreateOrderProductDTO
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 1;

    }
}
