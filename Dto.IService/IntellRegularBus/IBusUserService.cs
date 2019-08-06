using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel;
using ViewModel.BusViewModel.RequestViewModel.BusUserViewModel;

namespace Dto.IService.IntellRegularBus
{
    public interface IBusUserService
    {
        /// <summary>
        ///添加人员缴费信息
        /// </summary>
        /// <param name="busUserAddViewModel"></param>
        /// <returns></returns>
        int Bus_User_Add(BusUserAddViewModel busUserAddViewModel);
        /// <summary>
        /// 删除人员缴费信息
        /// </summary>
        /// <param name="busDelViewModel"></param>
        /// <returns></returns>
        int Bus_User_Delete(BusUserDelViewModel busDelViewModel);

        /// <summary>
        /// 更新人员缴费信息
        /// </summary>
        /// <param name="busUserUpdateViewModel"></param>
        /// <returns></returns>

        int Bus_User_Update(BusUserUpdateViewModel busUserUpdateViewModel);

        /// <summary>
        /// 查询所有人员缴费信息
        /// </summary>
        /// <param name="busSearchViewModel"></param>
        List<BusUserSearchMiddlecs> Bus_User_Search(BusUserSearchViewModel busUserSearchViewModell);

        /// <summary>
        /// 查询所有人员缴费信息数量
        /// </summary>
        /// <param name="busUserSearchViewModell"></param>
        int Bus_User_Get_ALLNum(BusUserSearchViewModel busUserSearchViewModell);


        /// <summary>
        /// 根据班车id查询数量
        /// </summary>
        /// <param name="busSearchByIdViewModel"></param>
        int ByBusIdSearchNum(BusSearchByIdViewModel busSearchByIdViewModel);
    }
}
