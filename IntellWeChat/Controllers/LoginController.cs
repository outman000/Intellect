using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AuthentValitor.AuthentModel;
using AuthentValitor.AuthHelper;
using AuthentValitor.Common;
using Dto.IService.IntellWeChat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using ViewModel.UserViewModel.MiddleModel;
using ViewModel.UserViewModel.ResponseModel;
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

        private readonly ILoginService _loginService;
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
            string jwtStr = string.Empty;
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
                TokenModelJwt tokenModel = new TokenModelJwt();
                tokenModel.Uid = 2;
                tokenModel.Role = "Admin";
                jwtStr = JwtHelper.IssueJwt(tokenModel);
                weChatLoginResModel.tokenViewModel.data = jwtStr;//token
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
            string jwtStr = string.Empty;
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
                TokenModelJwt tokenModel = new TokenModelJwt();
                tokenModel.Uid = 2;
                tokenModel.Role = "Admin";
                jwtStr = JwtHelper.IssueJwt(tokenModel);
                weChatLoginResModel.tokenViewModel.data = jwtStr;//token
                weChatLoginResModel.user_session = UserSearchResult;
                weChatLoginResModel.IsSuccess = true;
                weChatLoginResModel.baseViewModel.Message = "存在该用户，查询成功";
                weChatLoginResModel.baseViewModel.ResponseCode = 200;
              //  weChatLoginResModel.tokenViewModel.code ="200";
              //  weChatLoginResModel.tokenViewModel.data  = "2728b712288da12fffd103af3bd616ff" ;

                _ILogger.Information("查询用户信息，存在该用户，权限查询成功");


                return Ok(weChatLoginResModel);

            }
        }

        /// <summary>
        /// 根据用户账号和密码修改用户密码信息
        /// </summary>
        /// <param name="weChatUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<WeChatLoginResModel> Manage_User_UpdatePassword(WeChatUpdateViewModel weChatUpdateViewModel)
        {
            WeChatLoginResModel weChatLoginResModel = new WeChatLoginResModel();
            var UserSearchResult = _loginService.WeChatLogin_User_Update(weChatUpdateViewModel);

            if (UserSearchResult == 0)
            {
                weChatLoginResModel.IsSuccess = false;
                weChatLoginResModel.baseViewModel.Message = "用户名不存在或者密码错误";
                weChatLoginResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("用户名不存在或者密码错误，修改密码失败");
                return BadRequest(weChatLoginResModel);
            }
            else
            {
     
                weChatLoginResModel.IsSuccess = true;
                weChatLoginResModel.baseViewModel.Message = "存在该用户，修改密码成功";
                weChatLoginResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("查询用户信息，存在该用户，修改密码成功");
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



        /// <summary>
        /// 获取Openid 模型参考UserBindResModel
        /// </summary>
        /// <param name="code">用户code</param>
        /// <returns></returns>
        [HttpGet("Visit/GetVisitOpenID")]
 
        public ActionResult<UserBindResModel> GetVisitOpenID(string code)
        {
            try
            {
                UserBindResModel result = new UserBindResModel();
                WeChatAppDecrypt decrypt = new WeChatAppDecrypt();
                string openIdAndSessionKeyString = decrypt.GetOpenID(code);
                string openId = "";

                openId = openIdAndSessionKeyString;
                string msg = string.Empty;
                result.Status = "0";

               //if(openId=="")
               //{
               //     result.BindStatus = "1";
               //     result.OpenID = openId;
               //     msg += "获取openid失败";
               //     result.Msg = msg;
               //     return Ok(result);
               //}
               var userBind_Infos = _loginService.UserBindSearch(openId); 
              
               
                if (userBind_Infos.Count==0)
                {
                    result.BindStatus = "0";
                    result.OpenID = openId;
                    msg += "用户待绑定";
                    result.Msg = msg;
                }
                else
                {
                    
                    result.BindStatus = "1";
                    result.OpenID = openId;
                    result.RoleName = "0";
                    result.Moblie = userBind_Infos[0].Moblie;
                    result.userId = userBind_Infos[0].userId;
                    result.passWord = _loginService.Searchpwd(userBind_Infos[0].userId).UserPwd;
                    msg += "用户已绑定；";
                    
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }


        /// <summary>
        /// 身份绑定并获取用户身份信息 模型参考UserBindResModel
        /// </summary>
        /// <param name="openID">小程序的openId </param>
        /// <param name="userId">电话</param>
        /// <param name="passWord">电话</param>
        /// <returns></returns>
        [HttpGet("Visit/GetVisitInfo")]

        public ActionResult<UserBindResModel> GetVisitInfo(string openID, string userId,string passWord)
        {
            UserBindResModel result = new UserBindResModel();
            int count = 0;
            WeChatLoginViewModel weChatLoginViewModel = new WeChatLoginViewModel();
            weChatLoginViewModel.UserId = userId;
            weChatLoginViewModel.UserPwd = passWord;
            var UserSearchResult = _loginService.WeChatLogin_User(weChatLoginViewModel);
            if (UserSearchResult == null)
            {
                result.BindStatus = "0";
                result.Msg = "绑定失败，账号或者密码存在问题";
            }
            else
            {

                var res = _loginService.UserBindSearch2(userId);

                if(res.Count>0)
                {             
                        result.BindStatus = "2";
                        result.Msg = "不是本人";                   
                }
               else
               {

                    count = _loginService.AddUserBind(openID, userId, passWord);
                    string msg = string.Empty;
                    if (count > 0)
                    {
                        msg = "账号绑定成功；";
                        result.BindStatus = "1";
                        result.OpenID = openID;
                        result.RoleName = "0";
                        result.Status = "0";
                    }
                    else
                    {
                        result.BindStatus = "0";
                        result.Msg = "绑定失败，参数存在问题";
                    }

               }

            }
           
            return Ok(result);
        }


        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpGet("Visit/SendMessage")]

        public string Manage_SendMessage(string phone, string message)
        {
            var result=_loginService.SmsMessage(phone, message);
            return result;
        }


    }
}