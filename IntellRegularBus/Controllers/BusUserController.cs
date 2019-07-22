using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.IntellRegularBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.BusViewModel.RequestViewModel.BusUserViewModel;

namespace IntellRegularBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusUserController : ControllerBase
    {


        private readonly IBusUserService _IBusUserService;

        public BusUserController(IBusUserService lineService)
        {
            _IBusUserService = lineService;

        }

        /// <summary>
        ///  增加用户缴费信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Bus_User_Add(BusUserAddViewModel busUserAddViewModel)
        {
            return null;
        }
        /// <summary>
        /// 删除用户缴费信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Bus_User_Delete()
        {
            return null;
        }
        /// <summary>
        /// 查询用户缴费信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Bus_User_Search()
        {
            return null;
        }

        /// <summary>
        /// 修改用户缴费信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Bus_User_Update()
        {
            return null;
        }

    }
}