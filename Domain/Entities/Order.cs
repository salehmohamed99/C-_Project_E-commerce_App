using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
      public enum OrderStatus
      {
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
         public User User { get;  set; }

        public List<OrderProduct> OrderProducts { get;  set; }

    }
    
}
