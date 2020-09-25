using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel;
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;

namespace Dto.Service.AutoMapper.BusMapper.BusRequestMapper
{
    public class BusReqMapper : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public BusReqMapper()
        {
            CreateMap<Bus_Info, BusSearchMiddlecs>();
            CreateMap<BusAddViewModel, Bus_Info>();
            CreateMap<BusUpdateViewModel, Bus_Info>();
            CreateMap<LineByBusAddViewModel, LineSearchViewModel>();
            CreateMap<List<Bus_Line>, LineByBusAddMiddlecs>();
            CreateMap<LineByBusAddViewModel, Bus_Info>();
            CreateMap<RelateBusLineAddMiddlecs, Bus_Info>();
            CreateMap<Bus_Info, BusBasicSearchMiddle>();
            CreateMap<ReassignmentRecordAddViewModel, Car_Reassignment_Record >();
        }
    }
}
