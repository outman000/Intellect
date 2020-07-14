using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel;
using ViewModel.BusViewModel.RequestViewModel.BusUserViewModel;

namespace Dto.IRepository.IntellRegularBus
{
    public interface IBusUserRepository : IRepository<Bus_Payment>
    {
        //批量删除
        int DeleteByBusUserIdList(List<int> IdList);
        //根据人员缴费主键id查询
        Bus_Payment GetInfoByBusUserId(int id);
        //根据人员缴费动态码查询
        List<Bus_Payment> GetInfoByCode(string id);

        //根据人员身份证查询
        List<Bus_Payment> GetInfoByIdCard(Bus_OrderByIdCardSearchViewModel bus_OrderByIdCardSearchViewModel);

        List<Bus_Payment> GetInfoByBusPaymentOrderId(int id);
        List<Bus_Payment> GetInfoByBus(int id);
        // 根据条件查人员缴费
        IQueryable<Bus_Payment> SearchInfoByBusWhere(BusUserSearchViewModel busUserSearchViewModel);

        // 根据条件查人员缴费
        IQueryable<Bus_Payment> SearchInfoByBusWhere2(BusUserSearch2ViewModel busUserSearch2ViewModel);
        // 根据条件查人员缴费
        IQueryable<Bus_Payment> SearchInfoByBusWhere(BusPaymentUpdateViewModel busPamentUpdateViewModel);
        // 根据条件查人员缴费
        IQueryable<Bus_Payment> SearchInfoByBusWhere(BusUserValideViewModel  busUserValideViewModel);
        IQueryable<Bus_Payment> GetInfoByBusAll2(BusUserSearch2ViewModel busUserSearch2ViewModel);
        //根据条件查人员缴费数量
        IQueryable<Bus_Payment> GetInfoByBusAll(BusUserSearchViewModel busUserSearchViewModel);
        // 根据线路Id查人员缴费数量
        IQueryable<Bus_Payment> SearchInfoByLineIdWhere(BusSearchByIdViewModel  busSearchByIdViewModel);

        /// <summary>
        /// 查询所有时间列表
        /// </summary>
        /// <returns></returns>
        IQueryable<string> SearchInfoTimeWhere(BusUserSearchTimeViewModel busUserSearchTimeViewModel);

        List<int> SearchInfoByBusDistinctWhere(BusUserSearchViewModel busUserSearchViewModel);

        List<int> SearchInfoByBusDistinctWhere2(BusUserSearchByDeaprtIdViewModel busUserSearchByDeaprtIdViewModel);

        List<Bus_Payment> SearchInfoByDateAndIdWhere(SearchByIdCardAndCarDateViewModel searchByIdCardAndCarDateViewModel);

        IQueryable<Bus_Payment> SearchInfoByBusWhere2(BusUserSearchByDeaprtIdViewModel busUserSearchByDeaprtIdViewModel);

        IQueryable<Bus_Payment> SearchInfoByBusWhere4(BusUserSearchViewModel busUserSearchViewModel);
    }
}
