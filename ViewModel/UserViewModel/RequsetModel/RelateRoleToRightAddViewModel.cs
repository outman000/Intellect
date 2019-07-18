using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;

namespace ViewModel.UserViewModel.RequsetModel
{
    /// <summary>
    /// 根据角色添加权限关联关系视图
    /// </summary>
    public class RelateRoleToRightAddViewModel
    {
        /// <summary>
        /// 权限id集合
        /// </summary>
        public List<RelateRoleRightAddMiddlecs> RelateRightIdandRoleIdList { get; set; }
    }
}
