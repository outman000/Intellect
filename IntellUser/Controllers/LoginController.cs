using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Dto.IService.IntellUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.UserViewModel.RequsetModel;
using ViewModel.WeChatViewModel.RequestViewModel;
using Microsoft.AspNetCore.Authorization;

namespace IntellUser.Controllers
{
    [Route("UserApi/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //private readonly ILoginService _ILoginService;
        private readonly ILoginService _LoginService;
        private readonly ILogger _ILogger;
        public LoginController( ILoginService loginService, ILogger logger)
        {
            _LoginService = loginService;
            //_ILoginService = loginService;
            _ILogger = logger;
        }
        ///// <summary>
        ///// 正式登陆方法
        ///// </summary>
        ///// <param name="loginViewModel">用户名和密码</param>
        ///// <returns></returns>
        //[HttpPost]
        //public ActionResult UserLogin([FromBody] LoginViewModel loginViewModel)
        //{
        //  if (!ModelState.IsValid)
        //  {

        //  }

        //  else
        //  {
        //    return Content("输入数据通过验证");
        //  }
        //    _ILoginService.Login_Valide(loginViewModel);


        //    return Ok();
        //}


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
                    code = "200",
                    data = tk
                }
                );


            /// <summary>
            //     /// 根据用户账号和密码查询用户信息
            //     /// </summary>
            //     /// <param name="weChatLoginViewModel"></param>
            //     /// <returns></returns>
            //[HttpPost]
            //public ActionResult Manage_WeChatLogin_User(WeChatLoginViewModel weChatLoginViewModel)
            //{
            //    WeChatLoginResModel weChatLoginResModel = new WeChatLoginResModel();
            //    var UserSearchResult = _LoginService.WeChatLogin_User(weChatLoginViewModel);

            //    if (UserSearchResult == null)
            //    {
            //        weChatLoginResModel.IsSuccess = false;
            //        weChatLoginResModel.baseViewModel.Message = "用户名不存在或者密码错误";
            //        weChatLoginResModel.baseViewModel.ResponseCode = 400;
            //        _ILogger.Information("用户名不存在或者密码错误，进入系统失败");
            //        return BadRequest(weChatLoginResModel);
            //    }
            //    else
            //    {
            //        weChatLoginResModel.user_session = UserSearchResult;
            //        weChatLoginResModel.IsSuccess = true;
            //        weChatLoginResModel.baseViewModel.Message = "存在该用户，查询成功";
            //        weChatLoginResModel.baseViewModel.ResponseCode = 200;
            //        _ILogger.Information("查询用户信息，存在该用户，权限查询成功");

            //        return Ok(weChatLoginResModel);


            //    }
            //}
        }
    }
}