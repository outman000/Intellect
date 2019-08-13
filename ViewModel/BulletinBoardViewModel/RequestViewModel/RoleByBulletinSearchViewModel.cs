using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BulletinBoardViewModel.RequestViewModel
{
    /// <summary>
    /// 根据公告栏查询角色
    /// </summary>
    public class RoleByBulletinSearchViewModel
    {
        /// <summary>
        /// 公告栏id
        /// </summary>
        public int Bulletin_BoardId { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        RoleByBulletinSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
