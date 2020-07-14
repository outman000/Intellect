using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.MiddleModel
{
    public class UserSearchMiddlecs
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string UserId { get; set; }
        public string PhoneCall { get; set; }
        public string Email { get; set; }
        public string Idcard { get; set; }
        public string status { get; set; }
        public string Levels { get; set; }
        public int? user_DepartId { get; set; }
        public string WorkExperience { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? updateDate { get; set; }
    }
}
