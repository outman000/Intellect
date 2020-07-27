using Dto.IRepository.IntellRegularBus;
using Dtol;
using Dtol.dtol;
using Dtol.EfCoreExtion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel;

namespace Dto.Repository.IntellRegularBus
{
    public class BusLocationInformationRepository : IBusLocationInformationRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Bus_Location_Information> DbSet;

        public BusLocationInformationRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Bus_Location_Information>();
        }

        public virtual void Add(Bus_Location_Information obj)
        {
            DbSet.Add(obj);
        }

        public Bus_Location_Information GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<Bus_Location_Information> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(Bus_Location_Information obj)
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

        public List<Bus_Location_Information> SearchInfoByBusLocationInformationWhere(BusLocationInformationSearchViewModel busLocationInformationSearchViewModel)
        {
          
                //查询条件
                var predicate = SearchBusWhere(busLocationInformationSearchViewModel);
                var result = DbSet.Where(predicate)
                     .OrderByDescending(o => o.AddDate).ToList();
                return result;
           
        }

        //根据条件查询班车扫码记录
        private Expression<Func<Bus_Location_Information, bool>> SearchBusWhere(BusLocationInformationSearchViewModel busLocationInformationSearchViewModel)
        {
            var predicate = WhereExtension.True<Bus_Location_Information>();//初始化where表达式

            predicate = predicate.And(p => p.LineId==busLocationInformationSearchViewModel.LineId);  
            if (busLocationInformationSearchViewModel.AddDate != null)
                predicate = predicate.And(a => a.AddDate.Year == busLocationInformationSearchViewModel.AddDate.Value.Year
                                         && a.AddDate.Month == busLocationInformationSearchViewModel.AddDate.Value.Month);
            return predicate;
        }
    }
}
