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
            CreateMap<RelateRoleUserAddMiddlecs, User_Relate_Info_Role>();
            CreateMap<RelateRoleRightAddMiddlecs, User_Relate_Role_Right>();
        

        }
        
    }
}
