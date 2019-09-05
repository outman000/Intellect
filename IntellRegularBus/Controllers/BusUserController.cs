﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Dto.IService.IntellRegularBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.BusViewModel.RequestViewModel.BusUserViewModel;
using ViewModel.BusViewModel.ResponseModel.BusUserResModel;
using ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel;
using ViewModel.BusViewModel.ResponseModel.BusInfoResModel;

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
        public ActionResult<BusUserAddResModel> Bus_User_Add(BusUserAddViewModel busUserAddViewModel)
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
        public ActionResult<BusUserDelResModel> Bus_User_Delete(BusUserDelViewModel busUserDelViewModel)
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
        /// 查询本部门所有缴费时间列表信息（降序显示）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<BusUserTimeListSearchResModel> Bus_User_TimeList_Search(BusUserSearchTimeViewModel busUserSearchTimeViewModel)
        {
            BusUserTimeListSearchResModel  busUserTimeListSearchResModel = new BusUserTimeListSearchResModel();
            var BusUserSearchResult = _IBusUserService.Bus_User_TimeList_Search(busUserSearchTimeViewModel);

            busUserTimeListSearchResModel.bus_user_time_Info = BusUserSearchResult;
            busUserTimeListSearchResModel.isSuccess = true;
            busUserTimeListSearchResModel.baseViewModel.Message = "查询成功";
            busUserTimeListSearchResModel.baseViewModel.ResponseCode = 200;
            busUserTimeListSearchResModel.TotalNum = BusUserSearchResult.Count;
            _ILogger.Information("查询所有用户缴费信息成功");
            return Ok(busUserTimeListSearchResModel);
        }
        /// <summary>
        /// 查询所有用户缴费信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<BusUserSearchResModel> Bus_User_Search(BusUserSearchViewModel busUserSearchViewModel)
        {
            BusUserSearchResModel busUserSearchResModel = new BusUserSearchResModel();
            var BusUserSearchResult = _IBusUserService.Bus_User_Search(busUserSearchViewModel);
            int TotalExpen= _IBusUserService.Bus_UserExpen_Search(busUserSearchViewModel);//应缴费用总和

            var TotalNum = _IBusUserService.Bus_User_Get_ALLNum(busUserSearchViewModel);
            busUserSearchResModel.bus_user_Info = BusUserSearchResult;
            busUserSearchResModel.isSuccess = true;
            busUserSearchResModel.baseViewModel.Message = "查询成功";
            busUserSearchResModel.baseViewModel.ResponseCode = 200;
            busUserSearchResModel.TotalNum = TotalNum;
            busUserSearchResModel.TotalExpen = TotalExpen;
            _ILogger.Information("查询所有用户缴费信息成功");
            return Ok(busUserSearchResModel);
        }
        /// <summary>
        /// 把模板月份用户缴费信息添加到数据库（参数只需要传乘车时间和部门Id,PageSize设置为999 CurrentPageNum=0）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<BusUserAddResModel> Bus_PayMent_Template_Add(BusUserSearchViewModel busUserSearchViewModel)
        {

            int Bus_User_Add_Count;
            Bus_User_Add_Count = _IBusUserService.Bus_PayMent_Template(busUserSearchViewModel);
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
                busUserAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增加用户缴费信息失败");
                return Ok(busUserAddResModel);
            }
        }

        /// <summary>
        /// 根据线路Id查询该班车是否坐满人
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<BusSearchByIdResModel> Bus_Id_Search(BusSearchByIdViewModel busSearchByIdViewModel)
        {
            BusSearchByIdResModel  busSearchByIdResModel = new BusSearchByIdResModel();
            int Result = _IBusUserService.ByBusIdSearchNum(busSearchByIdViewModel);
             if(Result==-1)
             {
                    busSearchByIdResModel.isSuccess = false;
                    busSearchByIdResModel.baseViewModel.Message = "该线路已坐满人，请重新选择";
                    busSearchByIdResModel.baseViewModel.ResponseCode = 200;
                    _ILogger.Information("该线路已满员，请重新选择");
                   return Ok(busSearchByIdResModel);

            }
            else
            {
                busSearchByIdResModel.isSuccess = true;
                busSearchByIdResModel.baseViewModel.Message = "该线路未坐满人，可以添加该线路";
                busSearchByIdResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("该线路未坐满人，可以添加该线路");
                return Ok(busSearchByIdResModel);

            }
           
        }
        /// <summary>
        /// 修改单个用户缴费信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<BusUserUpdateResModel> Bus_User_Update(BusUserUpdateViewModel busUserUpdateViewModel)
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
        /// <summary>
        /// 修改用户缴费表单id信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<BusPaymentUpdateResModel> Bus_Payment_Update(BusPaymentUpdateViewModel busPamentUpdateViewModel)
        {
            BusPaymentUpdateResModel  busPamentUpdateResModel = new BusPaymentUpdateResModel();
            int UpdateRowNum = _IBusUserService.Bus_PayMent_Update(busPamentUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                busPamentUpdateResModel.IsSuccess = true;
                busPamentUpdateResModel.AddCount = UpdateRowNum;
                busPamentUpdateResModel.baseViewModel.Message = "更新成功";
                busPamentUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增加用户缴费表单id信息成功");
                return Ok(busPamentUpdateResModel);
            }
            else
            {
                busPamentUpdateResModel.IsSuccess = false;
                busPamentUpdateResModel.AddCount = 0;
                busPamentUpdateResModel.baseViewModel.Message = "更新失败";
                busPamentUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增加用户缴费表单id信息失败");
                return BadRequest(busPamentUpdateResModel);
            }
        }

        /// <summary>
        /// 缴费信息验证
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<BuUserValideResModel> Bus_Payment_Valide(BusUserValideViewModel  busUserValideViewModel)
        {
            BuUserValideResModel buUserValideResModel = new BuUserValideResModel();
            IDictionary<int, String> errorResult = _IBusUserService.Bus_Payment_valide(busUserValideViewModel);

            if (errorResult.Count > 0)
            {
                buUserValideResModel.isSuccess = false;
                buUserValideResModel.errorResult = errorResult;
                buUserValideResModel.baseViewModel.Message = "缴费单存在变更信息";
                buUserValideResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("验证班车缴费信息存在变更");
                return Ok(buUserValideResModel);
            }
            else
            {
                buUserValideResModel.isSuccess = true;
                buUserValideResModel.errorResult = errorResult;
                buUserValideResModel.baseViewModel.Message = "班车缴费单不存在变更信息";
                buUserValideResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("班车缴费信息可以使用，无异常");
                return Ok(buUserValideResModel);
            }

        }
    }
}