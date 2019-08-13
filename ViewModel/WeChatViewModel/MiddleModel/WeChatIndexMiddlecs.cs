using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.WeChatViewModel.MiddleModel
{
    /// <summary>
    /// 登录响应信息
    /// </summary>
    public class WeChatIndexMiddlecs
    {
        /// <summary>
        /// 用户主键id
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户手机号
        /// </summary>
        public string PhoneCall { get; set; }
        /// <summary>
        /// 部门信息Id
        /// </summary>
        /// 
        public int User_DepartId { get; set; }
        /// <summary>
        ///  部门详细信息
        /// </summary>
        public User_Depart User_Depart { get; set; }
        /// <summary>
        /// 权限id
        /// </summary>
        public List<User_Rights> User_Rights { get; set; }

    }
}
