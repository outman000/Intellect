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
  public class BusPaymentOrderRepository:IBusPaymentOrderRepository
  {
        protected readonly DtolContext Db;
       protected readonly DbSet<Bus_Payment_Order> DbSet;

        public BusPaymentOrderRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Bus_Payment_Order>();
        }

        public void Add(Bus_Payment_Order obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Bus_Payment_Order> GetAll()
        {
            return DbSet;
        }

        public Bus_Payment_Order GetById(Guid id)
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

        public void Update(Bus_Payment_Order obj)
        {
            DbSet.Update(obj);
        }
    }
}
