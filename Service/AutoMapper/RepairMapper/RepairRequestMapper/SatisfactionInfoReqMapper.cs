using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;

namespace Dto.Service.AutoMapper.RepairMapper.RepairRequestMapper
{
    public class SatisfactionInfoReqMapper : Profile

    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public SatisfactionInfoReqMapper()
        {

            CreateMap<Satisfaction_Info, SatisfactionInfoSearchMiddlecs>()
            .ForMember(s => s.Name, sp => sp.MapFrom(src => src.User_Info.User_Depart.Name))
            .ForMember(s => s.RepairsTitle, sp => sp.MapFrom(src => src.Repair_Info.RepairsTitle))
            .ForMember(s => s.UserName, sp => sp.MapFrom(src => src.User_Info.UserName));

        }
    }
}
