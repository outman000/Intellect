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
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;

namespace Dto.Repository.IntellRegularBus
{
    public class BusInfoRepository: IBusInfoRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Bus_Info> DbSet;

        public BusInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Bus_Info>();
        }

        public virtual void Add(Bus_Info obj)
        {
            DbSet.Add(obj);
        }

        public virtual Bus_Info GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<Bus_Info> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(Bus_Info obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int DeleteByBusIdList(List<int> IdList)
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


        public IQueryable<Bus_Info> GetInfoByBusId(string busid)
        {
            IQueryable<Bus_Info> bus_Infos = DbSet.Where(uid => uid.Code.Equals(busid));
            return bus_Infos;
        }
        //根据班车主键id查询
        public Bus_Info GetInfoByBusId(int id)
        {
            Bus_Info bus_Info = DbSet.Single(uid => uid.Id.Equals(id));
            return bus_Info;
        }

        //根据条件查询

        public List<Bus_Info> SearchInfoByWhere(BusSearchViewModel busSearchViewModel)
        {
            int SkipNum = busSearchViewModel.pageViewModel.CurrentPageNum * busSearchViewModel.pageViewModel.PageSize;

            //查询条件
            var predicate = SearchUserWhere(busSearchViewModel);
            DbSet.Where(predicate)
                .Skip(SkipNum)
                .Take(busSearchViewModel.pageViewModel.PageSize)
                .OrderBy(o => o.AddDate).ToList();


            return DbSet.Where(predicate).OrderBy(o => o.AddDate).ToList();
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


        //根据条件查询班车
        private Expression<Func<Bus_Info, bool>> SearchUserWhere(BusSearchViewModel busSearchViewModel)
        {
            var predicate = WhereExtension.True<Bus_Info>();//初始化where表达式
            predicate = predicate.And(p => p.Code.Contains(busSearchViewModel.Code));
            predicate = predicate.And(p => p.DriverName.Contains(busSearchViewModel.DriverName));
            predicate = predicate.And(p => p.CarPlate.Contains(busSearchViewModel.CarPlate));
            predicate = predicate.And(p => p.SeatNum.Contains(busSearchViewModel.SeatNum));

            return predicate;
        }

        public Bus_Info GetById(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 根据线路查班车
        /// </summary>
        /// <param name="busByLineSearchViewModel"></param>
        /// <returns></returns>

        public List<Bus_Info> SearchBusInfoByLineWhere(BusByLineSearchViewModel busByLineSearchViewModel)
        {
            int lineid = busByLineSearchViewModel.Bus_LineId;
            var queryResult = DbSet.Where(k => k.Bus_LineId == lineid).ToList();
            return queryResult;
        }

        /// <summary>
        /// 根据班车查线路
        /// </summary>
        /// <param name="lineByBusSearchViewModel"></param>
        /// <returns></returns>
        public List<Bus_Info> SearchLineInfoByBusWhere(LineByBusSearchViewModel lineByBusSearchViewModel)
        {

            int BusId = lineByBusSearchViewModel.id;
            var queryResult = DbSet.Where(k => k.Id == BusId).Include(p => p.Bus_Line).ToList();

            return queryResult.ToList();
        }

      
    }
 }
