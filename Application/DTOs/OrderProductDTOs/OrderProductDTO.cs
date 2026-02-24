using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.OrderProductDTOs
{
    public class OrderProductDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; } 

        public decimal TotalPrice { get; set; }
    }
}
