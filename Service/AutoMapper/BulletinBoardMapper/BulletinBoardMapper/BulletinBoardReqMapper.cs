using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BulletinBoardViewModel.MiddleModel;
using ViewModel.BulletinBoardViewModel.RequestViewModel;

namespace Dto.Service.AutoMapper.BulletinBoardMapper.BulletinBoardMapper
{
    public class BulletinBoardReqMapper : Profile
    {/// <summary>
     /// 配置构造函数，用来创建关系映射
     /// </summary>
        public BulletinBoardReqMapper()
        {
            CreateMap<Bulletin_Board, BulletinBoardSearchMiddlecs>();
            CreateMap<BulletinBoardAddViewModel, Bulletin_Board >();
            CreateMap< BulletinBoardUpdateViewModel, Bulletin_Board >();
        }
    }
}
