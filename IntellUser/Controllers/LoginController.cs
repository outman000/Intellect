using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.IntellUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.UserViewModel;
namespace IntellUser.Controllers
{
    [Route("UserApi/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _ILoginService;
        public LoginController(ILoginService  loginService)
        {
            _ILoginService = loginService;

        }
        /// <summary>
        /// 正式登陆方法
        /// </summary>
        /// <param name="loginViewModel">用户名和密码</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UserLogin([FromBody] LoginViewModel loginViewModel)
        {
          
            _ILoginService.Login_Valide();


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