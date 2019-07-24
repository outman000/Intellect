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
using ViewModel.BusViewModel.RequestViewModel.BusUserViewModel;

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

        public int DeleteByBusUserIdList(List<int> IdList)
        {
            int DeleteRowNum = 1;
            for (int i = 0; i < IdList.Count; i++)
            {
                var model = DbSet.Single(w => w.Id == IdList[i]);
            
                DbSet.Remove(model);
                SaveChanges();
                DeleteRowNum = i + 1;
            }
            return DeleteRowNum;

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

        public Bus_Payment GetInfoByBusUserId(int id)
        {
            Bus_Payment bus_user_Info = DbSet.Single(uid => uid.Id.Equals(id));
            return bus_user_Info;
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public IQueryable<Bus_Payment> SearchInfoByBusWhere(BusUserSearchViewModel busUserSearchViewModel)
        {
            int SkipNum = busUserSearchViewModel.pageViewModel.CurrentPageNum * busUserSearchViewModel.pageViewModel.PageSize;

            var preciateBydepart =   SearchBusUserWhere(busUserSearchViewModel);
           IQueryable<Bus_Payment> bus_Payments = Db.bus_Payment.Where(preciateBydepart);

            IQueryable<Bus_Payment> SearchResultTemp = bus_Payments.Include(a => a.User_Info)
                        .Include(a => a.Bus_Station)
                        .Include(a => a.Bus_Info)
                        .Include(a => a.Bus_Line)
                        .Include(a => a.User_Depart)
                        .Skip(SkipNum)
                        .Take(busUserSearchViewModel.pageViewModel.PageSize);


            return SearchResultTemp;


        }

        public void Update(Bus_Payment obj)
        {
            DbSet.Update(obj);
        }

        #region 条件
        //根据条件查询班车
        private Expression<Func<Bus_Payment, bool>> SearchBusUserWhere(BusUserSearchViewModel  busUserSearchViewModel)
        {
            var predicate = WhereExtension.True<Bus_Payment>();//初始化where表达式

            predicate = predicate.And(a => a.User_Info.UserName.Contains(busUserSearchViewModel.UserName));
            predicate = predicate.And(a => a.User_DepartId.ToString().Contains(busUserSearchViewModel.User_DepartId));
            predicate = predicate.And(a => a.Bus_LineId.ToString().Contains(busUserSearchViewModel.Bus_LineId) );
            predicate = predicate.And(a => a.Bus_StationId.ToString().Contains(busUserSearchViewModel.User_DepartId) );
            predicate = predicate.And(a => a.User_InfoId.ToString().Contains(busUserSearchViewModel.User_InfoId) );
            predicate = predicate.And(a => a.Bus_Station.Expense.ToString().Contains(busUserSearchViewModel.Expense) );

            return predicate;
        }

        #endregion

    }
}
