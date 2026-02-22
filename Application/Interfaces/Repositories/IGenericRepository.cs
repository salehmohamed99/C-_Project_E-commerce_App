using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity, TKey>
    {
        public IQueryable<TEntity> GetAllEntitys();
        public void Add(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
        public int SaveChanges();
    }
}
