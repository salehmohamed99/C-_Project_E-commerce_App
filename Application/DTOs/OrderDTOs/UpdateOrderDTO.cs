using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Application.DTOs.OrderDTOs
{
    public class UpdateOrderDTO
    {
        public int UserId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
