using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTOs.CategoryDTOs
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}
