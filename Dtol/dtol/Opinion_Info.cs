﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Opinion_Info
    {
        /// <summary>
        /// 意见id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int? User_InfoId { get; set; }
        public User_Info User_Info { get; set; }

     

        ///// <summary>
        ///// 意见箱表单id
        ///// </summary>
        //public int? Suggest_BoxId { get; set; }
        //public Suggest_Box Suggest_Box { get; set; }

        /// <summary>
        /// 表单外键id
        /// </summary>
        public int? Repair_InfoId { get; set; }
        public Repair_Info Repair_Info { get; set; }


        /// <summary>
        /// 节点id
        /// </summary>
        public int? Flow_NodeDefineId { get; set; }

        public Flow_NodeDefine Flow_NodeDefine { get; set; }

        /// <summary>
        /// 意见内容
        /// </summary>
        public string content { get; set; }


        /// <summary>
        /// 状态
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? updateDate { get; set; }



 

    }
}
