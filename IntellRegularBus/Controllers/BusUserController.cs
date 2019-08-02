using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Dto.IService.IntellRegularBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.BusViewModel.RequestViewModel.BusUserViewModel;
using ViewModel.BusViewModel.ResponseModel.BusUserResModel;

namespace IntellRegularBus.Controllers
{
    [Route("BusManageApi/[controller]/[action]")]
    [ApiController]
    public class BusUserController : ControllerBase
    {


        private readonly IBusUserService _IBusUserService;
        private readonly ILogger _ILogger;
        public BusUserController(IBusUserService lineService, ILogger logger)
        {
            _IBusUserService = lineService;
            _ILogger = logger;
        }

        /// <summary>
        ///  增加用户缴费信息
        /// </summary>
        /// <returns></returns>       
       [HttpPost]
        public ActionResult Bus_User_Add(BusUserAddViewModel busUserAddViewModel)
        {
       
            int Bus_User_Add_Count;
            Bus_User_Add_Count = _IBusUserService.Bus_User_Add(busUserAddViewModel);
            BusUserAddResModel busUserAddResModel = new BusUserAddResModel();
            if (Bus_User_Add_Count > 0)
            {
                busUserAddResModel.IsSuccess = true;
                busUserAddResModel.AddCount = Bus_User_Add_Count;
                busUserAddResModel.baseViewModel.Message = "添加成功";
                busUserAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增加用户缴费信息成功");
                return Ok(busUserAddResModel);
            }
            else
            {
                busUserAddResModel.IsSuccess = false;
                busUserAddResModel.AddCount = 0;
                busUserAddResModel.baseViewModel.Message = "添加失败";
                busUserAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增加用户缴费信息失败");
                return BadRequest(busUserAddResModel);
            }
       

    }
        /// <summary>
        /// 删除用户缴费信息
        /// </summary>
        /// <returns></returns>
         [HttpPost]
        public ActionResult Bus_User_Delete(BusUserDelViewModel busUserDelViewModel)
        {
            BusUserDelResModel busUserDelResModel = new BusUserDelResModel();
            int DeleteResult = _IBusUserService.Bus_User_Delete(busUserDelViewModel);

            if (DeleteResult > 0)
            {
                busUserDelResModel.DelCount = DeleteResult;
                busUserDelResModel.IsSuccess = true;
                busUserDelResModel.baseViewModel.Message = "删除成功";
                busUserDelResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("删除用户缴费信息成功");
                return Ok(busUserDelResModel);
            }
            else
            {
                busUserDelResModel.DelCount = -1;
                busUserDelResModel.IsSuccess = false;
                busUserDelResModel.baseViewModel.Message = "删除失败";
                busUserDelResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("删除用户缴费信息失败");
                return BadRequest(busUserDelResModel);
            }
        }
        /// <summary>
        /// 查询所有用户缴费信息
        /// </summary>
        /// <returns></returns>
       [HttpPost]
        public ActionResult Bus_User_Search(BusUserSearchViewModel busUserSearchViewModell)
        {
            BusUserSearchResModel busUserSearchResModel = new BusUserSearchResModel();
            var BusUserSearchResult = _IBusUserService.Bus_User_Search(busUserSearchViewModell);
            var TotalNum = _IBusUserService.Bus_User_Get_ALLNum(busUserSearchViewModell);
            busUserSearchResModel.bus_user_Info = BusUserSearchResult;
            busUserSearchResModel.isSuccess = true;
            busUserSearchResModel.baseViewModel.Message = "查询成功";
            busUserSearchResModel.baseViewModel.ResponseCode = 200;
            busUserSearchResModel.TotalNum = TotalNum;
            _ILogger.Information("查询所有用户缴费信息成功");
            return Ok(busUserSearchResModel);
        }

        /// <summary>
        /// 修改用户缴费信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Bus_User_Update(BusUserUpdateViewModel busUserUpdateViewModel)
        {
            BusUserUpdateResModel busUserUpdateResModel = new BusUserUpdateResModel();
            int UpdateRowNum = _IBusUserService.Bus_User_Update(busUserUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                busUserUpdateResModel.IsSuccess = true;
                busUserUpdateResModel.AddCount = UpdateRowNum;
                busUserUpdateResModel.baseViewModel.Message = "更新成功";
                busUserUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("修改用户缴费信息成功");
                return Ok(busUserUpdateResModel);
            }
            else
            {
                busUserUpdateResModel.IsSuccess = false;
                busUserUpdateResModel.AddCount = 0;
                busUserUpdateResModel.baseViewModel.Message = "更新失败";
                busUserUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("修改用户缴费信息失败");
                return BadRequest(busUserUpdateResModel);
            }
        }

    }
}