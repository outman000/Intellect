using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;

namespace ViewModel.UserViewModel.RequsetModel
{
    /// <summary>
    /// 根据角色增加用户关联关系视图
    /// </summary>
    public class RelateRoleToUserAddViewModel
    {
        /// <summary>
        /// 用户id集合
        /// </summary>
        public List<RelateRoleUserAddMiddlecs> RelateUserIdandRoleIdList { get; set; }
    }
}
