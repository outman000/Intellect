using AutoMapper;
using Dto.IRepository.IntellRegularBus;
using Dto.IService.IntellRegularBus;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;

namespace Dto.Service.IntellRegularBus
{
    public class BusLocationInformationService : IBusLocationInformationService
    {

        private readonly IBusLocationInformationRepository _BusLocationInformationRepository;
    
        private readonly IMapper _IMapper;


        public BusLocationInformationService(IBusLocationInformationRepository  busLocationInformationRepository, IMapper mapper)
        {
            _BusLocationInformationRepository = busLocationInformationRepository;

            _IMapper = mapper;
        }

       /// <summary>
       /// 添加班车位置信息
       /// </summary>
       /// <param name="busLocationInformationAddViewModel"></param>
       /// <returns></returns>
        public int BusLocationInformation_Add(BusLocationInformationAddViewModel busLocationInformationAddViewModel)
        {

            var bus_Info = _IMapper.Map<BusLocationInformationAddViewModel, Bus_Location_Information>(busLocationInformationAddViewModel);
            _BusLocationInformationRepository.Add(bus_Info);
            return _BusLocationInformationRepository.SaveChanges();
        }

       
    }
}
