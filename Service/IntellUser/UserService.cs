using Dto.IRepository.IntellUser;
using Dto.IService.IntellUser;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel;

namespace Dto.Service.IntellUser
{
    public class UserService : IUserService
    {
        private readonly IUserInfoRepository _IUserInfoRepository;

        public UserService(IUserInfoRepository iuserInfoRepository)
        {
            _IUserInfoRepository = iuserInfoRepository;
        }

        public void User_Add(UserAddViewModel userAddViewModel)
        {
            throw new NotImplementedException();
        }

        public void User_Delete(UserSearchViewModel userSearchViewModel)
        {
            throw new NotImplementedException();
        }

        public void User_Search(UserUpdateViewModel userUpdateViewModel)
        {
            throw new NotImplementedException();
        }

        public void User_Update(UserDeleteViewModel userDeleteViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
