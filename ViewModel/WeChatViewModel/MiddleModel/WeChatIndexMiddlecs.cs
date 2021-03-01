using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;

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
        /// 手机号
        /// </summary>
        public string PhoneCall { get; set; }

        /// <summary>
        /// 部门信息Id
        /// </summary>
        /// 
        public int User_DepartId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string status { get; set; }

        /// <summary>
        ///  部门详细信息
        /// </summary>
        public User_Depart User_Depart { get; set; }



        /// <summary>
        /// 工会信息
        /// </summary>
        public int? User_UnionId { get; set; }

        /// <summary>
        /// 工会详细信息
        /// </summary>
        public User_Union User_Union { get; set; }


        /// <summary>
        /// 权限id
        /// </summary>
        public List<RightsParentSearchMiddlecs> User_Rights { get; set; }


        /// <summary>
        /// 菜单权限  0-没有菜单，1-二联检，2-商务中心，3-全部权限
        /// </summary>
        public string FoodStatus { get; set; }

    }
}
