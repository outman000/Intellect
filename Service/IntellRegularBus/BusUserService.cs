using AutoMapper;
using Dto.IRepository.IntellRegularBus;
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


        public BusUserService(IBusUserRepository busUserRepository ,
                                IBusInfoRepository busInfoRepository,
                                IMapper mapper, 
                                IUserInfoRepository userInfoRepository,
                                IUserDepartRepository userDepartRepository, 
                                IBusLineRepository busLineRepository,
                                IBusStationRepository busStationRepository)
        {
            _IBusUserRepository = busUserRepository;
            _IMapper = mapper;
            _IUserInfoRepository = userInfoRepository;
            _IUserDepartRepository = userDepartRepository;
            _IBusLineRepository = busLineRepository;
            _IBusStationRepository = busStationRepository;
            _IBusInfoRepository = busInfoRepository;
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
      
            for (int i=0; i< bus_user_Info.Count;i++)
            {
              var temp=_IMapper.Map<BusPaymentUpdateViewModel, Bus_Payment>(busPamentUpdateViewModel, bus_user_Info[i]);
                _IBusUserRepository.Update(temp);
            }
           
            return _IBusUserRepository.SaveChanges();
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
            nowDateUpdateViewModel.carDate = DateTime.Now;//当前年月
            for(int i=0;i< bus_Payments.Count;i++)
            {
                var bus_user_Info = _IMapper.Map<NowDateUpdateViewModel, BusUserAddViewModel>(nowDateUpdateViewModel, busUserAddViewModel[i]);
                var Bus_Payment = _IMapper.Map<BusUserAddViewModel, Bus_Payment>(busUserAddViewModel[i]);
                _IBusUserRepository.Add(Bus_Payment);
               
            }
            return _IBusUserRepository.SaveChanges();
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
        /// 查询班车缴费清单表
        /// </summary>
        /// <param name="busUserSearchViewModell"></param>
        /// <returns></returns>
        public int Bus_User_Get_ALLNum(BusUserSearchViewModel busUserSearchViewModell)
        {
            return _IBusUserRepository.GetInfoByBusAll(busUserSearchViewModell).Count();
        }





        public int ByBusIdSearchNum(BusSearchByIdViewModel busSearchByIdViewModel)
        {


            Bus_Info bus_Payments = _IBusInfoRepository.GetInfoByBusId(busSearchByIdViewModel.Id);
            int seatNume = Convert.ToInt32(bus_Payments.SeatNum);//班车座位数
            var bus_User=_IBusUserRepository.SearchInfoByBusIdWhere(busSearchByIdViewModel).ToList();//最新月份坐该班车的各部门信息
            if (bus_User.Count == 0)//没查到该班车信息，可以添加该班车
            {
                return 0;
            }
    
            else if (bus_User.Count== seatNume)//说明该班车已坐满人
            {
                return -1;
            }
            else
            return 0;
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
            var aaaaa = from Pay in Bus_Payments
                        join line in Bus_Lines
                        on Pay.Bus_LineId equals line.Id into ig
                        from line in ig.DefaultIfEmpty()
                        select new
                        {
                            Id = Pay.Id,
                            Username = Pay.UserName,
                            PayName = Pay.LineName,
                            BaseName = line.LineName,
                            CreateDate = Pay.createDate
                        };

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
                           BaseName = infos.CarPlate,
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
    }
}
