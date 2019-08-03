using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dto.IRepository.IntellWeChat
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
        void Dispose();
    }
}
