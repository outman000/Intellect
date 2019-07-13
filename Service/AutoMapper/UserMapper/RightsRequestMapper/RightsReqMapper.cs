using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.Service.AutoMapper.UserMapper.RightsRequestMapper
{
  public  class RightsReqMapper : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public RightsReqMapper()
        {
            CreateMap<RightsAddViewModel, User_Rights> ();
            CreateMap <RightsUpdateViewModel, User_Rights> ();
            CreateMap<User_Rights, RightsSearchMiddlecs>();
        }
    }
}
