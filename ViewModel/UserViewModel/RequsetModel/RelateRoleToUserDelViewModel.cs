using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;

namespace ViewModel.UserViewModel.RequsetModel
{
    /// <summary>
    /// 根据角色删除用户关联关系视图
    /// </summary>
    public class RelateRoleToUserDelViewModel
    {
        /// <summary>
        /// 关系表主键id
        /// </summary>
        public List<int> RelateUserIdandRoleIdList   { get; set; }
    }
}
