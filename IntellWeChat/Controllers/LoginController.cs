using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.IntellWeChat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ViewModel.WeChatViewModel.RequestViewModel;
using ViewModel.WeChatViewModel.ResponseModel;

namespace IntellWeChat.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService  _loginService;
        readonly ILogger _ILogger;

        public LoginController(ILoginService loginService, ILogger logger)
        {
               _loginService = loginService;
               _ILogger = logger;
        }
        /// <summary>
        /// 根据用户id查询用户信息
        /// </summary>
        /// <param name="weChatInfoViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult Manage_WeChatLogin_Search(WeChatInfoViewModel  weChatInfoViewModel)
        {
            WeChatInfoResModel weChatInfoResModel = new WeChatInfoResModel();
            var UserSearchResult = _loginService.WeChatLogin_Search(weChatInfoViewModel);
            if(UserSearchResult.User_Rights.Count<1)
            {
                weChatInfoResModel.IsSuccess = false;
                weChatInfoResModel.baseViewModel.Message = "用户无权限登录";
                weChatInfoResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("用户无权限，进入系统失败");
                return BadRequest(weChatInfoResModel);
            }
            else
            {

                weChatInfoResModel.userInfo = UserSearchResult;
                weChatInfoResModel.IsSuccess = true;
                weChatInfoResModel.baseViewModel.Message = "存在该用户，查询成功";
                weChatInfoResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("查询用户信息，存在该用户，权限查询成功");
                return Ok(weChatInfoResModel);
            }
        }

        /// <summary>
        /// 根据用户账号和密码查询用户信息
        /// </summary>
        /// <param name="weChatLoginViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_WeChatLogin_User(WeChatLoginViewModel weChatLoginViewModel)
        {
            WeChatLoginResModel  weChatLoginResModel = new WeChatLoginResModel();
            var UserSearchResult = _loginService.WeChatLogin_User(weChatLoginViewModel);

            if (UserSearchResult == null)
            {
                weChatLoginResModel.IsSuccess = false;
                weChatLoginResModel.baseViewModel.Message = "用户名不存在或者密码错误";
                weChatLoginResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("用户名不存在或者密码错误，进入系统失败");
                return BadRequest(weChatLoginResModel);
            }
            else
            {
                weChatLoginResModel.user_session = UserSearchResult;
                weChatLoginResModel.IsSuccess = true;
                weChatLoginResModel.baseViewModel.Message = "存在该用户，查询成功";
                weChatLoginResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("查询用户信息，存在该用户，权限查询成功");
              
             return Ok(weChatLoginResModel);


            }
        }


        /// <summary>
        /// 根据用户账号和密码查询用户信息(旭旭专用)
        /// </summary>
        /// <param name="weChatLoginViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_XuXuLogin_User(WeChatLoginViewModel weChatLoginViewModel)
        {
            WeChatLoginResModel weChatLoginResModel = new WeChatLoginResModel();
            var UserSearchResult = _loginService.WeChatLogin_User(weChatLoginViewModel);

            if (UserSearchResult == null)
            {
                weChatLoginResModel.IsSuccess = false;
                weChatLoginResModel.baseViewModel.Message = "用户名不存在或者密码错误";
                weChatLoginResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("用户名不存在或者密码错误，进入系统失败");
                return BadRequest(weChatLoginResModel);
            }
            else
            {
                weChatLoginResModel.user_session = UserSearchResult;
                weChatLoginResModel.IsSuccess = true;
                weChatLoginResModel.baseViewModel.Message = "存在该用户，查询成功";
                weChatLoginResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("查询用户信息，存在该用户，权限查询成功");

                var tk = new { token = "2728b712288da12fffd103af3bd616ff" };
                return Ok(

                    new
                    {
                        code = "200",
                        data = tk
                    }
                    );


            }
        }
    }
}