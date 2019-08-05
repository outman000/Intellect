using AutoMapper;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;
using ViewModel.UserViewModel.RequsetModel;
using ViewModel.WeChatViewModel.MiddleModel;

namespace Dto.Service.AutoMapper.WeChatMapper
{
    public class WeChatReqMapper : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public WeChatReqMapper()
        {
            CreateMap<User_Info, WeChatIndexMiddlecs>();
     




        }
    }
}
