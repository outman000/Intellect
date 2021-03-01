using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Suggest_Food
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }




        /// <summary>
        /// 意见箱表单分类
        /// </summary>
        public string SuggestType { get; set; }


        /// <summary>
        /// 具体意见内容
        /// </summary>
        public string Content { get; set; }

    



        /// <summary>
        /// 意见箱表单匿名内容(两类：“匿名” 或者 用户真实姓名)
        /// </summary>
        public string Anonymous { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        public string isDelete { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string status { get; set; }



        /// 创建人
        /// </summary>

        public string createUser { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>

        public string updateUser { get; set; }

        /// <summary>
        /// 增加时间
        /// </summary>

        public DateTime? AddDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? updateDate { get; set; }


        /// <summary>
        /// 用户id
        /// </summary>
        public int? User_InfoId { get; set; }
        public User_Info User_Info { get; set; }

    }
}
