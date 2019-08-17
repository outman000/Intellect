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
        /// <param name="userListByNodeIdSearchViewModel"></param>
        /// <returns></returns>
        List<UserSearchMiddlecs> User_By_Node_Search(UserListByNodeIdSearchViewModel userListByNodeIdSearchViewModel);
        /// <summary>
        /// 根据节点查用户列表
        /// </summary>
        /// <param name="userListByNodeIdSearchViewModel"></param>
        /// <returns></returns>
        List<UserSearchMiddlecs> User_By_Node_Search(RoleByNodeSearchViewModel roleByNodeSearchViewModel);


        /// <summary>
        ///  正式走流程
        /// </summary>
        /// <param name="fLowInfoSearchViewModel"></param>
        /// <returns></returns>
        FlowNodePreMiddlecs Work_FlowNodeAll_Add(FlowInfoSearchViewModel fLowInfoSearchViewModel);
    }
   

}
