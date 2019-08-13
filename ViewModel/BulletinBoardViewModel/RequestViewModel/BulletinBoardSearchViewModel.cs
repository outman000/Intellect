using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BulletinBoardViewModel.RequestViewModel
{
    public class BulletinBoardSearchViewModel
    {

        /// <summary>
        /// 公告栏标题
        /// </summary>
        public string BulletinTitle { get; set; }

        /// <summary>
        /// 公告栏内容
        /// </summary>
        public string BulletinContent { get; set; }

        /// <summary>
        /// 滞留小时
        /// </summary>
        public string StayNum { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 状态  0-启用 1-禁用
        /// </summary>
        public string status { get; set; }

    
        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddDate { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        BulletinBoardSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }

    }
}
