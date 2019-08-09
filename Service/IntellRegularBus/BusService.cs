using AutoMapper;
using Dto.IRepository.IntellRegularBus;
using Dto.IService.IntellRegularBus;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel;
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;

namespace Dto.Service.IntellRegularBus
{
    public class BusService : IBusService
    {
        private readonly IBusInfoRepository _IBusInfoRepository;
        private readonly IBusLineRepository _IBusLineRepository;
        private readonly IMapper _IMapper;


        public BusService(IBusInfoRepository ibusInfoRepository, IBusLineRepository ibusLineRepository, IMapper mapper)
        {
            _IBusInfoRepository = ibusInfoRepository;
            _IBusLineRepository = ibusLineRepository;
                _IMapper = mapper;
        }
        public List<BusSearchMiddlecs> Bus_Search(BusSearchViewModel busSearchViewModel)
        {
            List<Bus_Info> bus_Infos = _IBusInfoRepository.SearchInfoByBusWhere(busSearchViewModel);

            List<BusSearchMiddlecs> busSearches = new List<BusSearchMiddlecs>();

            foreach (var item in bus_Infos)
            {
                var BusSearchMiddlecs = _IMapper.Map<Bus_Info, BusSearchMiddlecs>(item);
                busSearches.Add(BusSearchMiddlecs);

            }
            return busSearches;

        }
        //添加班车
        public int Bus_Add(BusAddViewModel busAddViewModel)
        {

            var bus_Info = _IMapper.Map<BusAddViewModel, Bus_Info>(busAddViewModel);
            _IBusInfoRepository.Add(bus_Info);
            return _IBusInfoRepository.SaveChanges();
        }
        //更新班车
        public int Bus_Update(BusUpdateViewModel busUpdateViewModel)
        {
            var bus_Info = _IBusInfoRepository.GetInfoByBusId(busUpdateViewModel.Id);
            var bus_Info_update = _IMapper.Map<BusUpdateViewModel, Bus_Info>(busUpdateViewModel, bus_Info);
            _IBusInfoRepository.Update(bus_Info_update);
            return _IBusInfoRepository.SaveChanges();
        }



        //删除班车（一个或者多个）
        public int Bus_Delete(BusDelViewModel busDelViewModel)
        {
            int DeleteRowsNum = _IBusInfoRepository
                 .DeleteByBusIdList(busDelViewModel.DeleleIdList);
            if (DeleteRowsNum == busDelViewModel.DeleleIdList.Count)
            {
                return DeleteRowsNum;
            }
            else
            {
                return -1;
            }

        }

        //给班车添加线路
        public int Bus_To_Line_Add(LineByBusAddViewModel lineByBusAddViewModel)
        {
            var bus_Info = _IBusInfoRepository.GetInfoByBusId(lineByBusAddViewModel.Id);
            var bus_Info_update=  _IMapper.Map<LineByBusAddViewModel, Bus_Info>(lineByBusAddViewModel, bus_Info);
            _IBusInfoRepository.Update(bus_Info_update);
            return _IBusInfoRepository.SaveChanges();
        }

        public bool Bus_Single(BusValideRepeat busValideRepeat)
        {
            IQueryable<Bus_Info> Queryable_UserDepart = _IBusInfoRepository
                                                                 .GetInfoByBusId(busValideRepeat.Code);
            return (Queryable_UserDepart.Count() < 1) ?
                   true : false;
        }

        public int Bus_Get_ALLNum()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 根据线路添加班车
        /// </summary>
        /// <param name="busByLineAddViewModel"></param>
        /// <returns></returns>
        public int Line_To_Bus_Add(BusByLineAddViewModel busByLineAddViewModel)
        {

            var busList = busByLineAddViewModel.relateBusIdAndLineIdList;//班车id和线路id列表

            for (int i = 0; i < busList.Count; i++)
            {
                var bus_info = _IBusInfoRepository.GetInfoByBusId(busList[i].Id);
                var bus_info_update = _IMapper.Map<RelateBusLineAddMiddlecs, Bus_Info>(busList[i], bus_info);
                _IBusInfoRepository.Update(bus_info_update);
            }   
            return _IBusInfoRepository.SaveChanges();
        }
        /// <summary>
        /// 根据线路查班车
        /// </summary>
        /// <param name="busByLineSearchViewModel"></param>
        /// <returns></returns>
        public List<Bus_Info> Bus_By_Line_Search(BusByLineSearchViewModel busByLineSearchViewModel)
        {
            List<Bus_Info> Bus_Relate_Line= _IBusInfoRepository.SearchBusInfoByLineWhere(busByLineSearchViewModel);

          
            return Bus_Relate_Line;
        }
        /// <summary>
        /// 根据班车查询线路
        /// </summary>
        /// <param name="lineByBusSearchViewModel"></param>
        /// <returns></returns>
        public List<LineSearchMiddlecs> Line_By_Bus_Search(LineByBusSearchViewModel lineByBusSearchViewModel)
        {
            List<Bus_Info> Bus_Relate_Line = _IBusInfoRepository.SearchLineInfoByBusWhere(lineByBusSearchViewModel);
            List<LineSearchMiddlecs> line_infos = new List<LineSearchMiddlecs>();
            foreach (var item in Bus_Relate_Line)
            {
                var user_info_temp = _IMapper.Map<Bus_Line, LineSearchMiddlecs>(item.Bus_Line);
                line_infos.Add(user_info_temp);
            }
            return line_infos;
        
        }
        /// <summary>
        /// 查询班车数量
        /// </summary>
        /// <param name="busSearchViewModel"></param>
        /// <returns></returns>
        public int Bus_Get_ALLNum(BusSearchViewModel busSearchViewModel)
        {
            return _IBusInfoRepository.GetBusAll(busSearchViewModel).Count();
        }
        /// <summary>
        /// 根据线路查班车数量
        /// </summary>
        /// <param name="busByLineSearchViewModel"></param>
        /// <returns></returns>
        public int Bus_By_Line_Get_ALLNum(BusByLineSearchViewModel busByLineSearchViewModel)
        {
            return _IBusInfoRepository.GetBusInfoByLineAll(busByLineSearchViewModel).Count();
        }
        /// <summary>
        /// 根据班车查线路数量
        /// </summary>
        /// <param name="lineByBusSearchViewModel"></param>
        /// <returns></returns>
        public int Line_By_Bus_Get_ALLNum(LineByBusSearchViewModel lineByBusSearchViewModel)
        {
            return _IBusInfoRepository.GetLineInfoByBusAll(lineByBusSearchViewModel).Count();
        }
    }
}
