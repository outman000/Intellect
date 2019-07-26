using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;
using ViewModel.BusViewModel.RequestViewModel.StationInfoViewModel;

namespace Dto.IService.IntellRegularBus
{
    public interface IStationService
    {
        /// <summary>
        /// 查询站点信息
        /// </summary>
        /// <param name="stationSearchViewModel"></param>
        List<StationSearchMiddlecs> Station_Search(StationSearchViewModel stationSearchViewModel);

        /// <summary>
        /// 查询站点信息数量
        /// </summary>
        /// <param name="stationSearchViewModel"></param>
        /// <returns></returns>
        int Station_Get_ALLNum(StationSearchViewModel stationSearchViewModel);
        /// <summary>
        /// 添加站点
        /// </summary>
        /// <param name="lineAddViewModel"></param>
        /// <returns></returns>
        int Station_Add(StationAddViewModel lineAddViewModel);

        /// <summary>
        /// 删除线路信息
        /// </summary>
        /// <param name="lineDelViewModel"></param>
        /// <returns></returns>
        int Station_Delete(StationDelViewModel stationDelViewModel);

        /// <summary>
        /// 更新线路信息
        /// </summary>
        /// <param name="lineUpdateViewModel"></param>
        /// <returns></returns>
        int Station_Update(StationUpdateViewModel stationUpdateViewModel);

        /// <summary>
        /// 验证线路的唯一性
        /// </summary>
        /// <param name="busValideRepeat"></param>
        /// <returns></returns>
        bool Station_Single(BusValideRepeat busValideRepeat);

        /// <summary>
        /// 根据线路增加站点
        /// </summary>
        /// <param name="stationByLineAddViewModel"></param>
        /// <returns></returns>
        int Line_To_Station_Add(StationByLineAddViewModel stationByLineAddViewModel);

        /// <summary>
        /// 根据站点增加线路
        /// </summary>
        /// <param name="lineByStationAddViewModel"></param>
        /// <returns></returns>
        int Station_To_Line_Add(LineByStationAddViewModel lineByStationAddViewModel);

        /// <summary>
        ///根据站点查询线路
        /// </summary>
        /// <param name="lineByStationViewModel"></param>
        /// <returns></returns>
        List<LineSearchMiddlecs> Line_By_Station_Search(LineByStationViewModel lineByStationViewModel);

        /// <summary>
        /// 根据站点查询线路数量
        /// </summary>
        /// <param name="lineByStationViewModel"></param>
        /// <returns></returns>
        int Line_By_Station_Get_ALLNum(LineByStationViewModel lineByStationViewModel);
        /// <summary>
        ///根据线路查站点
        /// </summary>
        /// <param name="stationByLineSearchViewModel"></param>
        /// <returns></returns>
        List<Bus_Station> Bus_By_Line_Search(StationByLineSearchViewModel stationByLineSearchViewModel);
        /// <summary>
        /// 根据线路查站点数量
        /// </summary>
        /// <param name="lineByStationViewModel"></param>
        /// <returns></returns>
        int Bus_By_Line_Get_ALLNum(StationByLineSearchViewModel stationByLineSearchViewModel);
    }
}
