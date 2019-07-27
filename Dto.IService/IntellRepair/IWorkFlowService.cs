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
        /// 根据节点查用户列表
        /// </summary>
        /// <param name="roleByNodeSearchViewModel"></param>
        /// <returns></returns>
        List<UserSearchMiddlecs> User_By_Node_Search(RoleByNodeSearchViewModel roleByNodeSearchViewModel);
    }
   

}
