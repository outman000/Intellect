using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.StationInfoViewModel;

namespace Dto.Service.AutoMapper.BusMapper.BusRequestMapper
{
    public class StationReqMapper : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public StationReqMapper()
        {
            CreateMap<Bus_Station, StationSearchMiddlecs>();
            CreateMap<StationUpdateViewModel, Bus_Station>();
            CreateMap<StationAddViewModel, Bus_Station >();
            CreateMap<RelateLineStationAddMiddlecs, Bus_Station >();
            CreateMap<Bus_Line, LineSearchMiddlecs>();
        }

       
    }
}
