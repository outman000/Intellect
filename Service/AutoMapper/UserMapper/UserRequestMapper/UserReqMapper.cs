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
        }
    }
    
}
