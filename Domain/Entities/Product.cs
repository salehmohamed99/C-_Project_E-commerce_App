using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Entities
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int UnitsInStock { get; set; } = 0;
        public bool IsActive { get; private set; } = true;

        public int CategoryId { get; set; }
        public Category category { get; set; }

        public List<OrderProduct> OrderProducts { get; private set; } = new List<OrderProduct>();
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
