using AutoMapper;
using Dto.IRepository.IntellOpinionInfo;
using Dto.IRepository.IntellRegularBus;
using Dto.IRepository.IntellRepair;
using Dto.IRepository.IntellUser;
using Dto.IService.IntellRegularBus;
using Dtol.dtol;
using Microsoft.AspNetCore.Http;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel;
using ViewModel.BusViewModel.RequestViewModel.BusUserViewModel;
using ViewModel.BusViewModel.ResponseModel.BusUserResModel;
using ViewModel.OpinionInfoViewModel.MiddleModel;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;
using System.Collections;
using System.Net.Http;
using System.Management;
using System.Net;
using System.Xml;
using Newtonsoft.Json;
using ViewModel.BusViewModel.RequestViewModel;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using Microsoft.Extensions.Options;

namespace Dto.Service.IntellRegularBus
{
    public class BusUserService : IBusUserService
    {

        private readonly IBusUserRepository _IBusUserRepository;
        private readonly IMapper _IMapper;
        private readonly IUserInfoRepository _IUserInfoRepository;
        private readonly IUserDepartRepository _IUserDepartRepository;
        private readonly IBusLineRepository _IBusLineRepository;
        private readonly IBusStationRepository _IBusStationRepository;
        private readonly IBusInfoRepository _IBusInfoRepository;
        private readonly IRepairInfoRepository _IRepairInfoRepository;
        private readonly IFlowProcedureInfoRepository _IFlowProcedureInfoRepository;
        private readonly IFlowNodeDefineInfoRepository _IFlowNodeDefineInfoRepository;
        private readonly IBusPaymentOrderRepository _IBusPaymentOrderRepository;
        private readonly IOpinionInfoRepository _IOpinionInfoRepository;
        private readonly IBusScanRecordRepository _IBusScanRecordRepository;
        //  private readonly IHttpClientFactory _httpClientFactory;
        //private IOptions<Bus_Payment_Order_Add> _IOptions;
        //private IOptions<Bus_Payment_Date> _IOptions2;
        private Bus_Payment_Date _IOptions2 { get; set; }
        private Bus_Payment_Order_Add _IOptions { get; set; }
        public BusUserService(IBusUserRepository busUserRepository ,
                                IBusInfoRepository busInfoRepository,
                                IMapper mapper, 
                                IUserInfoRepository userInfoRepository,
                                IUserDepartRepository userDepartRepository, 
                                IBusLineRepository busLineRepository,
                                IBusStationRepository busStationRepository,
                                IFlowProcedureInfoRepository iflowProcedureInfoRepository,
                                IFlowNodeDefineInfoRepository iflowNodeDefineInfoRepository,
                                IRepairInfoRepository irepairInfoRepository,
                                IOpinionInfoRepository opinionInfoRepository,
                                IBusPaymentOrderRepository ibusPaymentOrderRepository,
                                IBusScanRecordRepository busScanRecordRepository,
                                IOptions<Bus_Payment_Date> settings2,
                                IOptions<Bus_Payment_Order_Add> settings
                              )
                             
        {
            _IBusUserRepository = busUserRepository;
            _IMapper = mapper;
            _IUserInfoRepository = userInfoRepository;
            _IUserDepartRepository = userDepartRepository;
            _IBusLineRepository = busLineRepository;
            _IBusStationRepository = busStationRepository;
            _IBusInfoRepository = busInfoRepository;
            _IRepairInfoRepository = irepairInfoRepository;
            _IFlowProcedureInfoRepository = iflowProcedureInfoRepository;
            _IFlowNodeDefineInfoRepository = iflowNodeDefineInfoRepository;
            _IBusPaymentOrderRepository = ibusPaymentOrderRepository;
            _IRepairInfoRepository = irepairInfoRepository;
            _IOpinionInfoRepository = opinionInfoRepository;
            _IBusScanRecordRepository = busScanRecordRepository;
            //  _httpClientFactory = httpClientFactory;
            _IOptions = settings.Value;
            _IOptions2 = settings2.Value;
        }

        /// <summary>
        /// 添加缴费信息
        /// </summary>
        /// <param name="busUserAddViewModel"></param>
        /// <returns></returns>
        public int Bus_User_Add(BusUserAddViewModel busUserAddViewModel)
        {
            //string RandName = GetUserHead(busUserAddViewModel.formFile);//头像名
            //RandName = "E://东疆智慧后勤/IntellRegularBus/HeadImg/" + RandName;//头像存储路径
            //busUserAddViewModel.Userpicture = RandName;
            var bus_Info = _IMapper.Map<BusUserAddViewModel, Bus_Payment>(busUserAddViewModel);
            _IBusUserRepository.Add(bus_Info);
            return _IBusUserRepository.SaveChanges();
        }


   
        /// <summary>
        /// 获得头像名称
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        public string GetUserHead(IFormFile formFile)
        {
            string filePath = "";//上传文件的路径
            string RandName = "";
            string[] fileTail = formFile.FileName.Split('.');
            RandName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + fileTail[1];
            filePath = "E://东疆智慧后勤/IntellRegularBus/HeadImg/" + RandName;
            if (formFile.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            return RandName;
        }
        public int Bus_User_Delete(BusUserDelViewModel busDelViewModel)
        {
            int DeleteRowsNum = _IBusUserRepository
                  .DeleteByBusUserIdList(busDelViewModel.DeleleIdList);
            if (DeleteRowsNum == busDelViewModel.DeleleIdList.Count)
            {
                return DeleteRowsNum;
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// 更新单条人员缴费信息
        /// </summary>
        /// <param name="busUserUpdateViewModel"></param>
        /// <returns></returns>
        public int Bus_User_Update(BusUserUpdateViewModel busUserUpdateViewModel)
        {
            var bus_user_Info = _IBusUserRepository.GetInfoByBusUserId(busUserUpdateViewModel.Id);
            var bus_user_Info_update = _IMapper.Map<BusUserUpdateViewModel, Bus_Payment>(busUserUpdateViewModel, bus_user_Info);
            _IBusUserRepository.Update(bus_user_Info_update);
            return _IBusUserRepository.SaveChanges();
        }


        /// <summary>
        /// 校验名单里是否存在已缴费人员
        /// </summary>
        /// <param name="busPamentUpdateViewModel"></param>
        /// <returns></returns>
        public string Bus_PayMent_Update_Verification(BusPaymentUpdateViewModel busPamentUpdateViewModel)
        {
            List<Bus_Payment> bus_user_Info = _IBusUserRepository.SearchInfoByBusWhere(busPamentUpdateViewModel).ToList();
        
            for (int i = 0; i < bus_user_Info.Count; i++)
            {
               if(bus_user_Info[i].Bus_Payment_OrderId!=null)
               {
                    return bus_user_Info[i].UserName;
               }
            
            }
           
            return "true";
        }



        /// <summary>
        /// 更新人员缴费信息表单id列，将班车缴费表和流程表单id绑定
        /// </summary>
        /// <param name="busPamentUpdateViewModel"></param>
        /// <returns></returns>
        public int Bus_PayMent_Update(BusPaymentUpdateViewModel busPamentUpdateViewModel)
        {
            List<Bus_Payment> bus_user_Info = _IBusUserRepository.SearchInfoByBusWhere(busPamentUpdateViewModel).ToList();
            Double TotalExpen = 0;
            for (int i=0; i< bus_user_Info.Count;i++)
            {
              var temp=_IMapper.Map<BusPaymentUpdateViewModel, Bus_Payment>(busPamentUpdateViewModel, bus_user_Info[i]);
                _IBusUserRepository.Update(temp);
                TotalExpen += Convert.ToDouble(bus_user_Info[i].Expense);//当前条件下，每个人应交费用总和
            }
            _IBusUserRepository.SaveChanges();
            Bus_Payment_Order bus_Payment_Order =_IBusPaymentOrderRepository.GetInfoByBusPaymentOrderId(busPamentUpdateViewModel.Bus_Payment_OrderId);
            bus_Payment_Order.orderAmount = TotalExpen.ToString();
           _IBusPaymentOrderRepository.Update(bus_Payment_Order);
            return _IBusPaymentOrderRepository.SaveChanges();
        }

        ///// <summary>
        /////  根据以前某月的缴费信息，生成当前月的缴费信息
        ///// </summary>
        ///// <param name="busUserSearchViewModel"></param>
        ///// <returns></returns>
        //public int Bus_PayMent_Verification(BusUserSearchViewModel busUserSearchViewModel)
        //{
        //    List<Bus_Payment> bus_Payments = _IBusUserRepository.SearchInfoByBusWhere(busUserSearchViewModel).ToList();

        //}

        /// <summary>
        ///  校验一条数据，是否存在
        /// </summary>
        /// <param name="busUserSearchViewModel"></param>
        /// <returns></returns>
        public int Bus_PayMent_Single_Verification(SearchByIdCardAndCarDateViewModel  searchByIdCardAndCarDateViewModel)
        {

            var result = _IBusUserRepository.SearchInfoByDateAndIdWhere(searchByIdCardAndCarDateViewModel);
            if (result.Count > 0)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// 验证线路是否坐满人
        /// </summary>
        /// <param name="busUserSearchViewModel"></param>
        /// <returns></returns>
        public string Bus_PayMent_Verification(BusUserSearchByDeaprtIdViewModel busUserSearchByDeaprtIdViewModel)
        {

            List<Bus_Payment> bus_Payments = _IBusUserRepository.SearchInfoByBusWhere2(busUserSearchByDeaprtIdViewModel).ToList();
 
                List<int> bus_lineId = _IBusUserRepository.SearchInfoByBusDistinctWhere2(busUserSearchByDeaprtIdViewModel);
            BusSearchByIdViewModel busSearchByIdViewModel = new BusSearchByIdViewModel();
            for (int i = 0; i < bus_lineId.Count; i++)//检查线路是否坐满
            {
                int b = bus_Payments.Where(c => c.Bus_LineId == bus_lineId[i]).Count();
                busSearchByIdViewModel.Bus_LineId = bus_lineId[i];
                busSearchByIdViewModel.carDate = DateTime.Now.AddMonths(1);
                int a = ByBusIdSearchNum2(busSearchByIdViewModel, b);

                if (a == -1)
                {
                    var e = bus_Payments.Where(d => d.Bus_LineId == bus_lineId[i]).ToList();
                    return e[0].LineName;
                }

            }
            return "true";
        }


        /// <summary>
        ///  根据以前某月的缴费信息，生成当前月的缴费信息
        /// </summary>
        /// <param name="busUserSearchViewModel"></param>
        /// <returns></returns>
        public int Bus_PayMent_Template(BusUserSearchViewModel busUserSearchViewModel)
        {
            List<Bus_Payment> bus_Payments = _IBusUserRepository.SearchInfoByBusWhere4(busUserSearchViewModel).ToList();

            for (int i = 0; i < bus_Payments.Count; i++)
            {
                SearchByIdCardAndCarDateViewModel searchByIdCardAndCarDateViewModel = new SearchByIdCardAndCarDateViewModel();
                // searchByIdCardAndCarDateViewModel.carDate = bus_Payments[i].carDate.Value.AddMonths(1); 
                searchByIdCardAndCarDateViewModel.carDate = DateTime.Now.AddMonths(1);//当前年月
                searchByIdCardAndCarDateViewModel.IDNumber = bus_Payments[i].IDNumber;
               var result=  _IBusUserRepository.SearchInfoByDateAndIdWhere(searchByIdCardAndCarDateViewModel);
                if(result.Count>0)
                {
                    bus_Payments.Remove(bus_Payments[i]);

                }

            }

              //  List<int>   bus_lineId=_IBusUserRepository.SearchInfoByBusDistinctWhere(busUserSearchViewModel);
            //先以之前的月份为模板进行添加
            List <BusUserAddViewModel> busUserAddViewModel = new List<BusUserAddViewModel>();

           // BusSearchByIdViewModel busSearchByIdViewModel = new BusSearchByIdViewModel();
  
            //for (int i = 0; i < bus_lineId.Count; i++)//检查线路是否坐满
            //{
            //    int b = bus_Payments.Where(c => c.Bus_LineId == bus_lineId[i]).Count();
            //    busSearchByIdViewModel.Bus_LineId = bus_lineId[i];
            //    busSearchByIdViewModel.carDate = DateTime.Now.AddMonths(1);
            //    int a=  ByBusIdSearchNum2(busSearchByIdViewModel, b);
            
            //    if (a == -1)
            //    {
            //        var e = bus_Payments.Where(d => d.Bus_LineId == bus_lineId[i]).ToList();
            //        return e[0].LineName;
            //    }

            //}
            for (int j = 0; j < bus_Payments.Count; j++)
            {
              
               
                var bus_Info = _IMapper.Map<Bus_Payment, BusUserAddViewModel>(bus_Payments[j]);//把查询结果中的主键列去掉
                busUserAddViewModel.Add(bus_Info);
            }
            //按照模板添加后，更新日期为当前年份和月份
            NowDateUpdateViewModel nowDateUpdateViewModel = new NowDateUpdateViewModel();
            nowDateUpdateViewModel.carDate = DateTime.Now.AddMonths(1);//当前年月
            nowDateUpdateViewModel.Bus_Payment_OrderId = null;
            nowDateUpdateViewModel.Repair_InfoId = null;
            for (int i=0;i< bus_Payments.Count;i++)
            {
         
                var bus_user_Info = _IMapper.Map<NowDateUpdateViewModel, BusUserAddViewModel>(nowDateUpdateViewModel, busUserAddViewModel[i]);
                var Bus_Payment = _IMapper.Map<BusUserAddViewModel, Bus_Payment>(busUserAddViewModel[i]);
                _IBusUserRepository.Add(Bus_Payment);
               
            }

            return _IBusUserRepository.SaveChanges();
        }
        /// <summary>
        ///  查询出所有时间
        /// </summary>
        /// <param name="busUserSearchViewModel"></param>
        /// <returns></returns>
        public List<string> Bus_User_TimeList_Search(BusUserSearchTimeViewModel busUserSearchTimeViewModel)
        {
       
            List<string> bus_Payments = _IBusUserRepository.SearchInfoTimeWhere(busUserSearchTimeViewModel).ToList();
            return bus_Payments;
        }
        /// <summary>
        ///  查询出人员缴费信息
        /// </summary>
        /// <param name="busUserSearchViewModel"></param>
        /// <returns></returns>
        public List<BusUserSearchMiddlecs> Bus_User_Search(BusUserSearchViewModel busUserSearchViewModel)
        {
            BusUserSearchMiddlecs busUserSearchMiddlecs = new BusUserSearchMiddlecs();

            List<Bus_Payment> bus_Payments  =  _IBusUserRepository.SearchInfoByBusWhere(busUserSearchViewModel).ToList();

            var bus_User_Search = _IMapper.Map<List<Bus_Payment>, List<BusUserSearchMiddlecs>>(bus_Payments); 

            return bus_User_Search;
        }
        /// <summary>
        /// 查询当前条件下所有人的缴费总和
        /// </summary>
        /// <param name="busUserSearchViewModel"></param>
        /// <returns></returns>
        public Double Bus_UserExpen_Search(BusUserSearchViewModel busUserSearchViewModel)
        {
            List<Bus_Payment> bus_Payments = _IBusUserRepository.SearchInfoByBusWhere(busUserSearchViewModel).ToList();
            Double TotalExpen = 0;
            for (int i = 0; i < bus_Payments.Count; i++)
            {
                TotalExpen += Convert.ToDouble(bus_Payments[i].Expense);//当前条件下，每个人应交费用总和
            }
            return TotalExpen;
        }
        /// <summary>
        /// 查询班车缴费清单表
        /// </summary>
        /// <param name="busUserSearchViewModell"></param>
        /// <returns></returns>
        public int Bus_User_Get_ALLNum(BusUserSearchViewModel busUserSearchViewModell)
        {
            return _IBusUserRepository.GetInfoByBusAll(busUserSearchViewModell).Count();
        }

        /// <summary>
        /// 根据当前乘车时间和线路，判断座位有没有满员
        /// </summary>
        /// <param name="busSearchByIdViewModel"></param>
        /// <returns></returns>
        public int ByBusIdSearchNum(BusSearchByIdViewModel busSearchByIdViewModel)
        {
            Bus_Info bus_Info = _IBusInfoRepository.SearchBusInfoSingleByLineWhere(busSearchByIdViewModel.Bus_LineId);//根据线路Id查班车
            int seatNume = Convert.ToInt32(bus_Info.SeatNum);//班车座位数
            var bus_User=_IBusUserRepository.SearchInfoByLineIdWhere(busSearchByIdViewModel).ToList();//最新月份坐该班车的各部门信息
            if (bus_User.Count < seatNume)//该线路乘车人未满员，可以继续选择该线路
                return 0;
            else //说明该线路已坐满人
                return -1;
        }
        /// <summary>
        /// 根据当前乘车时间和线路，判断座位有没有满员2
        /// </summary>
        /// <param name="busSearchByIdViewModel"></param>
        /// <returns></returns>
        public int ByBusIdSearchNum2(BusSearchByIdViewModel busSearchByIdViewModel,int count)
        {
            Bus_Info bus_Info = _IBusInfoRepository.SearchBusInfoSingleByLineWhere(busSearchByIdViewModel.Bus_LineId);//根据线路Id查班车
            int seatNume = Convert.ToInt32(bus_Info.SeatNum);//班车座位数
            var bus_User = _IBusUserRepository.SearchInfoByLineIdWhere(busSearchByIdViewModel).ToList();//最新月份坐该班车的各部门信息
            if ((bus_User.Count+ count) < seatNume)//该线路乘车人未满员，可以继续选择该线路
                return 0;
            else //说明该线路已坐满人
                return -1;
        }
        /// <summary>
        /// 班车信息验证
        /// </summary>
        public IDictionary<int, String> Bus_Payment_valide(BusUserValideViewModel busUserValideViewModel)
        {
            IDictionary<int, String> ErrorResult = new Dictionary<int, String>();
            //查询缴费信息
            IQueryable<Bus_Payment> Bus_Payments = _IBusUserRepository.SearchInfoByBusWhere(busUserValideViewModel);
            //查询班车信息
            IQueryable<Bus_Info> bus_Infos = _IBusInfoRepository.GetAll();
            //查询站点信息
            IQueryable<Bus_Station> Bus_Stations = _IBusStationRepository.GetAll();
            //查询线路信息
            IQueryable<Bus_Line> Bus_Lines = _IBusLineRepository.GetAll();
            //错误信息汇总
            List<BusUserErrorMiddles> Errorqueryable = GetPayError(Bus_Payments, bus_Infos, Bus_Stations, Bus_Lines);

            //合成错误消息
            for (int i = 0; i < Errorqueryable.Count(); i++)
            {

                if (i == 0)
                {
                    if (Errorqueryable[i].BaseName == null || Errorqueryable[i].Status.Equals("1"))
                    {
                        ErrorResult.Add(Errorqueryable[i].Id, Errorqueryable[i].Username + "所选择的" + Errorqueryable[i].PayName + "已经删除，请重新选择。");
                    }
                    else
                    {
                        ErrorResult.Add(Errorqueryable[i].Id, Errorqueryable[i].Username + "所选择的" + Errorqueryable[i].PayName + "已经修改，请重新选择。");
                    }
                }
                else
                {
                    //查询某个key是否存在
                    if (ErrorResult.ContainsKey(Errorqueryable[i].Id))
                    {
                        int key = Errorqueryable[i].Id;
                        if (Errorqueryable[i].BaseName == null || Errorqueryable[i].Status.Equals("1"))
                        {
                            //将相同id的行的结果合并为一个，以文件信息返回出来
                            ErrorResult[key] += Errorqueryable[i].PayName + "已经不存在，请重新选择";
                        }
                        else
                        {
                            ErrorResult[key] += Errorqueryable[i].PayName + "已经修改，请重新选择";
                        }
                    }
                    else
                    {
                        if (Errorqueryable[i].BaseName == null || Errorqueryable[i].Status.Equals("1"))
                        {
                            ErrorResult.Add(Errorqueryable[i].Id, Errorqueryable[i].Username + "所选择的" + Errorqueryable[i].PayName + "已经删除，请重新选择。");
                        }
                        else
                        {
                            ErrorResult.Add(Errorqueryable[i].Id, Errorqueryable[i].Username + "所选择的" + Errorqueryable[i].PayName + "已经修改，请重新选择。");
                        }
                    }

                }

                
            }
            return ErrorResult;
        }

        /// <summary>
        /// 查询班车错误信息
        /// </summary>
        /// <param name="bus_Payments"></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        private List<BusUserErrorMiddles> GetPayError(IQueryable<Bus_Payment> Bus_Payments, IQueryable<Bus_Info> bus_Infos, IQueryable<Bus_Station> Bus_Stations, IQueryable<Bus_Line> Bus_Lines)
        {
          //  IQueryable<BusUserErrorMiddles> busUserErrorMiddles;
            var PayErrorList = ((
                       from Pay in Bus_Payments
                       join infos in bus_Infos
                       on Pay.Bus_InfoId equals infos.Id into ic
                       from infos in ic.DefaultIfEmpty()
                       select new BusUserErrorMiddles
                       {
                           Id = Pay.Id,
                           Username = Pay.UserName,
                           PayName = Pay.BusName,
                           BaseName = infos.DriverName,
                           CreateDate = Pay.createDate,
                           Status = infos.status
                       }
                   ).Union(
                           from Pay in Bus_Payments
                           join stat in Bus_Stations
                           on Pay.Bus_StationId equals stat.Id into ie
                           from stat in ie.DefaultIfEmpty()
                           select new BusUserErrorMiddles
                           {
                               Id = Pay.Id,
                               Username = Pay.UserName,
                               PayName = Pay.StationName,
                               BaseName = stat.StationName,
                               CreateDate = Pay.createDate,
                               Status = stat.status
                           }
                   ).Union(
                       from Pay in Bus_Payments
                       join line in Bus_Lines
                       on Pay.Bus_LineId equals line.Id into ig
                       from line in ig.DefaultIfEmpty()
                       select new BusUserErrorMiddles
                       {
                           Id = Pay.Id,
                           Username = Pay.UserName,
                           PayName = Pay.LineName,
                           BaseName = line.LineName,
                           CreateDate = Pay.createDate,
                           Status= line.status
                       }
                   )).Where(a => (!a.PayName.Equals(a.BaseName))
                               //|| a.BaseName == null
                           ).OrderBy(t => t.Id).ToList()
                  ;
            
            return PayErrorList;
        }

        /// <summary>
        /// 更新缴费订单信息
        /// </summary>
        /// <param name="bus_Payment_OrderUpdateViewModel"></param>
        /// <returns></returns>
        public int Bus_Payment_Order_Update(Bus_Payment_OrderUpdateViewModel bus_Payment_OrderUpdateViewModel)
        {
            var bus_user_Info = _IBusPaymentOrderRepository.GetInfoByBusPaymentOrderId(bus_Payment_OrderUpdateViewModel.Id);
            bus_user_Info.updateDate = DateTime.Now;
            var bus_user_Info_update = _IMapper.Map<Bus_Payment_OrderUpdateViewModel, Bus_Payment_Order>(bus_Payment_OrderUpdateViewModel, bus_user_Info);
            _IBusPaymentOrderRepository.Update(bus_user_Info_update);
            return _IBusPaymentOrderRepository.SaveChanges();
        }

        /// <summary>
        /// 更新缴费订单信息(金额)
        /// </summary>
        /// <param name="bus_Payment_OrderUpdateViewModel"></param>
        /// <returns></returns>
        public int Bus_Payment_Order_UpdateExpense(Bus_Payment_OrderUpdateExpenseViewModel  bus_Payment_OrderUpdateExpenseViewModel)
        {

            List<Bus_Payment> bus_Payments = _IBusUserRepository.GetInfoByBus(bus_Payment_OrderUpdateExpenseViewModel.Bus_Payment_OrderId).ToList();
            Double TotalExpen = 0;
            for (int i = 0; i < bus_Payments.Count; i++)
            {
                TotalExpen += Convert.ToDouble(bus_Payments[i].Expense);//当前条件下，每个人应交费用总和
            }   
            var bus_user_Info = _IBusPaymentOrderRepository.GetInfoByBusPaymentOrderId(bus_Payment_OrderUpdateExpenseViewModel.Bus_Payment_OrderId);
            bus_user_Info.updateDate = DateTime.Now;
            bus_user_Info.orderAmount = TotalExpen.ToString();
            _IBusPaymentOrderRepository.Update(bus_user_Info);
            return _IBusPaymentOrderRepository.SaveChanges();
        }
        /// <summary>
        /// 查询缴费订单
        /// </summary>
        /// <param name="bus_Payment_OrderSearchViewModel"></param>
        /// <returns></returns>
        public List<Bus_Payment_Order> Bus_Payment_Order_Search(Bus_Payment_OrderSearchViewModel bus_Payment_OrderSearchViewModel)
        {
         
            List<Bus_Payment_Order> bus_Payment_Order = _IBusPaymentOrderRepository.SearchInfoByBusPaymentOrderWhere(bus_Payment_OrderSearchViewModel).ToList();
            return bus_Payment_Order;
        }
        /// <summary>
        /// 查询缴费订单(根据用户ID)
        /// </summary>
        /// <param name="bus_Payment_OrderSearchViewModel"></param>
        /// <returns></returns>
        public List<Bus_Payment_Order> Bus_Payment_Order_SearchByUserid(Bus_OrderIsPassSearchViewModel  bus_OrderIsPassSearchViewModel)
        {

            List<Bus_Payment_Order> bus_Payment_Order = _IBusPaymentOrderRepository.SearchInfoByUserIdWhere(bus_OrderIsPassSearchViewModel);
            return bus_Payment_Order;
        }




        /// <summary>
        /// 查询缴费订单(根据支付状态)
        /// </summary>
        /// <param name="bus_Payment_OrderSearchViewModel"></param>
        /// <returns></returns>
        public List<Bus_Payment_Order> Bus_Payment_Order_SearchByCZ()
        {
            List<Bus_Payment_Order> bus_Payment_Order = _IBusPaymentOrderRepository.SearchInfoByUserIdWhereCZ();
            return bus_Payment_Order;
        }


        /// <summary>
        /// 查询缴费订单(根据用户ID)数量
        /// </summary>
        /// <param name="bus_Payment_OrderSearchViewModel"></param>
        /// <returns></returns>
        public int Bus_Payment_Order_Count(Bus_OrderIsPassSearchViewModel bus_OrderIsPassSearchViewModel)
        {

           int count = _IBusPaymentOrderRepository.SearchInfoByUserIdWhere(bus_OrderIsPassSearchViewModel).Count;
            return count;
        }


        /// <summary>
        /// 添加缴费订单信息
        /// </summary>
        /// <param name="busUserAddViewModel"></param>
        /// <returns></returns>
        public int Bus_Payment_Order_Add(Bus_Payment_OrderAddViewModel bus_Payment_OrderAddViewModel)
        {   
            bus_Payment_OrderAddViewModel.AddDate = DateTime.Now;
            bus_Payment_OrderAddViewModel.paymentStatus = "0";
            var list = Bus_Payment();
            if (list==null)
            {
                bus_Payment_OrderAddViewModel.orderNo = "510752" + DateTime.Now.ToString("yyyyMM") + "000";
            }           
            else
            {
                bus_Payment_OrderAddViewModel.orderNo = (Convert.ToInt64(list[0].orderNo) + 1).ToString();
            }
               
            var bus_Info = _IMapper.Map<Bus_Payment_OrderAddViewModel, Bus_Payment_Order>(bus_Payment_OrderAddViewModel);
            bus_Info.orderTime = bus_Payment_OrderAddViewModel.AddDate.Value.ToString("yyyyMMddHHMMss");//订单时间格式

            bus_Info.curCode = _IOptions.curCode;//币种
            bus_Info.payType = _IOptions.payType;
            bus_Info.deviceInfo = _IOptions.deviceInfo;
            bus_Info.terminalChnl = _IOptions.terminalChnl;
            bus_Info.tradeType = _IOptions.tradeType;
            bus_Info.merchantNo = _IOptions.merchantNo;

            //bus_Info.curCode = "001"; ;//币种
            //bus_Info.payType = "1"; 
            //bus_Info.deviceInfo = "WEB"; 
            //bus_Info.terminalChnl = "08";
            //bus_Info.tradeType = "WXAPP"; 
            //bus_Info.merchantNo = "104120086510752"; 
            _IBusPaymentOrderRepository.Add(bus_Info);
            _IBusPaymentOrderRepository.SaveChanges();
            return bus_Info.Id;
        }

        /// <summary>
        /// 查询班车缴费订单数量
        /// </summary>
        /// <param name="busUserSearchViewModell"></param>
        /// <returns></returns>
        public int Bus_Payment_Order_Get_ALLNum(Bus_Payment_OrderSearchViewModel bus_Payment_OrderSearchViewModel)
        {
            return _IBusPaymentOrderRepository.SearchInfoByBusPaymentOrderWhere(bus_Payment_OrderSearchViewModel).ToList().Count;
        }


        /// <summary>
        /// 查询班车缴费订单数量
        /// </summary>
        /// <param name="busUserSearchViewModell"></param>
        /// <returns></returns>
        public List<Bus_Payment_Order> Bus_Payment()
        {
  
             var Bus_Payment_Order =  _IBusPaymentOrderRepository.SearchInfoWhere();

            return Bus_Payment_Order;
        }



        /// <summary>
        /// 根据表单ID查询订单和缴费人员信息信息
        /// </summary>
        /// <param name="bus_OrderByRepairsIdSearchViewModel"></param>
        /// <returns></returns>
        public Bus_Payment_OrderSearchMiddle Bus_Payment_Order_BySearch(Bus_OrderByRepairsIdSearchViewModel bus_OrderByRepairsIdSearchViewModel)
        {
            Bus_Payment_OrderSearchMiddle bus_Payment_OrderSearchMiddle = new Bus_Payment_OrderSearchMiddle();
            bus_Payment_OrderSearchMiddle.bus_Payment_Order = _IBusPaymentOrderRepository.GetInfoByRepair_InfoId(bus_OrderByRepairsIdSearchViewModel.Repair_InfoId);

            var OpinionInfoList = _IOpinionInfoRepository.GetInfoByRepair_InfoId(bus_OrderByRepairsIdSearchViewModel.Repair_InfoId);//意见列表
            var repairSearchMiddlecs = _IMapper.Map<List<Opinion_Info>, List<OpinionInfoSearchMiddlecs>>(OpinionInfoList);
            bus_Payment_OrderSearchMiddle.opinion_Infos = repairSearchMiddlecs;

            var temp= _IBusUserRepository.GetInfoByBusPaymentOrderId(bus_OrderByRepairsIdSearchViewModel.Repair_InfoId);
            var bus_Payment = _IMapper.Map<List<Bus_Payment>, List< Bus_Payment_Search>>(temp);
            bus_Payment_OrderSearchMiddle.bus_Payments = bus_Payment;
            return bus_Payment_OrderSearchMiddle;
        }


        /// <summary>
        /// 根据订单ID 更新班车动态码
        /// </summary>
        /// <param name="bus_OrderByOrderIdSearchViewModel"></param>
        /// <returns></returns>
        public int Bus_PaymentSearchByOrderId(Bus_OrderByOrderIdSearchViewModel  bus_OrderByOrderIdSearchViewModel)
        {
          
          var bus_Payment = _IBusUserRepository.GetInfoByBus(bus_OrderByOrderIdSearchViewModel.Bus_Payment_OrderId);
            var updateDate= DateTime.Now; 
            for (int i=0;i< bus_Payment.Count;i++)
            {
                bus_Payment[i].Code= Guid.NewGuid().ToString();
                bus_Payment[i].UpdateCodeDate = updateDate;
                _IBusUserRepository.Update(bus_Payment[i]);
            }
           return  _IBusUserRepository.SaveChanges();
        }


        /// <summary>
        /// 根据动态码查询缴费人员信息
        /// </summary>
        /// <param name="bus_OrderByCodeSearchViewModel"></param>
        /// <returns></returns>
        public Bus_Payment Bus_PaymentSearchByCode(Bus_OrderByCodeSearchViewModel  bus_OrderByCodeSearchViewModel)
        {

            var bus_Payment = _IBusUserRepository.GetInfoByCode(bus_OrderByCodeSearchViewModel.Code);
            var updateDate = DateTime.Now;
          
            if(bus_Payment.Count==0)//二维码过期，动态码已刷新
            {
                return null;
            }
            else
            {
                if (DateTime.Now.Date.AddHours(-24).CompareTo(bus_Payment[0].UpdateCodeDate) <= 0)
                {
                    return bus_Payment[0];
                }
                else//二维码过期，但是动态码还未刷新
                {
                    return null;
                }
            }
        }



        /// <summary>
        /// 根据身份证号查询缴费人员信息
        /// </summary>
        /// <param name="bus_OrderByCodeSearchViewModel"></param>
        /// <returns></returns>
        public Bus_Payment Bus_PaymentSearchByIdCard(Bus_OrderByIdCardSearchViewModel  bus_OrderByIdCardSearchViewModel)
        {

            var bus_Payment = _IBusUserRepository.GetInfoByIdCard(bus_OrderByIdCardSearchViewModel);
            var updateDate = DateTime.Now;

            if (bus_Payment.Count == 0)//不存在该人员
            {
                return null;
            }
            else
            {
                if (DateTime.Now.Date.AddHours(-24).CompareTo(bus_Payment[0].UpdateCodeDate) <= 0)
                {
                    return bus_Payment[0];
                }
                else//二维码过期
                {
                    var bus_user_Info = _IBusUserRepository.GetInfoByBusUserId(bus_Payment[0].Id);
                    bus_user_Info.Code = Guid.NewGuid().ToString();
                    bus_user_Info.UpdateCodeDate = updateDate;
                    bus_user_Info.updateDate = updateDate;
                    _IBusUserRepository.Update(bus_user_Info);
                    _IBusUserRepository.SaveChanges();  
                    return bus_user_Info;
                }
            }


        }


        /// <summary>
        /// 中国银行接口
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Bank_PaymentMiddle Bank_Payment(Bank_PaymentRequestMiddle Bank_PaymentRequestMiddle)
        {

           // Bank_PaymentRequestMiddle Bank_PaymentRequestMiddle
          //  Bank_PaymentViewModel bank_PaymentViewModel = new Bank_PaymentViewModel();
            Bus_Payment_Order bus_Payment_Order = _IBusPaymentOrderRepository.GetInfoByBusPaymentOrderId(Bank_PaymentRequestMiddle.OrderId);
            var result = _IMapper.Map<Bus_Payment_Order, Bank_PaymentViewModel>(bus_Payment_Order);

            //OrderUrlMiddle orderUrlMiddle = new OrderUrlMiddle();//回调url中拼接参数对象
            //orderUrlMiddle.OrderId = Bank_PaymentRequestMiddle.OrderId;
            //orderUrlMiddle.orderAmount = result.orderAmount;

            result.orderNote = bus_Payment_Order.departName + "班车缴费金额为:" + bus_Payment_Order.orderAmount;
            result.body = "东疆智慧服务平台-费用-班车缴费";
            result.orderUrl = "http://zhfwpt.dongjiang.gov.cn/MobileServer/PaymentSuccess.html?OrderIde=" + Bank_PaymentRequestMiddle.OrderId+ "&orderAmount="+ result.orderAmount;
            string orderInfor = result.orderNo + "|" + result.orderTime + "|" + result.curCode + "|" + result.orderAmount + "|" + result.merchantNo;
            try
            {
                //  var b=  HttpContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
   
                string ip = "";
                string hostInfo = Dns.GetHostName();
                //IP地址
                System.Net.IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
                ip = addressList[2].ToString();
                result.spbillCreateIp = ip;
                bus_Payment_Order.spbillCreateIp = ip;
                _IBusPaymentOrderRepository.Update(bus_Payment_Order);
                _IBusPaymentOrderRepository.SaveChanges();
            }
            catch (Exception e)
            {
                e.ToString();
            }

            var clientsignData = new RestClient("http://172.30.10.243:8011/EdayAPI/MakeSign/AdditionalSignature?orderInfor="+orderInfor);
            //var clientsignData = new RestClient("http://172.30.10.243:8011/EdayAPI/MakeSign/AdditionalSignature?orderInfor=510752202006210|20200622112402|001|0.10|104120086510752");
            clientsignData.Timeout = -1;
            var requestsignData = new RestRequest(Method.GET);
            IRestResponse responsesignData = clientsignData.Execute(requestsignData);
            string signData= responsesignData.Content;
            Bank_PaymentMiddle bank_PaymentMiddle = new Bank_PaymentMiddle();
            var flag= signData.Substring(0,signData.IndexOf(","));
            if(flag=="1")
            {
                signData = signData.Substring(signData.IndexOf(",")+1);
            }
            else
            {
                bank_PaymentMiddle.rtnMsg = signData.Substring(signData.IndexOf(",") + 1);
                return bank_PaymentMiddle;
            }
            //4、发送请求
            var client = new RestClient("https://ebspay.boc.cn/PGWPortal/B2CRecvOrder.do");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddParameter("merchantNo", result.merchantNo);
            request.AddParameter("payType", result.payType);
            request.AddParameter("orderNo", result.orderNo);
            request.AddParameter("curCode", result.curCode);
            request.AddParameter("orderAmount", result.orderAmount);
            request.AddParameter("orderTime", result.orderTime);
            request.AddParameter("orderNote", result.orderNote);
            request.AddParameter("orderUrl", result.orderUrl);
            request.AddParameter("terminalChnl", result.terminalChnl);
            request.AddParameter("signData", signData);
            request.AddParameter("tradeType", result.tradeType);
            request.AddParameter("deviceInfo", result.deviceInfo);
            request.AddParameter("body", result.body);
            request.AddParameter("spbillCreateIp", result.spbillCreateIp);

            IRestResponse response = client.Execute(request);
            //5、返回结果:商户可以根据接口文档  自行处理xml报文格式的数据 如:返回结果字段多于文档则依据文档进行开发
            string res =response.Content.ToString();
            int a = res.IndexOf("<hdlSts>");
            int b = res.IndexOf("</hdlSts>");
            string uid = res.Substring(a +8, b-a-8);
            if(uid=="A")
            {
                int c = res.IndexOf("<qrCode>");
                int d = res.IndexOf("</qrCode>");
                bank_PaymentMiddle.qrCode = res.Substring(c + 8, d - c - 8);
                bank_PaymentMiddle.hdlSts = uid;
                //Bus_OrderByOrderIdSearchViewModel bus_OrderByOrderIdSearchViewModel = new Bus_OrderByOrderIdSearchViewModel();
                //bus_OrderByOrderIdSearchViewModel.Bus_Payment_OrderId = Bank_PaymentRequestMiddle.OrderId;
                //Bus_PaymentSearchByOrderId(bus_OrderByOrderIdSearchViewModel);


            }
           else
           {
                int c = res.IndexOf("<rtnMsg>");
                int d = res.IndexOf("</rtnMsg>");
                bank_PaymentMiddle.rtnMsg = res.Substring(c + 8, d - c - 8);
                bank_PaymentMiddle.hdlSts = uid;
           }

            return bank_PaymentMiddle;

        }
        /// <summary>
        /// 中国银行查询接口
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Bank_Payment_SearchMiddle Bank_Payment_Search(Bank_PaymentRequestMiddle Bank_PaymentRequestMiddle)
        {
            Bus_Payment_Order bus_Payment_Order = _IBusPaymentOrderRepository.GetInfoByBusPaymentOrderId(Bank_PaymentRequestMiddle.OrderId);

            string orderInfor = bus_Payment_Order.merchantNo+":"+ bus_Payment_Order.orderNo;
            var clientsignData = new RestClient("http://172.30.10.243:8011/EdayAPI/MakeSign/AdditionalSignature?orderInfor="+orderInfor );
            Bank_Payment_SearchMiddle bank_Payment_SearchMiddle = new Bank_Payment_SearchMiddle();
            clientsignData.Timeout = -1;
            var requestsignData = new RestRequest(Method.GET);
            IRestResponse responsesignData = clientsignData.Execute(requestsignData);
            string signData = responsesignData.Content;
            Bank_PaymentMiddle bank_PaymentMiddle = new Bank_PaymentMiddle();
            var flag = signData.Substring(0, signData.IndexOf(","));
            if (flag == "1")
            {
                signData = signData.Substring(signData.IndexOf(",") + 1);
            }
            else
            {
                bank_Payment_SearchMiddle.exception = signData.Substring(signData.IndexOf(",") + 1);
                return bank_Payment_SearchMiddle;
            }

            //4、发送请求
            var client = new RestClient("https://ebspay.boc.cn/PGWPortal/QueryOrder.do");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddParameter("merchantNo", bus_Payment_Order.merchantNo);
            request.AddParameter("orderNos", bus_Payment_Order.orderNo);
            request.AddParameter("signData", signData);
            IRestResponse response = client.Execute(request);
            string res = response.Content.ToString();
            int a = res.IndexOf("<orderTrans>");
            int b = res.IndexOf("<exception>");
            int c = res.IndexOf("</exception>");
            if (a==-1 && b!=-1)
            {
                bank_Payment_SearchMiddle.exception = res.Substring(b +11, c - b - 11);
            }
           else if (a == -1 && b == -1)
           {
                bank_Payment_SearchMiddle.exception ="未查询到任何订单信息";
           }
           else
           {
              
                 a = res.IndexOf("<merchantNo>");
                 b = res.IndexOf("</merchantNo>");
                bank_Payment_SearchMiddle .merchantNo= res.Substring(a + 12, b - a - 12);

                a = res.IndexOf("<orderNo>");
                b = res.IndexOf("</orderNo>");
                bank_Payment_SearchMiddle.orderNo = res.Substring(a + 9, b - a - 9);

                a = res.IndexOf("<orderSeq>");
                b = res.IndexOf("</orderSeq>");
                bank_Payment_SearchMiddle.orderSeq = res.Substring(a + 10, b - a - 10);

                a = res.IndexOf("<orderStatus>");
                b = res.IndexOf("</orderStatus>");

                string temp=res.Substring(a + 13, b - a - 13);

                if (temp == "0")
                {
                    bank_Payment_SearchMiddle.orderStatus = "未处理";
                }
                else if (temp == "1")
                {
                    bank_Payment_SearchMiddle.orderStatus = "支付";
                }
                else if (temp == "2")
                {
                    bank_Payment_SearchMiddle.orderStatus = "撤销";
                }
                else if (temp == "3")
                {
                    bank_Payment_SearchMiddle.orderStatus = "退货";
                }
                else if (temp == "4")
                {
                    bank_Payment_SearchMiddle.orderStatus = "未明";
                }
                else if (temp == "5")
                {
                    bank_Payment_SearchMiddle.orderStatus = "失败";
                }
                else
                {
                    bank_Payment_SearchMiddle.orderStatus = "失败";
                }

                a = res.IndexOf("<cardTyp>");
                b = res.IndexOf("</cardTyp>");
                bank_Payment_SearchMiddle.cardTyp = res.Substring(a + 9, b - a - 9);


                a = res.IndexOf("<payTime>");
                b = res.IndexOf("</payTime>");


                DateTime dt = DateTime.ParseExact(res.Substring(a + 9, b - a - 9), "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                bank_Payment_SearchMiddle.payTime = dt.ToString();

                a = res.IndexOf("<payAmount>");
                b = res.IndexOf("</payAmount>");
                bank_Payment_SearchMiddle.payAmount = res.Substring(a + 11, b - a - 11);

                a = res.IndexOf("<unionPaySeq>");
                b = res.IndexOf("</unionPaySeq>");
                bank_Payment_SearchMiddle.unionPaySeq = res.Substring(a + 13, b - a - 13);

           }
            return bank_Payment_SearchMiddle;
        }

        /// <summary>
        /// 中行退款
        /// </summary>
        /// <returns></returns>
        public Bank_Payment_RefundMiddle Bank_Payment_Refund(Bank_PaymentRequestMiddle Bank_PaymentRequestMiddle)
        {

       
          
            Bus_Payment_Order bus_Payment_Order = _IBusPaymentOrderRepository.GetInfoByBusPaymentOrderId(Bank_PaymentRequestMiddle.OrderId);
            string mRefundSeq = "510752" + DateTime.Now.ToString("yyyyMMdd") + "7";//这里存在问题
            string orderInfor = bus_Payment_Order.merchantNo + "|" + mRefundSeq + "|" + bus_Payment_Order.curCode + "|" + "0.02" + "|" + bus_Payment_Order.orderNo;
      
            var clientsignData = new RestClient("http://172.30.10.243:8011/EdayAPI/MakeSign/AdditionalSignature?orderInfor=" + orderInfor);
            Bank_Payment_RefundMiddle  bank_Payment_RefundMiddle = new Bank_Payment_RefundMiddle();
            clientsignData.Timeout = -1;
            var requestsignData = new RestRequest(Method.GET);
            IRestResponse responsesignData = clientsignData.Execute(requestsignData);
            string signData = responsesignData.Content;
            Bank_PaymentMiddle bank_PaymentMiddle = new Bank_PaymentMiddle();
            var flag = signData.Substring(0, signData.IndexOf(","));
            if (flag == "1")
            {
                signData = signData.Substring(signData.IndexOf(",") + 1);
            }
            else
            {
                bank_Payment_RefundMiddle.exception = signData.Substring(signData.IndexOf(",") + 1);
                return bank_Payment_RefundMiddle;
            }
            //4、发送请求
            var client = new RestClient("https://ebspay.boc.cn/PGWPortal/RefundOrder.do");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

         
          
            request.AddParameter("merchantNo", bus_Payment_Order.merchantNo);
            request.AddParameter("mRefundSeq", mRefundSeq);
            request.AddParameter("curCode", bus_Payment_Order.curCode);
            request.AddParameter("refundAmount", 0.02);
            request.AddParameter("orderNo", bus_Payment_Order.orderNo);
            request.AddParameter("signData", signData);
            IRestResponse response = client.Execute(request);
            string res = response.Content.ToString();
            int a = res.IndexOf("<dealStatus>");
            int b = res.IndexOf("</dealStatus>");
            int c = res.IndexOf("</dealStatus>");

           string n= res.Substring(a + 12, b - a - 12);

            if(n=="1")//失败
            {
                a = res.IndexOf("<merchantNo>");
                b = res.IndexOf("</merchantNo>");
                bank_Payment_RefundMiddle.merchantNo = res.Substring(a + 12, b - a - 12);

                a = res.IndexOf("<returnActFlag>");
                b = res.IndexOf("</returnActFlag>");
                bank_Payment_RefundMiddle.returnActFlag = res.Substring(a + 15, b - a - 15);


                a = res.IndexOf("<dealStatus>");
                b = res.IndexOf("</dealStatus>");
                bank_Payment_RefundMiddle.dealStatus = res.Substring(a + 12, b - a - 12);


                a = res.IndexOf("<bodyFlag>");
                b = res.IndexOf("</bodyFlag>");
                bank_Payment_RefundMiddle.dealStatus = res.Substring(a + 10, b - a - 10);

                a = res.IndexOf("<exception>");
                b = res.IndexOf("</exception>");
                bank_Payment_RefundMiddle.dealStatus = res.Substring(a + 11, b - a - 11);

            }
            else if(n == "0")//成功
            {
                a = res.IndexOf("<merchantNo>");
                b = res.IndexOf("</merchantNo>");
                bank_Payment_RefundMiddle.merchantNo = res.Substring(a + 12, b - a - 12);

                a = res.IndexOf("<returnActFlag>");
                b = res.IndexOf("</returnActFlag>");
                bank_Payment_RefundMiddle.returnActFlag = res.Substring(a + 15, b - a - 15);


                a = res.IndexOf("<dealStatus>");
                b = res.IndexOf("</dealStatus>");
                bank_Payment_RefundMiddle.dealStatus = res.Substring(a + 12, b - a - 12);


                a = res.IndexOf("<bodyFlag>");
                b = res.IndexOf("</bodyFlag>");
                bank_Payment_RefundMiddle.dealStatus = res.Substring(a + 10, b - a - 10);

                a = res.IndexOf("<exception>");
                b = res.IndexOf("</exception>");
                bank_Payment_RefundMiddle.dealStatus = res.Substring(a + 11, b - a - 11);


                a = res.IndexOf("<mRefundSeq>");
                b = res.IndexOf("</mRefundSeq>");
                bank_Payment_RefundMiddle.dealStatus = res.Substring(a + 12, b - a - 12);

                a = res.IndexOf("<curCode>");
                b = res.IndexOf("</curCode>");
                bank_Payment_RefundMiddle.dealStatus = res.Substring(a + 9, b - a - 9);


                a = res.IndexOf("<refundAmount>");
                b = res.IndexOf("</refundAmount>");
                bank_Payment_RefundMiddle.dealStatus = res.Substring(a + 14, b - a - 14);


                a = res.IndexOf("<orderNo>");
                b = res.IndexOf("</orderNo>");
                bank_Payment_RefundMiddle.dealStatus = res.Substring(a + 9, b - a - 9);

                a = res.IndexOf("<orderSeq>");
                b = res.IndexOf("</orderSeq>");
                bank_Payment_RefundMiddle.dealStatus = res.Substring(a + 10, b - a - 10);



                a = res.IndexOf("<orderAmount>");
                b = res.IndexOf("</orderAmount>");
                bank_Payment_RefundMiddle.dealStatus = res.Substring(a + 13, b - a - 13);


                a = res.IndexOf("<bankTranSeq>");
                b = res.IndexOf("</bankTranSeq>");
                bank_Payment_RefundMiddle.dealStatus = res.Substring(a + 13, b - a - 13);

                a = res.IndexOf("<tranTime>");
                b = res.IndexOf("</tranTime>");
                bank_Payment_RefundMiddle.dealStatus = res.Substring(a + 10, b - a - 10);


                a = res.IndexOf("<unionPaySeq>");
                b = res.IndexOf("</unionPaySeq>");
                bank_Payment_RefundMiddle.dealStatus = res.Substring(a + 13, b - a - 13);



                a = res.IndexOf("<signData>");
                b = res.IndexOf("</signData>");
                bank_Payment_RefundMiddle.dealStatus = res.Substring(a + 10, b - a - 10);



            }
            else//未明
            {
                a = res.IndexOf("<exception>");
                b = res.IndexOf("</exception>");
                bank_Payment_RefundMiddle.dealStatus = res.Substring(a + 11, b - a - 11);
            }
            return bank_Payment_RefundMiddle;
        }




        /// <summary>
        /// 班车扫码
        /// </summary>
        /// <param name="checkCodeSearchViewModel"></param>
        /// <returns></returns>
        public string CheckCode(CheckCodeSearchViewModel  checkCodeSearchViewModel)
        {
           
            try
            {
                Bus_Scan_RecordAddViewModel bus_Scan_RecordAddViewModel = new Bus_Scan_RecordAddViewModel();
                var bus_Payment = _IBusUserRepository.GetInfoByCode(checkCodeSearchViewModel.qrcode);     
                if (bus_Payment.Count == 0)//二维码过期，动态码已刷新
                {
                    var data = DateTime.Now;
                 
                    bus_Scan_RecordAddViewModel.deviceNumber = checkCodeSearchViewModel.deviceNumber;
                    bus_Scan_RecordAddViewModel.status = "1";
                    bus_Scan_RecordAddViewModel.AddDate = data;
                    var bus_Scan_Record = _IMapper.Map<Bus_Scan_RecordAddViewModel, Bus_Scan_Record>(bus_Scan_RecordAddViewModel);
                    _IBusScanRecordRepository.Add(bus_Scan_Record);
                    _IBusScanRecordRepository.SaveChanges();
                    return "1";
                }
                else
                {
                    if (DateTime.Now.AddHours(-24).CompareTo(bus_Payment[0].UpdateCodeDate) <= 0)
                    {


                        ////判断当前时间是否在工作时间段内
                        //string _staWorkingDayAM = "06:00";//工作时间上午06:00
                        //string _endWorkingDayAM = "09:00"; //工作时间上午09:00

                        //string _staWorkingDayPM = "14:00"; //工作时间下午17:00
                        //string _endWorkingDayPM = "19:00"; //工作时间上午19:00

                     
                        //判断当前时间是否在工作时间段内
                        string _staWorkingDayAM = _IOptions2._staWorkingDayAM;//工作时间上午06:00
                        string _endWorkingDayAM = _IOptions2._endWorkingDayAM; //工作时间上午09:00

                        string _staWorkingDayPM = _IOptions2._staWorkingDayPM; //工作时间下午17:00
                        string _endWorkingDayPM = _IOptions2._endWorkingDayPM; //工作时间上午19:00

                        TimeSpan dspWorkingDayAM = DateTime.Parse(_staWorkingDayAM).TimeOfDay;
                        TimeSpan dspWorkingDayAM2 = DateTime.Parse(_endWorkingDayAM).TimeOfDay;

                        TimeSpan dspWorkingDayPM = DateTime.Parse(_staWorkingDayPM).TimeOfDay;
                        TimeSpan dspWorkingDayPM2 = DateTime.Parse(_endWorkingDayPM).TimeOfDay;
                        TimeSpan dspNow = DateTime.Now.TimeOfDay;
                        if (bus_Payment[0].ScanCodeDate != null)
                        {
                            TimeSpan ScanCodeDate = bus_Payment[0].ScanCodeDate.Value.TimeOfDay;

                            if (dspNow > dspWorkingDayAM && dspNow < dspWorkingDayAM2)//上午6-9点
                            {
                                if (ScanCodeDate > dspWorkingDayAM && ScanCodeDate < dspWorkingDayAM2)
                                {
                                    var data = DateTime.Now;
                                    bus_Scan_RecordAddViewModel.DeptName = bus_Payment[0].Name;
                                    bus_Scan_RecordAddViewModel.UserName = bus_Payment[0].UserName;
                                    bus_Scan_RecordAddViewModel.LineId = bus_Payment[0].Bus_LineId.Value;
                                    bus_Scan_RecordAddViewModel.LineName = bus_Payment[0].LineName;
                                    bus_Scan_RecordAddViewModel.deviceNumber = checkCodeSearchViewModel.deviceNumber;
                                    bus_Scan_RecordAddViewModel.status = "3";
                                    bus_Scan_RecordAddViewModel.AddDate = data;
                                    var bus_Scan_Record = _IMapper.Map<Bus_Scan_RecordAddViewModel, Bus_Scan_Record>(bus_Scan_RecordAddViewModel);
                                    _IBusScanRecordRepository.Add(bus_Scan_Record);
                                    _IBusScanRecordRepository.SaveChanges();
                                    return "3";
                                }
                                else
                                {
                                    Bus_Info bus_Info = _IBusInfoRepository.SearchBusInfoSingleByLineWhere(bus_Payment[0].Bus_LineId.Value);//根据线路Id查班车
                                    if (bus_Info.deviceNumber == checkCodeSearchViewModel.deviceNumber)
                                    {
                                        var data = DateTime.Now;
                                       bus_Payment[0].ScanCodeDate = data;
                                        _IBusUserRepository.Update(bus_Payment[0]);
                                        _IBusUserRepository.SaveChanges();
                                        //增加扫码记录
                                     
                                        bus_Scan_RecordAddViewModel.DeptName = bus_Payment[0].Name;
                                        bus_Scan_RecordAddViewModel.UserName = bus_Payment[0].UserName;
                                        bus_Scan_RecordAddViewModel.LineId = bus_Payment[0].Bus_LineId.Value;
                                        bus_Scan_RecordAddViewModel.LineName = bus_Payment[0].LineName;
                                        bus_Scan_RecordAddViewModel.deviceNumber = bus_Info.deviceNumber;
                                        bus_Scan_RecordAddViewModel.status = "0";
                                        bus_Scan_RecordAddViewModel.AddDate = data;
                                    var bus_Scan_Record=  _IMapper.Map<Bus_Scan_RecordAddViewModel, Bus_Scan_Record>(bus_Scan_RecordAddViewModel);
                                        _IBusScanRecordRepository.Add(bus_Scan_Record);
                                        _IBusScanRecordRepository.SaveChanges();
                                        return "0";
                                    }

                                    else
                                    {
                                        var data = DateTime.Now;
                                        bus_Scan_RecordAddViewModel.DeptName = bus_Payment[0].Name;
                                        bus_Scan_RecordAddViewModel.UserName = bus_Payment[0].UserName;
                                        bus_Scan_RecordAddViewModel.LineId = bus_Payment[0].Bus_LineId.Value;
                                        bus_Scan_RecordAddViewModel.LineName = bus_Payment[0].LineName;
                                        bus_Scan_RecordAddViewModel.deviceNumber = bus_Info.deviceNumber;
                                        bus_Scan_RecordAddViewModel.status = "2";
                                        bus_Scan_RecordAddViewModel.AddDate = data;
                                        var bus_Scan_Record = _IMapper.Map<Bus_Scan_RecordAddViewModel, Bus_Scan_Record>(bus_Scan_RecordAddViewModel);
                                        _IBusScanRecordRepository.Add(bus_Scan_Record);
                                        _IBusScanRecordRepository.SaveChanges();
                                        return "2";

                                    }
                                       
                                }

                            }
                            if (dspNow > dspWorkingDayPM && dspNow < dspWorkingDayPM2)//下午5-7点
                            {

                                if (ScanCodeDate > dspWorkingDayAM && ScanCodeDate < dspWorkingDayAM2)//数据库最新扫码时间为上午6-9
                                {
                                    Bus_Info bus_Info = _IBusInfoRepository.SearchBusInfoSingleByLineWhere(bus_Payment[0].Bus_LineId.Value);//根据线路Id查班车
                                    if (bus_Info.deviceNumber == checkCodeSearchViewModel.deviceNumber)
                                    {
                                        var data = DateTime.Now;
                                        bus_Payment[0].ScanCodeDate = data;
                                        _IBusUserRepository.Update(bus_Payment[0]);
                                        _IBusUserRepository.SaveChanges();

                                        //增加扫码记录
                                
                                        bus_Scan_RecordAddViewModel.DeptName = bus_Payment[0].Name;
                                        bus_Scan_RecordAddViewModel.UserName = bus_Payment[0].UserName;
                                        bus_Scan_RecordAddViewModel.LineId = bus_Payment[0].Bus_LineId.Value;
                                        bus_Scan_RecordAddViewModel.LineName = bus_Payment[0].LineName;
                                        bus_Scan_RecordAddViewModel.deviceNumber = bus_Info.deviceNumber;
                                        bus_Scan_RecordAddViewModel.status = "0";
                                        bus_Scan_RecordAddViewModel.AddDate = data;
                                        var bus_Scan_Record = _IMapper.Map<Bus_Scan_RecordAddViewModel, Bus_Scan_Record>(bus_Scan_RecordAddViewModel);
                                        _IBusScanRecordRepository.Add(bus_Scan_Record);
                                        _IBusScanRecordRepository.SaveChanges();
                                        return "0";
                                    }

                                    else
                                    {
                                        var data = DateTime.Now;
                                        bus_Scan_RecordAddViewModel.DeptName = bus_Payment[0].Name;
                                        bus_Scan_RecordAddViewModel.UserName = bus_Payment[0].UserName;
                                        bus_Scan_RecordAddViewModel.LineId = bus_Payment[0].Bus_LineId.Value;
                                        bus_Scan_RecordAddViewModel.LineName = bus_Payment[0].LineName;
                                        bus_Scan_RecordAddViewModel.deviceNumber = checkCodeSearchViewModel.deviceNumber;
                                        bus_Scan_RecordAddViewModel.status = "2";
                                        bus_Scan_RecordAddViewModel.AddDate = data;
                                        var bus_Scan_Record = _IMapper.Map<Bus_Scan_RecordAddViewModel, Bus_Scan_Record>(bus_Scan_RecordAddViewModel);
                                        _IBusScanRecordRepository.Add(bus_Scan_Record);
                                        _IBusScanRecordRepository.SaveChanges();
                                        return "2";
                                    }
                                       

                                }
                                if (ScanCodeDate > dspWorkingDayPM && ScanCodeDate < dspWorkingDayPM2)//数据库最新扫码时间为下午5-7点
                                {
                                    var data = DateTime.Now;
                                    bus_Scan_RecordAddViewModel.DeptName = bus_Payment[0].Name;
                                    bus_Scan_RecordAddViewModel.UserName = bus_Payment[0].UserName;
                                    bus_Scan_RecordAddViewModel.LineId = bus_Payment[0].Bus_LineId.Value;
                                    bus_Scan_RecordAddViewModel.LineName = bus_Payment[0].LineName;
                                    bus_Scan_RecordAddViewModel.deviceNumber = checkCodeSearchViewModel.deviceNumber;
                                    bus_Scan_RecordAddViewModel.status = "3";
                                    bus_Scan_RecordAddViewModel.AddDate = data;
                                    var bus_Scan_Record = _IMapper.Map<Bus_Scan_RecordAddViewModel, Bus_Scan_Record>(bus_Scan_RecordAddViewModel);
                                    _IBusScanRecordRepository.Add(bus_Scan_Record);
                                    _IBusScanRecordRepository.SaveChanges();
                                    return "3";
                                }

                            }
                            var data1 = DateTime.Now;
                            bus_Scan_RecordAddViewModel.DeptName = bus_Payment[0].Name;
                            bus_Scan_RecordAddViewModel.UserName = bus_Payment[0].UserName;
                            bus_Scan_RecordAddViewModel.LineId = bus_Payment[0].Bus_LineId.Value;
                            bus_Scan_RecordAddViewModel.LineName = bus_Payment[0].LineName;
                            bus_Scan_RecordAddViewModel.deviceNumber = checkCodeSearchViewModel.deviceNumber;
                            bus_Scan_RecordAddViewModel.status = "11";
                            bus_Scan_RecordAddViewModel.AddDate = data1;
                            var bus_Scan_Record2 = _IMapper.Map<Bus_Scan_RecordAddViewModel, Bus_Scan_Record>(bus_Scan_RecordAddViewModel);
                            _IBusScanRecordRepository.Add(bus_Scan_Record2);
                            _IBusScanRecordRepository.SaveChanges();
                            return "1";
                        }
                        else
                        {
                            if ((dspNow > dspWorkingDayAM && dspNow < dspWorkingDayAM2)|| (dspNow > dspWorkingDayPM && dspNow < dspWorkingDayPM2))//上午6-9点或者下午5-7点
                            {

                                Bus_Info bus_Info = _IBusInfoRepository.SearchBusInfoSingleByLineWhere(bus_Payment[0].Bus_LineId.Value);//根据线路Id查班车
                                if (bus_Info.deviceNumber == checkCodeSearchViewModel.deviceNumber)
                                {
                                    var data = DateTime.Now;
                                    bus_Payment[0].ScanCodeDate = data;
                                    _IBusUserRepository.Update(bus_Payment[0]);
                                    _IBusUserRepository.SaveChanges();

                                    //增加扫码记录
                                  
                                    bus_Scan_RecordAddViewModel.DeptName = bus_Payment[0].Name;
                                    bus_Scan_RecordAddViewModel.UserName = bus_Payment[0].UserName;
                                    bus_Scan_RecordAddViewModel.LineId = bus_Payment[0].Bus_LineId.Value;
                                    bus_Scan_RecordAddViewModel.LineName = bus_Payment[0].LineName;
                                    bus_Scan_RecordAddViewModel.deviceNumber = bus_Info.deviceNumber;
                                    bus_Scan_RecordAddViewModel.status = "0";
                                    bus_Scan_RecordAddViewModel.AddDate = data;
                                    var bus_Scan_Record = _IMapper.Map<Bus_Scan_RecordAddViewModel, Bus_Scan_Record>(bus_Scan_RecordAddViewModel);
                                    _IBusScanRecordRepository.Add(bus_Scan_Record);
                                    _IBusScanRecordRepository.SaveChanges();
                                    return "0";
                                }

                                else
                                {
                                    var data = DateTime.Now;
                                    bus_Scan_RecordAddViewModel.DeptName = bus_Payment[0].Name;
                                    bus_Scan_RecordAddViewModel.UserName = bus_Payment[0].UserName;
                                    bus_Scan_RecordAddViewModel.LineId = bus_Payment[0].Bus_LineId.Value;
                                    bus_Scan_RecordAddViewModel.LineName = bus_Payment[0].LineName;
                                    bus_Scan_RecordAddViewModel.deviceNumber = checkCodeSearchViewModel.deviceNumber;
                                    bus_Scan_RecordAddViewModel.status = "2";
                                    bus_Scan_RecordAddViewModel.AddDate = data;
                                    var bus_Scan_Record = _IMapper.Map<Bus_Scan_RecordAddViewModel, Bus_Scan_Record>(bus_Scan_RecordAddViewModel);
                                    _IBusScanRecordRepository.Add(bus_Scan_Record);
                                    _IBusScanRecordRepository.SaveChanges();
                                    return "2";
                                }
                                   
                            }
                            else
                            {
                                var data = DateTime.Now;
                                bus_Scan_RecordAddViewModel.DeptName = bus_Payment[0].Name;
                                bus_Scan_RecordAddViewModel.UserName = bus_Payment[0].UserName;
                                bus_Scan_RecordAddViewModel.LineId = bus_Payment[0].Bus_LineId.Value;
                                bus_Scan_RecordAddViewModel.LineName = bus_Payment[0].LineName;
                                bus_Scan_RecordAddViewModel.deviceNumber = checkCodeSearchViewModel.deviceNumber;
                                bus_Scan_RecordAddViewModel.status = "12";
                                bus_Scan_RecordAddViewModel.AddDate = data;
                                var bus_Scan_Record = _IMapper.Map<Bus_Scan_RecordAddViewModel, Bus_Scan_Record>(bus_Scan_RecordAddViewModel);
                                _IBusScanRecordRepository.Add(bus_Scan_Record);
                                _IBusScanRecordRepository.SaveChanges();
                                return "1";
                            }
                                

                        }

                    }
                    else//二维码过期，但是动态码还未刷新
                    {
                        var data = DateTime.Now;
                        bus_Scan_RecordAddViewModel.DeptName = bus_Payment[0].Name;
                        bus_Scan_RecordAddViewModel.UserName = bus_Payment[0].UserName;
                        bus_Scan_RecordAddViewModel.LineId = bus_Payment[0].Bus_LineId.Value;
                        bus_Scan_RecordAddViewModel.LineName = bus_Payment[0].LineName;
                        bus_Scan_RecordAddViewModel.deviceNumber = checkCodeSearchViewModel.deviceNumber;
                        bus_Scan_RecordAddViewModel.status = "13";
                        bus_Scan_RecordAddViewModel.AddDate = data;
                        var bus_Scan_Record = _IMapper.Map<Bus_Scan_RecordAddViewModel, Bus_Scan_Record>(bus_Scan_RecordAddViewModel);
                        _IBusScanRecordRepository.Add(bus_Scan_Record);
                        _IBusScanRecordRepository.SaveChanges();
                        return "1";
                    }
                }
            }
            catch(Exception e)
            {
                
                return "4";

            }
           

        }


        /// <summary>
        /// 修改支付状态
        /// </summary>
        /// <param name="Bank_PaymentRequestMiddle"></param>
        /// <returns></returns>

        public int Update_Bank_Payment_Order(Bank_PaymentRequestMiddle Bank_PaymentRequestMiddle)
        {
            Bus_Payment_Order bus_Payment_Order = _IBusPaymentOrderRepository.GetInfoByBusPaymentOrderId(Bank_PaymentRequestMiddle.OrderId);


            var bus_Payment = _IBusUserRepository.GetInfoByBus(Bank_PaymentRequestMiddle.OrderId); //更新缴费人员的动态码
            var updateDate = DateTime.Now;
            for (int i = 0; i < bus_Payment.Count; i++)
            {
                bus_Payment[i].Code = Guid.NewGuid().ToString();
                bus_Payment[i].UpdateCodeDate = updateDate;
                _IBusUserRepository.Update(bus_Payment[i]);
            }
              _IBusUserRepository.SaveChanges();




            if (Bank_PaymentRequestMiddle.paymentStatus=="2")
            {
                bus_Payment_Order.paymentStatus = "2";
            }
           else
           {
                bus_Payment_Order.paymentStatus = "3";
           }
            bus_Payment_Order.updateDate = DateTime.Now;
            _IBusPaymentOrderRepository.Update(bus_Payment_Order);
           return  _IBusPaymentOrderRepository.SaveChanges();
        }



      

    }
}
