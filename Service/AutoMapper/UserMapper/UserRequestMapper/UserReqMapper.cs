using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.Service.AutoMapper.UserMapper.UserRequestMapper
{
    public class UserReqMapper : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public UserReqMapper()
        {
            CreateMap<UserAddViewModel, User_Info>();
            CreateMap<UserUpdateViewModel, User_Info>();
            CreateMap<User_Info, UserSearchMiddlecs>();
            CreateMap<RelateDepartUserAddMiddlecs, User_Info>();
            CreateMap<User_Info, User_Info>();
            CreateMap<UserRegisterViewModel, User_Info>();
            CreateMap<UserIntegralLogAddViewModel, User_Integral_Log>();
            CreateMap<UserIntegralLogAddViewModel, User_Integral>();
            CreateMap<UserRegisterViewModel, UserRegisterMiddle>();
            CreateMap< UserRegisterMiddle, User_Info >();
            CreateMap< UserRegisterViewModel, User_Register >();
            CreateMap<UserRegisterUpdateViewModel, User_Register>();
            CreateMap<UserRegisterMiddleToUserInfo, User_Info>();
            CreateMap<User_Register, UserRegisterMiddleToUserInfo >();
            CreateMap< RelateUnionUserAddMiddle, User_Info >();
            CreateMap < User_Test, User_Info > ();
            CreateMap < User_Test, UserTestMiddle>();
            CreateMap< UserTestMiddle, User_Info >();
            CreateMap<IntegralCommodityAddViewModel, Integral_Commodity>();
            CreateMap< ShoppingCarAddViewModel, Product_List>();
            CreateMap<Commodity_Attachs, Commodity_AttachsMiddles >();
            CreateMap<Integral_Commodity, IntegralCommodityMiddle>();
            CreateMap<Commodity_AttachsMiddles, Commodity_Attachs>();
            CreateMap<IntegralCommodityUpdateViewModel, Integral_Commodity>();
            CreateMap< Product_List, ProductListMiddle >();
            CreateMap<User_Integral, UserIntegralSearchMiddle>();


            CreateMap<User_Info, UserIntegralLogAddViewModel >()
            .ForMember(s => s.User_DepartId, sp => sp.MapFrom(src => src.User_DepartId))
            .ForMember(s => s.UserName, sp => sp.MapFrom(src => src.UserName))
            .ForMember(s => s.createUser, sp => sp.MapFrom(src => src.Id))
            .ForMember(s => s.Idcard, sp => sp.MapFrom(src => src.Idcard))
            .ForMember(s => s.Mobile, sp => sp.MapFrom(src => src.PhoneCall))
            .ForMember(s => s.Dept, sp => sp.MapFrom(src => src.User_Depart.Name));
        }
    }
    
}
