using AutoMapper;
using Dto.IRepository.IntellRegularBus;
using Dto.IService.IntellRegularBus;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
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
            List<Bus_Info> bus_Infos = _IBusInfoRepository.SearchInfoByWhere(busSearchViewModel);

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
            var bus_Info = _IMapper.Map<BusUpdateViewModel, Bus_Info>(busUpdateViewModel);
            _IBusInfoRepository.Update(bus_Info);
            return _IBusInfoRepository.SaveChanges();
        }
        //根据线路更新班车
        public int Bus_By_Line_Update(int id , int Bus_LineId)
        {
            LineByBusAddMiddlecs lineByBusAddMiddlecs = new LineByBusAddMiddlecs();
            lineByBusAddMiddlecs.Id = id;
            lineByBusAddMiddlecs.Bus_LineId = Bus_LineId;
            Bus_Info bus_Info = _IMapper.Map<LineByBusAddMiddlecs, Bus_Info>(lineByBusAddMiddlecs);
            _IBusInfoRepository.Update(bus_Info);
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
            //获取视图集合
            LineNameMiddlecs lineNameMiddlecs= _IMapper.Map<LineByBusAddViewModel, LineNameMiddlecs>(lineByBusAddViewModel);
            LineSearchViewModel lineSearchViewModel = _IMapper.Map<LineNameMiddlecs, LineSearchViewModel>(lineNameMiddlecs);
            List<Bus_Line> Line_Info=_IBusLineRepository.SearchBusByLineWhere(lineSearchViewModel);
            int Bus_LineId = Line_Info[0].Id;
            int updatenNum = Bus_By_Line_Update(lineByBusAddViewModel.Busid, Bus_LineId);
            return updatenNum;
        }

    }
}
