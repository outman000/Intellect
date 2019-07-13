using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;

namespace Dto.Service.AutoMapper.UserMapper.RoleRequestMapper
{
    public class RelateRoleMapper : Profile
    {

        public RelateRoleMapper()
        {
            CreateMap<RelateRoleUserAddMiddles, User_Relate_Info_Role>();
        }
    }
}
