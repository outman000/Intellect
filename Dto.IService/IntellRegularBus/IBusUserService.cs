using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel;
using ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel;
using ViewModel.BusViewModel.RequestViewModel.BusUserViewModel;
using ViewModel.BusViewModel.ResponseModel;
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
        Double Bus_UserExpen_Search(BusUserSearchViewModel busUserSearchViewModel);

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
        List<Bus_Payment_Order> Bus_Payment_Order_Search(Bus_Payment_OrderSearchViewModel bus_Payment_OrderSearchViewModel);

        /// <summary>
        /// 查询所有订单信息数量
        /// </summary>
        /// <param name="busUserSearchViewModell"></param>
        int Bus_Payment_Order_Get_ALLNum(Bus_Payment_OrderSearchViewModel bus_Payment_OrderSearchViewModel);

        /// <summary>
        /// 根据表单Id查询所有订单详细信息
        /// </summary>
        /// <param name="bus_OrderByRepairsIdSearchViewModel"></param>
        Bus_Payment_OrderSearchMiddle Bus_Payment_Order_BySearch(Bus_OrderByRepairsIdSearchViewModel bus_OrderByRepairsIdSearchViewModel);

        /// <summary>
        /// 根据用户ID查询缴费详情
        /// </summary>
        /// <param name="bus_OrderIsPassSearchViewModel"></param>
        /// <returns></returns>
        List<Bus_Payment_Order> Bus_Payment_Order_SearchByUserid(Bus_OrderIsPassSearchViewModel bus_OrderIsPassSearchViewModel);


        int Bus_Payment_Order_Count(Bus_OrderIsPassSearchViewModel bus_OrderIsPassSearchViewModel);

        int ByBusIdSearchNum2(BusSearchByIdViewModel busSearchByIdViewModel);


        int Bus_PaymentSearchByOrderId(Bus_OrderByOrderIdSearchViewModel bus_OrderByOrderIdSearchViewModel);
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

        Bank_PaymentMiddle Bank_Payment(Bank_PaymentRequestMiddle Bank_PaymentRequestMiddle);

        Bank_Payment_SearchMiddle Bank_Payment_Search(Bank_PaymentRequestMiddle Bank_PaymentRequestMiddle);
        string CheckCode(CheckCodeSearchViewModel checkCodeSearchViewModel);
        /// <summary>
        /// 修改支付状态
        /// </summary>
        /// <param name="Bank_PaymentRequestMiddle"></param>
        /// <returns></returns>
        int Update_Bank_Payment_Order(Bank_PaymentRequestMiddle Bank_PaymentRequestMiddle);


        List<Bus_Payment_Order> Bus_Payment_Order_SearchByCZ();
        /// <summary>
        /// 中行退款
        /// </summary>
        /// <returns></returns>
        Bank_Payment_RefundMiddle Bank_Payment_Refund(Bank_PaymentRequestMiddle Bank_PaymentRequestMiddle);


        /// <summary>
        /// 根据条件查询扫码记录
        /// </summary>
        /// <param name="busScanRecordSearchViewModel"></param>
        /// <returns></returns>
        List<Bus_Scan_Record> Bus_Scan_Record_Search(BusScanRecordSearchViewModel busScanRecordSearchViewModel);
        /// <summary>
        /// 根据条件查询扫码记录数量
        /// </summary>
        /// <param name="busScanRecordSearchViewModel"></param>
        /// <returns></returns>
        int Bus_Scan_Record_SearchNum(BusScanRecordSearchViewModel busScanRecordSearchViewModel);


        List<BusUserSearchMiddlecs> Bus_User_Search2(BusUserSearch2ViewModel busUserSearch2ViewModel);
        int Bus_User_Get_ALLNum2(BusUserSearch2ViewModel busUserSearch2ViewModell);

        List<BusUserTongJiExceptSearchMiddle> BusUserTongJiExcept_Search(BusPaymentSearchViewModel busPaymentSearchViewModel);

        /// <summary>
        /// 导出数据到Excel表格
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="heading"></param>
        /// <param name="isShowSlNo"></param>
        /// <param name="columnsToTake"></param>
        /// <returns></returns>
        byte[] ExportExcel1<T>(List<T> data, string heading = "", int temp = 1, bool isShowSlNo = false, params string[] columnsToTake);
        byte[] ExportExcel2<T>(List<T> data, string heading = "", int temp = 2, bool isShowSlNo = false, params string[] columnsToTake);
        byte[] ExportExcel3<T>(List<T> data, string heading = "", int temp = 3, bool isShowSlNo = false, params string[] columnsToTake);

        List<BusOrderExcelSearchMiddle> Bus_Payment_Order_SearchExcel(BusOrderSearchViewModel busOrderSearchViewModel);

        /// <summary>
        /// 根据条件查询扫码记录（统计各站点扫码数量）
        /// </summary>
        /// <param name="busScanRecordTongJiSearchViewModel"></param>
        /// <returns></returns>
        List<BusScanRecordTongjiNumMiddle> Bus_Scan_Record_SearchTongJi(BusScanRecordTongJiSearchViewModel busScanRecordTongJiSearchViewModel);


        /// <summary>
        /// 查询16个部门的已用里程和剩余里程
        /// </summary>
        /// <returns></returns>
        string SearchCarMileage(string jdfs);


        /// <summary>
        /// 查询当前年份，当前用车类型的各部门的用车趋势
        /// </summary>
        /// <returns></returns>
        string CarTrend(string jdfs, string Docdate);


        /// <summary>
        /// 查询当前年份，当前用车类型的各部门的日均派车量
        /// </summary>
        /// <returns></returns>
        string AverageDailyDispatch(string jdfs, string Docdate);
        /// <summary>
        /// 更新免费坐车人员乘车时间
        /// </summary>
        /// <returns></returns>
        int Bus_User_Update_Status();

        /// <summary>
        /// 查询一般公务和执法执勤车辆实时占用情况
        /// </summary>
        /// <returns></returns>
        List<CarOccupyMiddle> CarOccupySel(CarOccupyRequestModel carOccupyRequestModel);

        /// <summary>
        /// 更新已缴费但是没回调的订单数据
        /// </summary>
        /// <returns></returns>
        int Bus_Order_Update();

        /// <summary>
        /// 用车查询（智慧后勤）
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        List<UseCarSelResMiddle> UserCarSel(UseCarSelReqViewModel UseCarSelReq);


        /// <summary>
        /// 更新单条人员线路以及站点信息
        /// </summary>
        /// <param name="busPaymentUpdateLineViewModel"></param>
        /// <returns></returns>
        int Bus_Payment_Line_Update(BusPaymentUpdateLineViewModel busPaymentUpdateLineViewModel);
    }
}
