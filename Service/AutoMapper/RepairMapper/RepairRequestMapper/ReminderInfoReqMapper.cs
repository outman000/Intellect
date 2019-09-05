using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.Service.AutoMapper.RepairMapper.RepairRequestMapper
{
    public class ReminderInfoReqMapper : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public ReminderInfoReqMapper()
        {

            CreateMap<Reminder_Info, ReminderInfoSearchMiddlecs>()
            .ForMember(s => s.Name, sp => sp.MapFrom(src => src.User_Info.User_Depart.Name))
            .ForMember(s => s.RepairTitle, sp => sp.MapFrom(src => src.Repair_Info.RepairsTitle))
            .ForMember(s => s.UserName, sp => sp.MapFrom(src => src.User_Info.UserName));
            CreateMap<ReminderInfoAddViewModel, Reminder_Info>();

        }
    }
}
