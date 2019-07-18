using AutoMapper;
using Dto.IRepository.IntellRegularBus;
using Dto.IService.IntellRegularBus;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel;

namespace Dto.Service.IntellRegularBus
{
    public class BusService : IBusService
    {
        private readonly IBusInfoRepository _IBusInfoRepository;
        private readonly IMapper _IMapper;


        public BusService(IBusInfoRepository ibusInfoRepository,  IMapper mapper)
        {
            _IBusInfoRepository = ibusInfoRepository;
        
            _IMapper = mapper;
        }
        public List<BusSearchMiddlecs> Bus_Search(BusSearchViewModel busSearchViewModel)
        {
            List<Bus_Info> bus_Infos = _IBusInfoRepository.SearchInfoByWhere(busSearchViewModel);

            List<BusSearchMiddlecs> busSearches = new List<BusSearchMiddlecs>();

            foreach (var item in bus_Infos)
            {
                var BusSearchMiddlecs = _IMapper.Map<Bus_Info, BusSearchMiddlecs>(item);
                busSearches.Add(BusSearchMiddlecs);

            }
            return busSearches;

        }

      
    }
}
