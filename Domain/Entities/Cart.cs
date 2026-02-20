using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Domain.Models;

namespace Domain.Entities
{
    public class Cart : BaseEntity<int>
    {
        public decimal TotalPrice { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public List<CartItem> MyProperty { get; set; }
    }
}
