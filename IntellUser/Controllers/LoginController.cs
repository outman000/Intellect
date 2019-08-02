using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Dto.IService.IntellUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.UserViewModel.RequsetModel;

namespace IntellUser.Controllers
{
    [Route("UserApi/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _ILoginService;
        private readonly ILogger _ILogger;
        public LoginController(ILoginService  loginService, ILogger logger)
        {
            _ILoginService = loginService;
            _ILogger = logger;
        }
        /// <summary>
        /// 正式登陆方法
        /// </summary>
        /// <param name="loginViewModel">用户名和密码</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UserLogin([FromBody] LoginViewModel loginViewModel)
        {
          if (!ModelState.IsValid)
          {
               
          }

          else
          {
            return Content("输入数据通过验证");
          }
            _ILoginService.Login_Valide(loginViewModel);


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
            var tk = new { token = "2728b712288da12fffd103af3bd616ff" };
            return Ok(

                new {
                    code="200",
                    data= tk
                }
                );
        }

    }
}