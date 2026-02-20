using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public Order order { get; set; }
        public int ProductId { get; set; }

        public Product product { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
   
}
