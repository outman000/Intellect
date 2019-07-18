using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.IntellRegularBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;
using ViewModel.BusViewModel.ResponseModel.BusInfoResModel;

namespace IntellRegularBus.Controllers
{
    [Route("BusManageApi/[controller]/[action]")]
    [ApiController]
    public class BusInfoController : ControllerBase
    {

        private readonly IBusService _busService;
      


        public BusInfoController(IBusService busService)
        {
            _busService = busService;

        }
        /// <summary>
        /// 增添班车信息
        /// </summary>
        /// <param name="busAddViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Bus_Add(BusAddViewModel busAddViewModel)
        {
            int Bus_Add_Count;
            Bus_Add_Count = _busService.Bus_Add(busAddViewModel);
            BusAddResModel userAddResModel = new BusAddResModel();
            if (Bus_Add_Count > 0)
            {
                userAddResModel.IsSuccess = true;
                userAddResModel.AddCount = Bus_Add_Count;
                userAddResModel.baseViewModel.Message = "添加成功";
                userAddResModel.baseViewModel.ResponseCode = 200;
                return Ok(userAddResModel);
            }
            else
            {
                userAddResModel.IsSuccess = false;
                userAddResModel.AddCount = 0;
                userAddResModel.baseViewModel.Message = "添加失败";
                userAddResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(userAddResModel);
            }
        }
        /// <summary>
        /// 查询班车信息
        /// </summary>
        /// <param name="busSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Bus_Search(BusSearchViewModel busSearchViewModel)
        {
            BusSearchResModel busSearchResModel = new BusSearchResModel();
            var BusSearchResult = _busService.Bus_Search(busSearchViewModel);

            // var TotalNum = _userService.User_Get_ALLNum();
            var TotalNum = BusSearchResult.Count;
            busSearchResModel.bus_Infos = BusSearchResult;
            busSearchResModel.isSuccess = true;
            busSearchResModel.baseViewModel.Message = "查询成功";
            busSearchResModel.baseViewModel.ResponseCode = 200;
            busSearchResModel.TotalNum = TotalNum;
            return Ok(busSearchResModel);

        }
        /// <summary>
        /// 更新班车信息
        /// </summary>
        /// <param name="busUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Bus_Update(BusUpdateViewModel busUpdateViewModel)
        {
            BusUpdateResModel userValideResRepeat = new BusUpdateResModel();
            int UpdateRowNum = _busService.Bus_Update(busUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                userValideResRepeat.IsSuccess = true;
                userValideResRepeat.AddCount = UpdateRowNum;
                userValideResRepeat.baseViewModel.Message = "更新成功";
                userValideResRepeat.baseViewModel.ResponseCode = 200;
                return Ok(userValideResRepeat);
            }
            else
            {
                userValideResRepeat.IsSuccess = false;
                userValideResRepeat.AddCount = 0;
                userValideResRepeat.baseViewModel.Message = "更新失败";
                userValideResRepeat.baseViewModel.ResponseCode = 400;
                return BadRequest(userValideResRepeat);
            }
        }

        /// <summary>
        /// 删除班车
        /// </summary>
        /// <param name="busDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_UserRole_Delete(BusDelViewModel busDelViewModel)
        {
            BusDelResModel busDelResModel = new BusDelResModel();
            int DeleteResult = _busService.Bus_Delete(busDelViewModel);

            if (DeleteResult > 0)
            {
                busDelResModel.DelCount = DeleteResult;
                busDelResModel.IsSuccess = true;
                busDelResModel.baseViewModel.Message = "删除成功";
                busDelResModel.baseViewModel.ResponseCode = 200;
                return Ok(busDelResModel);
            }
            else
            {
                busDelResModel.DelCount = -1;
                busDelResModel.IsSuccess = false;
                busDelResModel.baseViewModel.Message = "删除失败";
                busDelResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(busDelResModel);
            }
        }

        /// <summary>
        /// 根据班车添加线路
        /// </summary>
        /// <param name="lineByBusAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_User_Depart(LineByBusAddViewModel lineByBusAddViewModel)
        {
            LineByBusAddResModel lineByBusAddResModel = new LineByBusAddResModel();
            int UpdateRowNum = _busService.Bus_To_Line_Add(lineByBusAddViewModel);  
            if (UpdateRowNum >0)
            {
                lineByBusAddResModel.IsSuccess = true;
                lineByBusAddResModel.AddCount = UpdateRowNum;
                lineByBusAddResModel.baseViewModel.Message = "根据班车添加线路成功";
                lineByBusAddResModel.baseViewModel.ResponseCode = 200;
                return Ok(lineByBusAddResModel);
            }
            else
            {
                lineByBusAddResModel.IsSuccess = false;
                lineByBusAddResModel.AddCount = 0;
                lineByBusAddResModel.baseViewModel.Message = "根据班车添加线路失败";
                lineByBusAddResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(lineByBusAddResModel);

            }

        }
    }
}