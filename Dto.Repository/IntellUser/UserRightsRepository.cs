
using Dtol;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dto.IRepository.IntellUser;

namespace Dto.Repository.IntellUser
{
    class UserRightsRepository: IUserRightsRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<User_Rights> DbSet;

        public UserRightsRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<User_Rights>();
        }

        public virtual void Add(User_Rights obj)
        {
            DbSet.Add(obj);
        }

        public virtual User_Rights GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<User_Rights> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(User_Rights obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
      
    }
}
