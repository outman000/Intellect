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
        public IQueryable<Bus_Payment> GetInfoByBusAll2(BusUserSearch2ViewModel busUserSearch2ViewModel)
        {
            var predicate = SearchBusUser2Where(busUserSearch2ViewModel);

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
         

            var result = DbSet.Where(predicate).OrderBy(o => o.Id)
                .Skip(SkipNum)
                .Take(busUserSearchViewModel.pageViewModel.PageSize);


            return result;


        }
        /// <summary>
        /// 查询人员缴费信息（重载,最普通的查询）
        /// </summary>
        /// <param name="busUserSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<Bus_Payment> BusUserTongJiExcept_Search(BusPaymentSearchViewModel busPaymentSearchViewModel)
        {
            int SkipNum = busPaymentSearchViewModel.pageViewModel.CurrentPageNum * busPaymentSearchViewModel.pageViewModel.PageSize;

            var predicate = BusUserTongJiExcept_SearchWhere(busPaymentSearchViewModel);


            var result = DbSet.Where(predicate).Include(a=>a.Bus_Payment_Order).OrderByDescending(o => o.carDate)
                .Skip(SkipNum)
                .Take(busPaymentSearchViewModel.pageViewModel.PageSize);


            return result;


        }
        /// <summary>
        /// 查询人员缴费信息（重载,最普通的查询）
        /// </summary>
        /// <param name="busUserSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<Bus_Payment> SearchInfoByBusWhere2(BusUserSearch2ViewModel busUserSearch2ViewModel)
        {
            int SkipNum = busUserSearch2ViewModel.pageViewModel.CurrentPageNum * busUserSearch2ViewModel.pageViewModel.PageSize;

            var predicate = SearchBusUser2Where(busUserSearch2ViewModel);

            var result = DbSet.Where(predicate).Include(b=>b.Bus_Payment_Order).OrderBy(o => o.Id)
                .Skip(SkipNum)
                .Take(busUserSearch2ViewModel.pageViewModel.PageSize);


            return result;


        }
        /// <summary>
        /// 查询人员缴费信息（重载,最普通的查询）
        /// </summary>
        /// <param name="busUserSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<Bus_Payment> SearchInfoByBusWhere4(BusUserSearchViewModel busUserSearchViewModel)
        {
            int SkipNum = busUserSearchViewModel.pageViewModel.CurrentPageNum * busUserSearchViewModel.pageViewModel.PageSize;

            var predicate = SearchBusUserWhere4(busUserSearchViewModel);


            var result = DbSet.Where(predicate).OrderBy(o => o.Id)
                .Skip(SkipNum)
                .Take(busUserSearchViewModel.pageViewModel.PageSize);


            return result;


        }
        /// <summary>
        /// 查询人员缴费信息
        /// </summary>
        /// <param name="busUserSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<Bus_Payment> SearchInfoByBusWhere2(BusUserSearchByDeaprtIdViewModel  busUserSearchByDeaprtIdViewModel)
        {
    
            var predicate = SearchBusUserWhere3(busUserSearchByDeaprtIdViewModel);
            var result = DbSet.Where(predicate);
               
            return result;


        }



        /// <summary>
        /// 查询人员缴费信息（重载,最普通的查询）
        /// </summary>
        /// <param name="busUserSearchViewModel"></param>
        /// <returns></returns>
        public List<int> SearchInfoByBusDistinctWhere(BusUserSearchViewModel busUserSearchViewModel)
        {
            //int SkipNum = busUserSearchViewModel.pageViewModel.CurrentPageNum * busUserSearchViewModel.pageViewModel.PageSize;

            var predicate = SearchBusUserWhere2(busUserSearchViewModel);


            var result = DbSet.Where(predicate).Select(a => a.Bus_LineId.Value).Distinct()
               .ToList();


            return result;

        }
        /// <summary>
        /// 查询人员缴费信息（重载,最普通的查询）
        /// </summary>
        /// <param name="busUserSearchViewModel"></param>
        /// <returns></returns>
        public List<int> SearchInfoByBusDistinctWhere2(BusUserSearchByDeaprtIdViewModel busUserSearchByDeaprtIdViewModel)
        {
         

            var predicate = SearchBusUserWhere3(busUserSearchByDeaprtIdViewModel);

            var result = DbSet.Where(predicate).Select(a => a.Bus_LineId.Value).Distinct()
               .ToList();


            return result;

        }


        /// <summary>
        /// 查询人员缴费信息（重载,最普通的查询）
        /// </summary>
        /// <param name="busUserSearchViewModel"></param>
        /// <returns></returns>
        public List<Bus_Payment> SearchInfoByDateAndIdWhere(SearchByIdCardAndCarDateViewModel  searchByIdCardAndCarDateViewModel)
        {

            var result = DbSet.Where(a => a.IDNumber == searchByIdCardAndCarDateViewModel.IDNumber &&
                              a.carDate.Value.Year == searchByIdCardAndCarDateViewModel.carDate.Value.Year
                              && a.carDate.Value.Month == searchByIdCardAndCarDateViewModel.carDate.Value.Month && a.status=="0").ToList();


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


        //根据条件查询班车
        private Expression<Func<Bus_Payment, bool>> SearchBusUserWhere2(BusUserSearchViewModel busUserSearchViewModel)
        {
            var predicate = WhereExtension.True<Bus_Payment>();//初始化where表达式

            if (busUserSearchViewModel.User_DepartId != "")
                predicate = predicate.And(a => a.User_DepartId.ToString() == (busUserSearchViewModel.User_DepartId));
            if (busUserSearchViewModel.carDate != null)
                predicate = predicate.And(a => a.carDate.Value.Year == busUserSearchViewModel.carDate.Value.Year
                                         && a.carDate.Value.Month == busUserSearchViewModel.carDate.Value.Month);
            predicate = predicate.And(a => a.status=="0");
            return predicate;
        }
        //根据条件查询班车
        private Expression<Func<Bus_Payment, bool>> SearchBusUserWhere3(BusUserSearchByDeaprtIdViewModel busUserSearchByDeaprtIdViewModel)
        {
            var predicate = WhereExtension.True<Bus_Payment>();//初始化where表达式
            if (busUserSearchByDeaprtIdViewModel.User_DepartId != "")
                predicate = predicate.And(a => a.User_DepartId.ToString() == (busUserSearchByDeaprtIdViewModel.User_DepartId));
            if (busUserSearchByDeaprtIdViewModel.carDate != null)
                predicate = predicate.And(a => a.carDate.Value.Year == busUserSearchByDeaprtIdViewModel.carDate.Value.Year
                                         && a.carDate.Value.Month == busUserSearchByDeaprtIdViewModel.carDate.Value.Month);
            predicate = predicate.And(a => a.status == "0");
            return predicate;
        }
        #region 条件
        //根据条件查询班车
        private Expression<Func<Bus_Payment, bool>> SearchBusUserWhere4(BusUserSearchViewModel busUserSearchViewModel)
        {
            var predicate = WhereExtension.True<Bus_Payment>();//初始化where表达式
            if (busUserSearchViewModel.Repair_InfoId != null)
                predicate = predicate.And(a => a.Repair_InfoId == busUserSearchViewModel.Repair_InfoId);
            if (busUserSearchViewModel.Bus_Payment_OrderId != null)
                predicate = predicate.And(a => a.Bus_Payment_OrderId == busUserSearchViewModel.Bus_Payment_OrderId);
            predicate = predicate.And(a => a.UserName.Contains(busUserSearchViewModel.UserName));
            if (busUserSearchViewModel.User_DepartId != "")
                predicate = predicate.And(a => a.User_DepartId.ToString() == (busUserSearchViewModel.User_DepartId));

            if (busUserSearchViewModel.Bus_LineId != "")
                predicate = predicate.And(a => a.Bus_LineId.ToString() == (busUserSearchViewModel.Bus_LineId));

            if (busUserSearchViewModel.Bus_StationId != "")
                predicate = predicate.And(a => a.Bus_StationId.ToString() == (busUserSearchViewModel.Bus_StationId));

            if (busUserSearchViewModel.User_InfoId != "")
                predicate = predicate.And(a => a.User_InfoId.ToString() == (busUserSearchViewModel.User_InfoId));

            predicate = predicate.And(a => a.status == (busUserSearchViewModel.status));

            if (busUserSearchViewModel.Expense != "")
                predicate = predicate.And(a => a.Expense == (busUserSearchViewModel.Expense));
            if (busUserSearchViewModel.carDate != null)
                predicate = predicate.And(a => a.carDate.Value.Year == busUserSearchViewModel.carDate.Value.Year
                                         && a.carDate.Value.Month == busUserSearchViewModel.carDate.Value.Month);

            return predicate;
        }
        #endregion
        #region 条件
        //根据条件查询班车
        private Expression<Func<Bus_Payment, bool>> SearchBusUserWhere(BusUserSearchViewModel  busUserSearchViewModel)
        {
            var predicate = WhereExtension.True<Bus_Payment>();//初始化where表达式
            if(busUserSearchViewModel.Repair_InfoId!=null)
                predicate = predicate.And(a => a.Repair_InfoId==busUserSearchViewModel.Repair_InfoId);
            if (busUserSearchViewModel.Bus_Payment_OrderId != null)
                predicate = predicate.And(a => a.Bus_Payment_OrderId == busUserSearchViewModel.Bus_Payment_OrderId);
            predicate = predicate.And(a => a.Bus_Payment_OrderId == null);
            predicate = predicate.And(a => a.UserName.Contains(busUserSearchViewModel.UserName));

            if (busUserSearchViewModel.User_DepartId !="")
                predicate = predicate.And(a => a.User_DepartId.ToString()== busUserSearchViewModel.User_DepartId);

            if (busUserSearchViewModel.Bus_LineId != "")
                predicate = predicate.And(a => a.Bus_LineId.ToString() == (busUserSearchViewModel.Bus_LineId) );

            if (busUserSearchViewModel.Bus_StationId != "")
                predicate = predicate.And(a => a.Bus_StationId.ToString() == (busUserSearchViewModel.Bus_StationId) );

            if (busUserSearchViewModel.User_InfoId != "")
                predicate = predicate.And(a => a.User_InfoId.ToString() == (busUserSearchViewModel.User_InfoId) );

            predicate = predicate.And(a => a.status == (busUserSearchViewModel.status));

            if (busUserSearchViewModel.Expense != "")
                predicate = predicate.And(a => a.Expense == (busUserSearchViewModel.Expense));
            if(busUserSearchViewModel.carDate!=null)
            predicate = predicate.And(a => a.carDate.Value.Year == busUserSearchViewModel.carDate.Value.Year
                                     && a.carDate.Value.Month == busUserSearchViewModel.carDate.Value.Month);
                                 
            return predicate;
        }
        #endregion
        #region 条件
        //根据条件查询班车
        private Expression<Func<Bus_Payment, bool>> BusUserTongJiExcept_SearchWhere(BusPaymentSearchViewModel busPaymentSearchViewModel)
        {
            var predicate = WhereExtension.True<Bus_Payment>();//初始化where表达式
            if (busPaymentSearchViewModel.Bus_LineId != null)          
                predicate = predicate.And(a => a.Bus_LineId == busPaymentSearchViewModel.Bus_LineId);

            predicate = predicate.And(a => a.Bus_Payment_OrderId!=null);
            if (busPaymentSearchViewModel.User_DepartId != null)
                predicate = predicate.And(a => a.User_DepartId == busPaymentSearchViewModel.User_DepartId);

            predicate = predicate.And(a => a.Bus_Payment_Order.orderNo.Contains(busPaymentSearchViewModel.orderNo));
            predicate = predicate.And(a => a.status == "0");
            predicate = predicate.And(a => a.UserName.Contains(busPaymentSearchViewModel.UserName));

            if (busPaymentSearchViewModel.carDate != null)
                predicate = predicate.And(a => a.carDate.Value.Year == busPaymentSearchViewModel.carDate.Value.Year
                                         && a.carDate.Value.Month == busPaymentSearchViewModel.carDate.Value.Month);

            return predicate;
        }
        #endregion

        #region 条件
        //根据条件查询班车
        private Expression<Func<Bus_Payment, bool>> SearchBusUser2Where(BusUserSearch2ViewModel busUserSearch2ViewModel)
        {
            var predicate = WhereExtension.True<Bus_Payment>();//初始化where表达式
            predicate = predicate.And(a => a.Bus_Payment_Order.orderNo.Contains(busUserSearch2ViewModel.orderNo));
            predicate = predicate.And(a => a.UserName.Contains(busUserSearch2ViewModel.UserName));
            predicate = predicate.And(a => a.Name.Contains(busUserSearch2ViewModel.User_DepartName));
            predicate = predicate.And(a => a.LineName.Contains(busUserSearch2ViewModel.Bus_LineName));
            predicate = predicate.And(a => a.UserName.Contains(busUserSearch2ViewModel.UserName));
            predicate = predicate.And(a => a.status == (busUserSearch2ViewModel.status));

            if (busUserSearch2ViewModel.Expense != "")
                predicate = predicate.And(a => a.Expense == (busUserSearch2ViewModel.Expense));
            if (busUserSearch2ViewModel.carDate != null)
                predicate = predicate.And(a => a.carDate.Value.Year == busUserSearch2ViewModel.carDate.Value.Year
                                         && a.carDate.Value.Month == busUserSearch2ViewModel.carDate.Value.Month);

            return predicate;
        }
        #endregion
        private Expression<Func<Bus_Payment, bool>> SearchBusUserWhere(BusPaymentUpdateViewModel  busPamentUpdateViewModel)
        {
            var predicate = WhereExtension.True<Bus_Payment>();//初始化where表达式
            predicate = predicate.And(a => a.status == "0");
            predicate = predicate.And(a => a.Bus_Payment_OrderId==null);
            predicate = predicate.And(a => a.User_DepartId==busPamentUpdateViewModel.User_DepartId);
            predicate = predicate.And(a => a.carDate.Value.Year== busPamentUpdateViewModel.carDate.Year 
                                    && a.carDate.Value.Month== busPamentUpdateViewModel.carDate.Month);

            return predicate;
        }

    
        #region 条件（查询模板账单的条件，根据模板账单生成新的班车账单）
        //根据条件查询班车
        private Expression<Func<Bus_Payment, bool>> SearchBusUserByIdWhere(BusSearchByIdViewModel busSearchByIdViewModel)
        {
            var predicate = WhereExtension.True<Bus_Payment>();//初始化where表达式
            predicate = predicate.And(a => a.status == "0");

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
            predicate = predicate.And(a => a.status == "0");
            predicate = predicate.And(a => a.User_DepartId == busUserValideViewModel.User_DepartId);
            predicate = predicate.And(a => a.carDate.Value.Year == busUserValideViewModel.carDate.Value.Year
                                 && a.carDate.Value.Month == busUserValideViewModel.carDate.Value.Month);
            return predicate;
        }




        #endregion

        /// <summary>
        /// 根据表单ID查询缴费人员信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Bus_Payment> GetInfoByBusPaymentOrderId(int id)
        {
           List<Bus_Payment> busPayment_Info = DbSet.Where(uid => uid.Repair_InfoId==id && uid.status=="0").ToList();
            return busPayment_Info;
        }


        /// <summary>
        /// 根据订单ID查询缴费人员信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Bus_Payment> GetInfoByBus(int id)
        {
            List<Bus_Payment> busPayment_Info = DbSet.Where(uid => uid.Bus_Payment_OrderId == id && uid.status == "0").ToList();
            return busPayment_Info;
        }

        public List<Bus_Payment> GetInfoByCode(string id)
        {
            List<Bus_Payment> busPayment_Info = DbSet.Where(uid => uid.Code== id && uid.status == "0").ToList();
            return busPayment_Info;
        }

        public List<Bus_Payment> GetInfoByIdCard(Bus_OrderByIdCardSearchViewModel bus_OrderByIdCardSearchViewModel)
        {
            List<Bus_Payment> busPayment_Info = DbSet.Where(uid => uid.IDNumber == bus_OrderByIdCardSearchViewModel.IDNumber &&
            uid.carDate.Value.Year == bus_OrderByIdCardSearchViewModel.CarDate.Year && uid.carDate.Value.Month == bus_OrderByIdCardSearchViewModel.CarDate.Month 
            && uid.status == "0" && uid.Code!=null).ToList();
            return busPayment_Info;
        }
    }
}
