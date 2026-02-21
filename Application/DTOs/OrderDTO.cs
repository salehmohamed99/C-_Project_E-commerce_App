using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Application.DTOs
{ 
    public class OrderDTO
    {
        public int ID { get; set; }
        public OrderStatus Status { get; set; }
        public string ShippingAddress { get; set; }
        public decimal TotalAmount { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

    }
}
