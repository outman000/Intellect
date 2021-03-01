using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.IntellUser;
using Dtol.dtol;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ViewModel.RoomViewModel;
using ViewModel.RoomViewModel.RequestViewModel;
using ViewModel.RoomViewModel.ResponseModel;

namespace IntellUser.Controllers
{
    [Route("UserManageApi/[controller]/[action]")]
    [ApiController]
    public class RoomReservationController : ControllerBase
    {
        private readonly IRoomReservationService _RoomReservationService;
        private readonly ILogger _ILogger;

        public RoomReservationController(IRoomReservationService roomReservationService, ILogger logger)
        {
            _RoomReservationService = roomReservationService;
            _ILogger = logger;
        }

        /// <summary>
        /// 增添会议室预定信息
        /// </summary>
        /// <param name="roomReservationAddViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult<RoomReservationAddResModel> Manage_RoomReservation_add(RoomReservationAddViewModel roomReservationAddViewModel)
        {
            int Room_Add_Count;
            RoomReservationAddResModel roomreservationAddResModel = new RoomReservationAddResModel();
            Room_Add_Count = _RoomReservationService.RoomReservation_Add(roomReservationAddViewModel);
            if (Room_Add_Count == 1)
            {
                roomreservationAddResModel.IsSuccess = true;
                roomreservationAddResModel.AddCount = Room_Add_Count;
                roomreservationAddResModel.baseViewModel.Message = "添加成功";
                roomreservationAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添会议室信息成功");
                return Ok(roomreservationAddResModel);
            }
            else if (Room_Add_Count == 2)
            {
                roomreservationAddResModel.IsSuccess = false;
                roomreservationAddResModel.AddCount = 0;
                roomreservationAddResModel.baseViewModel.Message = "与已预订时间冲突,添加失败";
                roomreservationAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添会议室信息失败");
                return Ok(Room_Add_Count);
            }
            else if (Room_Add_Count == 3)
            {
                roomreservationAddResModel.IsSuccess = false;
                roomreservationAddResModel.AddCount = 0;
                roomreservationAddResModel.baseViewModel.Message = "未在有效时间段内,添加失败";
                roomreservationAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添会议室信息失败");
                return Ok(Room_Add_Count);
            }
            else if (Room_Add_Count == 4)
            {
                roomreservationAddResModel.IsSuccess = false;
                roomreservationAddResModel.AddCount = 0;
                roomreservationAddResModel.baseViewModel.Message = "预定时间应大于等于三十分钟,添加失败";
                roomreservationAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添会议室信息失败");
                return Ok(Room_Add_Count);
            }
            else
            {
                roomreservationAddResModel.IsSuccess = false;
                roomreservationAddResModel.AddCount = 0;
                roomreservationAddResModel.baseViewModel.Message = "未知原因,添加失败";
                roomreservationAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添会议室信息失败");
                return Ok(roomreservationAddResModel);
            }

        }

        /// <summary>
        /// 取消会议室预定信息
        /// </summary>
        /// <param name="roomReservationUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<RoomReservationUpdateResModel> Manage_Room_Cancel(RoomReservationUpdateViewModel roomReservationUpdateViewModel)
        {
            RoomReservationUpdateResModel roomreservationUpdateResModel = new RoomReservationUpdateResModel();
            int DeleteResult = _RoomReservationService.RoomReservation_Update(roomReservationUpdateViewModel);

            if (DeleteResult == 1)
            {
                roomreservationUpdateResModel.UpdateCount = 1;
                roomreservationUpdateResModel.IsSuccess = true;
                roomreservationUpdateResModel.baseViewModel.Message = "取消会议室预定信息成功";
                roomreservationUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("取消会议室预定信息成功");
                return Ok(roomreservationUpdateResModel);
            }
            else
            {
                roomreservationUpdateResModel.UpdateCount = 0;
                roomreservationUpdateResModel.IsSuccess = false;
                roomreservationUpdateResModel.baseViewModel.Message = "取消会议室预定信息失败";
                roomreservationUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("取消会议室预定信息失败");
                return Ok(roomreservationUpdateResModel);
            }
        }

        /// <summary>
        /// 结束会议室预定信息
        /// </summary>
        /// <param name="roomReservationUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<RoomReservationUpdateResModel> Manage_Room_End(RoomReservationUpdateViewModel roomReservationUpdateViewModel)
        {
            RoomReservationUpdateResModel roomreservationUpdateResModel = new RoomReservationUpdateResModel();
            int DeleteResult = _RoomReservationService.RoomReservationEnd_Update(roomReservationUpdateViewModel);

            if (DeleteResult == 1)
            {
                roomreservationUpdateResModel.UpdateCount = 1;
                roomreservationUpdateResModel.IsSuccess = true;
                roomreservationUpdateResModel.baseViewModel.Message = "结束会议室预定信息成功";
                roomreservationUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("结束会议室预定信息成功");
                return Ok(roomreservationUpdateResModel);
            }
            else
            {
                roomreservationUpdateResModel.UpdateCount = 0;
                roomreservationUpdateResModel.IsSuccess = false;
                roomreservationUpdateResModel.baseViewModel.Message = "结束会议室预定信息失败";
                roomreservationUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("结束会议室预定信息失败");
                return Ok(roomreservationUpdateResModel);
            }
        }

        /// <summary>
        /// 确认会议室预定信息
        /// </summary>
        /// <param name="roomReservationUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<RoomReservationUpdateResModel> Manage_Room_Confirm(RoomReservationUpdateViewModel roomReservationUpdateViewModel)
        {
            RoomReservationUpdateResModel roomreservationUpdateResModel = new RoomReservationUpdateResModel();
            int DeleteResult = _RoomReservationService.RoomReservationReal_Update(roomReservationUpdateViewModel);

            if (DeleteResult == 1)
            {
                roomreservationUpdateResModel.UpdateCount = 1;
                roomreservationUpdateResModel.IsSuccess = true;
                roomreservationUpdateResModel.baseViewModel.Message = "确认使用会议室成功";
                roomreservationUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("确认使用会议室成功");
                return Ok(roomreservationUpdateResModel);
            }
            else
            {
                roomreservationUpdateResModel.UpdateCount = 0;
                roomreservationUpdateResModel.IsSuccess = false;
                roomreservationUpdateResModel.baseViewModel.Message = "确认使用会议室失败";
                roomreservationUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("确认使用会议室失败");
                return Ok(roomreservationUpdateResModel);
            }
        }
        /// <summary>
        /// 根据会议室预定信息查询
        /// </summary>
        /// <param name="roomReservationSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<MeetingRoom_Reservation> Manage_RoomSearchAll(RoomReservationSearchViewModel roomReservationSearchViewModel)
        {
            RoomReservationSearchResModel roomreservationSearchResModel = new RoomReservationSearchResModel();
            var Result = _RoomReservationService.RoomReservation_Search(roomReservationSearchViewModel);
            int count = _RoomReservationService.RoomReservation_SearchNum(roomReservationSearchViewModel);

            roomreservationSearchResModel.Room_info = Result;
            roomreservationSearchResModel.TotalNum = count;
            roomreservationSearchResModel.isSuccess = true;
            roomreservationSearchResModel.baseViewModel.Message = "查询成功";
            roomreservationSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据会议室信息，查询成功");
            return Ok(roomreservationSearchResModel);

        }

        /// <summary>
        /// 根据会议室预定信息Id查询
        /// </summary>
        /// <param name="roomReservationIdSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<MeetingRoom_Reservation> Manage_RoomSearchById(RoomReservationIdSearchViewModel roomReservationIdSearchViewModel)
        {
            RoomReservationSearchResModel roomreservationSearchResModel = new RoomReservationSearchResModel();
            var Result = _RoomReservationService.RoomReservation_SearchByid(roomReservationIdSearchViewModel.Id);
            int count = _RoomReservationService.RoomReservation_SearchByid(roomReservationIdSearchViewModel.Id).Count;

            roomreservationSearchResModel.Room_info = Result;
            roomreservationSearchResModel.TotalNum = count;
            roomreservationSearchResModel.isSuccess = true;
            roomreservationSearchResModel.baseViewModel.Message = "查询成功";
            roomreservationSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据会议室信息，查询成功");
            return Ok(roomreservationSearchResModel);

        }

        /// <summary>
        /// 扫码后查看详情
        /// </summary>
        /// <param name="roomReservationIdSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<MeetingRoom_Reservation> Manage_RoomScanCode(RoomReservationIdSearchViewModel roomReservationIdSearchViewModel)
        {
            RoomReservationSearchResModel roomreservationSearchResModel = new RoomReservationSearchResModel();
            var Result = _RoomReservationService.ScanCode_Search(roomReservationIdSearchViewModel.Id);
            int count = _RoomReservationService.ScanCode_Search(roomReservationIdSearchViewModel.Id).Count;

            roomreservationSearchResModel.Room_info = Result;
            roomreservationSearchResModel.TotalNum = count;
            roomreservationSearchResModel.isSuccess = true;
            roomreservationSearchResModel.baseViewModel.Message = "查询成功";
            roomreservationSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("扫码后查看详情，查询成功");
            return Ok(roomreservationSearchResModel);

        }
        /// <summary>
        /// 会议室预定信息大屏显示
        /// </summary>
        /// <param name="reservationMaxSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<MeetingRoom_Reservation> Manage_ReservationMax(ReservationMaxSearchViewModel reservationMaxSearchViewModel)
        {
            RoomReservationSearchResModel roomreservationSearchResModel = new RoomReservationSearchResModel();
            var Result = _RoomReservationService.ReservationMax_Search(reservationMaxSearchViewModel);
            int count = _RoomReservationService.ReservationMax_SearchNum(reservationMaxSearchViewModel);

            roomreservationSearchResModel.Room_info = Result;
            roomreservationSearchResModel.TotalNum = count;
            roomreservationSearchResModel.isSuccess = true;
            roomreservationSearchResModel.baseViewModel.Message = "查询成功";
            roomreservationSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据会议室信息，查询成功");
            return Ok(roomreservationSearchResModel);

        }
    }
}
