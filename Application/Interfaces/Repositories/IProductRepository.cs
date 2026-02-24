using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repositories
{
    public interface IProductRepository:IGenericRepository<Product,int>
    {
        Product GetById(int id);  
        
        IEnumerable<Product> SearchByName(string name);
    }
}
