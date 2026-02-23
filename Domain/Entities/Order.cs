using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
      public enum OrderStatus
      {
          Pending,
          Processing,
          Shipped,
          Delivered,
          Cancelled
      }
      public class Order : BaseEntity<int>
      {
         public OrderStatus Status { get; set; }
         public Decimal TotalAmount { get; set; }
         public string ShippingAddress { get; set; }
         public int UserId { get; set; }
         public User User { get; private set; }

        public List<OrderProduct> OrderProducts { get; private set; }

    }
    
}
