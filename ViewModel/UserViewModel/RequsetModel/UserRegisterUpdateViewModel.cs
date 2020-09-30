using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.RequsetModel
{
    public class UserRegisterUpdateViewModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 状态  8-不通过，9-通过
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 操作人的账号
        /// </summary>
        public string updateUser { get; set; }
    }
}
