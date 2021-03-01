using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RoomViewModel.MiddleModel;
using ViewModel.RoomViewModel.RequestViewModel;

namespace Dto.Service.AutoMapper.BookMapper.BookMapper
{
    public class RoomInformationReqMapper : Profile
    {

        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public RoomInformationReqMapper()
        {
            CreateMap<RoomInformationAddViewModel, MeetingRoom_Information>();
            CreateMap<RoomInformationUpdateViewModel, MeetingRoom_Information>();
            CreateMap<MeetingRoom_Information, RoomInformationSearchMiddle>()
                .ForMember(s => s.AreaName, sp => sp.MapFrom(src => src.DataBase_Type.Name));
            CreateMap<RoomReservationAddViewModel, MeetingRoom_Reservation>();
            CreateMap<DataBase_Type, DataBaseTypeSearchMiddle>();
            CreateMap<DataBase_Type, FloorAreaRoomSearchViewModel>();
            CreateMap<MeetingRoom_Information, FloorAreaRoomSearchViewModel>();
            CreateMap<MeetingRoom_Reservation, RoomReservationSearchMiddle>()
                .ForMember(s => s.RoomNum, sp => sp.MapFrom(src => src.MeetingRoom_Information.RoomNum))
                .ForMember(s => s.RoomEquipmentName, sp => sp.MapFrom(src => src.MeetingRoom_Information.RoomEquipmentName))
                 .ForMember(s => s.Meetingtime, sp => sp.MapFrom(src => src.Meetingtime.ToString("yyyy-MM-dd HH:mm")))
                  .ForMember(s => s.Endingtime, sp => sp.MapFrom(src => src.Endingtime.ToString("yyyy-MM-dd HH:mm")));


        }
    }
}
