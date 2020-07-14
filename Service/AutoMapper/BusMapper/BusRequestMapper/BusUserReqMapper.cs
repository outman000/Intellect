using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.BusUserViewModel;

namespace Dto.Service.AutoMapper.BusMapper.BusRequestMapper
{
    public class BusUserReqMapper : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public BusUserReqMapper()
        {
            CreateMap<BusUserAddViewModel, Bus_Payment>();
            CreateMap < BusUserUpdateViewModel, Bus_Payment>();

            CreateMap<Bus_Payment, BusUserSearchMiddlecs>()
           .ForMember(s => s.orderNo, sp => sp.MapFrom(src => src.Bus_Payment_Order.orderNo));

            CreateMap<BusPaymentUpdateViewModel, Bus_Payment>();
            CreateMap<NowDateUpdateViewModel, Bus_Payment>();
            CreateMap<NowDateUpdateViewModel, BusUserAddViewModel>();
            CreateMap<Bus_Payment, BusUserAddViewModel>();
            CreateMap<Bus_Payment_OrderAddViewModel,Bus_Payment_Order> ();
            CreateMap< Bus_Payment_OrderUpdateViewModel, Bus_Payment_Order > ();
            CreateMap< Bus_Payment , Bus_Payment_Search >();
            CreateMap<Bus_Payment_Order, Bank_PaymentViewModel>();
            CreateMap<BusLocationInformationAddViewModel, Bus_Location_Information>();
            CreateMap<Bus_Scan_RecordAddViewModel, Bus_Scan_Record>();
        }
    }
}
