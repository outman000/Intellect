using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;

namespace Dto.IService.IntellRegularBus
{
    public interface IBusService
    {
        /// <summary>
        /// 添加班车
        /// </summary>
        /// <param name="busAddViewModel"></param>
        /// <returns></returns>
        int Bus_Add(BusAddViewModel busAddViewModel);

        /// <summary>
        /// 更新班车信息
        /// </summary>
        /// <param name="busUpdateViewModel"></param>
        /// <returns></returns>

        int Bus_Update(BusUpdateViewModel busUpdateViewModel);
        /// <summary>
        /// 删除班车信息
        /// </summary>
        /// <param name="busDelViewModel"></param>
        /// <returns></returns>
        int Bus_Delete(BusDelViewModel busDelViewModel);
        /// <summary>
        /// 查询班车信息
        /// </summary>
        /// <param name="busSearchViewModel"></param>
        List<BusSearchMiddlecs> Bus_Search(BusSearchViewModel busSearchViewModel);
        /* /// <summary>
         /// 验证班车的唯一性
         /// </summary>
         /// <param name="userValideRepeat"></param>
         /// <returns></returns>
         bool User_Single(UserValideRepeat userValideRepeat);
         /// <summary>
         /// 获取班车总数
         /// </summary>
         /// <returns></returns>
         int User_Get_ALLNum();*/
        /// <summary>
        /// 根据班车添加线路
        /// </summary>
        /// <param name="lineByBusAddViewModel"></param>
        /// <returns></returns>
        int Bus_To_Line_Add(LineByBusAddViewModel lineByBusAddViewModel);
    }
}
