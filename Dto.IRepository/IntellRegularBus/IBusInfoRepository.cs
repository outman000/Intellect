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
        void Add_Reassignment_Record(Car_Reassignment_Record obj);
        //根据班车标识查询
        IQueryable<Bus_Info> GetInfoByBusId(string busid);
        //根据班车主键id查询
        Bus_Info GetInfoByBusId(int id);

        List<Bus_Info> GetInfoByDeviceNumber(string deviceNumber);
        //批量删除
        int DeleteByBusIdList(List<int> IdList);
        // 根据条件查班车
        List<Bus_Info> SearchInfoByBusWhere(BusSearchViewModel busSearchViewModel);
        // 根据id查班车
        Bus_Info GetById(int id);
        //查询班车数量
        IQueryable<Bus_Info> GetBusAll(BusSearchViewModel busSearchViewModel);
        /// <summary>
        ///根据线路查询班车
        /// </summary>
        /// <param name="busByLineSearchViewModel"></param>
        /// <returns></returns>
        List<Bus_Info> SearchBusInfoByLineWhere(BusByLineSearchViewModel busByLineSearchViewModel);

        /// <summary>
        ///根据线路查询班车（重载）
        /// </summary>
        /// <param name="bus_LineId"></param>
        /// <returns></returns>
       Bus_Info SearchBusInfoSingleByLineWhere(int  bus_LineId);

        //根据线路查询班车数量
        IQueryable<Bus_Info> GetBusInfoByLineAll(BusByLineSearchViewModel busByLineSearchViewModel);

        /// <summary>
        ///根据班车查询线路
        /// </summary>
        /// <param name="lineByBusSearchViewModel"></param>
        /// <returns></returns>
        List<Bus_Info> SearchLineInfoByBusWhere(LineByBusSearchViewModel lineByBusSearchViewModel);

        //根据班车查询线路数量
        IQueryable<Bus_Info> GetLineInfoByBusAll(LineByBusSearchViewModel lineByBusSearchViewModel);


        List<Gas_Card_Account> SearchGasCardAccount();


        List<Car_Reassignment_Record> SearchReassignmentRecord(ReassignmentRecordSearchViewModel reassignmentRecordSearchViewModel);

        int SearchReassignmentRecordNum();
    }
}
