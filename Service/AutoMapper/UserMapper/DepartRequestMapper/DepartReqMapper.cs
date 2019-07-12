using AutoMapper;
using Dtol.dtol;
using ViewModel.UserViewModel.MiddleModel;
using ViewModel.UserViewModel.RequsetModel;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.Service.AutoMapper.UserMapper.DepartRequestMapper
{
    public class DepartReqMapper : Profile
    {   /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public DepartReqMapper()
        {
            CreateMap<DepartAddViewModel, User_Depart>();
            CreateMap<DepartUpdateViewModel, User_Depart>();
            CreateMap<User_Depart, DepartSearchMiddlecs>();
        }
    }
}
