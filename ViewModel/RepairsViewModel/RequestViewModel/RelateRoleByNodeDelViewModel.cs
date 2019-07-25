using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.RequestViewModel
{

    /// <summary>
    /// 根据节点删除角色关联关系视图
    /// </summary>
    public class RelateRoleByNodeDelViewModel
    {
        /// <summary>
        /// 关系表主键id
        /// </summary>
        public List<int> RelateNodeIdandRoleIdList { get; set; }
    }
}
