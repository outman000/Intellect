using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class UserBindResModel
    {
        /// <summary>
        /// 用户状态 0：用户未绑定；1：用户绑定
        /// </summary>
        public string BindStatus { get; set; }
        /// <summary>
        /// 小程序openID
        /// </summary>
        public string OpenID;

        /// <summary>
        /// 小程序访问者身份   0：普通身份；1：物业身份
        /// </summary>
        public string RoleName;


        /// <summary>
        /// 在居民表中的状态  0：不存在该居民；1：存在未审核；9：存在审核通过
        /// </summary>
        public string Status;

        /// <summary>
        /// 身份证
        /// </summary>
        public string CertificateID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 居民类型 本地、外地来津、外地返津
        /// </summary>
        public string ResidentType { get; set; }


        /// <summary>
        /// 电话号
        /// </summary>
        public string Moblie { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Msg;
    }
}