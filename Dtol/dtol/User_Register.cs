using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class User_Register
    {
        public int Id { get; set; }
        
        public string UserId { get; set; }
     
        public string UserPwd { get; set; }
     
        public string Dept { get; set; }
      
        public string UserName { get; set; }
     
       
        public string Idcard { get; set; }
      
        public string PhoneCall { get; set; }
    
        public string Email { get; set; }

       
        public string status { get; set; }
     
        public int? User_DepartId { get; set; }
        public User_Depart User_Depart { get; set; }


        /// <summary>
        /// 工会名称
        /// </summary>
        public string UnionName { get; set; }
        /// <summary>
        /// 工会信息
        /// </summary>
        public int? User_UnionId { get; set; }
        public User_Union User_Union { get; set; }

        public DateTime? AddDate { get; set; }
        public DateTime? updateDate { get; set; }

        public string createUser { get; set; }

        public string updateUser { get; set; }
    }
}
