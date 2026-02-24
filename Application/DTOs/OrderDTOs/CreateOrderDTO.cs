using Application.DTOs.OrderProductDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.OrderDTOs
{
    public class CreateOrderDTO
    {
        
        public int UserId { get; set; }

        public List<OrderProductDTO> OrderProducts { get; set; }

        public string ShippingAddress { get; set; }


    }
}
