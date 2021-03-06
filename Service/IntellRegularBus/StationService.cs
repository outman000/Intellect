﻿using AutoMapper;
using Dto.IRepository.IntellRegularBus;
using Dto.IService.IntellRegularBus;
using Dtol.dtol;
using System.Collections.Generic;
using System.Linq;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;
using ViewModel.BusViewModel.RequestViewModel.StationInfoViewModel;

namespace Dto.Service.IntellRegularBus
{
    public class StationService : IStationService
    {
        private readonly IBusStationRepository _IBusStationRepository;
        private readonly IMapper _IMapper;

        public StationService(IBusStationRepository ibusStationRepository, IMapper mapper)
        {
            _IBusStationRepository = ibusStationRepository;

            _IMapper = mapper;
        }

        public List<StationSearchMiddlecs> Station_Search(StationSearchViewModel stationSearchViewModel)
        {
            List<Bus_Station> line_Infos = _IBusStationRepository.SearchInfoByWhere(stationSearchViewModel);

            List<StationSearchMiddlecs> lineSearches = new List<StationSearchMiddlecs>();

            foreach (var item in line_Infos)
            {
                var stationSearchMiddlecs = _IMapper.Map<Bus_Station, StationSearchMiddlecs>(item);

                if (stationSearchMiddlecs.OnWorkDate != null)
                    //把上班时间格式转为时和分
                 stationSearchMiddlecs.OnDate = stationSearchMiddlecs.OnWorkDate.Value.ToString("HH:mm");

                if(stationSearchMiddlecs.OffWorkDate!= null)
                 //把下班时间格式转为时和分
                 stationSearchMiddlecs.OffDate = stationSearchMiddlecs.OffWorkDate.Value.ToString("HH:mm");
                
                lineSearches.Add(stationSearchMiddlecs);
            }
            return lineSearches;
        }
        /// <summary>
        /// 线裤增加
        /// </summary>
        /// <param name="lineAddViewModel"></param>
        /// <returns></returns>
        public int Station_Add(StationAddViewModel lineAddViewModel)
        {

            var bus_Sation = _IMapper.Map<StationAddViewModel, Bus_Station>(lineAddViewModel);
            _IBusStationRepository.Add(bus_Sation);
            return _IBusStationRepository.SaveChanges();
        }
        /// <summary>
        /// 站点更新
        /// </summary>
        /// <param name="stationUpdateViewModel"></param>
        /// <returns></returns>
        public int Station_Update(StationUpdateViewModel stationUpdateViewModel)
        {
            var Station_Info = _IBusStationRepository.GetInfoByStationId(stationUpdateViewModel.Id);
            var Station_Info_Update = _IMapper.Map<StationUpdateViewModel, Bus_Station>(stationUpdateViewModel, Station_Info);
            _IBusStationRepository.Update(Station_Info_Update);
            return _IBusStationRepository.SaveChanges();
        }

        //删除班车（一个或者多个）
        public int Station_Delete(StationDelViewModel stationDelViewModel)
        {
            int DeleteRowsNum = _IBusStationRepository
                .DeleteByStationIdList(stationDelViewModel.DeleleIdList);
            if (DeleteRowsNum == stationDelViewModel.DeleleIdList.Count)
            {
                return DeleteRowsNum;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 验证线路唯一性
        /// </summary>
        /// <param name="busValideRepeat"></param>
        /// <returns></returns>
        public bool Station_Single(BusValideRepeat busValideRepeat)
        {
            IQueryable<Bus_Station> Queryable_UserDepart = _IBusStationRepository
                                                                .GetInfoByStationId(busValideRepeat.Code);
            return (Queryable_UserDepart.Count() < 1) ?
                   true : false;
        }
        /// <summary>
        /// 根据线路增加站点  /  根据线路取消站点
        /// </summary>
        /// <param name="stationByLineAddViewModel"></param>
        /// <returns></returns>
        public int Line_To_Station_Add(StationByLineAddViewModel stationByLineAddViewModel)
        {
            var staionList = stationByLineAddViewModel.relateLineIdAndStationIdList;  //线路id和站点id列表

            for (int i = 0; i < staionList.Count; i++)
            {
                var station_info = _IBusStationRepository.GetInfoByStationId(staionList[i].Id);
                var station_info_update = _IMapper.Map<RelateLineStationAddMiddlecs, Bus_Station>(staionList[i], station_info);
                _IBusStationRepository.Update(station_info_update);
            }
            return _IBusStationRepository.SaveChanges();
        }
        /// <summary>
        /// 根据站点增加线路  /  根据站点取消线路
        /// </summary>
        /// <param name="lineByStationAddViewModel"></param>
        /// <returns></returns>
        public int Station_To_Line_Add(LineByStationAddViewModel lineByStationAddViewModel)
        {
            var station_Info = _IBusStationRepository.GetById(lineByStationAddViewModel.Id);
            var station_Info_update = _IMapper.Map<LineByStationAddViewModel, Bus_Station>(lineByStationAddViewModel, station_Info);
            _IBusStationRepository.Update(station_Info_update);
            return _IBusStationRepository.SaveChanges();
        }
        /// <summary>
        /// 根据站点查询线路
        /// </summary>
        /// <param name="lineByStationViewModel"></param>
        /// <returns></returns>
        public List<LineSearchMiddlecs> Line_By_Station_Search(LineByStationViewModel lineByStationViewModel)
        {
            List<Bus_Station> Station_Relate_Line = _IBusStationRepository.SearchLineInfoByStationWhere(lineByStationViewModel);
            List<LineSearchMiddlecs> line_infos = new List<LineSearchMiddlecs>();
            foreach (var im in Station_Relate_Line)
            {
                var line_info_temp = _IMapper.Map<Bus_Line, LineSearchMiddlecs>(im.Bus_Line);
                line_infos.Add(line_info_temp);
            }
            return line_infos;
        }
        /// <summary>
        /// 根据线路查站点
        /// </summary>
        /// <param name="busByLineSearchViewModel"></param>
        /// <returns></returns>
        public List<Bus_Station> Bus_By_Line_Search(StationByLineSearchViewModel stationByLineSearchViewModel)
        {
            List<Bus_Station> Bus_Relate_Line = _IBusStationRepository.SearchStationInfoByLineWhere(stationByLineSearchViewModel);


            return Bus_Relate_Line;
        }
        /// <summary>
        /// 站点数量
        /// </summary>
        /// <param name="stationSearchViewModel"></param>
        /// <returns></returns>
        public int Station_Get_ALLNum(StationSearchViewModel stationSearchViewModel)
        {
            return _IBusStationRepository.GetStationAll(stationSearchViewModel).Count();
        }
        /// <summary>
        /// 根据站点查线路数量
        /// </summary>
        /// <param name="lineByStationViewModel"></param>
        /// <returns></returns>
        public int Line_By_Station_Get_ALLNum(LineByStationViewModel lineByStationViewModel)
        {
            return _IBusStationRepository.GetLineInfoByStationAll(lineByStationViewModel).Count();
        }
        /// <summary>
        /// 根据线路查班车数量
        /// </summary>
        /// <param name="stationByLineSearchViewModel"></param>
        /// <returns></returns>
        public int Bus_By_Line_Get_ALLNum(StationByLineSearchViewModel stationByLineSearchViewModel)
        {
            return _IBusStationRepository.GetStationInfoByLinAll(stationByLineSearchViewModel).Count();
        }
    }
}
