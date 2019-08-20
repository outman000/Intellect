using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    public class RoleByNodeSearchSingleViewModel
    {
        /// <summary>
        /// 节点id
        /// </summary>
        public int Flow_NextNodeDefineId { get; set; }

        /// <summary>
        /// 角色类型
        /// </summary>
        public string RoleType { get; set; }
    }
}
