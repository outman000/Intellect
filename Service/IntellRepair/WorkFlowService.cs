﻿using AutoMapper;
using Dto.IRepository.IntellRepair;
using Dto.IRepository.IntellUser;
using Dto.IService.IntellRepair;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;
using ViewModel.UserViewModel.MiddleModel;

namespace Dto.Service.IntellRepair
{
    public class WorkFlowService : IWorkFlowService
    {
        private readonly IFlowNodeDefineInfoRepository _IFlowNodeDefineInfoRepository;
        private readonly IRepairInfoRepository _IRepairInfoRepository;
        private readonly IRelateRoleByNodeRepository _IRelateRoleByNodeRepository;
        private readonly IUserRelateInfoRoleRepository _IUserRelateInfoRoleRepository;
        private readonly IFlowNodeRepository _IFlowNodeRepository;
        private readonly IFlowProcedureInfoRepository _IFlowProcedureInfoRepository;
        private readonly IMapper _IMapper;

        public WorkFlowService(IFlowNodeDefineInfoRepository flowNodeDefineInfoRepository,
                               IRelateRoleByNodeRepository relateRoleByNodeRepository,
                               IRepairInfoRepository irepairInfoRepository,
                               IUserRelateInfoRoleRepository userRelateInfoRoleRepository,
                               IFlowNodeRepository iflowNodeRepository,
                               IFlowProcedureInfoRepository iflowProcedureInfoRepository,
                               IMapper mapper)
        {
                _IFlowNodeDefineInfoRepository = flowNodeDefineInfoRepository;
                _IRelateRoleByNodeRepository = relateRoleByNodeRepository;
                _IRepairInfoRepository= irepairInfoRepository;
                _IUserRelateInfoRoleRepository = userRelateInfoRoleRepository;
                _IFlowNodeRepository = iflowNodeRepository;
                _IFlowProcedureInfoRepository = iflowProcedureInfoRepository;
                _IMapper = mapper;
        }
        /// <summary>
        /// 根据节点查用户列表（重载内部使用)
        /// </summary>
        /// <param name="roleByNodeSearchViewModel"></param>
        /// <returns></returns>
        public List<UserSearchMiddlecs> User_By_Node_Search(UserListByNodeIdSearchViewModel userListByNodeIdSearchViewModel)
        {
            List<Flow_Relate_NodeRole> node_Relate_Info_Roles = _IRelateRoleByNodeRepository.SearchRoleInfoByWhere(userListByNodeIdSearchViewModel.Flow_NextNodeDefineId);
            List<int> RoleList = new List<int>();
            for (int i = 0; i < node_Relate_Info_Roles.Count; i++)
            {
                int User_RoleId = node_Relate_Info_Roles[i].User_RoleId;
                RoleList.Add(User_RoleId);

            }

            List<User_Info> user_Relate_Info_Users = _IUserRelateInfoRoleRepository.SearchUserInfoByListWhere(RoleList);
            var userLsit_Info = _IMapper.Map<List<User_Info>, List<UserSearchMiddlecs>>(user_Relate_Info_Users);

            return userLsit_Info;
        }

        /// <summary>
        /// 根据节点查用户列表
        /// </summary>
        /// <param name="roleByNodeSearchViewModel"></param>
        /// <returns></returns>
        public List<UserSearchMiddlecs> User_By_Node_Search(RoleByNodeSearchViewModel roleByNodeSearchViewModel)
        {
            List<Flow_Relate_NodeRole> node_Relate_Info_Roles = _IRelateRoleByNodeRepository.SearchRoleInfoByWhere(roleByNodeSearchViewModel);
            List<int> RoleList = new List<int>();
            for(int i=0;i< node_Relate_Info_Roles.Count;i++)
            {
                int User_RoleId = node_Relate_Info_Roles[i].User_RoleId;
                RoleList.Add(User_RoleId);

            }
          
            List<User_Info> user_Relate_Info_Users = _IUserRelateInfoRoleRepository.SearchUserInfoByListWhere(RoleList);
            var userLsit_Info = _IMapper.Map<List<User_Info>, List<UserSearchMiddlecs>>(user_Relate_Info_Users);

            return userLsit_Info;
        }


        /// <summary>
        /// 增加流转信息（*******此方法适用于任何节点,正常调用一次即可******）
        /// </summary>
        /// <param name="flowInfoSearchViewModel"></param>
        /// <returns></returns>
        public FlowNodePreMiddlecs Work_FlowNodeAll_Add(FlowInfoSearchViewModel  flowInfoSearchViewModel)
        {
            //获取当前节点信息
            var currentNodeInfo = _IFlowNodeDefineInfoRepository
                           .GetInfoByNodeDefineId(flowInfoSearchViewModel.Flow_NodeDefineId);
            var currentAllInfo = _IMapper.Map<Flow_NodeDefine, FlowNodePreMiddlecs>(currentNodeInfo);
          
            //请求信息存入流转信息表
            var nodeByrepair_Info = _IMapper.Map<FlowInfoSearchViewModel, Flow_Node>(flowInfoSearchViewModel);
            currentAllInfo = _IMapper.Map<Flow_Node, FlowNodePreMiddlecs>(nodeByrepair_Info, currentAllInfo);

            if (nodeByrepair_Info.Parent_Flow_NodeDefineId != null)//说明是非开始节点，包括（普通节点和结束节点）
                Work_FlowNodeOperate_Update(flowInfoSearchViewModel, nodeByrepair_Info, currentNodeInfo);
            if(nodeByrepair_Info.operate!="2")//说明不是结束节点
                _IFlowNodeRepository.Add(nodeByrepair_Info);
                _IFlowNodeRepository.SaveChanges();
            if (nodeByrepair_Info.Parent_Flow_NodeDefineId==null) //说明是开始节点，需要再自动生成拟文和拟文下一步的流转信息
            { 
                var FirstFlow = _IMapper.Map<FlowNodePreMiddlecs, FlowInfoSearchViewModel>(currentAllInfo, flowInfoSearchViewModel);
                currentAllInfo=Work_FlowNodeAll_Add(FirstFlow);//生成拟文流转记录
                 //获得下一节点处理人id ，这里也就是管理员的 用户id
                UserListByNodeIdSearchViewModel userLis = new UserListByNodeIdSearchViewModel();
                userLis.Flow_NextNodeDefineId = currentAllInfo.Flow_NextNodeDefineId.Value;
                List<UserSearchMiddlecs> frn = User_By_Node_Search(userLis);
                //生成管理员流转信息
                var NiWenFlow = _IMapper.Map<FlowNodePreMiddlecs, FlowInfoSearchViewModel>(currentAllInfo, flowInfoSearchViewModel);
                NiWenFlow.User_InfoId = frn[0].id;
                NiWenFlow.EndTime = null;
                currentAllInfo = Work_FlowNodeAll_Add(NiWenFlow);//生成拟文下一节点流转记录
            }
            return currentAllInfo;
        }

        /// <summary>
        /// 更新上已流转记录中的状态  operate变为2 （已提交）
        /// </summary>
        /// <param name="flowInfoSearchViewModel"></param>
        /// <param name="nodeByrepair_Info"></param>
        /// <param name="currentNodeInfo"></param>
        private void Work_FlowNodeOperate_Update(FlowInfoSearchViewModel flowInfoSearchViewModel,
                                                              Flow_Node nodeByrepair_Info,
                                                              Flow_NodeDefine currentNodeInfo)
        {
           
            var flowInfo = _IMapper.Map<Flow_Node, FlowInfoSearchViewModel>(nodeByrepair_Info);
            List<Flow_Node> nodepre_Infos = _IFlowNodeRepository.SearchInfoByNodeWhere(flowInfo);//查询父节点操作信息
            if (nodepre_Infos[0].Parent_Flow_NodeDefineId == null) //说明是开始节点，需要把当前用户设置为null
                nodepre_Infos[0].User_InfoId = null;//开始的当前处理人变为空，防止查出两条已办
            nodepre_Infos[0].operate = "2";//把未提交状态（1），改为已提交状态（2）
            nodepre_Infos[0].EndTime = flowInfoSearchViewModel.StartTime;//用户提交时间，就是上一节点结束时间，是当前节点
            _IFlowNodeRepository.Update(nodepre_Infos[0]);
            if (currentNodeInfo.Flow_NextNodeDefineId == null)//说明是结束节点
            {
                nodeByrepair_Info.operate = "2";//把未提交状态（1），改为已提交状态（2）
                nodeByrepair_Info.EndTime = nodeByrepair_Info.StartTime;//结束节点的开始时间和结束时间一样，都为上一节点的提交时间
                _IFlowNodeRepository.Update(nodeByrepair_Info);
                _IFlowNodeRepository.SaveChanges();
                //把流程表结束时间赋上值
                var procedure_Info = _IFlowProcedureInfoRepository.GetInfoByProcedureId(flowInfoSearchViewModel.Flow_ProcedureId);
                procedure_Info.Endtime = nodeByrepair_Info.StartTime;
                procedure_Info.remark = "2";//流程结束
                _IFlowProcedureInfoRepository.Update(procedure_Info);
                _IFlowProcedureInfoRepository.SaveChanges();
            }
        }
    }
}
