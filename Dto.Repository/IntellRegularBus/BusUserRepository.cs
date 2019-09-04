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

                model.status = "1";
                DbSet.Update(model);
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

        public IQueryable<Bus_Payment> GetInfoByBusAll(BusUserSearchViewModel busUserSearchViewModel)
        {
            var predicate = SearchBusUserWhere(busUserSearchViewModel);

            return DbSet.Where(predicate);
        }

        public Bus_Payment GetInfoByBusUserId(int id)
        {
            Bus_Payment busPayment_Info = DbSet.Single(uid => uid.Id.Equals(id));
            return busPayment_Info;
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

        /// <summary>
        /// 根据线路id查询数量
        /// </summary>
        /// <param name="busSearchByIdViewModel"></param>
        /// <returns></returns>
        public IQueryable<Bus_Payment> SearchInfoByLineIdWhere(BusSearchByIdViewModel busSearchByIdViewModel)
        {
            var preciateBydepart = SearchBusUserByIdWhere(busSearchByIdViewModel);
            IQueryable<Bus_Payment> bus_Payments = DbSet.Where(preciateBydepart);
            //    .OrderByDescending(o => o.createDate);
            //DateTime cd = bus_Payments.ToList()[0].createDate.Value;//获取最新日期

            //var result = bus_Payments.Where(e => e.createDate.Value.Year== cd.Year && e.createDate.Value.Month == cd.Month);
            return bus_Payments;
        }
        /// <summary>
        /// 查询人员缴费信息（重载,最普通的查询）
        /// </summary>
        /// <param name="busUserSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<Bus_Payment> SearchInfoByBusWhere(BusUserSearchViewModel busUserSearchViewModel)
        {
            int SkipNum = busUserSearchViewModel.pageViewModel.CurrentPageNum * busUserSearchViewModel.pageViewModel.PageSize;

            var predicate =   SearchBusUserWhere(busUserSearchViewModel);
         

            var result = DbSet.Where(predicate)
                .Skip(SkipNum)
                .Take(busUserSearchViewModel.pageViewModel.PageSize)
                .OrderBy(o => o.Id);


            return result;


        }
        /// <summary>
        /// 查询本部门缴费时间列表
        /// </summary>
        /// <param name="busUserSearchTimeViewModel"></param>
        /// <returns></returns>
        private Expression<Func<Bus_Payment, bool>> SearchBusUserDateWhere(BusUserSearchTimeViewModel busUserSearchTimeViewModel)
        {
            var predicate = WhereExtension.True<Bus_Payment>();//初始化where表达式
            predicate = predicate.And(a => a.status == "0");
            predicate = predicate.And(a => a.User_DepartId.Value == busUserSearchTimeViewModel.User_DepartId);
            return predicate;
        }
        /// <summary>
        /// 查询本部门人员缴费时间列表信息
        /// </summary>
        /// <param name="busUserSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<string> SearchInfoTimeWhere(BusUserSearchTimeViewModel busUserSearchTimeViewModel)
        {
         
            var predicate = SearchBusUserDateWhere(busUserSearchTimeViewModel);

            var result = DbSet.Where(predicate).OrderByDescending(b => b.carDate)
                .Select(a=>a.carDate.Value.ToString("yyyy-MM")).Distinct();

            return result;


        }

        /// <summary>
        /// 查询人员缴费信息(重载，用户初始化当月的班车缴费清单而查询模板清单的方法)
        /// </summary>
        /// <param name="busUserSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<Bus_Payment> SearchInfoByBusWhere(BusPaymentUpdateViewModel busPamentUpdateViewModel)
        {

            var predicate = SearchBusUserWhere(busPamentUpdateViewModel);
            var result = DbSet.Where(predicate)
                .OrderBy(o => o.createDate);

            return result;
        }
        /// <summary>
        /// 查询人员缴费信息验证(重载，用于缴费单提交之前班车信息的验证)
        /// </summary>
        /// <param name="busUserSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<Bus_Payment> SearchInfoByBusWhere(BusUserValideViewModel  busUserValideViewModel)
        {

            var predicate = SearchBusValideWhere(busUserValideViewModel);
            var result = DbSet.Where(predicate)
                .OrderBy(o => o.createDate);
            return result;
        }

        public void aa()
        {
           
        }


        #region 条件
        //根据条件查询班车
        private Expression<Func<Bus_Payment, bool>> SearchBusUserWhere(BusUserSearchViewModel  busUserSearchViewModel)
        {
            var predicate = WhereExtension.True<Bus_Payment>();//初始化where表达式
            if(busUserSearchViewModel.Repair_InfoId!=null)
            predicate = predicate.And(a => a.Repair_InfoId==busUserSearchViewModel.Repair_InfoId);
            predicate = predicate.And(a => a.UserName.Contains(busUserSearchViewModel.UserName));
            predicate = predicate.And(a => a.User_DepartId.ToString().Contains(busUserSearchViewModel.User_DepartId));
            predicate = predicate.And(a => a.Bus_LineId.ToString().Contains(busUserSearchViewModel.Bus_LineId) );
            predicate = predicate.And(a => a.Bus_StationId.ToString().Contains(busUserSearchViewModel.Bus_StationId) );
            predicate = predicate.And(a => a.User_InfoId.ToString().Contains(busUserSearchViewModel.User_InfoId) );
            predicate = predicate.And(a => a.status.Contains(busUserSearchViewModel.status));
            predicate = predicate.And(a => a.Expense.Contains(busUserSearchViewModel.Expense));
            if(busUserSearchViewModel.carDate!=null)
            predicate = predicate.And(a => a.carDate.Value.Year == busUserSearchViewModel.carDate.Value.Year
                                     && a.carDate.Value.Month == busUserSearchViewModel.carDate.Value.Month);
                                 
            return predicate;
        }
        private Expression<Func<Bus_Payment, bool>> SearchBusUserWhere(BusPaymentUpdateViewModel  busPamentUpdateViewModel)
        {
            var predicate = WhereExtension.True<Bus_Payment>();//初始化where表达式
            predicate = predicate.And(a => a.status == "0");
            predicate = predicate.And(a => a.User_DepartId==busPamentUpdateViewModel.User_DepartId);
            predicate = predicate.And(a => a.carDate.Value.Year== busPamentUpdateViewModel.carDate.Year 
                                    && a.carDate.Value.Month== busPamentUpdateViewModel.carDate.Month);

            return predicate;
        }

        #endregion
        #region 条件（查询模板账单的条件，根据模板账单生成新的班车账单）
        //根据条件查询班车
        private Expression<Func<Bus_Payment, bool>> SearchBusUserByIdWhere(BusSearchByIdViewModel busSearchByIdViewModel)
        {
            var predicate = WhereExtension.True<Bus_Payment>();//初始化where表达式
           
            predicate = predicate.And(a => a.Bus_LineId==busSearchByIdViewModel.Bus_LineId);
            predicate = predicate.And(a => a.carDate.Value.Year == busSearchByIdViewModel.carDate.Year
                                     && a.carDate.Value.Month == busSearchByIdViewModel.carDate.Month);
            return predicate;
        }
        #endregion
        #region 条件(验证班车名单信息)
        //根据条件查询班车
        private Expression<Func<Bus_Payment, bool>> SearchBusValideWhere(BusUserValideViewModel  busUserValideViewModel)
        {
            var predicate = WhereExtension.True<Bus_Payment>();//初始化where表达式

            predicate = predicate.And(a => a.User_DepartId == busUserValideViewModel.User_DepartId);
            predicate = predicate.And(a => a.carDate.Value.Year == busUserValideViewModel.carDate.Value.Year
                                 && a.carDate.Value.Month == busUserValideViewModel.carDate.Value.Month);
            return predicate;
        }


        #endregion
    }
}
