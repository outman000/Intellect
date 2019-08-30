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
        /// 更新单个人员缴费信息
        /// </summary>
        /// <param name="busUserUpdateViewModel"></param>
        /// <returns></returns>

        int Bus_User_Update(BusUserUpdateViewModel busUserUpdateViewModel);
        /// <summary>
        /// 根据模板添加信息
        /// </summary>
        /// <param name="busUserSearchViewModel"></param>
        /// <returns></returns>
        int Bus_PayMent_Template(BusUserSearchViewModel busUserSearchViewModel);

        /// <summary>
        /// 更新人员缴费表单id信息
        /// </summary>
        /// <param name="busPamentUpdateViewModel"></param>
        /// <returns></returns>
        int Bus_PayMent_Update(BusPaymentUpdateViewModel busPamentUpdateViewModel);
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

        /// <summary>
        /// 班车缴费的验证
        /// </summary>
        /// <param name="busUserValideViewModel"></param>
        IDictionary<int, String> Bus_Payment_valide(BusUserValideViewModel busUserValideViewModel);

        /// <summary>
        /// 查询当前条件下缴费人员的应缴费用总和
        /// </summary>
        /// <param name="busUserSearchViewModel"></param>
        /// <returns></returns>
        int Bus_UserExpen_Search(BusUserSearchViewModel busUserSearchViewModel);
    }
}
