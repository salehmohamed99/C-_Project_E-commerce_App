using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.OrderProductDTOs
{
    public class UpdateOrderProductDTO
    {
        public int Id { get; set; }

        public int orderId { get; set; }
        public int productId { get; set; }

        public int Quantity { get; set; } 
    }
}
