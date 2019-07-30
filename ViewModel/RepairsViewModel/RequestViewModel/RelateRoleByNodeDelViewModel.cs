using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;

namespace ViewModel.RepairsViewModel.RequestViewModel
{

    /// <summary>
    /// 根据节点删除角色关联关系视图
    /// </summary>
    public class RelateRoleByNodeDelViewModel
    {
        /// <summary>
        /// 角色主键id和节点主键Id
        /// </summary>
        public List<RelateRoleByNodeDelModelcs> RelateNodeIdandRoleIdList { get; set; }
    }
}
