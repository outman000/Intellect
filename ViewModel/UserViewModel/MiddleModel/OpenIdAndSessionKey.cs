using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.MiddleModel
{
    public class OpenIdAndSessionKey
    {
        public string openid { get; set; }
        public string session_key { get; set; }
        public string errcode { get; set; }
        public string errmsg { get; set; }
    }
}
