using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.Service.AutoMapper.UserMapper.RoleRequestMapper
{
    public class RoleResMapper : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public RoleResMapper()
        {
            CreateMap<UserRoleAddViewModel, User_Role>();
            CreateMap<UserRoleUpdateViewModel, User_Role>();
            CreateMap<User_Role, UserRoleSearChMiddles>();
        }
    }
}
