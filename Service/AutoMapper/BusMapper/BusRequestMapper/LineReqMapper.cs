using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;

namespace Dto.Service.AutoMapper.BusMapper.BusRequestMapper
{
    public class LineReqMapper : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public LineReqMapper()
        {
            CreateMap<Bus_Line, LineSearchMiddlecs>();
            CreateMap<LineAddViewModel, Bus_Line>();

        }
    }
}
