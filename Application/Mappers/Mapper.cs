using Application.DTOs.CategoryDTOs;
using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappers
{
    public class Mapper
    {
        public void Map()
        {
           
            TypeAdapterConfig<Category, CategoryDto>.NewConfig();
            TypeAdapterConfig<CreateCategoryDto, Category>.NewConfig();
            TypeAdapterConfig<Category, UpdateCategoryDto>.NewConfig();
                
        }
    }
}
