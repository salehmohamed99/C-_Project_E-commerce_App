using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repositories
{
    public interface ICategoryRepository:IGenericRepository<Category,int>
    {
        Category GetByName(string name);
        bool HasProducts(int categoryId);
        Category GetById(int id);
    }
}
