using AutoMapper;
using Dto.IRepository.IntellRegularBus;
using Dto.IRepository.IntellUser;
using Dto.IService.IntellRegularBus;
using Dtol.dtol;
using System;
using System.Collections.Generic;
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


        public int Bus_User_Add(BusUserAddViewModel busUserAddViewModel)
        {
            var bus_Info = _IMapper.Map<BusUserAddViewModel, Bus_Payment>(busUserAddViewModel);
            _IBusUserRepository.Add(bus_Info);
            return _IBusUserRepository.SaveChanges();
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

        public int Bus_User_Update(BusUserUpdateViewModel busUserUpdateViewModel)
        {
            var bus_user_Info = _IBusUserRepository.GetInfoByBusUserId(busUserUpdateViewModel.Id);
            var bus_user_Info_update = _IMapper.Map<BusUserUpdateViewModel, Bus_Payment>(busUserUpdateViewModel, bus_user_Info);
            _IBusUserRepository.Update(bus_user_Info_update);
            return _IBusUserRepository.SaveChanges();
        }

        public List<BusUserSearchMiddlecs> Bus_User_Search(BusUserSearchViewModel busUserSearchViewModel)
        {
            BusUserSearchMiddlecs busUserSearchMiddlecs = new BusUserSearchMiddlecs();

            List<Bus_Payment> bus_Payments  =  _IBusUserRepository.SearchInfoByBusWhere(busUserSearchViewModel).ToList();

            var bus_User_Search = _IMapper.Map<List<Bus_Payment>, List<BusUserSearchMiddlecs>>(bus_Payments);


            return bus_User_Search;
        }

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
    }
}
