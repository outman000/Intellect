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
using ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel;
using ViewModel.BusViewModel.RequestViewModel.BusUserViewModel;

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
        public List<BusScanRecordTongjiNumMiddle> SearchInfoByBusScanRecordWhereTongji(BusScanRecordTongJiSearchViewModel busScanRecordTongJiSearchViewModel)
        {


            var LineId = busScanRecordTongJiSearchViewModel.LineId;
            var AddDate = busScanRecordTongJiSearchViewModel.AddDate;
            List<BusScanRecordTongjiNumMiddle> fpnm = new List<BusScanRecordTongjiNumMiddle>();
            var result = DbSet.Where(b => b.LineId==(LineId) && b.AddDate.Year == AddDate.Year
                                   && b.AddDate.Month == AddDate.Month && b.status=="0")
            .GroupBy(m => new {
                m.StationName             
            })
            .Select(k => new
            {
                StationName = k.Key.StationName,//站点名
                Num = k.Count()

            }).OrderByDescending(m => m.Num).ToList();

            foreach (var temp in result)
            {
                fpnm.Add(new BusScanRecordTongjiNumMiddle() { StationName = temp.StationName, Num = temp.Num });
            }
            return fpnm;
       
        }
        public List<Bus_Scan_Record> SearchInfoByBusScanRecordWhere(BusScanRecordSearchViewModel   busScanRecordSearchViewModel)
        {
            int SkipNum = busScanRecordSearchViewModel.pageViewModel.CurrentPageNum * busScanRecordSearchViewModel.pageViewModel.PageSize;

            //查询条件
            var predicate = SearchBusWhere(busScanRecordSearchViewModel);
            var result = DbSet.Where(predicate).OrderBy(o => o.AddDate)
                .Skip(SkipNum)
                .Take(busScanRecordSearchViewModel.pageViewModel.PageSize)
                 .ToList();


            return result;
        }

        //根据条件查询班车扫码记录
        private Expression<Func<Bus_Scan_Record, bool>> SearchBusWhere(BusScanRecordSearchViewModel busScanRecordSearchViewModel)
        {
            var predicate = WhereExtension.True<Bus_Scan_Record>();//初始化where表达式
            predicate = predicate.And(p => p.UserName.Contains(busScanRecordSearchViewModel.UserName));
            predicate = predicate.And(p => p.LineName.Contains(busScanRecordSearchViewModel.LineName));
            predicate = predicate.And(p => p.DeptName.Contains(busScanRecordSearchViewModel.DeptName));

            if (busScanRecordSearchViewModel.status !="")
          predicate = predicate.And(p => p.status == busScanRecordSearchViewModel.status);

            if (busScanRecordSearchViewModel.startdate != null && busScanRecordSearchViewModel.enddate != null)
            {
                predicate = predicate.And(p => p.AddDate >= busScanRecordSearchViewModel.startdate);
                predicate = predicate.And(p => p.AddDate <= busScanRecordSearchViewModel.enddate);
            }
            return predicate;
        }

        //根据条件查询班车扫码记录
        private Expression<Func<Bus_Scan_Record, bool>> SearchBusTongjiWhere(BusScanRecordTongJiSearchViewModel busScanRecordTongJiSearchViewModel)
        {
            var predicate = WhereExtension.True<Bus_Scan_Record>();//初始化where表达式
          

            if (busScanRecordTongJiSearchViewModel.LineId != null)
                predicate = predicate.And(p => p.LineId == busScanRecordTongJiSearchViewModel.LineId);

            if (busScanRecordTongJiSearchViewModel.AddDate != null )
            {
                predicate = predicate.And(p => p.AddDate.Year == busScanRecordTongJiSearchViewModel.AddDate.Year
                                           && p.AddDate.Month == busScanRecordTongJiSearchViewModel.AddDate.Month);
            }
            return predicate;
        }
    }
}

