using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.RequsetModel
{
    public partial class UserUpdateViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string UserPwd { get; set; }
        public string PhoneCall { get; set; }
        public string Email { get; set; }
        public string status { get; set; }
        public string Levels { get; set; }
      
        public string WorkExperience { get; set; }
        public DateTime? AddDate { get; set; }
    }
}
