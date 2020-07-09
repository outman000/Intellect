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
using ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel;

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
        public List<Bus_Scan_Record> SearchInfoByBusScanRecordWhereNum(BusScanRecordSearchViewModel busScanRecordSearchViewModel)
        {
            //查询条件
            var predicate = SearchBusWhere(busScanRecordSearchViewModel);
            var result = DbSet.Where(predicate)
                 .OrderBy(o => o.AddDate).ToList();


            return result;
        }

        public List<Bus_Scan_Record> SearchInfoByBusScanRecordWhere(BusScanRecordSearchViewModel   busScanRecordSearchViewModel)
        {
            int SkipNum = busScanRecordSearchViewModel.pageViewModel.CurrentPageNum * busScanRecordSearchViewModel.pageViewModel.PageSize;

            //查询条件
            var predicate = SearchBusWhere(busScanRecordSearchViewModel);
            var result = DbSet.Where(predicate)
                .Skip(SkipNum)
                .Take(busScanRecordSearchViewModel.pageViewModel.PageSize)
                 .OrderBy(o => o.AddDate).ToList();


            return result;
        }

        //根据条件查询班车扫码记录
        private Expression<Func<Bus_Scan_Record, bool>> SearchBusWhere(BusScanRecordSearchViewModel busScanRecordSearchViewModel)
        {
            var predicate = WhereExtension.True<Bus_Scan_Record>();//初始化where表达式
            predicate = predicate.And(p => p.UserName.Contains(busScanRecordSearchViewModel.UserName));
            predicate = predicate.And(p => p.LineName.Contains(busScanRecordSearchViewModel.LineName));
            predicate = predicate.And(p => p.DeptName.Contains(busScanRecordSearchViewModel.DeptName));
            predicate = predicate.And(p => p.status == busScanRecordSearchViewModel.status);

            if (busScanRecordSearchViewModel.startdate != null && busScanRecordSearchViewModel.enddate != null)
            {
                predicate = predicate.And(p => p.AddDate >= busScanRecordSearchViewModel.startdate);
                predicate = predicate.And(p => p.AddDate <= busScanRecordSearchViewModel.enddate);
            }
            return predicate;
        }
    }
}

