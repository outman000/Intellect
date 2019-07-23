using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.BusUserViewModel;

namespace Dto.Service.AutoMapper.BusMapper.BusRequestMapper
{
    public class BusUserReqMapper : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public BusUserReqMapper()
        {
            CreateMap<BusUserAddViewModel, Bus_Payment>();
            CreateMap < BusUserUpdateViewModel, Bus_Payment>();

            CreateMap<Bus_Payment, BusUserSearchMiddlecs>()
             .ForMember(s => s.Name, sp => sp.MapFrom(src => src.User_Depart.Name))
             .ForMember(s => s.LineName, sp => sp.MapFrom(src => src.Bus_Line.LineName))
             .ForMember(s => s.StationName, sp => sp.MapFrom(src => src.Bus_Station.StationName))
             .ForMember(s => s.UserName, sp => sp.MapFrom(src => src.User_Info.UserName))
             .ForMember(s => s.Expense, sp => sp.MapFrom(src => src.Bus_Station.Expense))
             .ForMember(s => s.status, sp => sp.MapFrom(src => src.status));

        }
    }
}
