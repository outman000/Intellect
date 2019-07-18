using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;

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
         

        }
    }
}
