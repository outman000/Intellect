﻿using AutoMapper;
using Dto.IRepository.IntellRegularBus;
using Dto.IRepository.IntellRepair;
using Dto.IRepository.IntellUser;
using Dto.IService.IntellRegularBus;
using Dtol.dtol;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel;
using ViewModel.BusViewModel.RequestViewModel.BusUserViewModel;
using ViewModel.BusViewModel.ResponseModel.BusUserResModel;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;

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
                                IBusPaymentOrderRepository ibusPaymentOrderRepository)
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
        /// 更新人员缴费信息表单id列，将班车缴费表和流程表单id绑定
        /// </summary>
        /// <param name="busPamentUpdateViewModel"></param>
        /// <returns></returns>
        public int Bus_PayMent_Update(BusPaymentUpdateViewModel busPamentUpdateViewModel)
        {
            List<Bus_Payment> bus_user_Info = _IBusUserRepository.SearchInfoByBusWhere(busPamentUpdateViewModel).ToList();
            int TotalExpen = 0;
            for (int i=0; i< bus_user_Info.Count;i++)
            {
              var temp=_IMapper.Map<BusPaymentUpdateViewModel, Bus_Payment>(busPamentUpdateViewModel, bus_user_Info[i]);
                _IBusUserRepository.Update(temp);
                TotalExpen += Convert.ToInt32(bus_user_Info[i].Expense);//当前条件下，每个人应交费用总和
            }
            _IBusUserRepository.SaveChanges();
            Bus_Payment_Order bus_Payment_Order =_IBusPaymentOrderRepository.GetInfoByBusPaymentOrderId(busPamentUpdateViewModel.Bus_Payment_OrderId);
            bus_Payment_Order.Expense = TotalExpen;
           _IBusPaymentOrderRepository.Update(bus_Payment_Order);
            return _IBusPaymentOrderRepository.SaveChanges();
        }

        /// <summary>
        ///  根据以前某月的缴费信息，生成当前月的缴费信息
        /// </summary>
        /// <param name="busUserSearchViewModel"></param>
        /// <returns></returns>
        public int Bus_PayMent_Template(BusUserSearchViewModel busUserSearchViewModel)
        {
            List<Bus_Payment> bus_Payments = _IBusUserRepository.SearchInfoByBusWhere(busUserSearchViewModel).ToList();
            //先以之前的月份为模板进行添加
            List <BusUserAddViewModel> busUserAddViewModel = new List<BusUserAddViewModel>();
    
            for (int j = 0; j < bus_Payments.Count; j++)
            {
                var bus_Info = _IMapper.Map<Bus_Payment, BusUserAddViewModel>(bus_Payments[j]);//把查询结果中的主键列去掉
                busUserAddViewModel.Add(bus_Info);
            }
            //按照模板添加后，更新日期为当前年份和月份
            NowDateUpdateViewModel nowDateUpdateViewModel = new NowDateUpdateViewModel();
            nowDateUpdateViewModel.carDate = DateTime.Now.AddMonths(1);//当前年月
            for(int i=0;i< bus_Payments.Count;i++)
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
        public int Bus_UserExpen_Search(BusUserSearchViewModel busUserSearchViewModel)
        {
            List<Bus_Payment> bus_Payments = _IBusUserRepository.SearchInfoByBusWhere(busUserSearchViewModel).ToList();
            int TotalExpen = 0;
            for (int i = 0; i < bus_Payments.Count; i++)
            {
                TotalExpen += Convert.ToInt32(bus_Payments[i].Expense);//当前条件下，每个人应交费用总和
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
        /// 添加缴费订单信息
        /// </summary>
        /// <param name="busUserAddViewModel"></param>
        /// <returns></returns>
        public int Bus_Payment_Order_Add(Bus_Payment_OrderAddViewModel bus_Payment_OrderAddViewModel)
        {
            bus_Payment_OrderAddViewModel.AddDate = DateTime.Now;
            bus_Payment_OrderAddViewModel.OrderId = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            var bus_Info = _IMapper.Map<Bus_Payment_OrderAddViewModel, Bus_Payment_Order>(bus_Payment_OrderAddViewModel);
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
        /// 根据表单ID查询订单和缴费人员信息信息
        /// </summary>
        /// <param name="bus_OrderByRepairsIdSearchViewModel"></param>
        /// <returns></returns>
        public Bus_Payment_OrderSearchMiddle Bus_Payment_Order_BySearch(Bus_OrderByRepairsIdSearchViewModel bus_OrderByRepairsIdSearchViewModel)
        {
            Bus_Payment_OrderSearchMiddle bus_Payment_OrderSearchMiddle = new Bus_Payment_OrderSearchMiddle();
            bus_Payment_OrderSearchMiddle.bus_Payment_Order = _IBusPaymentOrderRepository.GetInfoByRepair_InfoId(bus_OrderByRepairsIdSearchViewModel.Repair_InfoId);
    
            var temp= _IBusUserRepository.GetInfoByBusPaymentOrderId(bus_OrderByRepairsIdSearchViewModel.Repair_InfoId);
            var bus_Payment = _IMapper.Map<List<Bus_Payment>, List< Bus_Payment_Search>>(temp);
            bus_Payment_OrderSearchMiddle.bus_Payments = bus_Payment;
            return bus_Payment_OrderSearchMiddle;
        }
        //public int Bus_Payment(RepairAddViewModel repairAddViewModel, int Flow_ProcedureDefineId, BusPaymentUpdateViewModel busPamentUpdateViewModel)
        //{
        //    //存入表单信息
        //    var repair_Info = _IMapper.Map<RepairAddViewModel, Repair_Info>(repairAddViewModel);
        //    _IRepairInfoRepository.Add(repair_Info);
        //    _IRepairInfoRepository.SaveChanges();

        //    //存入流程信息（只有在开始节点的时候才会存入一条数据）
        //    var flowProcedureAddViewModel = _IMapper.Map<Repair_Info, FlowProcedureAddViewModel>(repair_Info);
        //    var procedure_Info = _IMapper.Map<FlowProcedureAddViewModel, Flow_Procedure>(flowProcedureAddViewModel);
        //    procedure_Info.remark = "1";//流程开始
        //    _IFlowProcedureInfoRepository.Add(procedure_Info);
        //    _IFlowProcedureInfoRepository.SaveChanges();

        //    //通过流程定义Id去查开始节点的主键id
        //    var ProcedureDefine = _IFlowNodeDefineInfoRepository.GetInfoByProcedureDefineId(Flow_ProcedureDefineId);
        //    int FirstNodeId = ProcedureDefine.Id;
        //    //返回三个Id
        //    WorkFlowFistReturnIdList workFlowFistReturnIdList = new WorkFlowFistReturnIdList();
        //    workFlowFistReturnIdList.Repair_InfoId = repair_Info.id;//表单主键Id
        //    workFlowFistReturnIdList.RepairType = repair_Info.RepairsType;//填写的类型与角色类相对应
        //    workFlowFistReturnIdList.User_InfoId = repair_Info.User_InfoId;//填写表单的用户Id
        //    workFlowFistReturnIdList.Flow_ProcedureId = procedure_Info.Id;//流程Id
        //    workFlowFistReturnIdList.Flow_NodeDefineId = FirstNodeId;//该流程第一个节点Id


        //}
    }
}
