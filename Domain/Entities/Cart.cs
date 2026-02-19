using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Entities
{
    public class Cart : BaseEntity<int>
    {
        public decimal TotalPrice { get; set; } = 0;

        public int? UserID { get; set; }
        public User User { get; set; }
    }
}
