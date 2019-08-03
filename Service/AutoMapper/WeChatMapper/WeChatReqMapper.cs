using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;
using ViewModel.UserViewModel.RequsetModel;
using ViewModel.WeChatViewModel.MiddleModel;

namespace Dto.Service.AutoMapper.WeChatMapper
{
    public class WeChatReqMapper : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public WeChatReqMapper()
        {
            CreateMap<User_Info, WeChatLoginMiddlecs>()
            .ForMember(s => s.Name, sp => sp.MapFrom(src => src.User_Depart.Name));

            CreateMap<WeChatLoginMiddlecs, RoleByUserSearchViewModel>()
           .ForMember(s => s.UserId, sp => sp.MapFrom(src => src.Id));

            CreateMap<User_Relate_Info_Role, RightsByRoleSearchViewModel > ()
          .ForMember(s => s.RoleId, sp => sp.MapFrom(src => src.User_RoleId));


            CreateMap<User_Rights, RightsSearchMiddlecs>();

            CreateMap<RightsSearchMiddlecs, WeChatLoginMiddlecs>()
              .ForMember(s => s.RightsId, sp => sp.MapFrom(src => src.Id))
              .ForMember(s => s.RightsName  , sp => sp.MapFrom(src => src.RightsName))
              .ForMember(s => s.RightsValue, sp => sp.MapFrom(src => src.RightsValue))
              .ForMember(s => s.Sort, sp => sp.MapFrom(src => src.Sort))
              .ForMember(s => s.Url, sp => sp.MapFrom(src => src.Url))
              .ForMember(s => s.Type, sp => sp.MapFrom(src => src.Type));

        }
    }
}
