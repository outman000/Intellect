using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BulletinBoardViewModel.RequestViewModel
{
    public class BulletinByUserSearchViewModel
    {
        /// <summary>
        /// 用户主键id
        /// </summary>
        public int UserUid { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        BulletinByUserSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
