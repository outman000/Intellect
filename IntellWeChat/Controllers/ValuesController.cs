using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthentValitor.AuthentModel;
using AuthentValitor.AuthHelper;
using Dto.IService.IntellWeChat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ViewModel.WeChatViewModel.RequestViewModel;
using ViewModel.WeChatViewModel.ResponseModel;

namespace IntellWeChat.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly ILoginService _loginService;
        readonly ILogger _ILogger;

        public ValuesController(ILoginService loginService, ILogger logger)
        {
            _loginService = loginService;
            _ILogger = logger;
        }
       

        /// <summary>
        /// 这个也需要认证，只不过登录即可，不一定是Admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult Get1231232(int id,String token)
        {
            TokenModelJwt aa = JwtHelper.SerializeJwt(token);
            return Ok("value");
        }

        /// <summary>
        /// 登录接口：随便输入字符，获取token，然后添加 Authoritarian
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpGet]
        public  ActionResult GetJWTToken(string name, string pass)
        {
            string jwtStr = string.Empty;
            bool suc = false;
            //这里就是用户登陆以后，通过数据库去调取数据，分配权限的操作
            //这里直接写死了
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass))
            {
                return new JsonResult(new
                {
                    Status = false,
                    message = "用户名或密码不能为空"
                });
            }
            TokenModelJwt tokenModel = new TokenModelJwt();
            tokenModel.Uid = 2;
            tokenModel.Role = "Admin";
            jwtStr = JwtHelper.IssueJwt(tokenModel);
            suc = true;
            return Ok(new
            {
                success = suc,
                token = jwtStr
            });
        }

        /// <summary>
        /// 根据用户账号和密码查询用户信息
        /// </summary>
        /// <param name="weChatLoginViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<WeChatLoginResModel> Manage_WeChatLogin_User123123(WeChatLoginViewModel weChatLoginViewModel)
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

                TokenModelJwt tokenModel = new TokenModelJwt();
                tokenModel.Uid = 2;
                tokenModel.Role = "Admin";
                string  token = JwtHelper.IssueJwt(tokenModel);
              

                _ILogger.Information("查询用户信息，存在该用户，权限查询成功");

                return Ok(weChatLoginResModel);


            }
        }




        [HttpPost]
        [Authorize]
        public ActionResult<WeChatInfoResModel> GetJWTToken1(WeChatInfoViewModel weChatInfoViewModel)
        {
            WeChatInfoResModel weChatInfoResModel = new WeChatInfoResModel();
            var UserSearchResult = _loginService.WeChatLogin_Search(weChatInfoViewModel);
            if (UserSearchResult.User_Rights.Count < 1)
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


    }
}
