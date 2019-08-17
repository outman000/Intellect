using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.Service.AutoMapper.RepairMapper.RepairRequestMapper
{
    public class WorkFlowReqMapper : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>E
        public WorkFlowReqMapper()
        {
            //增加表单的同时增加流程信息
            CreateMap<Repair_Info, FlowProcedureAddViewModel>()
            .ForMember(s => s.Repair_InfoId, sp => sp.MapFrom(src => src.id))
            .ForMember(s => s.Starttime, sp => sp.MapFrom(src => src.repairsDate))
            .ForMember(s => s.status, sp => sp.MapFrom(src => src.status));

            CreateMap<FlowProcedureAddViewModel, Flow_Procedure>();

            CreateMap<Flow_NodeDefine, FlowNodePreMiddlecs>()
            .ForMember(s => s.Flow_NodeDefineId, sp => sp.MapFrom(src => src.Id))
            .ForMember(s => s.Flow_NextNodeDefineId, sp => sp.MapFrom(src => src.Flow_NextNodeDefineId))
            .ForMember(s => s.status, sp => sp.MapFrom(src => src.status));



            CreateMap<FlowInfoSearchViewModel, Flow_Node>()
            .ForMember(s => s.Flow_NodeDefineId, sp => sp.MapFrom(src => src.Flow_NodeDefineId))
            .ForMember(s => s.Parent_Flow_NodeDefineId, sp => sp.MapFrom(src => src.Parent_Flow_NodeDefineId))
            .ForMember(s => s.status, sp => sp.MapFrom(src => src.status))
            .ForMember(s => s.operate, sp => sp.MapFrom(src => src.operate))
            .ForMember(s => s.EndTime, sp => sp.MapFrom(src => src.EndTime))
            .ForMember(s => s.StartTime, sp => sp.MapFrom(src => src.StartTime))
            .ForMember(s => s.Pre_User_InfoId, sp => sp.MapFrom(src => src.Pre_User_InfoId))
            .ForMember(s => s.Repair_InfoId, sp => sp.MapFrom(src => src.Repair_InfoId))
            .ForMember(s => s.Flow_ProcedureId, sp => sp.MapFrom(src => src.Flow_ProcedureId))
            .ForMember(s => s.User_InfoId, sp => sp.MapFrom(src => src.User_InfoId));

            CreateMap< FlowNodePreMiddlecs, FlowInfoSearchViewModel >()
            .ForMember(s => s.Flow_NodeDefineId, sp => sp.MapFrom(src => src.Flow_NextNodeDefineId))
            .ForMember(s => s.Parent_Flow_NodeDefineId, sp => sp.MapFrom(src => src.Flow_NodeDefineId))
            .ForMember(s => s.status, sp => sp.MapFrom(src => src.status))
            .ForMember(s => s.StartTime, sp => sp.MapFrom(src => src.StartTime))
            .ForMember(s => s.EndTime, sp => sp.MapFrom(src => src.EndTime))
            .ForMember(s => s.operate, sp => sp.MapFrom(src => "1" ));

            CreateMap<Flow_Node, FlowNodePreMiddlecs>()
            //把当前操作人做为下一节点的父操作人
            .ForMember(s => s.Pre_User_InfoId, sp => sp.MapFrom(src => src.User_InfoId))
            //把当前节点的提交时间，赋值给下一节点开始时间
            .ForMember(s => s.StartTime, sp => sp.MapFrom(src => src.StartTime))
            .ForMember(s => s.EndTime, sp => sp.MapFrom(src => src.EndTime))
            .ForMember(s => s.Flow_ProcedureId, sp => sp.MapFrom(src => src.Flow_ProcedureId));

            CreateMap<Flow_Node, FlowInfoSearchViewModel>()
            //获得当前节点的父节点id
            .ForMember(s => s.Flow_NodeDefineId, sp => sp.MapFrom(src => src.Parent_Flow_NodeDefineId))
            //当前节点的父节点操作人Id
            .ForMember(s => s.User_InfoId, sp => sp.MapFrom(src => src.Pre_User_InfoId))
             
            ;

        }
    }
}
