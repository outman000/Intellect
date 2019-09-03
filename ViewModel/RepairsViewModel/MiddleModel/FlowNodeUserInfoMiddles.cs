using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.MiddleModel
{
    /// <summary>
    /// 流转信息用户中间件
    /// </summary>
    public class FlowNodeUserInfoMiddles
    {
        /// <summary>
        /// 当前操作人姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 当前操作人手机号
        /// </summary>
        public string PhoneCall { get; set; }
        /// <summary>
        /// 部门信息
        /// </summary>
        public User_Depart User_Depart { get; set; }
    }
}
