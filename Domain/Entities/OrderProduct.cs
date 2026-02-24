using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class OrderProduct : BaseEntity<int>
    {
        public int OrderId { get; set; }
        public Order order { get; set; }
        public int ProductId { get; set; }

        public Product product { get; set; }

        public bool IsDeleted { get; set; } = false;

        public int Quantity { get; set; } = 1;
        public decimal UnitPrice { get; set; }
    }
   
}
