using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Bulletin_Board
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
        /// 创建者Id
        /// </summary>
        public int User_InfoId { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 状态  0-启用 1-禁用
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 表单id-----外键
        /// </summary>
        public int? Repair_InfoId { get; set; }
        public Repair_Info Repair_Info { get; set; }
        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime AddDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? updateDate { get; set; }
    }
}
