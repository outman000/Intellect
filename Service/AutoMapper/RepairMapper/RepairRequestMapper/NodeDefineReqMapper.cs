using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;
using ViewModel.UserViewModel.MiddleModel;

namespace Dto.Service.AutoMapper.RepairMapper.RepairRequestMapper
{
    public class NodeDefineReqMapper : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public NodeDefineReqMapper()
        {
            CreateMap<Flow_NodeDefine, FlowNodeDefineSearchMiddlecs>()
            .ForMember(s => s.NodeName, sp => sp.MapFrom(src => src.NodeName))
            .ForMember(s => s.FlowNextName, sp => sp.MapFrom(src => src.Flow_NextNodeDefine.NodeName))
            .ForMember(s => s.FlowProcedureDefineName, sp => sp.MapFrom(src => src.Flow_ProcedureDefine.ProcedureName))
            .ForMember(s => s.NodeType, sp => sp.MapFrom(src => src.NodeType));
            CreateMap<FlowNodeDefineAddViewModel, Flow_NodeDefine>();
            CreateMap<FlowNodeDefineUpdateViewModel, Flow_NodeDefine>();
            CreateMap <RelateRoleByNodeAddModelcs,Flow_Relate_NodeRole>();
            CreateMap<User_Role, UserRoleSearChMiddles>();
        }
    }
}
