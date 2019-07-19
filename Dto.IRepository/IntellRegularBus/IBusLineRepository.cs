using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;

namespace Dto.IRepository.IntellRegularBus
{
  public interface IBusLineRepository : IRepository<Bus_Line>
    {
        //根据线路标识查询
        IQueryable<Bus_Line> GetInfoByLineid(string lineid);
        //根据线路主键id查询
        Bus_Line GetInfoByLineId(int id);
        //批量删除
        int DeleteByLineIdList(List<int> IdList);
        // 根据条件查线路
        List<Bus_Line> SearchInfoByLineWhere(LineSearchViewModel lineSearchViewModel);
     

    }
}
