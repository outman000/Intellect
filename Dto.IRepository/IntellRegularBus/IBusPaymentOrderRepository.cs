using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.BusViewModel.RequestViewModel.BusUserViewModel;

namespace Dto.IRepository.IntellRegularBus
{
   public interface IBusPaymentOrderRepository : IRepository<Bus_Payment_Order>
    {
        //根据人员缴费主键id查询
        Bus_Payment_Order GetInfoByBusPaymentOrderId(int id);
        //根据人员表单id查询
        Bus_Payment_Order GetInfoByRepair_InfoId(int id);

 
        // 根据条件查人员缴费
        IQueryable<Bus_Payment_Order> SearchInfoByBusPaymentOrderWhere(Bus_Payment_OrderSearchViewModel  bus_Payment_OrderSearchViewModel);

        // 根据条件查人员缴费
        List<Bus_Payment_Order> SearchInfoByUserIdWhere(Bus_OrderIsPassSearchViewModel bus_OrderIsPassSearchViewModel);
        List<Bus_Payment_Order> SearchInfoWhere();
    }
}
