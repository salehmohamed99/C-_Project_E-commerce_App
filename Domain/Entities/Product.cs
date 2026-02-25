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

        public void Deactivate()
        {
            IsActive = false;
            IsDeleted = true;
        }

        public void Activate()
        {
            IsActive = true;
            IsDeleted = false;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentException("Price must be greater than zero.");
            Price = newPrice;
        }

        public void Restock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Restock quantity must be positive.");
            UnitsInStock += quantity;
        }

        public void ReduceStock(int quantity)
        {
            
            if (UnitsInStock < quantity)
                throw new InvalidOperationException("Quantity dosn't enough");
            UnitsInStock -= quantity;
        }

    }
}
