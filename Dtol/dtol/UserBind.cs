using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class UserBind
    {
        public string ID { get; set; }
        /// <summary>
        /// 小程序OpernID
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 电话号
        /// </summary>
        public string Moblie { get; set; }
        /// <summary>
        /// 账号类型  1：管委会内部；2：别的公司
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string userId { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string passWord { get; set; }
        public string bak1 { get; set; }
        public string bak2 { get; set; }
        public string bak3 { get; set; }
        public string bak4 { get; set; }
        public string bak5 { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string isDelete { get; set; }
    }
}
