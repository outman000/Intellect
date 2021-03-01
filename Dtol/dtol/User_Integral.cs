using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class User_Integral
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Idcard { get; set; }

        public string Dept { get; set; }
        /// <summary>
        /// 部门id
        /// </summary>
        public int? User_DepartId { get; set; }
        public string Type { get; set; }
        public string TotalPoints { get; set; }
        public string Mobile { get; set; }
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
