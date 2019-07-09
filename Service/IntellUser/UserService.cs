using AutoMapper;
using Dto.IRepository.IntellUser;
using Dto.IService.IntellUser;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.Service.IntellUser
{
    public class UserService : IUserService
    {
        private readonly IUserInfoRepository _IUserInfoRepository;
        private readonly IMapper _IMapper;

        public UserService(IUserInfoRepository iuserInfoRepository,IMapper mapper)
        {
            _IUserInfoRepository = iuserInfoRepository;
            _IMapper = mapper;
        }

        //添加用户
        public int User_Add(UserAddViewModel userAddViewModel)
        {

            User_Info user_Info  = _IMapper.Map<UserAddViewModel, User_Info>(userAddViewModel);
            _IUserInfoRepository.Add(user_Info);
            return _IUserInfoRepository.SaveChanges();
        }
        //单一用户
        public bool User_Single(UserValideRepeat userValideRepeat)
        {
            IQueryable<User_Info>  Queryable_UserInfo =_IUserInfoRepository
                                                        .GetInfoByUserid(userValideRepeat.UserId);

            return (Queryable_UserInfo.Count() > 0 && Queryable_UserInfo.Count() == 1) ?
                   true : false;
        }

        public int User_Delete(UserDeleteViewModel  userDeleteViewModel)
        {
            throw new NotImplementedException();
        }

        public void User_Search(UserSearchViewModel  userSearchViewModel)
        {
            throw new NotImplementedException();
        }

        public int User_Update(UserUpdateViewModel  userUpdateViewModel)
        {
            throw new NotImplementedException();
        }

     
    }
}
