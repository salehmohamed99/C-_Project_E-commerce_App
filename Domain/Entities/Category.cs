//using Domain.Models;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Domain.Entities
//{
//    public class Category: BaseEntity<int>
//    {
//        public string Name { get; set; }

//        public List<Product> products { get; set; }

//        public void Rename(string newName)
//        {
//            if (string.IsNullOrWhiteSpace(newName))
//                throw new ArgumentException("Category name cannot be empty.");
//            if (newName.Length > 100)
//                throw new ArgumentException("Category name cannot exceed 100 characters.");
//            Name = newName;
//        }
//    }
//}


using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }

        public List<Product> products { get; set; }

        public bool IsActive { get; private set; } = true;


        public void Deactivate()
        {

            IsActive = false;
        }

        public void Activate()
        {
            IsActive = true;
        }
        public void Rename(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Category name cannot be empty.");
            if (newName.Length > 100)
                throw new ArgumentException("Category name cannot exceed 100 characters.");
            Name = newName;
        }
    }
}
