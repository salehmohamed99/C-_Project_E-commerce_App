using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Product: BaseEntity<int>
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int UnitsInStock { get; set; } = 0;
        public bool IsActive { get; private set; } = true;
    }
}
