using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.Service.AutoMapper.UserMapper.RightsResponseMapper
{
   public class RightsAddResMapper : Profile
    {  /// <summary>
       /// 配置构造函数，用来创建关系映射
       /// </summary>
        public RightsAddResMapper()
        {
            // CreateMap<User_Info, LoginViewModel>();
            CreateMap<RightsAddViewModel, User_Rights>();

        }
    }
}
