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
    public class BusPaymentOrderRepository : IBusPaymentOrderRepository
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

        public Bus_Payment_Order GetInfoByBusPaymentOrderId(int id)
        {
            Bus_Payment_Order busPayment_Info = DbSet.Single(uid => uid.Id.Equals(id));
            return busPayment_Info;
        }
        public List<Bus_Payment_Order> SearchInfoWhere()
        {

            var predicate = SearchBusPaymentWhere();
            if (DbSet.Where(predicate).ToList().Count == 0)
            {
                return null;
            }
            else
            {
                var result = DbSet.Where(predicate).OrderByDescending(o => o.AddDate).ToList();
                return result;
            }

        }

        #region 条件
        //根据条件查询班车
        private Expression<Func<Bus_Payment_Order, bool>> SearchBusPaymentWhere()
        {
            var predicate = WhereExtension.True<Bus_Payment_Order>();//初始化where表达式

            predicate = predicate.And(a => a.isDelete == "0");
            predicate = predicate.And(a => a.AddDate.Value.Year == DateTime.Now.Year && a.AddDate.Value.Month == DateTime.Now.Month);
            return predicate;
        }
        #endregion

        public IQueryable<Bus_Payment_Order> SearchInfoByBusPaymentOrderWhere(Bus_Payment_OrderSearchViewModel bus_Payment_OrderSearchViewModel)
        {
            int SkipNum = bus_Payment_OrderSearchViewModel.pageViewModel.CurrentPageNum * bus_Payment_OrderSearchViewModel.pageViewModel.PageSize;

            var predicate = SearchBusPaymentOrderWhere(bus_Payment_OrderSearchViewModel);


            var result = DbSet.Where(predicate)
                .Skip(SkipNum)
                .Take(bus_Payment_OrderSearchViewModel.pageViewModel.PageSize)
                .OrderBy(o => o.Id);


            return result;
        }
        #region 条件
        //根据条件查询班车
        private Expression<Func<Bus_Payment_Order, bool>> SearchBusPaymentOrderWhere(Bus_Payment_OrderSearchViewModel bus_Payment_OrderSearchViewModel)
        {
            var predicate = WhereExtension.True<Bus_Payment_Order>();//初始化where表达式
            if (bus_Payment_OrderSearchViewModel.Repair_InfoId != null)
                predicate = predicate.And(a => a.Repair_InfoId == bus_Payment_OrderSearchViewModel.Repair_InfoId);
            predicate = predicate.And(a => a.departName.Contains(bus_Payment_OrderSearchViewModel.departName));
            predicate = predicate.And(a => a.isDelete.Contains(bus_Payment_OrderSearchViewModel.isDelete));
            predicate = predicate.And(a => a.paymentStatus.Contains(bus_Payment_OrderSearchViewModel.paymentStatus));
            predicate = predicate.And(a => a.confirmStatus.Contains(bus_Payment_OrderSearchViewModel.confirmStatus));
            predicate = predicate.And(a => a.paymentStatus.Contains(bus_Payment_OrderSearchViewModel.paymentStatus));
            return predicate;
        }
        #endregion

        public Bus_Payment_Order GetInfoByRepair_InfoId(int id)
        {
            Bus_Payment_Order busPayment_Info = DbSet.Single(uid => uid.Repair_InfoId == id && uid.status == "0");
            return busPayment_Info;
        }

        public List<Bus_Payment_Order> SearchInfoByUserIdWhere(Bus_OrderIsPassSearchViewModel bus_OrderIsPassSearchViewModel)
        {

            int SkipNum = bus_OrderIsPassSearchViewModel.pageViewModel.CurrentPageNum * bus_OrderIsPassSearchViewModel.pageViewModel.PageSize;

            var predicate = SearchBusPaymentWhere(bus_OrderIsPassSearchViewModel);


            var result = DbSet.Where(predicate)
                .Skip(SkipNum)
                .Take(bus_OrderIsPassSearchViewModel.pageViewModel.PageSize)
                .OrderBy(o => o.Id).ToList();
            return result;
        }

        public List<Bus_Payment_Order> SearchInfoByUserIdWhereCZ()
        {

            var predicate = SearchBusPaymentWhereCZ();
            var result = DbSet.Where(predicate)
                .OrderBy(o => o.Id).ToList();
            return result;
        }

        #region 条件
        //根据条件查询订单
        private Expression<Func<Bus_Payment_Order, bool>> SearchBusPaymentWhere(Bus_OrderIsPassSearchViewModel bus_OrderIsPassSearchViewModel)
        {
            var predicate = WhereExtension.True<Bus_Payment_Order>();//初始化where表达式
            if (bus_OrderIsPassSearchViewModel.User_InfoId != null)
                predicate = predicate.And(a => a.createUser == bus_OrderIsPassSearchViewModel.User_InfoId);
            predicate = predicate.And(a => a.paymentStatus!="0");
            //  predicate = predicate.And(a => a.Repair_Info.isEnd== bus_OrderIsPassSearchViewModel.isPass);
            predicate = predicate.And(a => a.isDelete == "0");
            return predicate;
        }
        #endregion


        #region 条件
        //根据条件查询订单
        private Expression<Func<Bus_Payment_Order, bool>> SearchBusPaymentWhereCZ()
        {
            var predicate = WhereExtension.True<Bus_Payment_Order>();//初始化where表达式

            predicate = predicate.And(a => a.paymentStatus == "2" || a.paymentStatus == "3");
            predicate = predicate.And(a => a.isDelete == "0");
            return predicate;
        }
        #endregion
        public List<Bus_Payment_Order> GetOrderInfoByRepair_InfoId(int id)
        {
            List<Bus_Payment_Order> busPayment_Info = DbSet.Where(uid => uid.Repair_InfoId == id && uid.status == "0").ToList();
            return busPayment_Info;
        }
       
    }
}
