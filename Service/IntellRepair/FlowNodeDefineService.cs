using AutoMapper;
using Dto.IRepository.IntellRepair;
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
    public class FlowNodeDefineService : IFlowNodeDefineService
    {
        private readonly IFlowNodeDefineInfoRepository _IFlowNodeDefineInfoRepository;
        private readonly IRelateRoleByNodeRepository _IRelateRoleByNodeRepository;
        private readonly IMapper _IMapper;

        public FlowNodeDefineService(IFlowNodeDefineInfoRepository iflowNodeDefineInfoRepository,
                                        IRelateRoleByNodeRepository irelateRoleByNodeRepository,
                                        IMapper mapper)
        {
            _IFlowNodeDefineInfoRepository = iflowNodeDefineInfoRepository;
            _IRelateRoleByNodeRepository = irelateRoleByNodeRepository;
            _IMapper = mapper;
        }


     

        /// <summary>
        /// 节点定义查询
        /// </summary>
        /// <param name="flowNodeDefineSearchViewModel"></param>
        /// <returns></returns>
        public List<FlowNodeDefineSearchMiddlecs> NodeDefine_Search(FlowNodeDefineSearchViewModel flowNodeDefineSearchViewModel)
        {
            FlowNodeDefineSearchMiddlecs nodeDefineSearches = new FlowNodeDefineSearchMiddlecs();
            List<Flow_NodeDefine> nodeDefine_Infos = _IFlowNodeDefineInfoRepository.SearchInfoByNodeDefineWhere(flowNodeDefineSearchViewModel).ToList();

            var repairSearchMiddlecs = _IMapper.Map<List<Flow_NodeDefine>, List<FlowNodeDefineSearchMiddlecs>>(nodeDefine_Infos);

            return repairSearchMiddlecs;
        }
        /// <summary>
        /// 节点定义增加
        /// </summary>
        /// <param name="flowNodeDefineAddViewModel"></param>
        /// <returns></returns>
        public int NodeDefine_Add(FlowNodeDefineAddViewModel flowNodeDefineAddViewModel)
        {
            var node_Info = _IMapper.Map<FlowNodeDefineAddViewModel, Flow_NodeDefine>(flowNodeDefineAddViewModel);
            _IFlowNodeDefineInfoRepository.Add(node_Info);
            return _IFlowNodeDefineInfoRepository.SaveChanges();
        }
        /// <summary>
        /// 删除节点定义
        /// </summary>
        /// <param name="flowNodeDefineDelViewModel"></param>
        /// <returns></returns>
        public int NodeDefine_Delete(FlowNodeDefineDelViewModel flowNodeDefineDelViewModel)
        {
            int DeleteRowsNum = _IFlowNodeDefineInfoRepository
                  .DeleteByNodeDefineIdList(flowNodeDefineDelViewModel.DeleleIdList);
            if (DeleteRowsNum == flowNodeDefineDelViewModel.DeleleIdList.Count)
            {
                return DeleteRowsNum;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 节点定义更新
        /// </summary>
        /// <param name="flowNodeDefineUpdateViewModel"></param>
        /// <returns></returns>
        public int NodeDefine_Update(FlowNodeDefineUpdateViewModel flowNodeDefineUpdateViewModel)
        {
            var node_Info = _IFlowNodeDefineInfoRepository.GetInfoByNodeDefineId(flowNodeDefineUpdateViewModel.Id);
            var node_Info_update = _IMapper.Map<FlowNodeDefineUpdateViewModel, Flow_NodeDefine>(flowNodeDefineUpdateViewModel, node_Info);
            _IFlowNodeDefineInfoRepository.Update(node_Info_update);
            return _IFlowNodeDefineInfoRepository.SaveChanges();
        }

        /// <summary>
        /// 给节点分配角色 
        /// </summary>
        /// <param name="relateRoleByNodeAddViewModel"></param>
        /// <returns></returns>

        public int NodeDefine_RoleToNode_Add(RelateRoleByNodeAddViewModel relateRoleByNodeAddViewModel)
        {

            //获取视图集合
            List<RelateRoleByNodeAddModelcs> relateNodeIdandRoleIdList = relateRoleByNodeAddViewModel.RelateNodeIdandRoleIdList;
            //将视图模型和转为领域模型集合
            List<Flow_Relate_NodeRole> node_Relate_Role = _IMapper.Map<List<RelateRoleByNodeAddModelcs>, List<Flow_Relate_NodeRole>>(relateNodeIdandRoleIdList);

            int AddNum = _IRelateRoleByNodeRepository
                       .RelateNodeToRoleAdd(node_Relate_Role);

            return AddNum;
        }
        /// <summary>
        /// 给节点删除角色
        /// </summary>
        /// <param name="relateRoleByNodeDelViewModel"></param>
        /// <returns></returns>
        public int NodeDefine_RoleToNode_Del(RelateRoleByNodeDelViewModel relateRoleByNodeDelViewModel)
        {

            int DelNum = _IRelateRoleByNodeRepository
                       .RelateNodeToRoleDel(relateRoleByNodeDelViewModel.RelateNodeIdandRoleIdList);

            return DelNum;
        }
        /// <summary>
        /// 根据节点查角色
        /// </summary>
        /// <param name="roleByNodeSearchViewModel"></param>
        /// <returns></returns>
        public List<UserRoleSearChMiddles> User_By_Node_Search(RoleByNodeSearchViewModel roleByNodeSearchViewModel)
        {
            List<Flow_Relate_NodeRole> node_Relate_Info_Roles = _IRelateRoleByNodeRepository.SearchRoleInfoByWhere(roleByNodeSearchViewModel);
            List<UserRoleSearChMiddles> user_roles = new List<UserRoleSearChMiddles>();

            foreach (var item in node_Relate_Info_Roles)
            {
                var user_role_temp = _IMapper.Map<User_Role, UserRoleSearChMiddles>(item.User_Role);
                user_roles.Add(user_role_temp);
            }
            return user_roles;
        }
        /// <summary>
        /// 查询节点定义数量
        /// </summary>
        /// <param name="flowNodeDefineSearchViewModel"></param>
        /// <returns></returns>
        public int NodeDefine_Get_ALLNum(FlowNodeDefineSearchViewModel flowNodeDefineSearchViewModel)
        {
            return _IFlowNodeDefineInfoRepository.GetNodeDefineAll(flowNodeDefineSearchViewModel).Count();
        }

        /// <summary>
        /// 根据当前节点查询下一节点数量
        /// </summary>
        /// <param name="nextNodeByCurrentNodeSearchViewModel"></param>
        /// <returns></returns>
        public int NodeDefine_Get_ALLNum(NextNodeByCurrentNodeSearchViewModel nextNodeByCurrentNodeSearchViewModel)
        {
            return _IFlowNodeDefineInfoRepository.SearchNextNodeInfoByWhere(nextNodeByCurrentNodeSearchViewModel).Count();


        }
        /// <summary>
        /// 根据节点查角色数量
        /// </summary>
        /// <param name="roleByNodeSearchViewModel"></param>
        /// <returns></returns>
        public int Role_By_Node_Get_ALLNum(RoleByNodeSearchViewModel roleByNodeSearchViewModel)
        {
            return _IRelateRoleByNodeRepository.Role_By_Node_Get_ALLNum(roleByNodeSearchViewModel).Count();
        }

        /// <summary>
        /// 根据流程定义增加节点  /   根据节点定义增加流程定义
        /// </summary>
        /// <param name="flowProcedureByNodeIdAddViewModel"></param>
        /// <returns></returns>
        public int ProcedureDefine_To_Node_Add(FlowProcedureByNodeIdAddViewModel flowProcedureByNodeIdAddViewModel)
        {

            var List = flowProcedureByNodeIdAddViewModel.relateNodeIdAndProcedureIdList;  //线路id和站点id列表

            for (int i = 0; i < List.Count; i++)
            {
                var nodeDefine_info = _IFlowNodeDefineInfoRepository.GetInfoByNodeDefineId(List[i].Flow_NodeDefineId);
                var nodeDefine_info_update = _IMapper.Map<FlowProcedureByNodeIdAddMiddlecs, Flow_NodeDefine>(List[i], nodeDefine_info);
                _IFlowNodeDefineInfoRepository.Update(nodeDefine_info_update);
            }
            return _IFlowNodeDefineInfoRepository.SaveChanges();
           
        }

        /// <summary>
        /// 给当前节点增加下一节点
        /// </summary>
        /// <param name="currentNodeToNextNodeAddViewModel"></param>
        /// <returns></returns>
        public int CurrentNodeToNextNode_Add(CurrentNodeToNextNodeAddViewModel currentNodeToNextNodeAddViewModel)
        {
            //获取视图集合
            List<CurrentNodeToNextNodeAddMiddlecs> currentNodeAndNextNodeIdList = currentNodeToNextNodeAddViewModel.CurrentNodeAndNextNodeIdList;
            //将视图模型和转为领域模型集合
            List<Flow_CurrentNodeAndNextNode> currentNodeAndNextNode = _IMapper.Map<List<CurrentNodeToNextNodeAddMiddlecs>, List<Flow_CurrentNodeAndNextNode>>(currentNodeAndNextNodeIdList);

            int AddNum = _IFlowNodeDefineInfoRepository
                       .CurrentNodeAddNextNode(currentNodeAndNextNode);

            return AddNum;
        }
        /// <summary>
        /// 根据当前节点查下一节点信息
        /// </summary>
        /// <param name="flowNodeDefineSearchViewModel"></param>
        /// <returns></returns>
        public List<FlowNodeDefineSearchMiddlecs> NextNodeDefine_Search(NextNodeByCurrentNodeSearchViewModel nextNodeByCurrentNodeSearchViewModel)
        {
            List<FlowNodeDefineSearchMiddlecs> nodeDefineSearches = new List<FlowNodeDefineSearchMiddlecs>();
            List<Flow_CurrentNodeAndNextNode> nodeDefine_Infos = _IFlowNodeDefineInfoRepository
                                                    .SearchNextNodeInfoByWhere(nextNodeByCurrentNodeSearchViewModel);


            //foreach (var item in nodeDefine_Infos)
            //{
                var user_role_temp = _IMapper.Map<List<Flow_CurrentNodeAndNextNode>, List< FlowNodeDefineSearchMiddlecs> >(nodeDefine_Infos);
            //    nodeDefineSearches.Add(user_role_temp);
            //}
            return user_role_temp;
        }

    

        // 给当前节点删下一节点
        public int CurrentNodeToNextNode_Del(CurrentNodeToNextNodeDelViewModel  currentNodeToNextNodeDelViewModel)
        {


            int DelNum = _IFlowNodeDefineInfoRepository
                       .RelateCurrentNodeToNextNodeDel(currentNodeToNextNodeDelViewModel.CurrentNodeAndNextNodeIdList);

            return DelNum;
        }
    }
    
}
