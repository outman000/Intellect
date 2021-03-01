using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RoomViewModel;
using ViewModel.RoomViewModel.MiddleModel;
using ViewModel.RoomViewModel.RequestViewModel;

namespace Dto.IService.IntellUser
{
    public interface IRoomInformationService
    {
        /// <summary>
        /// 增加会议室
        /// </summary>
        /// <param name="departAddViewModel"></param>
        /// <returns></returns>

        int Room_Add(RoomInformationAddViewModel roomInformationAddViewModel);
        /// <summary>
        ///  查询会议室信息
        /// </summary>
        /// <param name="roomInformationSearchViewModel"></param>
        /// <returns></returns>
        List<RoomInformationSearchMiddle> Room_Search(RoomInformationSearchViewModel roomInformationSearchViewModel);

        /// <summary>
        ///  根据id查询会议室信息
        /// </summary>
        /// <param name="roomInformationSearchViewModel"></param>
        /// <returns></returns>
        List<RoomInformationSearchMiddle> RoomById_Search(RoomInformationByIdSearchViewModel roomInformationByIdSearchViewModel);

        /// <summary>
        /// 更改会议室信息
        /// </summary>
        /// <param name="BookUpdateViewModel"></param>
        /// <returns></returns>
        int Room_Update(RoomInformationUpdateViewModel roomInformationUpdateViewModel);

        /// <summary>
        /// id查询会议室数量
        /// </summary>
        /// <param name="roomInformationSearchViewModel"></param>
        /// <returns></returns>
        int RoomById_SearchNum(RoomInformationByIdSearchViewModel roomInformationByIdSearchViewModel);
        /// <summary>
        /// 查询会议室数量
        /// </summary>
        /// <param name="roomInformationSearchViewModel"></param>
        /// <returns></returns>
        int Room_SearchNum(RoomInformationSearchViewModel roomInformationSearchViewModel);

        /// <summary>
        /// 删除会议室
        /// </summary>
        /// <param name="roomInformationDeleteViewModel"></param>
        /// <returns></returns>
        List<int> Room_Delete(RoomInformationDeleteViewModel roomInformationDeleteViewModel);

        /// <summary>
        ///  楼—区—会议室
        /// </summary>
        /// <param name="roomInformationSearchViewModel"></param>
        /// <returns></returns>
        List<FloorAreaRoomSearchViewModel> FloorAreaRoom(string id, string code, string departid);

        /// <summary>
        ///  根据会议室条件查询会议室信息
        /// </summary>
        /// <param name="roomInformationSearchViewModel"></param>
        /// <returns></returns>
        List<RoomInformationSearchMiddle> SearchRoominfoByinformation(RoomInformationByInfoSearchViewModel roomInformationByInfoSearchViewModel);

        /// <summary>
        /// 根据会议室条件查询会议室信息数量
        /// </summary>
        /// <param name="roomInformationSearchViewModel"></param>
        /// <returns></returns>
        int SearchRoominfoByinformationNum(RoomInformationByInfoSearchViewModel roomInformationByInfoSearchViewModel);
    }
}
