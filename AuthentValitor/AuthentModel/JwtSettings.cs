using System;
using System.Collections.Generic;
using System.Text;

namespace AuthentValitor.AuthentModel
{
     public  class JwtSettings
    {
        /// <summary>
        /// Token是谁颁发的
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Token给那些客户端去使用
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// 用于加密的key 必须是16个字符以上，要大于128个字节
        /// </summary>
        public string SecetKey { get; set; }

    }
}
