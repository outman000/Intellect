using AutoMapper;
using Dto.IRepository.IntellRegularBus;
using Dto.IService.IntellRegularBus;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.RequestViewModel.BusUserViewModel;

namespace Dto.Service.IntellRegularBus
{
    public class BusUserService : IBusUserService
    {

        private readonly IBusUserRepository _IBusUserRepository;
        private readonly IMapper _IMapper;


        public BusUserService(IBusUserRepository busUserRepository ,IMapper mapper)
        {
            _IBusUserRepository = busUserRepository;
            _IMapper = mapper;
        }


        public int Bus_User_Add(BusUserAddViewModel busUserAddViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
