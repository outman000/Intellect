using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    /// <summary>
    /// 根据节点增加角色关联关系视图
    /// </summary>
    public class RelateRoleByNodeAddViewModel
    {
        /// <summary>
        /// 角色id集合
        /// </summary>
        public List<RelateRoleByNodeAddModelcs> RelateNodeIdandRoleIdList { get; set; }
    }
}
