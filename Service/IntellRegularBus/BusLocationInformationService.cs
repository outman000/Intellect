using AutoMapper;
using Dto.IRepository.IntellRegularBus;
using Dto.IService.IntellRegularBus;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel;

namespace Dto.Service.IntellRegularBus
{
    public class BusLocationInformationService : IBusLocationInformationService
    {

        private readonly IBusLocationInformationRepository _BusLocationInformationRepository;
        private readonly IBusInfoRepository _IBusInfoRepository;
        private readonly IMapper _IMapper;


        public BusLocationInformationService(IBusInfoRepository ibusInfoRepository, IBusLocationInformationRepository  busLocationInformationRepository, IMapper mapper)
        {
            _BusLocationInformationRepository = busLocationInformationRepository;
            _IBusInfoRepository = ibusInfoRepository;
            _IMapper = mapper;
        }

       /// <summary>
       /// 添加班车位置信息
       /// </summary>
       /// <param name="busLocationInformationAddViewModel"></param>
       /// <returns></returns>
        public int BusLocationInformation_Add(BusLocationInformationAddViewModel busLocationInformationAddViewModel)
        {

            //判断当前时间是否在工作时间段内
            try
            {

                string _staWorkingDayAM = "06:00";//工作时间上午08:30
                string _endWorkingDayAM = "09:00";//工作时间上午08:30

                string _staWorkingDayPM = "17:00";
                string _endWorkingDayPM = "19:00";
                TimeSpan dspWorkingDayAM = DateTime.Parse(_staWorkingDayAM).TimeOfDay;
                TimeSpan dspWorkingDayAM2 = DateTime.Parse(_endWorkingDayAM).TimeOfDay;

                TimeSpan dspWorkingDayPM = DateTime.Parse(_staWorkingDayPM).TimeOfDay;
                TimeSpan dspWorkingDayPM2 = DateTime.Parse(_endWorkingDayPM).TimeOfDay;
                TimeSpan dspNow = DateTime.Now.TimeOfDay;
                if ((dspNow > dspWorkingDayAM && dspNow < dspWorkingDayAM2) || (dspNow > dspWorkingDayPM && dspNow < dspWorkingDayPM2))//上午6-9点或者下午5-7点
                {
                    var bus_Info = _IBusInfoRepository.GetInfoByDeviceNumber(busLocationInformationAddViewModel.deviceNumber);         
                    if(bus_Info.Count>0)
                    {
                        var Bus_Location_Information = _IMapper.Map<BusLocationInformationAddViewModel, Bus_Location_Information>(busLocationInformationAddViewModel);
                        Bus_Location_Information.LineName = bus_Info[0].Bus_Line.LineName;
                        Bus_Location_Information.LineId = bus_Info[0].Bus_LineId.Value;
                        _BusLocationInformationRepository.Add(Bus_Location_Information);
                        _BusLocationInformationRepository.SaveChanges();
                        return 0;

                    }
                    else
                    {
                        return 2;
                    }

                }
                else
                    return 1;
        }
            catch(Exception e)
            {

                return 3;
            }
        }
        /// <summary>
        /// 根据条件查询车辆经纬度
        /// </summary>
        /// <param name="busLocationInformationSearchViewModel"></param>
        /// <returns></returns>
        public BusLocationInformationSearchMiddle BusLocationInformation_Search(BusLocationInformationSearchViewModel busLocationInformationSearchViewModel)
        {

            List<Bus_Location_Information> bus_Location_Information = _BusLocationInformationRepository.
                SearchInfoByBusLocationInformationWhere(busLocationInformationSearchViewModel);

        

            var result = _IMapper.Map<List<Bus_Location_Information>, List<BusLocationInformationSearchMiddle>>(bus_Location_Information);
            if (result.Count == 0)
                return null;

            return result[0];
        }


        /// <summary>
        /// 根据条件查询车辆基本信息
        /// </summary>
        /// <param name="busLocationInformationSearchViewModel"></param>
        /// <returns></returns>
        public BusBasicSearchMiddle BusBasic_Search(BusLocationInformationSearchViewModel busLocationInformationSearchViewModel)
        {

            Bus_Info bus_Info = _IBusInfoRepository.SearchBusInfoSingleByLineWhere(busLocationInformationSearchViewModel.LineId);//根据线路Id查班车
            var result = _IMapper.Map<Bus_Info, BusBasicSearchMiddle>(bus_Info);

            return result;
        }
    }
}
