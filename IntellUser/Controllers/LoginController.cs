using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntellUser.InterFace;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.UserViewModel;
namespace IntellUser.Controllers
{
    [Route("UserApi/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginInterface _loginInterface;
        public LoginController(LoginInterface loginInterface)
        {
            _loginInterface = loginInterface;

        }
        /// <summary>
        /// 正式登陆方法
        /// </summary>
        /// <param name="obj">用户名和密码</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UserLogin([FromBody] LoginViewModel obj)
        {
            return Ok();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <remarks>绝对正确</remarks>
        /// <returns></returns>
        
        [HttpPost]
        public ActionResult UserLoginAbsolute()
        {
            return Ok();
        }

    }
}