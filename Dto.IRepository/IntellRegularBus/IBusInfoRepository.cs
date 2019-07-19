using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel;
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;

namespace Dto.IRepository.IntellRegularBus
{
    public  interface IBusInfoRepository : IRepository<Bus_Info>
    {
        //根据班车标识查询
        IQueryable<Bus_Info> GetInfoByBusId(string busid);
        //根据班车主键id查询
        Bus_Info GetInfoByBusId(int id);
        //批量删除
        int DeleteByBusIdList(List<int> IdList);
        // 根据条件查班车
        List<Bus_Info> SearchInfoByWhere(BusSearchViewModel busSearchViewModel);
        // 根据id查班车
        Bus_Info GetById(int id);

        /// <summary>
        ///根据线路查询班车
        /// </summary>
        /// <param name="busByLineSearchViewModel"></param>
        /// <returns></returns>
        List<Bus_Info> SearchBusInfoByLineWhere(BusByLineSearchViewModel busByLineSearchViewModel);

        /// <summary>
        ///根据班车查询线路
        /// </summary>
        /// <param name="lineByBusSearchViewModel"></param>
        /// <returns></returns>
        List<Bus_Info> SearchLineInfoByBusWhere(LineByBusSearchViewModel lineByBusSearchViewModel);
    }
}
