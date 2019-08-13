using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BulletinBoardViewModel.MiddleModel;

namespace ViewModel.BulletinBoardViewModel.RequestViewModel
{
    /// <summary>
    /// 根据公告栏删除角色关联关系视图
    /// </summary>
    public class RoleByBulletinDelViewModel
    {
        /// <summary>
        /// 公告栏id和角色主键id
        /// </summary>
        public List<RelateRoleBulletinDelMiddlecs> RelateBulletinIdandRoleIdList { get; set; }
    }
}
