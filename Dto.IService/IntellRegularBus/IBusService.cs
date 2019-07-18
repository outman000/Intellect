using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel;

namespace Dto.IService.IntellRegularBus
{
    public interface IBusService
    {
        /*   /// <summary>
           /// 添加班车
           /// </summary>
           /// <param name="userAddViewModel"></param>
           /// <returns></returns>
           int User_Add(UserAddViewModel userAddViewModel);
           /// <summary>
           /// 更新班车信息
           /// </summary>
           /// <param name="userUpdateViewModel"></param>
           /// <returns></returns>
           int User_Update(UserUpdateViewModel userUpdateViewModel);
           /// <summary>
           /// 删除班车信息
           /// </summary>
           /// <param name="userDeleteViewModel"></param>
           /// <returns></returns>
           int User_Delete(UserDeleteViewModel userDeleteViewModel);*/
        /// <summary>
        /// 查询班车信息
        /// </summary>
        /// <param name="busSearchViewModel"></param>
        List<BusSearchMiddlecs> Bus_Search(BusSearchViewModel busSearchViewModel);
        /// <summary>
    /*    /// 验证班车的唯一性
        /// </summary>
        /// <param name="userValideRepeat"></param>
        /// <returns></returns>
        bool User_Single(UserValideRepeat userValideRepeat);
        /// <summary>
        /// 获取班车总数
        /// </summary>
        /// <returns></returns>
        int User_Get_ALLNum();*/

        
    }
}
