using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.FoodViewModel.MiddleModel;
using ViewModel.FoodViewModel.RequestViewModel;

namespace Dto.Service.AutoMapper.FoodMapper.FoodReqMapper
{
    public class FoodReqMapper : Profile
    {

        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public FoodReqMapper()
        {
            CreateMap<FoodInfoAddViewModel, Food_Info>();
            CreateMap< FoodInfoUpdateViewModel, Food_Info >();
            CreateMap< FoodByUserPraiseViewModel, User_Relate_Food > ();
            CreateMap< FoodByUserAddCpViewModel, User_Relate_Food >();
            CreateMap< User_Relate_Food, FoodCpMiddlecs >()
            .ForMember(s => s.UserName, sp => sp.MapFrom(src => src.User_Info.UserName))
            .ForMember(s => s.FoodName, sp => sp.MapFrom(src => src.Food_Info.FoodName))
            .ForMember(s => s.Content, sp => sp.MapFrom(src => src.Content))
            .ForMember(s => s.WeekNumber, sp => sp.MapFrom(src => src.Food_Info.WeekNumber))
            .ForMember(s => s.Year, sp => sp.MapFrom(src => src.Food_Info.Year))
            .ForMember(s => s.Name, sp => sp.MapFrom(src => src.User_Info.User_Depart.Name));
            CreateMap< FoodByUserCpViewModel, User_Relate_Food >();

            CreateMap<SuggestFoodAddViewModel, Suggest_Food>();

            CreateMap< Suggest_Food ,SuggestFoodSearchMiddleModel>()
            .ForMember(s => s.UserName, sp => sp.MapFrom(src => src.User_Info.UserName))
            .ForMember(s => s.DeptName, sp => sp.MapFrom(src => src.User_Info.User_Depart.Name));

            CreateMap<Food_Info, TemplateAddMiddleViewModel>();
            CreateMap< TemplateAddMiddleViewModel, Food_Info>();

            CreateMap<Food_Info,FoodInfoSearchMiddle>();
        }
    }
}
