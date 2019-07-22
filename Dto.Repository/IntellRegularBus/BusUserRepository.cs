using Dto.IRepository.IntellRegularBus;
using Dtol;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dto.Repository.IntellRegularBus
{
    public class BusUserRepository: IBusUserRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Bus_Payment> DbSet;

        public BusUserRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Bus_Payment>();
        }

        public void Add(Bus_Payment obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Bus_Payment> GetAll()
        {
            return DbSet;
        }

        public Bus_Payment GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Update(Bus_Payment obj)
        {
            DbSet.Update(obj);
        }
    }
}
