using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.ProductDTOs
{
    public class ProductDto
    {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
            public int UnitsInStock { get; set; }
            public bool IsActive { get; set; }
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        
    }
}
