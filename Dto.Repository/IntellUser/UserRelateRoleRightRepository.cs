
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
    class UserRelateRoleRightRepository : IUserRelateRoleRightRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<User_Relate_Role_Right> DbSet;

        public UserRelateRoleRightRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<User_Relate_Role_Right>();
        }

        public virtual void Add(User_Relate_Role_Right obj)
        {
            DbSet.Add(obj);
        }

        public virtual User_Relate_Role_Right GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<User_Relate_Role_Right> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(User_Relate_Role_Right obj)
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
