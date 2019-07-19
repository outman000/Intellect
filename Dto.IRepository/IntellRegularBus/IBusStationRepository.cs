using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.BusViewModel.RequestViewModel.StationInfoViewModel;

namespace Dto.IRepository.IntellRegularBus
{
    public interface IBusStationRepository : IRepository<Bus_Station>
    {
        //根据站点标识查询
        IQueryable<Bus_Station> GetInfoByStationId(string stationid);
        //根据站点主键id查询
        Bus_Station GetInfoByStationId(int id);
        //批量删除
        int DeleteByStationIdList(List<int> IdList);
        // 根据条件查站点
        List<Bus_Station> SearchInfoByWhere(StationSearchViewModel stationSearchViewModel);
        // 根据id查站点
        Bus_Station GetById(int id);
    }
}
