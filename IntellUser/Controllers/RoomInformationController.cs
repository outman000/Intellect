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
using ViewModel.RoomViewModel.MiddleModel;
using ViewModel.RoomViewModel.RequestViewModel;
using ViewModel.RoomViewModel.ResponseModel;

namespace IntellUser.Controllers
{
    [Route("UserManageApi/[controller]/[action]")]
    [ApiController]
    public class RoomInformationController : ControllerBase
    {
        private readonly IRoomInformationService _RoomInformationService;
        private readonly ILogger _ILogger;

        public RoomInformationController(IRoomInformationService roomInformationService, ILogger logger)
        {
            _RoomInformationService = roomInformationService;
            _ILogger = logger;
        }

        /// <summary>
        /// 增添会议室信息
        /// </summary>
        /// <param name="roomInformationAddViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult<RoomInformationAddResModel> Manage_Room_add(RoomInformationAddViewModel roomInformationAddViewModel)
        {
            int Room_Add_Count;
            RoomInformationAddResModel roomInformationAddResModel = new RoomInformationAddResModel();
            Room_Add_Count = _RoomInformationService.Room_Add(roomInformationAddViewModel);
            if (Room_Add_Count > 0)
            {
                roomInformationAddResModel.IsSuccess = true;
                roomInformationAddResModel.AddCount = Room_Add_Count;
                roomInformationAddResModel.baseViewModel.Message = "添加成功";
                roomInformationAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添会议室信息成功");
                return Ok(roomInformationAddResModel);
            }
            else
            {
                roomInformationAddResModel.IsSuccess = false;
                roomInformationAddResModel.AddCount = 0;
                roomInformationAddResModel.baseViewModel.Message = "添加失败";
                roomInformationAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添会议室信息失败");
                return Ok(roomInformationAddResModel);
            }
        }
        /// <summary>
        /// 根据会议室条件查询会议室信息
        /// </summary>
        /// <param name="roomInformationByInfoSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<MeetingRoom_Information> Manage_RoomInfoSearchAll(RoomInformationByInfoSearchViewModel roomInformationByInfoSearchViewModel)
        {
            RoomInformationSearchResModel roomInformationSearchResModel = new RoomInformationSearchResModel();
            var Result = _RoomInformationService.SearchRoominfoByinformation(roomInformationByInfoSearchViewModel);
            int count = _RoomInformationService.SearchRoominfoByinformationNum(roomInformationByInfoSearchViewModel);

            roomInformationSearchResModel.Room_info = Result;
            roomInformationSearchResModel.TotalNum = count;
            roomInformationSearchResModel.isSuccess = true;
            roomInformationSearchResModel.baseViewModel.Message = "查询成功";
            roomInformationSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据会议室信息，查询成功");
            return Ok(roomInformationSearchResModel);

        }
        /// <summary>
        /// 根据楼-区-会议室查询会议室信息
        /// </summary>
        /// <param name="roomInformationSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<MeetingRoom_Information> Manage_RoomSearchAll(RoomInformationSearchViewModel roomInformationSearchViewModel)
        {
            RoomInformationSearchResModel roomInformationSearchResModel = new RoomInformationSearchResModel();
            var Result = _RoomInformationService.Room_Search(roomInformationSearchViewModel);
            int count = _RoomInformationService.Room_SearchNum(roomInformationSearchViewModel);

            roomInformationSearchResModel.Room_info = Result;
            roomInformationSearchResModel.TotalNum = count;
            roomInformationSearchResModel.isSuccess = true;
            roomInformationSearchResModel.baseViewModel.Message = "查询成功";
            roomInformationSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据会议室信息，查询成功");
            return Ok(roomInformationSearchResModel);

        }
        /// <summary>
        /// 根据id查询会议室信息
        /// </summary>
        /// <param name="roomInformationByIdSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<MeetingRoom_Information> Manage_RoomSearchById(RoomInformationByIdSearchViewModel roomInformationByIdSearchViewModel)
        {
            RoomInformationSearchResModel roomInformationSearchResModel = new RoomInformationSearchResModel();
            var Result = _RoomInformationService.RoomById_Search(roomInformationByIdSearchViewModel);
            int count = _RoomInformationService.RoomById_SearchNum(roomInformationByIdSearchViewModel);

            roomInformationSearchResModel.Room_info = Result;
            roomInformationSearchResModel.TotalNum = count;
            roomInformationSearchResModel.isSuccess = true;
            roomInformationSearchResModel.baseViewModel.Message = "查询成功";
            roomInformationSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据会议室信息，查询成功");
            return Ok(roomInformationSearchResModel);

        }
        /// <summary>
        /// 楼—区—会议室
        /// </summary>
        /// <param name="floorAreaRoomSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<FloorAreaRoomSearchViewModel> SearchFloorAreaRoom(FloorAreaRoomSearchViewModel floorAreaRoomSearchViewModel)
        {
            FloorAreaRoomSearchResModel floorarearoomSearchResModel = new FloorAreaRoomSearchResModel();
            var Result = _RoomInformationService.FloorAreaRoom(floorAreaRoomSearchViewModel.Id, floorAreaRoomSearchViewModel.Value, floorAreaRoomSearchViewModel.departid);
            int count = _RoomInformationService.FloorAreaRoom(floorAreaRoomSearchViewModel.Id, floorAreaRoomSearchViewModel.Value, floorAreaRoomSearchViewModel.departid).Count;

            floorarearoomSearchResModel.Room_info = Result;
            floorarearoomSearchResModel.TotalNum = count;
            floorarearoomSearchResModel.isSuccess = true;
            floorarearoomSearchResModel.baseViewModel.Message = "查询成功";
            floorarearoomSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据会议室信息，查询成功");
            return Ok(floorarearoomSearchResModel);

        }
        /// <summary>
        /// 更新会议室信息
        /// </summary>
        /// <param name="roomInformationUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<RoomInformationUpdateResModel> Manage_Room_Update(RoomInformationUpdateViewModel roomInformationUpdateViewModel)
        {
            RoomInformationUpdateResModel roomInformationUpdateResModel = new RoomInformationUpdateResModel();
            int UpdateRowNum = _RoomInformationService.Room_Update(roomInformationUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                roomInformationUpdateResModel.IsSuccess = true;
                roomInformationUpdateResModel.AddCount = UpdateRowNum;
                roomInformationUpdateResModel.baseViewModel.Message = "更新成功";
                roomInformationUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更新会议室信息，更新成功");
                return Ok(roomInformationUpdateResModel);
            }
            else
            {
                roomInformationUpdateResModel.IsSuccess = false;
                roomInformationUpdateResModel.AddCount = 0;
                roomInformationUpdateResModel.baseViewModel.Message = "更新失败";
                roomInformationUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("更新会议室信息，更新失败");
                return Ok(roomInformationUpdateResModel);
            }
        }
        /// <summary>
        /// 删除会议室
        /// </summary>
        /// <param name="roomInformationDeleteViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<RoomInformationDeleteResModel> Manage_Room_Delete(RoomInformationDeleteViewModel roomInformationDeleteViewModel)
        {
            RoomInformationDeleteResModel roomInformationDeleteResModel = new RoomInformationDeleteResModel();
            List<int> DeleteResult = _RoomInformationService.Room_Delete(roomInformationDeleteViewModel);

            if (DeleteResult[1] == roomInformationDeleteViewModel.DeleteIdList.Count)
            {
                roomInformationDeleteResModel.DeleteCount = DeleteResult[1];
                roomInformationDeleteResModel.IsSuccess = true;
                roomInformationDeleteResModel.baseViewModel.Message = "删除成功";
                roomInformationDeleteResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("删除会议室成功");
                return Ok(roomInformationDeleteResModel);
            }
            else
            {
                roomInformationDeleteResModel.DeleteCount = DeleteResult[1];
                roomInformationDeleteResModel.DeleteFalseCount = DeleteResult[0];
                roomInformationDeleteResModel.IsSuccess = false;
                roomInformationDeleteResModel.baseViewModel.Message = "删除会议室成功" + DeleteResult[1] + "条数据；" + DeleteResult[0] + "条数据因预定未能删除";
                roomInformationDeleteResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("删除会议室成功" + DeleteResult[1] + "条数据；" + DeleteResult[0] + "条数据因预定未能删除");
                return Ok(roomInformationDeleteResModel);
            }
        }
    }
}
