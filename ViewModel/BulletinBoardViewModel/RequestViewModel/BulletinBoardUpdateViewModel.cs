using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BulletinBoardViewModel.RequestViewModel
{
    public class BulletinBoardUpdateViewModel
    {
        /// <summary>
        /// 公告栏id
        /// </summary>
        public int Id { get; set; }

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
        /// 修改时间
        /// </summary>
        public DateTime? updateDate { get; set; }
    }
}
