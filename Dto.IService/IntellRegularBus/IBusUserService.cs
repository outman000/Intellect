using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel;
using ViewModel.BusViewModel.RequestViewModel.BusUserViewModel;
using ViewModel.BusViewModel.ResponseModel.BusUserResModel;
using ViewModel.RepairsViewModel.RequestViewModel;

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
        string Bus_PayMent_Template(BusUserSearchViewModel busUserSearchViewModel);

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

        /// <summary>
        /// 查询所有缴费时间列表
        /// </summary>
        /// <returns></returns>
        List<string> Bus_User_TimeList_Search(BusUserSearchTimeViewModel busUserSearchTimeViewModel);

        /// <summary>
        /// 增加订单信息
        /// </summary>
        /// <param name="bus_Payment_OrderAddViewModel"></param>
        /// <returns></returns>
        int Bus_Payment_Order_Add(Bus_Payment_OrderAddViewModel bus_Payment_OrderAddViewModel);

        /// <summary>
        /// 修改订单信息
        /// </summary>
        /// <param name="bus_Payment_OrderAddViewModel"></param>
        /// <returns></returns>
        int Bus_Payment_Order_Update(Bus_Payment_OrderUpdateViewModel bus_Payment_OrderUpdateViewModel);


        /// <summary>
        /// 查询所有订单信息
        /// </summary>
        /// <param name="bus_Payment_OrderSearchViewModel"></param>
        List<Bus_Payment_Order> Bus_Payment_Order_Search(Bus_Payment_OrderSearchViewModel  bus_Payment_OrderSearchViewModel);

        /// <summary>
        /// 查询所有订单信息数量
        /// </summary>
        /// <param name="busUserSearchViewModell"></param>
        int Bus_Payment_Order_Get_ALLNum(Bus_Payment_OrderSearchViewModel bus_Payment_OrderSearchViewModel);

        /// <summary>
        /// 根据表单Id查询所有订单详细信息
        /// </summary>
        /// <param name="bus_OrderByRepairsIdSearchViewModel"></param>
       Bus_Payment_OrderSearchMiddle Bus_Payment_Order_BySearch(Bus_OrderByRepairsIdSearchViewModel  bus_OrderByRepairsIdSearchViewModel);

        /// <summary>
        /// 根据用户ID查询缴费详情
        /// </summary>
        /// <param name="bus_OrderIsPassSearchViewModel"></param>
        /// <returns></returns>
        List<Bus_Payment_Order> Bus_Payment_Order_SearchByUserid(Bus_OrderIsPassSearchViewModel bus_OrderIsPassSearchViewModel);


        int Bus_Payment_Order_Count(Bus_OrderIsPassSearchViewModel bus_OrderIsPassSearchViewModel);

        int ByBusIdSearchNum2(BusSearchByIdViewModel busSearchByIdViewModel, int count);


        void Bus_PaymentSearchByOrderId(Bus_OrderByOrderIdSearchViewModel bus_OrderByOrderIdSearchViewModel);
        /// <summary>
        /// 根据身份证号查询人员缴费信息
        /// </summary>
        /// <param name="bus_OrderByIdCardSearchViewModel"></param>
        /// <returns></returns>

        Bus_Payment Bus_PaymentSearchByIdCard(Bus_OrderByIdCardSearchViewModel bus_OrderByIdCardSearchViewModel);
        /// <summary>
        /// 根据动态码查询人员缴费信息
        /// </summary>
        /// <param name="bus_OrderByCodeSearchViewModel"></param>
        /// <returns></returns>
        Bus_Payment Bus_PaymentSearchByCode(Bus_OrderByCodeSearchViewModel bus_OrderByCodeSearchViewModel);

        /// <summary>
        /// 更新缴费订单信息(金额)
        /// </summary>
        /// <param name="bus_Payment_OrderUpdateViewModel"></param>
        /// <returns></returns>
        int Bus_Payment_Order_UpdateExpense(Bus_Payment_OrderUpdateExpenseViewModel bus_Payment_OrderUpdateExpenseViewModel);

        string Bus_PayMent_Update_Verification(BusPaymentUpdateViewModel busPamentUpdateViewModel);

        int Bus_PayMent_Single_Verification(SearchByIdCardAndCarDateViewModel searchByIdCardAndCarDateViewModel);

        string Bus_PayMent_Verification(BusUserSearchByDeaprtIdViewModel busUserSearchByDeaprtIdViewModel);
    }
}
