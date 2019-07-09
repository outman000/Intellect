using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.Service.AutoMapper.UserMapper.UserResponseMapper
{
    public class UserAddResMapper : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public UserAddResMapper()
        {
            // CreateMap<User_Info, LoginViewModel>();
            CreateMap<UserAddViewModel, User_Info>();

        }
    }
}
