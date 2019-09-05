﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Dto.IService.IntellRegularBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;
using ViewModel.BusViewModel.RequestViewModel.StationInfoViewModel;
using ViewModel.BusViewModel.ResponseModel.LineInforResModel;
using ViewModel.BusViewModel.ResponseModel.StationInfoResModel;

namespace IntellRegularBus.Controllers
{
    [Route("BusManageApi/[controller]/[action]")]
    [ApiController]
    public class BusStationController : ControllerBase
    {
        private readonly IStationService _stationService;
        private readonly ILogger _ILogger;
        public BusStationController(IStationService stationService, ILogger logger)
        {
            _stationService = stationService;
            _ILogger = logger;
        }

        /// <summary>
        /// 查询站点信息
        /// </summary>
        /// <param name="stationSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<StationSearchResModel> Manage_Station_Search(StationSearchViewModel stationSearchViewModel)
        {
            StationSearchResModel stationSearchResModel = new StationSearchResModel();
            var StationSearchResult = _stationService.Station_Search(stationSearchViewModel);
            var TotalNum = _stationService.Station_Get_ALLNum(stationSearchViewModel);
            stationSearchResModel.station_Infos = StationSearchResult;
            stationSearchResModel.isSuccess = true;
            stationSearchResModel.baseViewModel.Message = "查询成功";
            stationSearchResModel.baseViewModel.ResponseCode = 200;
            stationSearchResModel.TotalNum = TotalNum;
            _ILogger.Information("查询站点信息成功");
            return Ok(stationSearchResModel);

        }
        /// <summary>
        /// 更新站点信息
        /// </summary>
        /// <param name="stationeUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult<StationUpdateResModel> Manage_Station_Update(StationUpdateViewModel stationeUpdateViewModel)
        {
            StationUpdateResModel stationUpdateResModel = new StationUpdateResModel();
            int UpdateRowNum = _stationService.Station_Update(stationeUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                stationUpdateResModel.IsSuccess = true;
                stationUpdateResModel.AddCount = UpdateRowNum;
                stationUpdateResModel.baseViewModel.Message = "更新成功";
                stationUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更新站点信息成功");
                return Ok(stationUpdateResModel);
            }
            else
            {
                stationUpdateResModel.IsSuccess = false;
                stationUpdateResModel.AddCount = 0;
                stationUpdateResModel.baseViewModel.Message = "更新失败";
                stationUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("更新站点信息失败");
                return BadRequest(stationUpdateResModel);
            }
        }

        /// <summary>
        /// 添加站点
        /// </summary>
        /// <param name="stationAddViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]
        public ActionResult<StationAddResModel> Manage_Station_Add(StationAddViewModel stationAddViewModel)
        {
            int Statio_Add_Count;
            Statio_Add_Count = _stationService.Station_Add(stationAddViewModel);
            StationAddResModel stationAddResModel = new StationAddResModel();
            if (Statio_Add_Count > 0)
            {
                stationAddResModel.IsSuccess = true;
                stationAddResModel.AddCount = Statio_Add_Count;
                stationAddResModel.baseViewModel.Message = "添加成功";
                stationAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("添加站点成功");
                return Ok(stationAddResModel);
            }
            else
            {
                stationAddResModel.IsSuccess = false;
                stationAddResModel.AddCount = 0;
                stationAddResModel.baseViewModel.Message = "添加失败";
                stationAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("添加站点失败");
                return BadRequest(stationAddResModel);
            }
        }
        /// <summary>
        /// 验证站点id是否重复
        /// </summary>
        /// <param name="busValideRepeat"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult<BusValideResRepeat> Manage_Station_ValideRepeat(BusValideRepeat busValideRepeat)
        {
            BusValideResRepeat busValideResRepeat = new BusValideResRepeat();
            bool ValideResutlt = _stationService.Station_Single(busValideRepeat);
            busValideResRepeat.IsSuccess = ValideResutlt;
            if (ValideResutlt)
            {
                busValideResRepeat.IsSuccess = true;
                busValideResRepeat.baseViewModel.Message = "此id可以使用";
                busValideResRepeat.baseViewModel.ResponseCode = 200;
                _ILogger.Information("验证站点id是否重复，此id可以使用");
                return Ok(busValideResRepeat);
            }
            else
            {
                busValideResRepeat.IsSuccess = false;
                busValideResRepeat.baseViewModel.Message = "此id已经存在，请更换";
                busValideResRepeat.baseViewModel.ResponseCode = 400;
                _ILogger.Information("验证站点id是否重复，此id已经存在，请更换");
                return BadRequest(busValideResRepeat);
            }
        }

        /// <summary>
        /// 删除站点
        /// </summary>
        /// <param name="stationDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<StationDelResModel> Manage_Station_Del(StationDelViewModel stationDelViewModel)
        {
            StationDelResModel stationDelResModel = new StationDelResModel();
            int DeleteResult = _stationService.Station_Delete(stationDelViewModel);

            if (DeleteResult > 0)
            {
                stationDelResModel.DelCount = DeleteResult;
                stationDelResModel.IsSuccess = true;
                stationDelResModel.baseViewModel.Message = "删除成功";
                stationDelResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("删除站点成功");
                return Ok(stationDelResModel);
            }
            else
            {
                stationDelResModel.DelCount = -1;
                stationDelResModel.IsSuccess = false;
                stationDelResModel.baseViewModel.Message = "删除失败";
                stationDelResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("删除站点失败");
                return BadRequest(stationDelResModel);
            }
        }
        /// <summary>
        /// 根据线路添加站点 / 根据线路取消站点
        /// </summary>
        /// <param name="stationByLineAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<StationByLineAddResMode> Manage_Line_Station(StationByLineAddViewModel stationByLineAddViewModel)
        {
            StationByLineAddResMode stationByLineAddResMode = new StationByLineAddResMode();
            int UpdateRowNum = _stationService.Line_To_Station_Add(stationByLineAddViewModel);
            if (UpdateRowNum > 0)
            {
                stationByLineAddResMode.IsSuccess = true;
                stationByLineAddResMode.AddCount = UpdateRowNum;
                stationByLineAddResMode.baseViewModel.Message = "根据线路添加/取消站点成功";
                stationByLineAddResMode.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据线路添加/取消站点成功");
                return Ok(stationByLineAddResMode);
            }
            else
            {
                stationByLineAddResMode.IsSuccess = false;
                stationByLineAddResMode.AddCount = 0;
                stationByLineAddResMode.baseViewModel.Message = "根据线路添加/取消站点失败";
                stationByLineAddResMode.baseViewModel.ResponseCode = 400;
                _ILogger.Information("根据线路添加/取消站点失败");
                return BadRequest(stationByLineAddResMode);

            }

        }
        /// <summary>
        /// 根据站点添加线路 / 根据站点取消线路
        /// </summary>
        /// <param name="lineByStationAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<LineByStationAddResModel> Manage_Station_Line(LineByStationAddViewModel lineByStationAddViewModel)
        {
            LineByStationAddResModel lineByStationAddResModel = new LineByStationAddResModel();
            int UpdateRowNum = _stationService.Station_To_Line_Add(lineByStationAddViewModel);
            if (UpdateRowNum > 0)
            {
                lineByStationAddResModel.IsSuccess = true;
                lineByStationAddResModel.AddCount = UpdateRowNum;
                lineByStationAddResModel.baseViewModel.Message = "根据站点添加/取消线路成功";
                lineByStationAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据站点添加/取消线路成功");
                return Ok(lineByStationAddResModel);
            }
            else
            {
                lineByStationAddResModel.IsSuccess = false;
                lineByStationAddResModel.AddCount = 0;
                lineByStationAddResModel.baseViewModel.Message = "根据站点添加/取消线路失败";
                lineByStationAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("根据站点添加/取消线路失败");
                return BadRequest(lineByStationAddResModel);

            }

        }

        /// <summary>
        /// 根据站点查线路
        /// </summary>
        /// <param name="lineByStationViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<LineByStationSearchResModel> Manage_Bus_Line_Search(LineByStationViewModel lineByStationViewModel)
        {
            LineByStationSearchResModel lineByStationSearchResModel = new LineByStationSearchResModel();
            lineByStationSearchResModel.line_Infos = _stationService.Line_By_Station_Search(lineByStationViewModel);
            
                lineByStationSearchResModel.IsSuccess = true;
                lineByStationSearchResModel.TotalNum = _stationService.Line_By_Station_Get_ALLNum(lineByStationViewModel);
                lineByStationSearchResModel.baseViewModel.Message = "根据站点查线路成功";
                lineByStationSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据站点查线路成功");
            return Ok(lineByStationSearchResModel);
          

        }

        /// <summary>
        /// 根据线路查站点 /  根据班车查站点
        /// </summary>
        /// <param name="stationByLineSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<StationByLineSearchResModel> Manage_Line_Bus_Search(StationByLineSearchViewModel stationByLineSearchViewModel)
        {
            StationByLineSearchResModel stationByLineSearchResModel = new StationByLineSearchResModel();
            stationByLineSearchResModel.busStation = _stationService.Bus_By_Line_Search(stationByLineSearchViewModel);
           
                stationByLineSearchResModel.IsSuccess = true;
                stationByLineSearchResModel.TotalNum = _stationService.Bus_By_Line_Get_ALLNum(stationByLineSearchViewModel);
                stationByLineSearchResModel.baseViewModel.Message = "根据线路查站点成功";
                stationByLineSearchResModel.baseViewModel.ResponseCode = 200;
              _ILogger.Information("根据线路查站点成功");
            return Ok(stationByLineSearchResModel);
          

        }

       
    }
}