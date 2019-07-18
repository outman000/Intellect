using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel;

namespace Dto.IRepository.IntellRegularBus
{
    public  interface IBusInfoRepository : IRepository<Bus_Info>
    {
        //根据班车标识查询
        IQueryable<Bus_Info> GetInfoByUserid(string busid);
        //根据班车主键id查询
        Bus_Info GetInfoByUserid(int id);
        //批量删除
        int DeleteByBusidList(List<int> IdList);
        // 根据条件查班车
        List<Bus_Info> SearchInfoByWhere(BusSearchViewModel busSearchViewModel);
    }
}
