﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Dto.IService.IntellRegularBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.BusViewModel.RequestViewModel.BusUserViewModel;
using ViewModel.BusViewModel.ResponseModel.BusUserResModel;
using ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel;
using ViewModel.BusViewModel.ResponseModel.BusInfoResModel;
using Dto.IService.IntellRepair;
using ViewModel.RepairsViewModel.RequestViewModel;
using ViewModel.RepairsViewModel.MiddleModel;
using Microsoft.AspNetCore.Authorization;
using ViewModel.BusViewModel.RequestViewModel;
using ViewModel.BusViewModel.MiddleModel;
using Microsoft.Extensions.Options;
using ViewModel.BusViewModel.ResponseModel;
using System.IO;
using Dtol.dtol;

namespace IntellRegularBus.Controllers
{
    [Route("BusManageApi/[controller]/[action]")]
    [ApiController]
    public class BusUserController : ControllerBase
    {
       
        public static IServiceProvider ServiceProvider;
        private readonly IBusUserService _IBusUserService;
        private readonly IRepairService _IRepairService;
        private readonly IBusLocationInformationService _IBusLocationInformationService;
        private readonly ILogger _ILogger;
       // private readonly IHttpContextAccessor httpContextAccessor;
    

        public BusUserController(IBusUserService lineService, IRepairService repairService, IBusLocationInformationService busLocationInformationService,
           // IHttpContextAccessor httpContextAccessor,
            ILogger logger)
        {

           // this.httpContextAccessor = httpContextAccessor;
            _IBusUserService = lineService;
            _IRepairService = repairService;
            _IBusLocationInformationService = busLocationInformationService;
            _ILogger = logger;
          

        }

        /// <summary>
        ///  增加用户缴费信息
        /// </summary>
        /// <returns></returns>       
       [HttpPost]

        public ActionResult<BusUserAddResModel> Bus_User_Add(BusUserAddViewModel busUserAddViewModel)
        {
           
        int Bus_User_Add_Count;
            Bus_User_Add_Count = _IBusUserService.Bus_User_Add(busUserAddViewModel);
            BusUserAddResModel busUserAddResModel = new BusUserAddResModel();
            if (Bus_User_Add_Count > 0)
            {
                busUserAddResModel.IsSuccess = true;
                busUserAddResModel.AddCount = Bus_User_Add_Count;
                busUserAddResModel.baseViewModel.Message = "添加成功";
                busUserAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增加用户缴费信息成功");
                return Ok(busUserAddResModel);
            }
            else
            {
                busUserAddResModel.IsSuccess = false;
                busUserAddResModel.AddCount = 0;
                busUserAddResModel.baseViewModel.Message = "添加失败";
                busUserAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增加用户缴费信息失败");
                return Ok(busUserAddResModel);
            }
       

        }
        /// <summary>
        /// 删除用户缴费信息
        /// </summary>
        /// <returns></returns>
         [HttpPost]

        public ActionResult<BusUserDelResModel> Bus_User_Delete(BusUserDelViewModel busUserDelViewModel)
        {
            BusUserDelResModel busUserDelResModel = new BusUserDelResModel();
            int DeleteResult = _IBusUserService.Bus_User_Delete(busUserDelViewModel);

            if (DeleteResult > 0)
            {
                busUserDelResModel.DelCount = DeleteResult;
                busUserDelResModel.IsSuccess = true;
                busUserDelResModel.baseViewModel.Message = "删除成功";
                busUserDelResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("删除用户缴费信息成功");
                return Ok(busUserDelResModel);
            }
            else
            {
                busUserDelResModel.DelCount = -1;
                busUserDelResModel.IsSuccess = false;
                busUserDelResModel.baseViewModel.Message = "删除失败";
                busUserDelResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("删除用户缴费信息失败");
                return Ok(busUserDelResModel);
            }
        }

        /// <summary>
        /// 查询本部门所有缴费时间列表信息（降序显示）
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusUserTimeListSearchResModel> Bus_User_TimeList_Search(BusUserSearchTimeViewModel busUserSearchTimeViewModel)
        {
            BusUserTimeListSearchResModel  busUserTimeListSearchResModel = new BusUserTimeListSearchResModel();
            var BusUserSearchResult = _IBusUserService.Bus_User_TimeList_Search(busUserSearchTimeViewModel);
            if (BusUserSearchResult.Count == 0)
            {
                BusUserSearchResult.Add(DateTime.Now.ToString("yyyy-MM"));
             //   BusUserSearchResult.Add(DateTime.Now.AddMonths(1).ToString("yyyy-MM"));  
            }
               
            busUserTimeListSearchResModel.bus_user_time_Info = BusUserSearchResult;
            busUserTimeListSearchResModel.isSuccess = true;
            busUserTimeListSearchResModel.baseViewModel.Message = "查询成功";
            busUserTimeListSearchResModel.baseViewModel.ResponseCode = 200;
            busUserTimeListSearchResModel.TotalNum = BusUserSearchResult.Count;
            _ILogger.Information("查询所有用户缴费信息成功");
            return Ok(busUserTimeListSearchResModel);
        }
        /// <summary>
        /// 查询所有用户缴费信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusUserSearchResModel> Bus_User_Search(BusUserSearchViewModel busUserSearchViewModel)
        {
            BusUserSearchResModel busUserSearchResModel = new BusUserSearchResModel();
            var BusUserSearchResult = _IBusUserService.Bus_User_Search(busUserSearchViewModel);
            Double TotalExpen= _IBusUserService.Bus_UserExpen_Search(busUserSearchViewModel);//应缴费用总和

            var TotalNum = _IBusUserService.Bus_User_Get_ALLNum(busUserSearchViewModel);
            busUserSearchResModel.bus_user_Info = BusUserSearchResult;
            busUserSearchResModel.isSuccess = true;
            busUserSearchResModel.baseViewModel.Message = "查询成功";
            busUserSearchResModel.baseViewModel.ResponseCode = 200;
            busUserSearchResModel.TotalNum = TotalNum;
            busUserSearchResModel.TotalExpen = TotalExpen;
            _ILogger.Information("查询所有用户缴费信息成功");
            return Ok(busUserSearchResModel);
        }

        /// <summary>
        /// 更新已缴费但是没回调的订单数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusUserSearchResModel> Bus_Order_Update()
        {
          
          
           var temp = _IBusUserService.Bus_Order_Update();//应缴费用总和

        
            return Ok(temp);
        }



        /// <summary>
        /// 查询所有用户缴费信息2
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusUserSearchResModel> Bus_User_Search2(BusUserSearch2ViewModel busUserSearch2ViewModel)
        {
            BusUserSearchResModel busUserSearchResModel = new BusUserSearchResModel();
            var BusUserSearchResult = _IBusUserService.Bus_User_Search2(busUserSearch2ViewModel);       
            var TotalNum = _IBusUserService.Bus_User_Get_ALLNum2(busUserSearch2ViewModel);
            busUserSearchResModel.bus_user_Info = BusUserSearchResult;
            busUserSearchResModel.isSuccess = true;
            busUserSearchResModel.baseViewModel.Message = "查询成功";
            busUserSearchResModel.baseViewModel.ResponseCode = 200;
            busUserSearchResModel.TotalNum = TotalNum;
            _ILogger.Information("查询所有用户缴费信息成功");
            return Ok(busUserSearchResModel);
        }



        /// <summary>
        /// 把模板月份用户缴费信息添加到数据库（参数只需要传乘车时间和部门Id,PageSize设置为999 CurrentPageNum=0）
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusUserAddResModel> Bus_PayMent_Template_Add(BusUserSearchViewModel busUserSearchViewModel)
        {

            int result;
            result = _IBusUserService.Bus_PayMent_Template(busUserSearchViewModel);
            BusUserAddResModel busUserAddResModel = new BusUserAddResModel();
            if (result>0)
            {
                busUserAddResModel.IsSuccess = true;
                busUserAddResModel.AddCount = result;
                busUserAddResModel.baseViewModel.Message = "添加成功";
                busUserAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增加用户缴费信息成功");
                return Ok(busUserAddResModel);
            }
            else
            {
                busUserAddResModel.IsSuccess = false;
                // busUserAddResModel.LineName = result;
                busUserAddResModel.AddCount = 0;
                busUserAddResModel.baseViewModel.Message = "添加失败";
                busUserAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增加用户缴费信息失败");
                return Ok(busUserAddResModel);
            }
        }

        /// <summary>
        /// 根据线路Id查询该班车是否坐满人
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusSearchByIdResModel> Bus_Id_Search(BusSearchByIdViewModel busSearchByIdViewModel)
        {
            BusSearchByIdResModel  busSearchByIdResModel = new BusSearchByIdResModel();
            int Result = _IBusUserService.ByBusIdSearchNum(busSearchByIdViewModel);
             if(Result==-1)
             {
                    busSearchByIdResModel.isSuccess = false;
                    busSearchByIdResModel.baseViewModel.Message = "该线路已坐满人，请重新选择";
                    busSearchByIdResModel.baseViewModel.ResponseCode = 200;
                    _ILogger.Information("该线路已满员，请重新选择");
                   return Ok(busSearchByIdResModel);

            }
            else
            {
                busSearchByIdResModel.isSuccess = true;
                busSearchByIdResModel.baseViewModel.Message = "该线路未坐满人，可以添加该线路";
                busSearchByIdResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("该线路未坐满人，可以添加该线路");
                return Ok(busSearchByIdResModel);

            }
           
        }


        /// <summary>
        /// 根据乘车时间和部门查
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusSearchByIdResModel> Bus_PayMent_Verification(BusUserSearchByDeaprtIdViewModel busUserSearchByDeaprtIdViewModel)
        {
            BusSearchByIdResModel busSearchByIdResModel = new BusSearchByIdResModel();
            string Result = _IBusUserService.Bus_PayMent_Verification(busUserSearchByDeaprtIdViewModel);
            if (!Result.Equals("true"))
            {
               
                string msg= Result.Substring(0, Result.IndexOf(',')) + "，该线路已坐满人，已超员" + Result.Substring(Result.IndexOf(',')+1) + "个人；请重新选择。";
                busSearchByIdResModel.isSuccess = false;
                busSearchByIdResModel.baseViewModel.Message = msg;
                busSearchByIdResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information(Result+"线路已满员，请重新选择");
                return Ok(busSearchByIdResModel);

            }
            else
            {
                busSearchByIdResModel.isSuccess = true;
                busSearchByIdResModel.baseViewModel.Message = "该线路未坐满人，可以添加该线路";
                busSearchByIdResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("该线路未坐满人，可以添加该线路");
                return Ok(busSearchByIdResModel);

            }

        }
        /// <summary>
        /// 修改单个用户的乘车线路以及站点信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusUserUpdateResModel> Bus_Payment_Line_Update(BusPaymentUpdateLineViewModel busPaymentUpdateLineViewModel)
        {
            BusUserUpdateResModel busUserUpdateResModel = new BusUserUpdateResModel();
            int UpdateRowNum = _IBusUserService.Bus_Payment_Line_Update(busPaymentUpdateLineViewModel);

            if (UpdateRowNum > 0)
            {
                busUserUpdateResModel.IsSuccess = true;
                busUserUpdateResModel.AddCount = UpdateRowNum;
                busUserUpdateResModel.baseViewModel.Message = "更新成功";
                busUserUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("修改用户缴费信息成功");
                return Ok(busUserUpdateResModel);
            }
            else
            {
                busUserUpdateResModel.IsSuccess = false;
                busUserUpdateResModel.AddCount = 0;
                busUserUpdateResModel.baseViewModel.Message = "更新失败";
                busUserUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("修改用户缴费信息失败");
                return Ok(busUserUpdateResModel);
            }
        }

        /// <summary>
        /// 修改单个用户缴费信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusUserUpdateResModel> Bus_User_Update(BusUserUpdateViewModel busUserUpdateViewModel)
        {
            BusUserUpdateResModel busUserUpdateResModel = new BusUserUpdateResModel();
            int UpdateRowNum = _IBusUserService.Bus_User_Update(busUserUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                busUserUpdateResModel.IsSuccess = true;
                busUserUpdateResModel.AddCount = UpdateRowNum;
                busUserUpdateResModel.baseViewModel.Message = "更新成功";
                busUserUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("修改用户缴费信息成功");
                return Ok(busUserUpdateResModel);
            }
            else
            {
                busUserUpdateResModel.IsSuccess = false;
                busUserUpdateResModel.AddCount = 0;
                busUserUpdateResModel.baseViewModel.Message = "更新失败";
                busUserUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("修改用户缴费信息失败");
                return Ok(busUserUpdateResModel);
            }
        }


        /// <summary>
        /// 根据订单ID修改用户缴费总金额信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusUserUpdateResModel> Bus_Payment_Order_UpdateExpense(Bus_Payment_OrderUpdateExpenseViewModel bus_Payment_OrderUpdateExpenseViewModel)
        {
            BusUserUpdateResModel busUserUpdateResModel = new BusUserUpdateResModel();
            int UpdateRowNum = _IBusUserService.Bus_Payment_Order_UpdateExpense(bus_Payment_OrderUpdateExpenseViewModel);

            if (UpdateRowNum > 0)
            {
                busUserUpdateResModel.IsSuccess = true;
                busUserUpdateResModel.AddCount = UpdateRowNum;
                busUserUpdateResModel.baseViewModel.Message = "更新成功";
                busUserUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据订单ID修改用户缴费总金额信息成功");
                return Ok(busUserUpdateResModel);
            }
            else
            {
                busUserUpdateResModel.IsSuccess = false;
                busUserUpdateResModel.AddCount = 0;
                busUserUpdateResModel.baseViewModel.Message = "更新失败";
                busUserUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("根据订单ID修改用户缴费总金额信息失败");
                return Ok(busUserUpdateResModel);
            }
        }
        /// <summary>
        /// 校验一条数据，是否存在
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusPaymentUpdateResModel> Bus_Payment_Add_Verification(SearchByIdCardAndCarDateViewModel searchByIdCardAndCarDateViewModel)
        {
            BusPaymentUpdateResModel busPamentUpdateResModel = new BusPaymentUpdateResModel();
            int result = _IBusUserService.Bus_PayMent_Single_Verification(searchByIdCardAndCarDateViewModel);
            if (result==0)
            {
                busPamentUpdateResModel.IsSuccess = true;
                busPamentUpdateResModel.baseViewModel.Message = "可以增加";
                busPamentUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增加用户缴费表单id信息成功");
                return Ok(busPamentUpdateResModel);
            }
            else
            {
                busPamentUpdateResModel.IsSuccess = false;
                busPamentUpdateResModel.baseViewModel.Message = "不能增加";
                busPamentUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("失败，存在当前月份存在已缴费的人员");
                return Ok(busPamentUpdateResModel);

            }

        }

        /// <summary>
        /// 修改用户缴费表单id信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusPaymentUpdateResModel> Bus_Payment_Update(BusPaymentUpdateViewModel busPamentUpdateViewModel)
        {
            BusPaymentUpdateResModel  busPamentUpdateResModel = new BusPaymentUpdateResModel();
            int Add = _IBusUserService.Bus_PayMent_Update(busPamentUpdateViewModel);
                busPamentUpdateResModel.IsSuccess = true;
                busPamentUpdateResModel.Add = Add;
                busPamentUpdateResModel.baseViewModel.Message = "更新成功";
                busPamentUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增加用户缴费表单id信息成功");
                return Ok(busPamentUpdateResModel);
          
        }

        /// <summary>
        /// 缴费信息验证
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BuUserValideResModel> Bus_Payment_Valide(BusUserValideViewModel  busUserValideViewModel)
        {
            BuUserValideResModel buUserValideResModel = new BuUserValideResModel();
            IDictionary<int, String> errorResult = _IBusUserService.Bus_Payment_valide(busUserValideViewModel);

            if (errorResult.Count > 0)
            {
                buUserValideResModel.isSuccess = false;
                buUserValideResModel.errorResult = errorResult;
                buUserValideResModel.baseViewModel.Message = "缴费单存在变更信息";
                buUserValideResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("验证班车缴费信息存在变更");
                return Ok(buUserValideResModel);
            }
            else
            {
                buUserValideResModel.isSuccess = true;
                buUserValideResModel.errorResult = errorResult;
                buUserValideResModel.baseViewModel.Message = "班车缴费单不存在变更信息";
                buUserValideResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("班车缴费信息可以使用，无异常");
                return Ok(buUserValideResModel);
            }

        }

        /// <summary>
        ///  增加用户缴费订单信息
        /// </summary>
        /// <returns></returns>       
        [HttpPost]

        public ActionResult<BusUserAddResModel> Bus_Payment_Order_Add(Bus_Payment_OrderAddViewModel  bus_Payment_OrderAddViewModel)
        {

            int Bus_Payment_Order_ID;
            Bus_Payment_Order_ID = _IBusUserService.Bus_Payment_Order_Add(bus_Payment_OrderAddViewModel);
            BusUserAddResModel busUserAddResModel = new BusUserAddResModel();
 
                busUserAddResModel.IsSuccess = true;
                busUserAddResModel.Bus_Payment_Order_ID = Bus_Payment_Order_ID;
                busUserAddResModel.baseViewModel.Message = "添加成功";
                busUserAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增加用户缴费订单信息成功");
                return Ok(busUserAddResModel);
          
         


        }

        /// <summary>
        /// 修改用户缴费订单信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusUserUpdateResModel> Bus_Payment_Order_Update(Bus_Payment_OrderUpdateViewModel  bus_Payment_OrderUpdateViewModel)
        {
            BusUserUpdateResModel busUserUpdateResModel = new BusUserUpdateResModel();
            int UpdateRowNum = _IBusUserService.Bus_Payment_Order_Update(bus_Payment_OrderUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                busUserUpdateResModel.IsSuccess = true;
                busUserUpdateResModel.AddCount = UpdateRowNum;
                busUserUpdateResModel.baseViewModel.Message = "更新成功";
                busUserUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("修改用户缴费订单信息成功");
                return Ok(busUserUpdateResModel);
            }
            else
            {
                busUserUpdateResModel.IsSuccess = false;
                busUserUpdateResModel.AddCount = 0;
                busUserUpdateResModel.baseViewModel.Message = "更新失败";
                busUserUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("修改用户缴费订单信息失败");
                return Ok(busUserUpdateResModel);
            }
        }


        /// <summary>
        /// 查询用户缴费订单信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusUserSearchResModel> Bus_Payment_Order_Search(Bus_Payment_OrderSearchViewModel  bus_Payment_OrderSearchViewModel)
        {
            Bus_Payment_OrderSearchResModel  bus_Payment_OrderSearchResModel = new Bus_Payment_OrderSearchResModel();
            var BusUserSearchResult = _IBusUserService.Bus_Payment_Order_Search(bus_Payment_OrderSearchViewModel);
        
            var TotalNum = _IBusUserService.Bus_Payment_Order_Get_ALLNum(bus_Payment_OrderSearchViewModel);
            bus_Payment_OrderSearchResModel.bus_Payment_Orders = BusUserSearchResult;
            bus_Payment_OrderSearchResModel.isSuccess = true;
            bus_Payment_OrderSearchResModel.baseViewModel.Message = "查询成功";
            bus_Payment_OrderSearchResModel.baseViewModel.ResponseCode = 200;
            bus_Payment_OrderSearchResModel.TotalNum = TotalNum;
            _ILogger.Information("查询用户缴费订单信息成功");
            return Ok(bus_Payment_OrderSearchResModel);
        }

        /// <summary>
        /// 根据表单ID查询订单下所有用户缴费详细信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<Bus_Payment_OrderSearchResModel> Bus_Payment_Order_BySearch(Bus_OrderByRepairsIdSearchViewModel bus_OrderByRepairsIdSearchViewModel)
        {
            Bus_OrderByRepairsSearchResModel  bus_OrderByRepairsSearchResModel = new Bus_OrderByRepairsSearchResModel();
            var BusUserSearchResult = _IBusUserService.Bus_Payment_Order_BySearch(bus_OrderByRepairsIdSearchViewModel);
            bus_OrderByRepairsSearchResModel.bus_Payment_OrderSearchMiddle = BusUserSearchResult;
            bus_OrderByRepairsSearchResModel.isSuccess = true;
            bus_OrderByRepairsSearchResModel.baseViewModel.Message = "查询成功";
            bus_OrderByRepairsSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据表单ID查询订单下所有用户缴费详细信息成功");
            return Ok(bus_OrderByRepairsSearchResModel);
        }


        /// <summary>
        /// 根据用户ID查询订单和缴费人员信息信息（局务列表）
        /// </summary>
        /// <param name="bus_OrderIsPassSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<Bus_Payment_OrderSearchResModel> Bus_Payment_Order_IsPassSearch(Bus_OrderIsPassSearchViewModel bus_OrderIsPassSearchViewModel)
        {
            Bus_Payment_OrderSearchResModel bus_OrderByRepairsSearchResModel = new Bus_Payment_OrderSearchResModel();
            var BusUserSearchResult = _IBusUserService.Bus_Payment_Order_SearchByUserid(bus_OrderIsPassSearchViewModel);
            var count = _IBusUserService.Bus_Payment_Order_Count(bus_OrderIsPassSearchViewModel);
            bus_OrderByRepairsSearchResModel.bus_Payment_Orders = BusUserSearchResult;
            bus_OrderByRepairsSearchResModel.isSuccess = true;
            bus_OrderByRepairsSearchResModel.TotalNum = count;
            bus_OrderByRepairsSearchResModel.baseViewModel.Message = "查询成功";
            bus_OrderByRepairsSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据表单ID查询订单和缴费人员信息信息（局务列表）成功");
            return Ok(bus_OrderByRepairsSearchResModel);
        }
        /// <summary>
        ///查询所有支付状态为2或者3的缴费列表（财务列表）
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<Bus_Payment_OrderSearchResModel> Bus_Payment_Order_CZ()
        {
            Bus_Payment_OrderSearchResModel bus_OrderByRepairsSearchResModel = new Bus_Payment_OrderSearchResModel();
            var BusUserSearchResult = _IBusUserService.Bus_Payment_Order_SearchByCZ();
            bus_OrderByRepairsSearchResModel.bus_Payment_Orders = BusUserSearchResult;
            bus_OrderByRepairsSearchResModel.isSuccess = true;
            bus_OrderByRepairsSearchResModel.baseViewModel.Message = "查询成功";
            bus_OrderByRepairsSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询所有支付状态为2或者3的缴费列表（财务列表）");
            return Ok(bus_OrderByRepairsSearchResModel);
        }

        /// <summary>
        /// 根据动态码查询用户缴费信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusUserSearchByCodeResModel> Bus_UserByCode_Search(Bus_OrderByCodeSearchViewModel bus_OrderByCodeSearchViewModel)
        {
            BusUserSearchByCodeResModel  busUserSearchByCodeResModel = new BusUserSearchByCodeResModel();
            var BusUserSearchResult = _IBusUserService.Bus_PaymentSearchByCode(bus_OrderByCodeSearchViewModel);
            busUserSearchByCodeResModel.bus_user_Info = BusUserSearchResult;
            busUserSearchByCodeResModel.isSuccess = true;
            busUserSearchByCodeResModel.baseViewModel.Message = "查询成功";
            busUserSearchByCodeResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information(" 根据动态码查询用户缴费信息成功");
            return Ok(busUserSearchByCodeResModel);
        }

        /// <summary>
        /// 根据身份证号查询用户缴费信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusUserSearchByCodeResModel> Bus_UserByIdCard_Search(Bus_OrderByIdCardSearchViewModel bus_OrderByIdCardSearchViewModel)
        {
            string Code = "无";
            BusUserSearchByCodeResModel busUserSearchByCodeResModel = new BusUserSearchByCodeResModel();
            var BusUserSearchResult = _IBusUserService.Bus_PaymentSearchByIdCard(bus_OrderByIdCardSearchViewModel);
            //if(BusUserSearchResult!=null)
            //  Code = BusUserSearchResult.Code;
            busUserSearchByCodeResModel.bus_user_Info = BusUserSearchResult;
            busUserSearchByCodeResModel.isSuccess = true;
            busUserSearchByCodeResModel.baseViewModel.Message = "查询成功";
            busUserSearchByCodeResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据身份证号查询用户缴费信息成功");
            return Ok(busUserSearchByCodeResModel);
        }
      
        /// <summary>
        ///中行缴费
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<Bank_PaymentResModel> Bank_Payment(Bank_PaymentRequestMiddle Bank_PaymentRequestMiddle)
        {

            Bank_PaymentResModel busUserSearchByCodeResModel = new Bank_PaymentResModel();
            // busUserSearchByCodeResModel.ip = this.httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var BusUserSearchResult = _IBusUserService.Bank_Payment(Bank_PaymentRequestMiddle);
            if (BusUserSearchResult.hdlSts == "A")
            {
                busUserSearchByCodeResModel.baseViewModel.Message = "中行缴费成功";
                _ILogger.Information("中行缴费成功");
                busUserSearchByCodeResModel.bank_PaymentMiddle = BusUserSearchResult;
                busUserSearchByCodeResModel.isSuccess = true;
                busUserSearchByCodeResModel.baseViewModel.ResponseCode = 200;
            }
            else
            {
                busUserSearchByCodeResModel.baseViewModel.Message = "中行缴费失败";
                _ILogger.Information("中行缴费失败");
                busUserSearchByCodeResModel.bank_PaymentMiddle = BusUserSearchResult;
                busUserSearchByCodeResModel.isSuccess = false;
                busUserSearchByCodeResModel.baseViewModel.ResponseCode = 400;
            }
            return Ok(busUserSearchByCodeResModel);
        }
        /// <summary>
        ///中行缴费查询
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<Bank_Payment_SearchResModel> Bank_Payment_Search(Bank_PaymentRequestMiddle Bank_PaymentRequestMiddle)
        {
            Bank_Payment_SearchResModel busUserSearchByCodeResModel = new Bank_Payment_SearchResModel();
            var BusUserSearchResult = _IBusUserService.Bank_Payment_Search(Bank_PaymentRequestMiddle);

            busUserSearchByCodeResModel.bank_Payment_SearchMiddle = BusUserSearchResult;
            busUserSearchByCodeResModel.isSuccess = true;
            busUserSearchByCodeResModel.baseViewModel.Message = "中行缴费查询信息成功";
            busUserSearchByCodeResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("中行缴费查询信息成功");
            return Ok(busUserSearchByCodeResModel);
        }


        /// <summary>
        ///中行退款
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<Bank_Payment_SearchResModel> Bank_Payment_Refund(Bank_PaymentRequestMiddle Bank_PaymentRequestMiddle)
        {
            Bank_Payment_SearchResModel busUserSearchByCodeResModel = new Bank_Payment_SearchResModel();
            var BusUserSearchResult = _IBusUserService.Bank_Payment_Refund(Bank_PaymentRequestMiddle);

            busUserSearchByCodeResModel.bank_Payment_RefundMiddle = BusUserSearchResult;
            busUserSearchByCodeResModel.isSuccess = true;
            busUserSearchByCodeResModel.baseViewModel.Message = "中行缴费退款信息成功";
            busUserSearchByCodeResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("中行缴费退款信息成功");
            return Ok(busUserSearchByCodeResModel);
        }



        /// <summary>
        ///校验设备码与二维码是否匹配
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<CheckCodeResModel> uploadCode(CheckCodeSearchViewModel checkCodeSearchViewModel)
        {
            CheckCodeResModel  checkCodeResModel = new CheckCodeResModel();
            var Result = _IBusUserService.CheckCode(checkCodeSearchViewModel);
            if(Result=="0")
            {
                checkCodeResModel.code = "0";
                checkCodeResModel.msg = "通过";
                _ILogger.Information("校验设备码与二维码通过");
            }
            else if(Result == "1")
            {
                checkCodeResModel.code = "1";
                checkCodeResModel.msg = "不通过";
                _ILogger.Information("校验设备码与二维码不通过,二维码已失效");
            }
            else if (Result == "2")
            {
                checkCodeResModel.code = "2";
                checkCodeResModel.msg = "不通过";
                _ILogger.Information("校验设备码与二维码不通过，乘车线路不符");
            }
            else if (Result == "3")
            {
                checkCodeResModel.code = "3";
                checkCodeResModel.msg = "不通过";
                _ILogger.Information("校验设备码与二维码不通过，二维码已使用");
            }
            else
            {
                checkCodeResModel.code = "4";
                checkCodeResModel.msg = "不通过";
                _ILogger.Information("校验设备码与二维码不通过，系统异常");
            }

            return Ok(checkCodeResModel);
        }



        /// <summary>
        ///更新订单表支付状态
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<CheckCodeResModel> Update_Bank_Payment_Order(Bank_PaymentRequestMiddle Bank_PaymentRequestMiddle)
        {
            BusUserUpdateResModel busUserUpdateResModel = new BusUserUpdateResModel();
            int UpdateRowNum = _IBusUserService.Update_Bank_Payment_Order(Bank_PaymentRequestMiddle);
    
            if (UpdateRowNum > 0)
            {
                busUserUpdateResModel.IsSuccess = true;
                busUserUpdateResModel.AddCount = UpdateRowNum;
                busUserUpdateResModel.baseViewModel.Message = "更新成功";
                busUserUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("修改订单表支付状态信息成功");
                return Ok(busUserUpdateResModel);
            }
            else
            {
                busUserUpdateResModel.IsSuccess = false;
                busUserUpdateResModel.AddCount = 0;
                busUserUpdateResModel.baseViewModel.Message = "更新失败";
                busUserUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("修改订单表支付状态信息失败");
                return Ok(busUserUpdateResModel);
            }

        }



        /// <summary>
        ///根据订单ID 更新班车动态码
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<CheckCodeResModel> Bus_PaymentSearchByOrderId(Bus_OrderByOrderIdSearchViewModel bus_OrderByOrderIdSearchViewModel)
        {
            BusUserUpdateResModel busUserUpdateResModel = new BusUserUpdateResModel();
            int UpdateRowNum = _IBusUserService.Bus_PaymentSearchByOrderId(bus_OrderByOrderIdSearchViewModel);

            if (UpdateRowNum > 0)
            {
                busUserUpdateResModel.IsSuccess = true;
                busUserUpdateResModel.AddCount = UpdateRowNum;
                busUserUpdateResModel.baseViewModel.Message = "更新成功";
                busUserUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据订单ID，更新班车动态码成功");
                return Ok(busUserUpdateResModel);
            }
            else
            {
                busUserUpdateResModel.IsSuccess = false;
                busUserUpdateResModel.AddCount = 0;
                busUserUpdateResModel.baseViewModel.Message = "更新失败";
                busUserUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("根据订单ID，更新班车动态码失败");
                return Ok(busUserUpdateResModel);
            }

        }




        /// <summary>
        ///增加班车位置信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<CheckCodeResModel> BusLocationInformation_Add(BusLocationInformationAddViewModel busLocationInformationAddViewModel)
        {

            
            var temp = _IBusLocationInformationService.BusLocationInformation_Add(busLocationInformationAddViewModel);
            CheckCodeResModel checkCodeResModel = new CheckCodeResModel();
            if (temp == 0)
            {
                checkCodeResModel.code = "0";
                checkCodeResModel.msg = "成功";
                _ILogger.Information("增加班车位置信息成功");
                return Ok(checkCodeResModel);
            }
            else if(temp ==1)
            {
                checkCodeResModel.code = "1";
                checkCodeResModel.msg = "失败,时间段不符合";
                _ILogger.Information("增加班车位置信息失败,时间段不符合");
                return Ok(checkCodeResModel);
            }
            else if (temp == 2)
            {
                checkCodeResModel.code = "2";
                checkCodeResModel.msg = "失败,找不到设备号";
                _ILogger.Information("增加班车位置信息失败,找不到设备号");
                return Ok(checkCodeResModel);
            }
            else
            {
                checkCodeResModel.code = "3";
                checkCodeResModel.msg = "失败,系统异常";
                _ILogger.Information("增加班车位置信息失败,系统异常");
                return Ok(checkCodeResModel);
            }

        }

        /// <summary>
        /// 根据条件查询扫码记录
        /// </summary>
        /// <param name="busScanRecordSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusScanRecordSearchResModel> Bus_Scan_Record_Search(BusScanRecordSearchViewModel busScanRecordSearchViewModel)
        {
            BusScanRecordSearchResModel  busScanRecordSearchResModel = new BusScanRecordSearchResModel();
            var Result = _IBusUserService.Bus_Scan_Record_Search(busScanRecordSearchViewModel);

            int count = _IBusUserService.Bus_Scan_Record_SearchNum(busScanRecordSearchViewModel);
            if (Result.Count!=0)
            {
                busScanRecordSearchResModel.count = count;
                busScanRecordSearchResModel.bus_Scan_Record = Result;
                busScanRecordSearchResModel.isSuccess = true;
                busScanRecordSearchResModel.baseViewModel.Message = "根据条件查询扫码记录成功";
                busScanRecordSearchResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据条件查询扫码记录成功");
            }
            else 
            {
                busScanRecordSearchResModel.count = 0;
                busScanRecordSearchResModel.isSuccess = false;
                busScanRecordSearchResModel.baseViewModel.Message = "根据条件查询扫码记录成功";
                busScanRecordSearchResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("中行缴费查询信息成功");
            }               
            return Ok(busScanRecordSearchResModel);
        }



        /// <summary>
        /// 导出（月票信息）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string ExportToExcel(BusPaymentSearchViewModel  busPaymentSearchViewModel)
        {
            byte[] filecontent;
            var busUserSearchResult = _IBusUserService.BusUserTongJiExcept_Search(busPaymentSearchViewModel);

            string[] columns = { "UserName", "LineName", "StationName", "orderNo", "carDateStr", "Name", "Expense" };        
            filecontent = _IBusUserService.ExportExcel1<BusUserTongJiExceptSearchMiddle>(busUserSearchResult, "", 1, false, columns);
            string path = "";
            try
            {  //获取上传案例图片路径     

                string sj = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                path = "C://SystemFormal/BusFormal/ExportExcelFiles/";   //服务器路径C:\SystemFormal\BusFormal
                //path = "D://客户临时文件/ExportExcelFiles/";   //服务器路径C:\SystemFormal\BusFormal
                
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //定义实际文件对象，保存上载的文件。    
                //文件流的写入
                path = path + sj + "_导出月票列表.xlsx";
                System.IO.File.WriteAllBytes(@"" + path + "", filecontent);
                string filename = sj + "_导出月票列表.xlsx";
                return filename;
             
            }
            catch (Exception ex)
            {
                return "";
            }

        }


        /// <summary>
        /// 导出（用车信息）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string ExportToOrderCar(UseCarSelReqViewModel  useCarSelReqViewModel)
        {
            byte[] filecontent;
            var busOrderSearchResult = _IBusUserService.UserCarSel(useCarSelReqViewModel);
          
         
            string[] columns = { "jdfs", "nigaodanwei", "nigaoren", "hyjylx", "djbh", "spzt","yylb","title", "docdate", "status" };
            filecontent = _IBusUserService.ExportExcel3<UseCarSelResMiddle>(busOrderSearchResult, "", 3, false, columns);
            string path = "";
            try
            {  //获取上传案例图片路径     

                string sj = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                  path = "C://SystemFormal/BusFormal/ExportExcelFiles/";   //服务器路径C:\SystemFormal\BusFormal
                 //   path = "D://客户临时文件/ExportExcelFiles/";                                                          
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //定义实际文件对象，保存上载的文件。    
                //文件流的写入
                path = path + sj + "_导出订单列表.xlsx";
                System.IO.File.WriteAllBytes(@"" + path + "", filecontent);
                string filename = sj + "_导出订单列表.xlsx";


                return filename;

            }
            catch (Exception ex)
            {
                return "";
            }

        }

        /// <summary>
        /// 文件下载（导出月票信息）
        /// </summary>
        /// <param name="Physicsname"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult downloadGetNew(string Physicsname, string filename)
        {
            try
            {
                String filePath = Directory.GetCurrentDirectory() + "\\ExportExcelFiles\\" + Physicsname;
                FileStream fs = new FileStream(filePath, FileMode.Open);
                return File(fs, "application/vnd.android.package-archive", filename);
            }
            catch (Exception ex)
            {
                return NotFound("文件下载错误");
            }
        }


        /// <summary>
        /// 导出（订单信息）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string ExportToExcel2(BusOrderSearchViewModel  busOrderSearchViewModel)
        {
            byte[] filecontent;
            var busOrderSearchResult = _IBusUserService.Bus_Payment_Order_SearchExcel(busOrderSearchViewModel);

            string[] columns = { "orderNo", "departName", "AddDateStr", "orderAmount" };
            filecontent = _IBusUserService.ExportExcel2<BusOrderExcelSearchMiddle>(busOrderSearchResult, "", 2, false, columns);
            string path = "";
            try
            {  //获取上传案例图片路径     

                string sj = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                path = "C://SystemFormal/BusFormal/ExportExcelFiles/";   //服务器路径C:\SystemFormal\BusFormal
               // path = "D://客户临时文件/ExportExcelFiles/";                                                          
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //定义实际文件对象，保存上载的文件。    
                //文件流的写入
                path = path + sj + "_导出订单列表.xlsx";
                System.IO.File.WriteAllBytes(@"" + path + "", filecontent);
                string filename = sj + "_导出订单列表.xlsx";

              
                return filename;

            }
            catch (Exception ex)
            {
                return "";
            }

        }



        /// <summary>
        /// 根据条件查询车辆经纬度
        /// </summary>
        /// <param name="busLocationInformationSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusLocationInformationSearchResModel> BusLocationInformation_Search(BusLocationInformationSearchViewModel busLocationInformationSearchViewModel)
        {
            BusLocationInformationSearchResModel  busLocationInformationSearchResModel = new BusLocationInformationSearchResModel();
            var Result = _IBusLocationInformationService.BusLocationInformation_Search(busLocationInformationSearchViewModel);

          
            if (Result== null)
            {
              
                busLocationInformationSearchResModel.isSuccess = false;
                busLocationInformationSearchResModel.baseViewModel.Message = "根据条件查询车辆经纬度成功，查询结果为空";
                busLocationInformationSearchResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据条件查询车辆经纬度成功，查询结果为空");
            }
            else
            {
                busLocationInformationSearchResModel.busLocationInformationSearchMiddle = Result;
                busLocationInformationSearchResModel.isSuccess = true;
                busLocationInformationSearchResModel.baseViewModel.Message = "根据条件查询车辆经纬度成功";
                busLocationInformationSearchResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据条件查询车辆经纬度成功");
            }
            return Ok(busLocationInformationSearchResModel);
        }


        /// <summary>
        /// 根据条件查询车辆基本信息
        /// </summary>
        /// <param name="busLocationInformationSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusBasicSearchResModel> BusBasic_Search(BusLocationInformationSearchViewModel busLocationInformationSearchViewModel)
        {
            BusBasicSearchResModel  busBasicSearchResModel = new BusBasicSearchResModel();
            var Result = _IBusLocationInformationService.BusBasic_Search(busLocationInformationSearchViewModel);
            if (Result == null)
            {

                busBasicSearchResModel.isSuccess = false;
                busBasicSearchResModel.baseViewModel.Message = "根据条件查询车辆基本信息成功，查询结果为空";
                busBasicSearchResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据条件查询车辆基本信息成功，查询结果为空");
            }
            else
            {
                busBasicSearchResModel.busBasicSearchMiddle = Result;
                busBasicSearchResModel.isSuccess = true;
                busBasicSearchResModel.baseViewModel.Message = "根据条件查询车辆基本信息成功";
                busBasicSearchResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据条件查询车辆基本信息成功");
            }
            return Ok(busBasicSearchResModel);
        }



        /// <summary>
        /// 根据条件查询扫码记录(统计)
        /// </summary>
        /// <param name="busScanRecordTongJiSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusScanRecordSearchResModel> Bus_Scan_Record_SearchTongJi(BusScanRecordTongJiSearchViewModel busScanRecordTongJiSearchViewModel)
        {
            BusScanRecordTongJiSearchResModel  busScanRecordTongJiSearchResModel = new BusScanRecordTongJiSearchResModel();
            var Result = _IBusUserService.Bus_Scan_Record_SearchTongJi(busScanRecordTongJiSearchViewModel);

            if (Result.Count != 0)
            {
                busScanRecordTongJiSearchResModel.bus_Scan_Record = Result;
                busScanRecordTongJiSearchResModel.isSuccess = true;
                busScanRecordTongJiSearchResModel.baseViewModel.Message = "根据条件查询扫码记录(统计)成功";
                busScanRecordTongJiSearchResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据条件查询扫码记录(统计)成功");
            }
            else
            {             
                busScanRecordTongJiSearchResModel.isSuccess = false;
                busScanRecordTongJiSearchResModel.baseViewModel.Message = "根据条件查询扫码记录(统计)成功";
                busScanRecordTongJiSearchResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据条件查询扫码记录(统计)成功");
            }
            return Ok(busScanRecordTongJiSearchResModel);
        }

        /// <summary>
        /// 查询16个部门的已用里程和剩余里程
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<SearchCarMileageResModel> SearchCarMileage(BusCarLiChengSearchViewModel  busCarLiChengSearchViewModel)
        {
            SearchCarMileageResModel  searchCarMileageResModel = new SearchCarMileageResModel();
            var searchCarMileageMiddles = _IBusUserService.SearchCarMileage(busCarLiChengSearchViewModel.jdfs);
            if (searchCarMileageMiddles != null)
            {
                searchCarMileageResModel.isSuccess = true;
                searchCarMileageResModel.searchCarMileageMiddles = searchCarMileageMiddles;
                searchCarMileageResModel.baseViewModel.Message = "查询16个部门的已用里程和剩余里程成功";
                searchCarMileageResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("查询16个部门的已用里程和剩余里程成功");
                return Ok(searchCarMileageResModel);
            }
            else
            {
                searchCarMileageResModel.isSuccess = false;
                searchCarMileageResModel.baseViewModel.Message = "查询16个部门的已用里程和剩余里程失败";
                searchCarMileageResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("查询16个部门的已用里程和剩余里程失败");
                return Ok(searchCarMileageResModel);
            }

        }

        /// <summary>
        /// 查询当前年份，当前用车类型的各部门的用车趋势
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<SearchCarMileageResModel> CarTrend(CarTrendSearchViewModel  carTrendSearchViewModel)
        {
            SearchCarMileageResModel searchCarMileageResModel = new SearchCarMileageResModel();
            var CarTrendMiddles = _IBusUserService.CarTrend(carTrendSearchViewModel.jdfs, carTrendSearchViewModel.docDate);
            if (CarTrendMiddles != "异常")
            {
                searchCarMileageResModel.isSuccess = true;
                searchCarMileageResModel.searchCarMileageMiddles = CarTrendMiddles;
                searchCarMileageResModel.baseViewModel.Message = "查询当前年份，当前用车类型的各部门的用车趋势成功";
                searchCarMileageResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("查询当前年份，当前用车类型的各部门的用车趋势成功");
                return Ok(searchCarMileageResModel);
            }
            else
            {
                searchCarMileageResModel.isSuccess = false;
                searchCarMileageResModel.baseViewModel.Message = "查询当前年份，当前用车类型的各部门的用车趋势失败";
                searchCarMileageResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("查询当前年份，当前用车类型的各部门的用车趋势失败");
                return Ok(searchCarMileageResModel);
            }

        }



        /// <summary>
        /// 查询当前年份，当前用车类型的各部门的日均派车量
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<SearchCarMileageResModel> AverageDailyDispatch(CarTrendSearchViewModel carTrendSearchViewModel)
        {
            SearchCarMileageResModel searchCarMileageResModel = new SearchCarMileageResModel();
            var CarTrendMiddles = _IBusUserService.AverageDailyDispatch(carTrendSearchViewModel.jdfs, carTrendSearchViewModel.docDate);
            if (CarTrendMiddles != "异常")
            {
                searchCarMileageResModel.isSuccess = true;
                searchCarMileageResModel.searchCarMileageMiddles = CarTrendMiddles;
                searchCarMileageResModel.baseViewModel.Message = "查询当前年份，当前用车类型的各部门的日均派车量成功";
                searchCarMileageResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("查询当前年份，当前用车类型的各部门的日均派车量成功");
                return Ok(searchCarMileageResModel);
            }
            else
            {
                searchCarMileageResModel.isSuccess = false;
                searchCarMileageResModel.baseViewModel.Message = "查询当前年份，当前用车类型的各部门的日均派车量失败";
                searchCarMileageResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("查询当前年份，当前用车类型的各部门的日均派车量败");
                return Ok(searchCarMileageResModel);
            }

        }


        /// <summary>
        /// 修改免费坐车人员的乘车时间
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusUserUpdateResModel> Bus_User_Update_Status()
        {
            BusUserUpdateResModel busUserUpdateResModel = new BusUserUpdateResModel();
            int UpdateRowNum = _IBusUserService.Bus_User_Update_Status();

            if (UpdateRowNum > 0)
            {
                busUserUpdateResModel.IsSuccess = true;
                busUserUpdateResModel.AddCount = UpdateRowNum;
                busUserUpdateResModel.baseViewModel.Message = "更新成功";
                busUserUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information(" 修改免费坐车人员的乘车时间成功");
                return Ok(busUserUpdateResModel);
            }
            else
            {
                busUserUpdateResModel.IsSuccess = false;
                busUserUpdateResModel.AddCount = 0;
                busUserUpdateResModel.baseViewModel.Message = "更新失败";
                busUserUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information(" 修改免费坐车人员的乘车时间失败");
                return Ok(busUserUpdateResModel);
            }
        }



        /// <summary>
        ///  查询一般公务和执法执勤车辆实时占用情况
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<BusBasicSearchResModel> CarOccupySel(CarOccupyRequestModel carOccupyRequestModel)
        {
            CarOccupyResModel  carOccupyResModel = new CarOccupyResModel();
            var Result = _IBusUserService.CarOccupySel(carOccupyRequestModel);
            if (Result.Count==0)
            {
                carOccupyResModel.isSuccess = false;
                carOccupyResModel.baseViewModel.Message = " 查询一般公务和执法执勤车辆实时占用情况成功，查询结果为空";
                carOccupyResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("查询一般公务和执法执勤车辆实时占用情况成功，查询结果为空");
            }
            else
            {
                carOccupyResModel.carOccupyMiddles = Result;
                carOccupyResModel.isSuccess = true;
                carOccupyResModel.baseViewModel.Message = " 查询一般公务和执法执勤车辆实时占用情况成功";
                carOccupyResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("查询一般公务和执法执勤车辆实时占用情况成功");
            }
            return Ok(carOccupyResModel);
        }





    }


}