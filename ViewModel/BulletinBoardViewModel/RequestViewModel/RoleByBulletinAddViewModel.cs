using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BulletinBoardViewModel.MiddleModel;

namespace ViewModel.BulletinBoardViewModel.RequestViewModel
{
    /// <summary>
    /// 根据公告栏增加角色
    /// </summary>
    public class RoleByBulletinAddViewModel
    {
        /// <summary>
        /// 公告栏id和角色id集合
        /// </summary>
        public List<RelateRoleBulletinAddMiddlecs> RelateBulletinIdandRoleIdList { get; set; }
    }
}
