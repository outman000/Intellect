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
    public class BusScanRecordRepository : IBusScanRecordRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Bus_Scan_Record> DbSet;

        public BusScanRecordRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Bus_Scan_Record>();
        }

        public virtual void Add(Bus_Scan_Record obj)
        {
            DbSet.Add(obj);
        }

        public Bus_Scan_Record GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<Bus_Scan_Record> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(Bus_Scan_Record obj)
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

