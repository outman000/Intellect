using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RoomViewModel.RequestViewModel;

namespace Dto.IRepository.IntellUser
{
    public interface IRoomReservationRepository : IRepository<MeetingRoom_Reservation>
    {

        /// <summary>
        /// 根据预订信息id查询预定信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        List<MeetingRoom_Reservation> SearchReservationByid(string Id);
        //查询
        List<MeetingRoom_Reservation> SearchRoomReservationWhere(RoomReservationSearchViewModel roomReservationSearchViewModel);

        //查询会议室预定数量
        List<MeetingRoom_Reservation> SearchRoomReservationNum(RoomReservationSearchViewModel roomReservationSearchViewModel);
        /// <summary>
        /// 根据会议室信息id查询会议室预定信息
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        List<MeetingRoom_Reservation> SearchRoomReservationByid(string id);

        /// <summary>
        /// 根据会议室id查询全部预定信息
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        List<MeetingRoom_Reservation> SearchReservationAllByid(string id);
        /// <summary>
        /// 会议室预定信息大屏显示
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        List<MeetingRoom_Reservation> SearchReservationMaxWhere(ReservationMaxSearchViewModel reservationMaxSearchViewModel);
        List<MeetingRoom_Reservation> SearchReservationMaxNum(ReservationMaxSearchViewModel reservationMaxSearchViewModel);
    }
}
