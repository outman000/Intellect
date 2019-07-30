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
        /// 用户和角色主键id
        /// </summary>
        public List<RelateRoleUserDelMiddlecs> RelateUserIdandRoleIdList   { get; set; }
    }
}
