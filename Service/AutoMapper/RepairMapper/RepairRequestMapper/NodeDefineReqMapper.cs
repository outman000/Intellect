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
            .ForMember(s => s.FlowProcedureDefineName, sp => sp.MapFrom(src => src.Flow_ProcedureDefine.ProcedureName))
            .ForMember(s => s.NodeKeep, sp => sp.MapFrom(src => src.NodeKeep))
            .ForMember(s => s.status, sp => sp.MapFrom(src => src.status))
            .ForMember(s => s.Flow_ProcedureDefineId, sp => sp.MapFrom(src => src.Flow_ProcedureDefineId))
            .ForMember(s => s.NodeType, sp => sp.MapFrom(src => src.NodeType));

            CreateMap< Flow_CurrentNodeAndNextNode, FlowNodeDefineSearchMiddlecs> ()
            .ForMember(s => s.NodeName, sp => sp.MapFrom(src => src.Flow_NextNodeDefine.NodeName))
            .ForMember(s => s.FlowProcedureDefineName, sp => sp.MapFrom(src => src.Flow_NextNodeDefine.Flow_ProcedureDefine.ProcedureName))
            .ForMember(s => s.NodeKeep, sp => sp.MapFrom(src => src.Flow_NextNodeDefine.NodeKeep))
            .ForMember(s => s.Flow_ProcedureDefineId, sp => sp.MapFrom(src => src.Flow_NextNodeDefine.Flow_ProcedureDefineId))
            .ForMember(s => s.status, sp => sp.MapFrom(src => src.Flow_NextNodeDefine.status))
            .ForMember(s => s.Flow_NodeDefineId, sp => sp.MapFrom(src => src.Flow_NextNodeDefineId))
            .ForMember(s => s.NodeType, sp => sp.MapFrom(src => src.Flow_NextNodeDefine.NodeType));


            CreateMap<FlowNodeDefineAddViewModel, Flow_NodeDefine>();
            CreateMap<FlowNodeDefineUpdateViewModel, Flow_NodeDefine>();
            CreateMap <RelateRoleByNodeAddModelcs,Flow_Relate_NodeRole>();
            CreateMap<User_Role, UserRoleSearChMiddles>();
            CreateMap<FlowProcedureByNodeIdAddMiddlecs, Flow_NodeDefine>();

            CreateMap< CurrentNodeToNextNodeAddMiddlecs ,Flow_CurrentNodeAndNextNode>();
        }
    }
}
