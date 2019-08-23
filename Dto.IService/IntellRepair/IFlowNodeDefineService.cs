using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;
using ViewModel.UserViewModel.MiddleModel;

namespace Dto.IService.IntellRepair
{
    public interface IFlowNodeDefineService
    {
        /// <summary>
        /// 查询节点定义信息
        /// </summary>
        /// <param name="flowNodeDefineSearchViewModel"></param>
        List<FlowNodeDefineSearchMiddlecs> NodeDefine_Search(FlowNodeDefineSearchViewModel  flowNodeDefineSearchViewModel);

        /// <summary>
        /// 查询节点定义信息数量
        /// </summary>
        /// <param name="flowNodeDefineSearchViewModel"></param>
        /// <returns></returns>
        int NodeDefine_Get_ALLNum(FlowNodeDefineSearchViewModel flowNodeDefineSearchViewModel);
        /// <summary>
        /// 查询下一节点定义信息数量
        /// </summary>
        /// <param name="flowNodeDefineSearchViewModel"></param>
        /// <returns></returns>
        int NodeDefine_Get_ALLNum(NextNodeByCurrentNodeSearchViewModel nextNodeByCurrentNodeSearchViewModel);
        /// <summary>
        /// 添加节点定义信息
        /// </summary>
        /// <param name="flowNodeDefineAddViewModel"></param>
        /// <returns></returns>
        int NodeDefine_Add(FlowNodeDefineAddViewModel  flowNodeDefineAddViewModel);

        /// <summary>
        /// 删除节点定义信息
        /// </summary>
        /// <param name="repairDelViewModel"></param>
        /// <returns></returns>
        int NodeDefine_Delete(FlowNodeDefineDelViewModel flowNodeDefineDelViewModel);


        /// <summary>
        /// 更新节点定义信息
        /// </summary>
        /// <param name="repairUpdateViewModel"></param>
        /// <returns></returns>
        int NodeDefine_Update(FlowNodeDefineUpdateViewModel  flowNodeDefineUpdateViewModel);

        /// <summary>
        /// 给节点分配角色
        /// </summary>
        /// <param name="relateRoleByNodeAddViewModel"></param>
        /// <returns></returns>
        int NodeDefine_RoleToNode_Add(RelateRoleByNodeAddViewModel relateRoleByNodeAddViewModel);

        /// <summary>
        /// 给节点删除角色
        /// </summary>
        /// <param name="relateRoleByNodeDelViewModel"></param>
        /// <returns></returns>
        int NodeDefine_RoleToNode_Del(RelateRoleByNodeDelViewModel relateRoleByNodeDelViewModel);

        /// <summary>
        ///根据节点查询角色
        /// </summary>
        /// <param name="roleByNodeSearchViewModel"></param>
        /// <returns></returns>
        List<UserRoleSearChMiddles> User_By_Node_Search(RoleByNodeSearchViewModel  roleByNodeSearchViewModel);

        /// <summary>
        /// 根据节点查询角色数量
        /// </summary>
        /// <param name="roleByNodeSearchViewModel"></param>
        /// <returns></returns>
        int Role_By_Node_Get_ALLNum(RoleByNodeSearchViewModel roleByNodeSearchViewModel);


        /// <summary>
        /// 根据流程定义增加节点  /   根据节点定义增加流程定义
        /// </summary>
        /// <param name="flowProcedureByNodeIdAddViewModel"></param>
        /// <returns></returns>
        int ProcedureDefine_To_Node_Add(FlowProcedureByNodeIdAddViewModel  flowProcedureByNodeIdAddViewModel);


        /// <summary>
        /// 给当前节点分配下一节点
        /// </summary>
        /// <param name="currentNodeToNextNodeAddViewModel"></param>
        /// <returns></returns>
        int CurrentNodeToNextNode_Add(CurrentNodeToNextNodeAddViewModel  currentNodeToNextNodeAddViewModel);


        /// <summary>
        /// 给当前节点删除下一节点
        /// </summary>
        /// <param name="currentNodeToNextNodeDelViewModel"></param>
        /// <returns></returns>
        int CurrentNodeToNextNode_Del(CurrentNodeToNextNodeDelViewModel  currentNodeToNextNodeDelViewModel);
        
        /// <summary>
        /// 根据当前节点查下一节点
        /// </summary>
        /// <param name="nextNodeByCurrentNodeSearchViewModel"></param>
        /// <returns></returns>
        List<FlowNodeDefineSearchMiddlecs> NextNodeDefine_Search(NextNodeByCurrentNodeSearchViewModel nextNodeByCurrentNodeSearchViewModel);
    }
}
