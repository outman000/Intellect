using Dto.IRepository.IntellUser;
using Dtol;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dto.Repository.IntellUser
{
    class UserRoleRepository: IUserRoleRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<User_Role> DbSet;

        public UserRoleRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<User_Role>();
        }

        public virtual void Add(User_Role obj)
        {
            DbSet.Add(obj);
        }

        public virtual User_Role GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<User_Role> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(User_Role obj)
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
