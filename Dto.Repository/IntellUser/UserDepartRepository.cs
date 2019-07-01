
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
    class UserDepartRepository : IUserDepartRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<User_Depart> DbSet;

        public UserDepartRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<User_Depart>();
        }

        public void Add(User_Depart obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<User_Depart> GetAll()
        {
            throw new NotImplementedException();
        }

        public User_Depart GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(User_Depart obj)
        {
            throw new NotImplementedException();
        }
    }
}
