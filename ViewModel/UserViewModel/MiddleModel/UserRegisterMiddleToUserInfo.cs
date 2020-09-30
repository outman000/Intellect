using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.MiddleModel
{
    public class UserRegisterMiddleToUserInfo
    {
        public string UserId { get; set; }

        public string UserPwd { get; set; }

        public string Dept { get; set; }

        public string UserName { get; set; }


        public string Idcard { get; set; }

        public string PhoneCall { get; set; }

        public string Email { get; set; }


        public string status { get; set; }

        public int? User_DepartId { get; set; }
    


        /// <summary>
        /// 工会名称
        /// </summary>
        public string UnionName { get; set; }
        /// <summary>
        /// 工会信息
        /// </summary>
        public int? User_UnionId { get; set; }
       

        public DateTime? AddDate { get; set; }
        public DateTime? updateDate { get; set; }

    
    }
}
