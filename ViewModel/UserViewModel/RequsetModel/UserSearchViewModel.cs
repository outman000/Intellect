using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.RequsetModel
{
    public partial class UserSearchViewModel
    {
        
        /// <summary>
       /// 用户id
       /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户登录账号
        /// </summary>
        public string UserId { get; set; }
        //public string PhoneCall { get; set; }
       //public string Email { get; set; }
       /// <summary>
       /// 账号状态，0启用1停用
       /// </summary>
        public string status { get; set; }
       /// <summary>
       /// 账号身份0普通身份1临时身份
       /// </summary>
        public string Levels { get; set; }

        /// <summary>
        /// 部门id
        /// </summary>
        public int? User_DepartId { get; set; }

        //public DateTime? AddDate { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        UserSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
