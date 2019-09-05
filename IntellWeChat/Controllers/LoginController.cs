using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Dto.IService.IntellWeChat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Serilog;
using ViewModel.WeChatViewModel.MiddleModel;
using ViewModel.WeChatViewModel.RequestViewModel;
using ViewModel.WeChatViewModel.ResponseModel;

namespace IntellWeChat.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private IOptions<WeChartTokenMiddles> _IOptions;
        private readonly IWeChatHttpClientService _weChatHttpClientService;

        private readonly ILoginService  _loginService;
        private readonly ILogger _ILogger;

        public LoginController(IWeChatHttpClientService weChatHttpClientService, IOptions<WeChartTokenMiddles> iOptions, ILoginService loginService, ILogger logger, IHttpClientFactory httpClientFactory)
        {
               _IOptions = iOptions;
               _loginService = loginService;
               _ILogger = logger;
               _httpClientFactory = httpClientFactory;
               _weChatHttpClientService = weChatHttpClientService;
        }
        /// <summary>
        /// 根据用户id查询用户信息
        /// </summary>
        /// <param name="weChatInfoViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<WeChatInfoResModel> Manage_WeChatLogin_Search(WeChatInfoViewModel  weChatInfoViewModel)
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
        public ActionResult<WeChatLoginResModel> Manage_WeChatLogin_User(WeChatLoginViewModel weChatLoginViewModel)
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
        public ActionResult<WeChatLoginResModel> Manage_XuXuLogin_User(WeChatLoginViewModel weChatLoginViewModel)
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
                weChatLoginResModel.tokenViewModel.code ="200";
                weChatLoginResModel.tokenViewModel.data  = "2728b712288da12fffd103af3bd616ff" ;

                _ILogger.Information("查询用户信息，存在该用户，权限查询成功");


                return Ok(weChatLoginResModel);

            }
        }
        /// <summary>
        /// 获取微信token
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<WeChatTokenResModel>> wechartTokenAsync()
        {
            var weChatTokenResModel =await _weChatHttpClientService.getWeChatTokenAsync();
            return Ok(weChatTokenResModel);
        }
    }
}