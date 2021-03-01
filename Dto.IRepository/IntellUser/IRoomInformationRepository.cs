using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RoomViewModel;
using ViewModel.RoomViewModel.MiddleModel;
using ViewModel.RoomViewModel.RequestViewModel;

namespace Dto.IRepository.IntellUser
{
    public interface IRoomInformationRepository : IRepository<MeetingRoom_Information>
    {

        //添加会议室
        int AddByNum(MeetingRoom_Information obj);
        //批量删除
        List<int> DeleteByRoomidList(List<string> IdList);
        //查询
        List<RoomInformationSearchMiddle> SearchRoomInformationWhere(RoomInformationSearchViewModel roomInformationSearchViewModel);
        //根据主键id查询
        MeetingRoom_Information GetInfoByRoomid(Guid id);
        //查询会议室数量
        List<MeetingRoom_Information> SearchRoomInformationNum(RoomInformationSearchViewModel roomInformationSearchViewModel);
        List<MeetingRoom_Information> SearchInformationNumById(string id);
        /// <summary>
        /// 根据会议室id查询预定信息
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        List<MeetingRoom_Reservation> GetReservationByInformation(string roomid, string dateTime);
        /// <summary>
        /// 根据id查会议室信息
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        List<MeetingRoom_Information> SearchInformationByid(string id);

        /// <summary>
        /// 根据区id查会议室
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        List<MeetingRoom_Information> SearchRoomByArea(string id);

        /// <summary>
        /// 根据会议室条件查询会议室信息
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        List<RoomInformationSearchMiddle> SearchRoomInfoByinfo(RoomInformationByInfoSearchViewModel roomInformationByInfoSearchViewModel);

        List<RoomInformationSearchMiddle> SearchRoominfoByinfoNum(RoomInformationByInfoSearchViewModel roomInformationByInfoSearchViewModel);
    }
}
