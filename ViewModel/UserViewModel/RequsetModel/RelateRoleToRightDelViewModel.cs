using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.RequsetModel
{
    /// <summary>
    /// 根据角色删除权限关联关系视图
    /// </summary>
    public class RelateRoleToRightDelViewModel
    {
        /// <summary>
        /// 权限id集合
        /// </summary>
        public List<int> RelateRightIdandRoleIdList { get; set; }
    }
}
