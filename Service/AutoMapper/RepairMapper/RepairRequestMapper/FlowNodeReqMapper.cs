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
        /// </summary>
        public FlowNodeReqMapper()
        {
            CreateMap<FlowNodeAddViewModel, Flow_Node>();
            CreateMap< FlowNodeDefineUpdateViewModel, Flow_Node >();
            CreateMap < FlowNodeUpdateViewModel, Flow_Node >();
            CreateMap < Flow_Node,FlowNodeSearchMiddlecs>();
        }
    }
}
