using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RoomViewModel.MiddleModel;
using ViewModel.RoomViewModel.RequestViewModel;

namespace Dto.IService.IntellUser
{
    public interface IRoomReservationService
    {
        /// <summary>
        /// 增加会议室预定信息
        /// </summary>
        /// <param name="roomReservationAddViewModel"></param>
        /// <returns></returns>

        int RoomReservation_Add(RoomReservationAddViewModel roomReservationAddViewModel);
        /// <summary>
        ///  查询会议室预定信息
        /// </summary>
        /// <param name="roomReservationSearchViewModel"></param>
        /// <returns></returns>
        List<RoomReservationSearchMiddle> RoomReservation_Search(RoomReservationSearchViewModel roomReservationSearchViewModel);

        /// <summary>
        /// 查询会议室数量
        /// </summary>
        /// <param name="roomReservationSearchViewModel"></param>
        /// <returns></returns>
        int RoomReservation_SearchNum(RoomReservationSearchViewModel roomReservationSearchViewModel);

        /// <summary>
        /// 取消会议室预定信息
        /// </summary>
        /// <param name="roomReservationDeleteViewModel"></param>
        /// <returns></returns>
        int RoomReservation_Update(RoomReservationUpdateViewModel roomReservationUpdateViewModel);

        /// <summary>
        /// 确认会议室预定信息
        /// </summary>
        /// <param name="roomReservationDeleteViewModel"></param>
        /// <returns></returns>
        int RoomReservationReal_Update(RoomReservationUpdateViewModel roomReservationUpdateViewModel);

        /// <summary>
        /// 根据会议室信息id查询会议室预定信息
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        List<RoomReservationSearchMiddle> RoomReservation_SearchByid(string id);

        /// <summary>
        /// 扫码后查看详情
        /// </summary>
        /// <param name="roomReservationDeleteViewModel"></param>
        /// <returns></returns>
        List<RoomReservationSearchMiddle> ScanCode_Search(string id);

        /// <summary>
        /// 结束会议室预定信息
        /// </summary>
        /// <param name="roomReservationDeleteViewModel"></param>
        /// <returns></returns>
        int RoomReservationEnd_Update(RoomReservationUpdateViewModel roomReservationUpdateViewModel);
        /// <summary>
        ///  会议室预定信息大屏显示
        /// </summary>
        /// <param name="roomReservationSearchViewModel"></param>
        /// <returns></returns>
        List<RoomReservationSearchMiddle> ReservationMax_Search(ReservationMaxSearchViewModel reservationMaxSearchViewModel);
        /// <summary>
        /// 会议室预定信息大屏显示数量
        /// </summary>
        /// <param name="roomReservationSearchViewModel"></param>
        /// <returns></returns>
        int ReservationMax_SearchNum(ReservationMaxSearchViewModel reservationMaxSearchViewModel);
    }
}
