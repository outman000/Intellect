using AutoMapper;
using Dto.IRepository.IntellUser;
using Dto.IService.IntellUser;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.RoomViewModel;
using ViewModel.RoomViewModel.MiddleModel;
using ViewModel.RoomViewModel.RequestViewModel;

namespace Dto.Service.IntellUser
{
    public class RoomInformationService : IRoomInformationService
    {
        private readonly IRoomInformationRepository _IRoomInformationRepository;
        private readonly IDataBaseTypeRepository _IDataBaseTypeRepository;
        private readonly IMapper _IMapper;

        public RoomInformationService(IDataBaseTypeRepository dataBaseTypeRepository, IRoomInformationRepository roomInformationRepository, IMapper mapper)
        {
            _IRoomInformationRepository = roomInformationRepository;
            _IDataBaseTypeRepository = dataBaseTypeRepository;
            _IMapper = mapper;

        }

        /// <summary>
        /// 增加会议室
        /// </summary>
        /// <param name="departAddViewModel"></param>
        /// <returns></returns>

        public int Room_Add(RoomInformationAddViewModel roomInformationAddViewModel)
        {
            var meetingroom_information = _IMapper.Map<RoomInformationAddViewModel, MeetingRoom_Information>(roomInformationAddViewModel);
            meetingroom_information.IsDelete = "0";
            meetingroom_information.Status = "0";
            meetingroom_information.CreateDate = DateTime.Now;
            _IRoomInformationRepository.AddByNum(meetingroom_information);
            return _IRoomInformationRepository.SaveChanges();

        }

        /// <summary>
        /// 删除会议室
        /// </summary>
        /// <param name="roomInformationDeleteViewModel"></param>
        /// <returns></returns>
        public List<int> Room_Delete(RoomInformationDeleteViewModel roomInformationDeleteViewModel)
        {
            List<int> DeleteRowsNum = _IRoomInformationRepository
                .DeleteByRoomidList(roomInformationDeleteViewModel.DeleteIdList);

            return DeleteRowsNum;

        }

        /// <summary>
        ///  根据楼-区-会议室查询会议室信息
        /// </summary>
        /// <param name="roomInformationSearchViewModel"></param>
        /// <returns></returns>
        public List<RoomInformationSearchMiddle> Room_Search(RoomInformationSearchViewModel roomInformationSearchViewModel)
        {
            var meetingroom_information = _IRoomInformationRepository.SearchRoomInformationWhere(roomInformationSearchViewModel);

            for (int i = 0; i < meetingroom_information.Count; i++)
            {
                TimeSpan GapTime = new TimeSpan(0, 0, 00);
                var RoomReservation = _IRoomInformationRepository.GetReservationByInformation(meetingroom_information[i].Id.ToString(), roomInformationSearchViewModel.ReservationDate);
                if (RoomReservation.Count > 0)
                {
                    for (int j = 0; j < RoomReservation.Count; j++)
                    {
                        string startdate = RoomReservation[j].Meetingtime.ToString("HH:mm");
                        string endingdate = RoomReservation[j].Endingtime.ToString("HH:mm");
                        meetingroom_information[i].ReservationDate += startdate + "-" + endingdate + "  | ";
                        GapTime += (TimeSpan)(RoomReservation[j].Endingtime - RoomReservation[j].Meetingtime);
                    }
                    TimeSpan ralTime = new TimeSpan(15, 30, 00);

                    if (ralTime > GapTime)
                    {
                        meetingroom_information[i].RoomStatus = "1";//部分预定
                    }
                    if (ralTime <= GapTime)
                    {
                        meetingroom_information[i].RoomStatus = "2";//已经订满
                    }
                }
                else
                {
                    meetingroom_information[i].RoomStatus = "0";//全天空闲
                }

            }
            return meetingroom_information;

        }
        /// <summary>
        ///  根据id查询会议室信息
        /// </summary>
        /// <param name="roomInformationSearchViewModel"></param>
        /// <returns></returns>
        public List<RoomInformationSearchMiddle> RoomById_Search(RoomInformationByIdSearchViewModel roomInformationByIdSearchViewModel)
        {

            List<MeetingRoom_Information> meetingroom_information = _IRoomInformationRepository.SearchInformationByid(roomInformationByIdSearchViewModel.Id);
            var meetingroom_result = _IMapper.Map<List<MeetingRoom_Information>, List<RoomInformationSearchMiddle>>(meetingroom_information);
            List<DataBase_Type> Areasearchfloor = _IDataBaseTypeRepository.SearchFloorByArea(meetingroom_result[0].DataBase_TypeId);
            meetingroom_result[0].FloorName = Areasearchfloor[0].Name;
            meetingroom_result[0].Property = meetingroom_information[0].DataBase_Type.Property;
            meetingroom_result[0].PropertyPhone = meetingroom_information[0].DataBase_Type.PropertyPhone;
            for (int i = 0; i < meetingroom_result.Count; i++)
            {
                TimeSpan GapTime = new TimeSpan(0, 0, 00);
                var RoomReservation = _IRoomInformationRepository.GetReservationByInformation(meetingroom_result[i].Id.ToString(), roomInformationByIdSearchViewModel.ReservationDate);
                if (RoomReservation.Count > 0)
                {
                    for (int j = 0; j < RoomReservation.Count; j++)
                    {
                        string startdate = RoomReservation[j].Meetingtime.ToString("HH:mm");
                        string endingdate = RoomReservation[j].Endingtime.ToString("HH:mm");
                        meetingroom_result[i].ReservationDate += startdate + "-" + endingdate + "  | ";
                        GapTime += (TimeSpan)(RoomReservation[j].Endingtime - RoomReservation[j].Meetingtime);
                    }
                    TimeSpan ralTime = new TimeSpan(15, 30, 00);

                    if (ralTime > GapTime)
                    {
                        meetingroom_result[i].RoomStatus = "1";//部分预定
                    }
                    if (ralTime == GapTime)
                    {
                        meetingroom_result[i].RoomStatus = "2";//已经订满
                    }

                }
                else
                {
                    meetingroom_result[i].RoomStatus = "0";//全天空闲
                }

            }
            return meetingroom_result;
        }
        /// <summary>
        /// id查询会议室数量
        /// </summary>
        /// <param name="roomInformationSearchViewModel"></param>
        /// <returns></returns>
        public int RoomById_SearchNum(RoomInformationByIdSearchViewModel roomInformationByIdSearchViewModel)
        {

            List<MeetingRoom_Information> meetingroom_information = _IRoomInformationRepository.SearchInformationNumById(roomInformationByIdSearchViewModel.Id);
            return meetingroom_information.Count;
        }
        /// <summary>
        /// 查询会议室数量
        /// </summary>
        /// <param name="roomInformationSearchViewModel"></param>
        /// <returns></returns>
        public int Room_SearchNum(RoomInformationSearchViewModel roomInformationSearchViewModel)
        {

            List<MeetingRoom_Information> meetingroom_information = _IRoomInformationRepository.SearchRoomInformationNum(roomInformationSearchViewModel);
            List<MeetingRoom_Information> AreaSearchFloor = new List<MeetingRoom_Information>();
            if ((roomInformationSearchViewModel.AreaAll == "" || roomInformationSearchViewModel.AreaAll == null)
             && (roomInformationSearchViewModel.FloorId != "" && roomInformationSearchViewModel.FloorId != null))
            {
                List<DataBase_Type> floor_searchArea = _IDataBaseTypeRepository.SearchAreaByFloor(roomInformationSearchViewModel.FloorId);
                for (int i = 0; i < floor_searchArea.Count; i++)
                {
                    var dd = meetingroom_information.FindAll(a => a.DataBase_TypeId.ToString() == floor_searchArea[i].Id.ToString());

                    AreaSearchFloor = AreaSearchFloor.Union(dd).ToList();

                }
                return AreaSearchFloor.Count;
            }
            else
            {
                return meetingroom_information.Count;
            }


        }
        /// <summary>
        /// 更改会议室信息
        /// </summary>
        /// <param name="BookUpdateViewModel"></param>
        /// <returns></returns>
        public int Room_Update(RoomInformationUpdateViewModel roomInformationUpdateViewModel)
        {
            var room_information = _IRoomInformationRepository.GetInfoByRoomid(roomInformationUpdateViewModel.Id);
            var room_Information_Result = _IMapper.Map<RoomInformationUpdateViewModel, MeetingRoom_Information>(roomInformationUpdateViewModel, room_information);
            room_Information_Result.UpdateDate = DateTime.Now;
            _IRoomInformationRepository.Update(room_Information_Result);
            return _IRoomInformationRepository.SaveChanges();
        }

        /// <summary>
        ///  楼—区—会议室
        /// </summary>
        /// <param name="roomInformationSearchViewModel"></param>
        /// <returns></returns>
        public List<FloorAreaRoomSearchViewModel> FloorAreaRoom(string id, string code, string departid)
        {
            if (code == "0")
            {
                List<DataBase_Type> Floor = _IDataBaseTypeRepository.SearchFloor();
                var Floor_result = _IMapper.Map<List<DataBase_Type>, List<FloorAreaRoomSearchViewModel>>(Floor);
                for (int i = 0; i < Floor.Count; i++)
                {
                    Floor_result[i].Value = Floor[i].Name;
                }
                return Floor_result;
            }
            else if (code == "1")
            {
                List<DataBase_Type> floor_searchArea = _IDataBaseTypeRepository.SearchAreaByFloor(id);
                var Area_result = _IMapper.Map<List<DataBase_Type>, List<FloorAreaRoomSearchViewModel>>(floor_searchArea);
                List<FloorAreaRoomSearchViewModel> depart = new List<FloorAreaRoomSearchViewModel>();

                for (int i = 0; i < floor_searchArea.Count; i++)
                {

                    Area_result[i].Value = floor_searchArea[i].Name;

                    if (floor_searchArea[i].Purview == "all")
                    {
                        depart.Add(Area_result[i]);
                    }
                    else if (floor_searchArea[i].Purview.Contains("(" + departid + ")"))
                    {
                        depart.Add(Area_result[i]);
                    }

                }
                if (departid == "" || departid == null)
                {
                    return Area_result;

                }

                return depart;
            }
            else
            {
                List<MeetingRoom_Information> Area_searchRoom = _IRoomInformationRepository.SearchRoomByArea(id);
                var meetingroom_result = _IMapper.Map<List<MeetingRoom_Information>, List<FloorAreaRoomSearchViewModel>>(Area_searchRoom);
                for (int i = 0; i < Area_searchRoom.Count; i++)
                {
                    meetingroom_result[i].Value = Area_searchRoom[i].RoomNum;
                }
                return meetingroom_result;
            }

        }

        /// <summary>
        ///  根据会议室条件查询会议室信息
        /// </summary>
        /// <param name="roomInformationSearchViewModel"></param>
        /// <returns></returns>
        public List<RoomInformationSearchMiddle> SearchRoominfoByinformation(RoomInformationByInfoSearchViewModel roomInformationByInfoSearchViewModel)
        {
            List<RoomInformationSearchMiddle> meetingroom_information = _IRoomInformationRepository.SearchRoomInfoByinfo(roomInformationByInfoSearchViewModel);

            return meetingroom_information;
        }
        /// <summary>
        /// 根据会议室条件查询会议室信息数量
        /// </summary>
        /// <param name="roomInformationSearchViewModel"></param>
        /// <returns></returns>
        public int SearchRoominfoByinformationNum(RoomInformationByInfoSearchViewModel roomInformationByInfoSearchViewModel)
        {
            List<RoomInformationSearchMiddle> meetingroom_information = _IRoomInformationRepository.SearchRoominfoByinfoNum(roomInformationByInfoSearchViewModel);

            return meetingroom_information.Count;
        }
    }
}
