﻿using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
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


        }
    }
}