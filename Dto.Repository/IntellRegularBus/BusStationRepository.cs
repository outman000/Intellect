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
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;
using ViewModel.BusViewModel.RequestViewModel.StationInfoViewModel;

namespace Dto.Repository.IntellRegularBus
{
    public class BusStationRepository : IBusStationRepository
    {


        protected readonly DtolContext Db;
        protected readonly DbSet<Bus_Station> DbSet;

        public BusStationRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Bus_Station>();
        }

        public virtual void Add(Bus_Station obj)
        {
            DbSet.Add(obj);
        }

        public virtual Bus_Station GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<Bus_Station> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(Bus_Station obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public IQueryable<Bus_Station> GetInfoByStationId(string stationid)
        {
            IQueryable<Bus_Station> station_Infos = DbSet.Where(uid => uid.Code.Equals(stationid));
            return station_Infos;
        }

        public Bus_Station GetInfoByStationId(int id)
        {
            Bus_Station bus_Station = DbSet.Single(uid => uid.Id.Equals(id));
                return bus_Station;
        }
        /// <summary>
        /// 根据id列表删
        /// </summary>
        /// <param name="IdList"></param>
        /// <returns></returns>
        public int DeleteByStationIdList(List<int> IdList)
        {
            int DeleteRowNum = 1;
            for (int i = 0; i < IdList.Count; i++)
            {
                var model = DbSet.Single(w => w.Id == IdList[i]);
                model.status = "1";
                DbSet.Update(model);
                SaveChanges();
                DeleteRowNum = i + 1;
            }
            return DeleteRowNum;
        }

        public List<Bus_Station> SearchInfoByWhere(StationSearchViewModel stationSearchViewModel)
        {
            int SkipNum = stationSearchViewModel.pageViewModel.CurrentPageNum * stationSearchViewModel.pageViewModel.PageSize;

            //查询条件
            var predicate = SearchStationWhere(stationSearchViewModel);
            var result = DbSet.Where(predicate).OrderBy(o => o.AddDate)
                .Skip(SkipNum)
                .Take(stationSearchViewModel.pageViewModel.PageSize)
                .ToList();


            return result;
        }

        public Bus_Station GetById(int id)
        {
            return DbSet.Find(id);
        }

        Bus_Station IRepository<Bus_Station>.GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        IQueryable<Bus_Station> IRepository<Bus_Station>.GetAll()
        {
            return DbSet;
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


        //根据条件查询站点
        private Expression<Func<Bus_Station, bool>> SearchStationWhere(StationSearchViewModel stationSearchViewModel)
        {
            var predicate = WhereExtension.True<Bus_Station>();//初始化where表达式
            predicate = predicate.And(p => p.Code.Contains(stationSearchViewModel.Code));
            predicate = predicate.And(p => p.StationName.Contains(stationSearchViewModel.StationName));
            predicate = predicate.And(p => p.status.Contains(stationSearchViewModel.status));
            //if(stationSearchViewModel.Expense!=null)
            //predicate = predicate.And(p => p.Expense.Value.ToString().Contains(stationSearchViewModel.Expense.Value.ToString()));
            return predicate;
        }

        /// <summary>
        /// 根据站点查线路
        /// </summary>
        /// <param name="lineByBusSearchViewModel"></param>
        /// <returns></returns>
        public List<Bus_Station> SearchLineInfoByStationWhere(LineByStationViewModel lineByStationViewModel)
        {
            int SkipNum = lineByStationViewModel.pageViewModel.CurrentPageNum * lineByStationViewModel.pageViewModel.PageSize;
            int StationId = lineByStationViewModel.id;
            var queryResult = DbSet.Where(k => k.Id == StationId).Include(p => p.Bus_Line).OrderBy(o => o.AddDate)
                        .Skip(SkipNum)
                        .Take(lineByStationViewModel.pageViewModel.PageSize)           
                        .ToList();

            return queryResult.ToList();
        }
        /// <summary>
        /// 根据线路查站点
        /// </summary>
        /// <param name="stationByLineSearchViewModel"></param>
        /// <re
        public List<Bus_Station> SearchStationInfoByLineWhere(StationByLineSearchViewModel stationByLineSearchViewModel)
        {
            int SkipNum = stationByLineSearchViewModel.pageViewModel.CurrentPageNum * stationByLineSearchViewModel.pageViewModel.PageSize;
            int lineid = stationByLineSearchViewModel.Bus_LineId;
            var queryResult = DbSet.Where(k => k.Bus_LineId == lineid && k.status == "0")
                        .Skip(SkipNum)
                        .Take(stationByLineSearchViewModel.pageViewModel.PageSize)
                        .ToList();
            return queryResult;
        }
        /// <summary>
        /// 站点总数量
        /// </summary>
        /// <param name="stationSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<Bus_Station> GetStationAll(StationSearchViewModel stationSearchViewModel)
        {
            var predicate = SearchStationWhere(stationSearchViewModel);

            return DbSet.Where(predicate);
        }
        /// <summary>
        /// 根据站点查线路数量
        /// </summary>
        /// <param name="lineByStationViewModel"></param>
        /// <returns></returns>
        public IQueryable<Bus_Station> GetLineInfoByStationAll(LineByStationViewModel lineByStationViewModel)
        {
            int StationId = lineByStationViewModel.id;
            var queryResult = DbSet.Where(k => k.Id == StationId).Include(p => p.Bus_Line);

            return queryResult;
        }
        /// <summary>
        /// 根据线路查站点数量
        /// </summary>
        /// <param name="stationByLineSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<Bus_Station> GetStationInfoByLinAll(StationByLineSearchViewModel stationByLineSearchViewModel)
        {
            int lineid = stationByLineSearchViewModel.Bus_LineId;
            var queryResult = DbSet.Where(k => k.Bus_LineId == lineid && k.status == "0");
            return queryResult;
        }
    }
}
