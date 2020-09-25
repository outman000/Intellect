using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel;
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;

namespace Dto.IService.IntellRegularBus
{
    public interface IBusService
    {
        /// <summary>
        /// 添加班车
        /// </summary>
        /// <param name="busAddViewModel"></param>
        /// <returns></returns>
        int Bus_Add(BusAddViewModel busAddViewModel);

        /// <summary>
        /// 更新班车信息
        /// </summary>
        /// <param name="busUpdateViewModel"></param>
        /// <returns></returns>

        int Bus_Update(BusUpdateViewModel busUpdateViewModel);
        /// <summary>
        /// 删除班车信息
        /// </summary>
        /// <param name="busDelViewModel"></param>
        /// <returns></returns>
        int Bus_Delete(BusDelViewModel busDelViewModel);
        /// <summary>
        /// 查询班车信息
        /// </summary>
        /// <param name="busSearchViewModel"></param>
        List<BusSearchMiddlecs> Bus_Search(BusSearchViewModel busSearchViewModel);

        /// <summary>
        /// 获取班车总数
        /// </summary>
        /// <returns></returns>
        int Bus_Get_ALLNum(BusSearchViewModel busSearchViewModel);
        /// <summary>
        /// 验证班车的唯一性
        /// </summary>
        /// <param name="busValideRepeat"></param>
        /// <returns></returns>
        bool Bus_Single(BusValideRepeat busValideRepeat);
         /// <summary>
         /// 获取班车总数
         /// </summary>
         /// <returns></returns>
         int Bus_Get_ALLNum();
        /// <summary>
        /// 根据班车添加线路
        /// </summary>
        /// <param name="lineByBusAddViewModel"></param>
        /// <returns></returns>
        int Bus_To_Line_Add(LineByBusAddViewModel lineByBusAddViewModel);

        /// <summary>
        /// 根据线路添加班车
        /// </summary>
        /// <param name="lineByBusAddViewModel"></param>
        /// <returns></returns>
        int Line_To_Bus_Add(BusByLineAddViewModel busByLineAddView);
        /// <summary>
        ///根据线路查班车
        /// </summary>
        /// <param name="busByLineSearchViewModel"></param>
        /// <returns></returns>
        List<Bus_Info> Bus_By_Line_Search(BusByLineSearchViewModel busByLineSearchViewModel);

        /// <summary>
        ///根据线路查班车（重载）
        /// </summary>
        /// <param name="bus_LineId"></param>
        /// <returns></returns>
        Bus_Info Bus_By_Line_Search(int bus_LineId);

        //根据线路查班车数量
        int Bus_By_Line_Get_ALLNum(BusByLineSearchViewModel busByLineSearchViewModel);
        /// <summary>
        ///根据班车查询线路
        /// </summary>
        /// <param name="lineByBusSearchViewModel"></param>
        /// <returns></returns>
        List<LineSearchMiddlecs> Line_By_Bus_Search(LineByBusSearchViewModel lineByBusSearchViewModel);

        /// <summary>
        /// 根据班车查线路
        /// </summary>
        /// <param name="lineByBusSearchViewModel"></param>
        /// <returns></returns>
        int Line_By_Bus_Get_ALLNum(LineByBusSearchViewModel lineByBusSearchViewModel);

        /// <summary>
        /// 查询加油卡账户
        /// </summary>
        /// <returns></returns>
        List<Gas_Card_Account> GasCardAccount_Search();


        /// <summary>
        /// 增加改派信息并给改派前司机发短信
        /// </summary>
        /// <param name="reassignmentRecordAddViewModel"></param>
        /// <returns></returns>
        int Car_Reassignment_Record_Add(ReassignmentRecordAddViewModel reassignmentRecordAddViewModel);

        /// <summary>
        /// 查询改派记录
        /// </summary>
        /// <param name="reassignmentRecordSearchViewMode"></param>
        /// <returns></returns>
        List<Car_Reassignment_Record> Search_ReassignmentRecord(ReassignmentRecordSearchViewModel reassignmentRecordSearchViewMode);


        /// <summary>
        /// 改派记录数量
        /// </summary>
        /// <returns></returns>
        int Search_ReassignmentRecord_Num();
    }
}
