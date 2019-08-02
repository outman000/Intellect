using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthentValitor.AuthentModel;
using AuthentValitor.AuthHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace IntellWeChat.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        readonly ILogger _ILogger;
        
        public ValuesController(ILogger logger)
        {
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

    }
}
