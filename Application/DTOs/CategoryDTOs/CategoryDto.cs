using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.CategoryDTOs
{
    public class CategoryDto
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public int ProductCount { get; set; }       
        public DateTime Created_At { get; set; }
    }

}
