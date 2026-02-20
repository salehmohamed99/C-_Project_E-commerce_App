using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Category: BaseEntity<int>
    {
        public string Name { get; set; }

        public List<Product> products { get; set; }
    }
}
