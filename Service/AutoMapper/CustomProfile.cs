using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Dtol.dtol;
using ViewModel.UserViewModel;

namespace Dto.Service.AutoMapper
{
    class CustomProfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public CustomProfile()
        {
            CreateMap<User_Info, LoginViewModel>();
        }
           
    }
}
