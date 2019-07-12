using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.Service.AutoMapper.UserMapper.DepartResponseMapper
{
   public class DepartAddResMappper : Profile
    {   /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public DepartAddResMappper()
        {
            // CreateMap<User_Info, LoginViewModel>();
            CreateMap<DepartAddViewModel, User_Depart>();

        }
    }
}
