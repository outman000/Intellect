using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.Service.AutoMapper.RepairMapper.RepairRequestMapper
{
    public class RepairReqMapper : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public RepairReqMapper()
        {
          
             CreateMap<Repair_Info, RepairInfoSearchMiddlecs>()
             .ForMember(s => s.Name, sp => sp.MapFrom(src => src.User_Depart.Name))
             .ForMember(s => s.RepairsTitle, sp => sp.MapFrom(src => src.RepairsTitle))
             .ForMember(s => s.RepairsType, sp => sp.MapFrom(src => src.RepairsType))
             .ForMember(s => s.UserName, sp => sp.MapFrom(src => src.User_Info.UserName))
             .ForMember(s => s.repairsDate, sp => sp.MapFrom(src => src.repairsDate))
             .ForMember(s => s.status, sp => sp.MapFrom(src => src.status));
             CreateMap<RepairUpdateViewModel, Repair_Info>();
             CreateMap<RepairAddViewModel, Repair_Info>();

        }
    }
}
