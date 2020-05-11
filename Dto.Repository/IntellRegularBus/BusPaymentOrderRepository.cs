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

        public Bus_Payment_Order GetInfoByBusPaymentOrderId(int id)
        {
            Bus_Payment_Order busPayment_Info = DbSet.Single(uid => uid.Id.Equals(id));
            return busPayment_Info;
        }

        public IQueryable<Bus_Payment_Order> SearchInfoByBusPaymentOrderWhere(Bus_Payment_OrderSearchViewModel  bus_Payment_OrderSearchViewModel)
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
            Bus_Payment_Order busPayment_Info = DbSet.Single(uid => uid.Repair_InfoId.Equals(id));
            return busPayment_Info;
        }
       

    }
}
