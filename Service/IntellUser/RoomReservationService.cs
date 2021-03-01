using AutoMapper;
using Dto.IRepository.IntellUser;
using Dto.IService.IntellUser;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.RoomViewModel.MiddleModel;
using ViewModel.RoomViewModel.RequestViewModel;

namespace Dto.Service.IntellUser
{
    public class RoomReservationService : IRoomReservationService
    {
        private readonly IRoomReservationRepository _IRoomReservationRepository;
        private readonly IMapper _IMapper;

        public RoomReservationService(IRoomReservationRepository roomReservationRepository, IMapper mapper)
        {
            _IRoomReservationRepository = roomReservationRepository;
            _IMapper = mapper;

        }

        /// <summary>
        /// 增加会议室预定信息
        /// </summary>
        /// <param name="roomReservationAddViewModel"></param>
        /// <returns></returns>

        public int RoomReservation_Add(RoomReservationAddViewModel roomReservationAddViewModel)
        {

            DateTime Meetingtime = roomReservationAddViewModel.Meetingtime;
            DateTime Endingtime = roomReservationAddViewModel.Endingtime;
            DateTime time2 = Convert.ToDateTime(roomReservationAddViewModel.Meetingtime.ToShortDateString() + " " + "13:30");
            DateTime time1 = Convert.ToDateTime(roomReservationAddViewModel.Meetingtime.ToShortDateString() + " " + "8:30");
            DateTime time3 = Convert.ToDateTime(roomReservationAddViewModel.Meetingtime.ToShortDateString() + " " + "23:59");
            TimeSpan GapTime = new TimeSpan(0, 30, 00);
            var meetingroom_reservation = _IMapper.Map<RoomReservationAddViewModel, MeetingRoom_Reservation>(roomReservationAddViewModel);
            if (Meetingtime < Endingtime && (Endingtime - Meetingtime >= GapTime))
            {


                if ((Endingtime <= time2 && time1 <= Meetingtime) || (Endingtime <= time3 && Meetingtime >= time2))
                {

                    List<MeetingRoom_Reservation> Reservation_time = _IRoomReservationRepository.SearchRoomReservationByid(roomReservationAddViewModel.MeetingRoom_InformationId);
                    for (int i = 0; i < Reservation_time.Count; i++)
                    {

                        if (roomReservationAddViewModel.Endingtime <= Reservation_time[i].Meetingtime || roomReservationAddViewModel.Meetingtime >= Reservation_time[i].Endingtime)
                        {
                        }
                        else
                        {
                            //meetingroom_reservation.Status = "2";
                            return 2;//与已预订时间冲突

                        }
                    }
                    meetingroom_reservation.IsDelete = "0";
                    meetingroom_reservation.Status = "0";
                    meetingroom_reservation.RoomStatus = "1";
                    meetingroom_reservation.CreateDate = DateTime.Now;
                    _IRoomReservationRepository.Add(meetingroom_reservation);
                    return _IRoomReservationRepository.SaveChanges();
                }
                else
                {
                    //meetingroom_reservation.Status = "1";
                    return 3;//未在有效时间段内
                }
            }
            else
            {
                return 4;//申请时间应大于三十分钟
            }
        }

        /// <summary>
        /// 取消会议室预定信息
        /// </summary>
        /// <param name="roomReservationDeleteViewModel"></param>
        /// <returns></returns>
        public int RoomReservation_Update(RoomReservationUpdateViewModel roomReservationUpdateViewModel)
        {
            List<MeetingRoom_Reservation> RowsNum = _IRoomReservationRepository
                .SearchReservationByid(roomReservationUpdateViewModel.Id);
            if (RowsNum.Count > 0)
            {
                RowsNum[0].RoomStatus = "2";
                RowsNum[0].Status = "1";
                RowsNum[0].UpdateDate = DateTime.Now;
                RowsNum[0].UpdateUser = roomReservationUpdateViewModel.UserId;
                _IRoomReservationRepository.Update(RowsNum[0]);
            }
            return _IRoomReservationRepository.SaveChanges();

        }
        /// <summary>
        /// 结束会议室预定信息
        /// </summary>
        /// <param name="roomReservationDeleteViewModel"></param>
        /// <returns></returns>
        public int RoomReservationEnd_Update(RoomReservationUpdateViewModel roomReservationUpdateViewModel)
        {
            List<MeetingRoom_Reservation> RowsNum = _IRoomReservationRepository
                .SearchReservationByid(roomReservationUpdateViewModel.Id);
            if (RowsNum.Count > 0)
            {
                RowsNum[0].RoomStatus = "4";
                RowsNum[0].Status = "1";
                RowsNum[0].UpdateDate = DateTime.Now;
                RowsNum[0].UpdateUser = roomReservationUpdateViewModel.UserId;
                _IRoomReservationRepository.Update(RowsNum[0]);
            }
            return _IRoomReservationRepository.SaveChanges();

        }
        /// <summary>
        ///  查询会议室预定信息
        /// </summary>
        /// <param name="roomReservationSearchViewModel"></param>
        /// <returns></returns>
        public List<RoomReservationSearchMiddle> RoomReservation_Search(RoomReservationSearchViewModel roomReservationSearchViewModel)
        {
            List<MeetingRoom_Reservation> Reservation_Search = new List<MeetingRoom_Reservation>();
            List<MeetingRoom_Reservation> meetingroom_reservation = _IRoomReservationRepository.SearchRoomReservationWhere(roomReservationSearchViewModel);
            for (int i = 0; i < meetingroom_reservation.Count; i++)
            {
                if (!(meetingroom_reservation[i].Endingtime < roomReservationSearchViewModel.Meetingtime ||
                    meetingroom_reservation[i].Meetingtime > roomReservationSearchViewModel.Endingtime))
                {
                    Reservation_Search.Add(meetingroom_reservation[i]);
                }
            }

            var meetingroom_result = _IMapper.Map<List<MeetingRoom_Reservation>, List<RoomReservationSearchMiddle>>(Reservation_Search);

            return meetingroom_result;
        }
        /// <summary>
        /// 查询会议室预定信息数量
        /// </summary>
        /// <param name="roomReservationSearchViewModel"></param>
        /// <returns></returns>
        public int RoomReservation_SearchNum(RoomReservationSearchViewModel roomReservationSearchViewModel)
        {

            List<MeetingRoom_Reservation> Reservation_Search = new List<MeetingRoom_Reservation>();
            List<MeetingRoom_Reservation> meetingroom_reservation = _IRoomReservationRepository.SearchRoomReservationNum(roomReservationSearchViewModel);
            for (int i = 0; i < meetingroom_reservation.Count; i++)
            {
                if (!(meetingroom_reservation[i].Endingtime < roomReservationSearchViewModel.Meetingtime ||
                    meetingroom_reservation[i].Meetingtime > roomReservationSearchViewModel.Endingtime))
                {
                    Reservation_Search.Add(meetingroom_reservation[i]);
                }
            }

            var meetingroom_result = _IMapper.Map<List<MeetingRoom_Reservation>, List<RoomReservationSearchMiddle>>(Reservation_Search);

            return meetingroom_result.Count;
        }
        /// <summary>
        /// 根据会议室预定id查询会议室预定信息
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        public List<RoomReservationSearchMiddle> RoomReservation_SearchByid(string id)
        {
            List<MeetingRoom_Reservation> meetingroom_reservation = _IRoomReservationRepository.SearchReservationByid(id);
            var meetingroom_result = _IMapper.Map<List<MeetingRoom_Reservation>, List<RoomReservationSearchMiddle>>(meetingroom_reservation);
            meetingroom_result[0].Property = meetingroom_reservation[0].MeetingRoom_Information.DataBase_Type.Property;
            meetingroom_result[0].PropertyPhone = meetingroom_reservation[0].MeetingRoom_Information.DataBase_Type.PropertyPhone;
            return meetingroom_result;
        }
        /// <summary>
        /// 确认会议室预定信息
        /// </summary>
        /// <param name="roomReservationDeleteViewModel"></param>
        /// <returns></returns>
        public int RoomReservationReal_Update(RoomReservationUpdateViewModel roomReservationUpdateViewModel)
        {
            List<MeetingRoom_Reservation> RowsNum = _IRoomReservationRepository
                .SearchReservationByid(roomReservationUpdateViewModel.Id);
            if (RowsNum.Count > 0)
            {
                RowsNum[0].RoomStatus = "3";
                RowsNum[0].UpdateDate = DateTime.Now;
                RowsNum[0].UpdateUser = roomReservationUpdateViewModel.UserId;
                _IRoomReservationRepository.Update(RowsNum[0]);
            }
            return _IRoomReservationRepository.SaveChanges();

        }
        /// <summary>
        /// 扫码后查看详情
        /// </summary>
        /// <param name="roomReservationDeleteViewModel"></param>
        /// <returns></returns>
        public List<RoomReservationSearchMiddle> ScanCode_Search(string id)
        {

            List<MeetingRoom_Reservation> meetingroom_reservation = _IRoomReservationRepository.SearchReservationAllByid(id);
            List<RoomReservationSearchMiddle> meetingroom_ScanCode = new List<RoomReservationSearchMiddle>();
            var meetingroom_result = _IMapper.Map<List<MeetingRoom_Reservation>, List<RoomReservationSearchMiddle>>(meetingroom_reservation);
            for (int i = 0; i < meetingroom_reservation.Count; i++)
            {
                if (meetingroom_reservation[i].Endingtime > DateTime.Now && meetingroom_reservation[i].Meetingtime <= DateTime.Now)
                {
                    meetingroom_ScanCode.Add(meetingroom_result[i]);
                    meetingroom_ScanCode[meetingroom_ScanCode.Count - 1].Property = meetingroom_reservation[i].MeetingRoom_Information.DataBase_Type.Property;
                    meetingroom_ScanCode[meetingroom_ScanCode.Count - 1].PropertyPhone = meetingroom_reservation[i].MeetingRoom_Information.DataBase_Type.PropertyPhone;
                }
            }
            return meetingroom_ScanCode;
        }
        /// <summary>
        ///  会议室预定信息大屏显示
        /// </summary>
        /// <param name="roomReservationSearchViewModel"></param>
        /// <returns></returns>
        public List<RoomReservationSearchMiddle> ReservationMax_Search(ReservationMaxSearchViewModel reservationMaxSearchViewModel)
        {
            List<MeetingRoom_Reservation> Reservation_Search = new List<MeetingRoom_Reservation>();
            List<MeetingRoom_Reservation> meetingroom_reservation = _IRoomReservationRepository.SearchReservationMaxWhere(reservationMaxSearchViewModel);
            for (int i = 0; i < meetingroom_reservation.Count; i++)
            {
                if (!(meetingroom_reservation[i].Endingtime < reservationMaxSearchViewModel.Meetingtime ||
                    meetingroom_reservation[i].Meetingtime > reservationMaxSearchViewModel.Endingtime))
                {
                    Reservation_Search.Add(meetingroom_reservation[i]);
                }
            }

            var meetingroom_result = _IMapper.Map<List<MeetingRoom_Reservation>, List<RoomReservationSearchMiddle>>(Reservation_Search);

            return meetingroom_result;
        }
        /// <summary>
        /// 会议室预定信息大屏显示数量
        /// </summary>
        /// <param name="roomReservationSearchViewModel"></param>
        /// <returns></returns>
        public int ReservationMax_SearchNum(ReservationMaxSearchViewModel reservationMaxSearchViewModel)
        {

            List<MeetingRoom_Reservation> Reservation_Search = new List<MeetingRoom_Reservation>();
            List<MeetingRoom_Reservation> meetingroom_reservation = _IRoomReservationRepository.SearchReservationMaxNum(reservationMaxSearchViewModel);
            for (int i = 0; i < meetingroom_reservation.Count; i++)
            {
                if (!(meetingroom_reservation[i].Endingtime < reservationMaxSearchViewModel.Meetingtime ||
                    meetingroom_reservation[i].Meetingtime > reservationMaxSearchViewModel.Endingtime))
                {
                    Reservation_Search.Add(meetingroom_reservation[i]);
                }
            }

            var meetingroom_result = _IMapper.Map<List<MeetingRoom_Reservation>, List<RoomReservationSearchMiddle>>(Reservation_Search);

            return meetingroom_result.Count;
        }
    }
}
