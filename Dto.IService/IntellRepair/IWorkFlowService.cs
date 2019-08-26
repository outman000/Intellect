using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;
using ViewModel.UserViewModel.MiddleModel;

namespace Dto.IService.IntellRepair
{
    public interface IWorkFlowService
    {

        /// <summary>
        /// 根据节点查用户列表（内部使用）
        /// </summary>
        /// <param name="roleByNodeSearchSingleViewModel"></param>
        /// <returns></returns>
        List<UserSearchMiddlecs> User_By_Node_Search(RoleByNodeSearchSingleViewModel roleByNodeSearchSingleViewModel);
        /// <summary>
        /// 根据节点查用户列表
        /// </summary>
        /// <param name="userListByNodeIdSearchViewModel"></param>
        /// <returns></returns>
        List<UserSearchMiddlecs> User_By_Node_Search(RoleByNodeSearchViewModel roleByNodeSearchViewModel);

        /// <summary>
        /// 查询当前节点是否是结束（如果是结束，出现评论按钮）
        /// </summary>
        /// <param name="flowNodeSearchViewModel"></param>
        /// <returns></returns>
        List<RepairIsEndMiddlecs> CurrentNodeSearch(NodeEndSearchViewModel  nodeEndSearchViewModel);

        /// <summary>
        /// 查询当前是否超时（如果超时，出现催单按钮）
        /// </summary>
        /// <param name="flowNodeSearchViewModel"></param>
        /// <returns></returns>
        int CurrentNodeOverTimeSearch(FlowNodeSearchViewModel flowNodeSearchViewModel);
        /// <summary>
        ///  正式走流程
        /// </summary>
        /// <param name="fLowInfoSearchViewModel"></param>
        /// <returns></returns>
        FlowNodePreMiddlecs Work_FlowNodeAll_Add(FlowInfoSearchViewModel fLowInfoSearchViewModel);


        /// <summary>
        ///  跳转走流程
        /// </summary>
        /// <param name="fLowInfoSearchViewModel"></param>
        /// <returns></returns>
        FlowNodePreMiddlecs Work_FlowNodeJump_Add(FlowInfoSearchViewModel fLowInfoSearchViewModel);

        List<RepairIsEndMiddlecs> CurrentNodeSearchNoEnd(NodeEndSearchViewModel nodeEndSearchViewModel);
    }
   

}
