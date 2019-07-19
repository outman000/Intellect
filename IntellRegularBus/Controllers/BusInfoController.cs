using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.IntellRegularBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel;
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;
using ViewModel.BusViewModel.ResponseModel.BusInfoResModel;
using ViewModel.BusViewModel.ResponseModel.LineInforResModel;

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
        /// 验证班车id是否重复
        /// </summary>
        /// <param name="busValideRepeat"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Bus_ValideRepeat(BusValideRepeat busValideRepeat)
        {
            BusValideResRepeat busValideResRepeat = new BusValideResRepeat();
            bool ValideResutlt = _busService.Bus_Single(busValideRepeat);
            busValideResRepeat.IsSuccess = ValideResutlt;
            if (ValideResutlt)
            {
                busValideResRepeat.IsSuccess = true;
                busValideResRepeat.baseViewModel.Message = "此id可以使用";
                busValideResRepeat.baseViewModel.ResponseCode = 200;
                return Ok(busValideResRepeat);
            }
            else
            {
                busValideResRepeat.IsSuccess = false;
                busValideResRepeat.baseViewModel.Message = "此id已经存在，请更换";
                busValideResRepeat.baseViewModel.ResponseCode = 400;
                return BadRequest(busValideResRepeat);
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
            BusUpdateResModel busUpdateResModel = new BusUpdateResModel();
            int UpdateRowNum = _busService.Bus_Update(busUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                busUpdateResModel.IsSuccess = true;
                busUpdateResModel.AddCount = UpdateRowNum;
                busUpdateResModel.baseViewModel.Message = "更新成功";
                busUpdateResModel.baseViewModel.ResponseCode = 200;
                return Ok(busUpdateResModel);
            }
            else
            {
                busUpdateResModel.IsSuccess = false;
                busUpdateResModel.AddCount = 0;
                busUpdateResModel.baseViewModel.Message = "更新失败";
                busUpdateResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(busUpdateResModel);
            }
        }

        /// <summary>
        /// 删除班车
        /// </summary>
        /// <param name="busDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Bus_Delete(BusDelViewModel busDelViewModel)
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
        /// 根据班车添加线路 / 根据班车取消线路
        /// </summary>
        /// <param name="lineByBusAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Bus_Line(LineByBusAddViewModel lineByBusAddViewModel)
        {
            LineByBusAddResModel lineByBusAddResModel = new LineByBusAddResModel();
            int UpdateRowNum = _busService.Bus_To_Line_Add(lineByBusAddViewModel);  
            if (UpdateRowNum >0)
            {
                lineByBusAddResModel.IsSuccess = true;
                lineByBusAddResModel.AddCount = UpdateRowNum;
                lineByBusAddResModel.baseViewModel.Message = "根据班车添加/取消线路成功";
                lineByBusAddResModel.baseViewModel.ResponseCode = 200;
                return Ok(lineByBusAddResModel);
            }
            else
            {
                lineByBusAddResModel.IsSuccess = false;
                lineByBusAddResModel.AddCount = 0;
                lineByBusAddResModel.baseViewModel.Message = "根据班车添加/取消线路失败";
                lineByBusAddResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(lineByBusAddResModel);

            }

        }

        /// <summary>
        /// 根据线路添加班车 / 根据线路取消班车
        /// </summary>
        /// <param name="busByLineAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Line_Bus(BusByLineAddViewModel busByLineAddViewModel)
        {
            BusByLineAddResModel busByLineAddResModel = new BusByLineAddResModel();
            int UpdateRowNum = _busService.Line_To_Bus_Add(busByLineAddViewModel);
            if (UpdateRowNum > 0)
            {
                busByLineAddResModel.IsSuccess = true;
                busByLineAddResModel.AddCount = UpdateRowNum;
                busByLineAddResModel.baseViewModel.Message = "根据班车添加/取消线路成功";
                busByLineAddResModel.baseViewModel.ResponseCode = 200;
                return Ok(busByLineAddResModel);
            }
            else
            {
                busByLineAddResModel.IsSuccess = false;
                busByLineAddResModel.AddCount = 0;
                busByLineAddResModel.baseViewModel.Message = "根据班车添加/取消线路失败";
                busByLineAddResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(busByLineAddResModel);

            }

        }

        /// <summary>
        /// 根据线路查班车 
        /// </summary>
        /// <param name="busByLineSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Line_Bus_Search(BusByLineSearchViewModel busByLineSearchViewModel)
        {
            BusByLineSearchResModel busByLineSearchResModel = new BusByLineSearchResModel();
            busByLineSearchResModel.busInfo= _busService.Bus_By_Line_Search(busByLineSearchViewModel);
            if (busByLineSearchResModel.busInfo.Count > 0)
            {
                busByLineSearchResModel.IsSuccess = true;
                busByLineSearchResModel.TotalNum = busByLineSearchResModel.busInfo.Count;
                busByLineSearchResModel.baseViewModel.Message = "根据线路查班车成功";
                busByLineSearchResModel.baseViewModel.ResponseCode = 200;
                return Ok(busByLineSearchResModel);
            }
            else
            {
                busByLineSearchResModel.IsSuccess = false;
                busByLineSearchResModel.TotalNum = 0;
                busByLineSearchResModel.baseViewModel.Message = "根据线路查班车失败";
                busByLineSearchResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(busByLineSearchResModel);

            }

        }


        /// <summary>
        /// 根据班车查线路
        /// </summary>
        /// <param name="lineByBusSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Bus_Line_Search(LineByBusSearchViewModel lineByBusSearchViewModel)
        {
            LineByBusSearchResModel lineByBusSearchResModel = new LineByBusSearchResModel();
            lineByBusSearchResModel.line_Infos = _busService.Line_By_Bus_Search(lineByBusSearchViewModel);
            if (lineByBusSearchResModel.line_Infos.Count > 0)
            {
                lineByBusSearchResModel.IsSuccess = true;
                lineByBusSearchResModel.TotalNum = lineByBusSearchResModel.line_Infos.Count;
                lineByBusSearchResModel.baseViewModel.Message = "根据班车查线路成功";
                lineByBusSearchResModel.baseViewModel.ResponseCode = 200;
                return Ok(lineByBusSearchResModel);
            }
            else
            {
                lineByBusSearchResModel.IsSuccess = false;
                lineByBusSearchResModel.TotalNum = 0;
                lineByBusSearchResModel.baseViewModel.Message = "根据班车查线路失败";
                lineByBusSearchResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(lineByBusSearchResModel);

            }

        }
    }
}