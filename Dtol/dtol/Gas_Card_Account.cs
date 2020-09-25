using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Gas_Card_Account
    {
        /// <summary>
        /// 班车id
        /// </summary>
        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserPwd { get; set; }


        public string Dept { get; set; }
        /// <summary>
        /// 部门id
        /// </summary>
        public int? User_DepartId { get; set; }

        public string status { get; set; }


        public string IsDelete { get; set; }
        /// <summary>
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
    }
}
