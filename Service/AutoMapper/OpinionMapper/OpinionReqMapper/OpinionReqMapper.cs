using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.OpinionInfoViewModel.MiddleModel;
using ViewModel.OpinionInfoViewModel.RequestViewModel;

namespace Dto.Service.AutoMapper.OpinionMapper.OpinionReqMapper
{
    public class OpinionReqMapper : Profile
    {  
        /// <summary>
        /// 配置构造函数，用来创建关系映射
         /// </summary>
        public OpinionReqMapper()
        {
            CreateMap<OpinionInfoUpdateViewModel, Opinion_Info>();
            CreateMap<OpinionInfoAddViewModel, Opinion_Info>();
            CreateMap<Opinion_Info, OpinionInfoSearchMiddlecs>()
            .ForMember(s => s.NodeName, sp => sp.MapFrom(src => src.Flow_NodeDefine.NodeName))     
            .ForMember(s => s.DepartName, sp => sp.MapFrom(src => src.User_Info.User_Depart.Name))
            .ForMember(s => s.UserName, sp => sp.MapFrom(src => src.User_Info.UserName));


        }
    }
}
