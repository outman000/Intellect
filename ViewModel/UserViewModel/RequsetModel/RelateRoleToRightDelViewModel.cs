using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;

namespace ViewModel.UserViewModel.RequsetModel
{
    /// <summary>
    /// 根据角色删除权限关联关系视图
    /// </summary>
    public class RelateRoleToRightDelViewModel
    {
        /// <summary>
        /// 权限id和角色id集合
        /// </summary>
        public List<RelateRoleRightDelMiddlecs> RelateRightIdandRoleIdList { get; set; }
    }
}
