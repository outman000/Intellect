using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.BusViewModel.RequestViewModel.BusUserViewModel;

namespace Dto.IRepository.IntellRegularBus
{
    public interface IBusUserRepository : IRepository<Bus_Payment>
    {
        //批量删除
        int DeleteByBusUserIdList(List<int> IdList);
        //根据人员缴费主键id查询
        Bus_Payment GetInfoByBusUserId(int id);

        // 根据条件查人员缴费
        IQueryable<Bus_Payment> SearchInfoByBusWhere(BusUserSearchViewModel busUserSearchViewModel);
    }
}
