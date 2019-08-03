using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.IntellWeChat;
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
        /// 根据用户账号和密码查询用户信息
        /// </summary>
        /// <param name="weChatLoginViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_WeChatLogin_Search(WeChatLoginViewModel weChatLoginViewModel)
        {
            WeChatLoginResModel  weChatLoginResModel = new WeChatLoginResModel();
            var UserSearchResult = _loginService.WeChatLogin_Search(weChatLoginViewModel);
            if(UserSearchResult.Count== 0)
            {
                weChatLoginResModel.IsSuccess = false;
                weChatLoginResModel.baseViewModel.Message = "不存在该用户，查询失败";
                weChatLoginResModel.TotalNum = 0;
                weChatLoginResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("查询用户信息，查询失败");
                return BadRequest(weChatLoginResModel);
            }
            else if(UserSearchResult[0].Id == 8888888)
            {
                //var TotalNum = _userService.User_Get_ALLNum();
                weChatLoginResModel.userInfo = UserSearchResult;
                weChatLoginResModel.IsSuccess = false;
                weChatLoginResModel.baseViewModel.Message = "存在该用户，但是该用户没有角色";
                weChatLoginResModel.TotalNum = UserSearchResult.Count;
                weChatLoginResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("查询用户信息，存在该用户，但是该用户没有角色");
                return Ok(weChatLoginResModel);
               

            }
            else if(UserSearchResult[0].Id == 6666666)
            {
                weChatLoginResModel.userInfo = UserSearchResult;
                weChatLoginResModel.IsSuccess = false;
                weChatLoginResModel.baseViewModel.Message = "存在该用户，但是该用户没有权限";
                weChatLoginResModel.TotalNum = UserSearchResult.Count;
                weChatLoginResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("查询用户信息，存在该用户，但是该用户没有权限");
                return Ok(weChatLoginResModel);


            }
            else
            {

                weChatLoginResModel.userInfo = UserSearchResult;
                weChatLoginResModel.IsSuccess = true;
                weChatLoginResModel.baseViewModel.Message = "存在该用户，查询成功";
                weChatLoginResModel.TotalNum = UserSearchResult.Count;
                weChatLoginResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("查询用户信息，存在该用户，查询成功");
                return Ok(weChatLoginResModel);
            }

        }


    }
}