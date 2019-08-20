using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.Service.AutoMapper.RepairMapper.RepairRequestMapper
{
    public class FlowNodeReqMapper : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>E
        public FlowNodeReqMapper()
        {
            CreateMap<FlowNodeAddViewModel, Flow_Node>();
            CreateMap< FlowNodeDefineUpdateViewModel, Flow_Node >();
            CreateMap < FlowNodeUpdateViewModel, Flow_Node >();
            CreateMap<Flow_Node, FlowNodeSearchMiddlecs>();
            //二级属性将第二层级的一些属性userinfo过滤掉
            CreateMap<Repair_Info, FlowNodeRepaireInfoMiddle>()
                 .ForMember(s => s.userName, sp => sp.MapFrom(src => src.User_Info.UserName));

            //二级复杂属性User_Info的信息过滤掉
            CreateMap<User_Info, FlowNodeUserInfoMiddles>();
            
        }
    }
}
