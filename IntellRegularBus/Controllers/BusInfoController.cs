using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Dto.IService.IntellRegularBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel;
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;
using ViewModel.BusViewModel.ResponseModel.BusInfoResModel;
using ViewModel.BusViewModel.ResponseModel.LineInforResModel;
using Microsoft.AspNetCore.Authorization;

namespace IntellRegularBus.Controllers
{
    [Route("BusManageApi/[controller]/[action]")]
    [ApiController]
    public class BusInfoController : ControllerBase
    {

        private readonly IBusService _busService;
        private readonly IStationService _stationService;
        private readonly ILogger _ILogger;

        public BusInfoController(IBusService busService, IStationService stationService, ILogger logger)
        {
            _busService = busService;
            _stationService= stationService;
            _ILogger = logger;
        }
        /// <summary>
        /// 增添班车信息
        /// </summary>
        /// <param name="busAddViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]

        public ActionResult<BusAddResModel> Manage_Bus_Add(BusAddViewModel busAddViewModel)
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
                _ILogger.Information("增添班车信息成功");
                return Ok(userAddResModel);
            }
            else
            {
                userAddResModel.IsSuccess = false;
                userAddResModel.AddCount = 0;
                userAddResModel.baseViewModel.Message = "添加失败";
                userAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增添班车信息失败");
                return BadRequest(userAddResModel);
            }
        }

        /// <summary>
        /// 验证班车标识是否重复
        /// </summary>
        /// <param name="busValideRepeat"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]

        public ActionResult<BusValideResRepeat> Manage_Bus_ValideRepeat(BusValideRepeat busValideRepeat)
        {
            BusValideResRepeat busValideResRepeat = new BusValideResRepeat();
            bool ValideResutlt = _busService.Bus_Single(busValideRepeat);
            busValideResRepeat.IsSuccess = ValideResutlt;
            if (ValideResutlt)
            {
                busValideResRepeat.IsSuccess = true;
                busValideResRepeat.baseViewModel.Message = "此id可以使用";
                busValideResRepeat.baseViewModel.ResponseCode = 200;
                _ILogger.Information("验证班车标识是否重复，此id可以使用");
                return Ok(busValideResRepeat);
            }
            else
            {
                busValideResRepeat.IsSuccess = false;
                busValideResRepeat.baseViewModel.Message = "此id已经存在，请更换";
                busValideResRepeat.baseViewModel.ResponseCode = 400;
                _ILogger.Information("验证班车标识是否重复，此id已经存在，请更换");
                return BadRequest(busValideResRepeat);
            }
        }
        /// <summary>
        /// 查询班车信息
        /// </summary>
        /// <param name="busSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusSearchResModel> Manage_Bus_Search(BusSearchViewModel busSearchViewModel)
        {
            BusSearchResModel busSearchResModel = new BusSearchResModel();
            var BusSearchResult = _busService.Bus_Search(busSearchViewModel);

            // var TotalNum = _userService.User_Get_ALLNum();
            var TotalNum = _busService.Bus_Get_ALLNum(busSearchViewModel);
            busSearchResModel.bus_Infos = BusSearchResult;
            busSearchResModel.isSuccess = true;
            busSearchResModel.baseViewModel.Message = "查询成功";
            busSearchResModel.baseViewModel.ResponseCode = 200;
            busSearchResModel.TotalNum = TotalNum;
            _ILogger.Information("查询班车信息成功");
            return Ok(busSearchResModel);

        }
        /// <summary>
        /// 更新班车信息
        /// </summary>
        /// <param name="busUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]

        public ActionResult<BusUpdateResModel> Manage_Bus_Update(BusUpdateViewModel busUpdateViewModel)
        {
            BusUpdateResModel busUpdateResModel = new BusUpdateResModel();
            int UpdateRowNum = _busService.Bus_Update(busUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                busUpdateResModel.IsSuccess = true;
                busUpdateResModel.AddCount = UpdateRowNum;
                busUpdateResModel.baseViewModel.Message = "更新成功";
                busUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更新班车信息成功");
                return Ok(busUpdateResModel);
            }
            else
            {
                busUpdateResModel.IsSuccess = false;
                busUpdateResModel.AddCount = 0;
                busUpdateResModel.baseViewModel.Message = "更新失败";
                busUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("更新班车信息失败");
                return BadRequest(busUpdateResModel);
            }
        }

        /// <summary>
        /// 删除班车
        /// </summary>
        /// <param name="busDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusDelResModel> Manage_Bus_Delete(BusDelViewModel busDelViewModel)
        {
            BusDelResModel busDelResModel = new BusDelResModel();
            int DeleteResult = _busService.Bus_Delete(busDelViewModel);

            if (DeleteResult > 0)
            {
                busDelResModel.DelCount = DeleteResult;
                busDelResModel.IsSuccess = true;
                busDelResModel.baseViewModel.Message = "删除成功";
                busDelResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("删除班车成功");
                return Ok(busDelResModel);
            }
            else
            {
                busDelResModel.DelCount = -1;
                busDelResModel.IsSuccess = false;
                busDelResModel.baseViewModel.Message = "删除失败";
                busDelResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("删除班车失败");
                return BadRequest(busDelResModel);
            }
        }

        /// <summary>
        /// 根据班车添加线路 / 根据班车取消线路
        /// </summary>
        /// <param name="lineByBusAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<LineByBusAddResModel> Manage_Bus_Line(LineByBusAddViewModel lineByBusAddViewModel)
        {
            LineByBusAddResModel lineByBusAddResModel = new LineByBusAddResModel();
            int UpdateRowNum = _busService.Bus_To_Line_Add(lineByBusAddViewModel);  
            if (UpdateRowNum >0)
            {
                lineByBusAddResModel.IsSuccess = true;
                lineByBusAddResModel.AddCount = UpdateRowNum;
                lineByBusAddResModel.baseViewModel.Message = "根据班车添加/取消线路成功";
                lineByBusAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据班车添加线路/取消线路成功");
                return Ok(lineByBusAddResModel);
            }
            else
            {
                lineByBusAddResModel.IsSuccess = false;
                lineByBusAddResModel.AddCount = 0;
                lineByBusAddResModel.baseViewModel.Message = "根据班车添加/取消线路失败";
                lineByBusAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("根据班车添加/取消线路失败");
                return BadRequest(lineByBusAddResModel);

            }

        }

        /// <summary>
        /// 根据线路添加班车 / 根据线路取消班车
        /// </summary>
        /// <param name="busByLineAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusByLineAddResModel> Manage_Line_Bus(BusByLineAddViewModel busByLineAddViewModel)
        {
            BusByLineAddResModel busByLineAddResModel = new BusByLineAddResModel();
            int UpdateRowNum = _busService.Line_To_Bus_Add(busByLineAddViewModel);
            if (UpdateRowNum > 0)
            {
                busByLineAddResModel.IsSuccess = true;
                busByLineAddResModel.AddCount = UpdateRowNum;
                busByLineAddResModel.baseViewModel.Message = "根据线路添加/取消班车成功";
                busByLineAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据线路添加/取消班车成功");
                return Ok(busByLineAddResModel);
            }
            else
            {
                busByLineAddResModel.IsSuccess = false;
                busByLineAddResModel.AddCount = 0;
                busByLineAddResModel.baseViewModel.Message = "根据线路添加/取消班车失败";
                busByLineAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("根据线路添加/取消班车失败");
                return BadRequest(busByLineAddResModel);

            }

        }

        /// <summary>
        /// 根据线路查班车  /  根据站点查班车 
        /// </summary>
        /// <param name="busByLineSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusByLineSearchResModel> Manage_Line_Bus_Search(BusByLineSearchViewModel busByLineSearchViewModel)
        {
            BusByLineSearchResModel busByLineSearchResModel = new BusByLineSearchResModel();
            busByLineSearchResModel.busInfo= _busService.Bus_By_Line_Search(busByLineSearchViewModel);
  
                busByLineSearchResModel.IsSuccess = true;
                busByLineSearchResModel.TotalNum = _busService.Bus_By_Line_Get_ALLNum(busByLineSearchViewModel);
                busByLineSearchResModel.baseViewModel.Message = "根据线路查班车成功";
                busByLineSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据线路查班车成功");
            return Ok(busByLineSearchResModel);
          

        }


      

        /// <summary>
        /// 根据班车查线路
        /// </summary>
        /// <param name="lineByBusSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<LineByBusSearchResModel> Manage_Bus_Line_Search(LineByBusSearchViewModel lineByBusSearchViewModel)
        {
            LineByBusSearchResModel lineByBusSearchResModel = new LineByBusSearchResModel();
            lineByBusSearchResModel.line_Infos = _busService.Line_By_Bus_Search(lineByBusSearchViewModel);
           
                lineByBusSearchResModel.IsSuccess = true;
                lineByBusSearchResModel.TotalNum = _busService.Line_By_Bus_Get_ALLNum(lineByBusSearchViewModel);
                lineByBusSearchResModel.baseViewModel.Message = "根据班车查线路成功";
                lineByBusSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据班车查线路成功");
            return Ok(lineByBusSearchResModel);
           

        }


       
    }
}