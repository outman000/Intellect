
using Dto.IRepository.IntellUser;
using Dto.IService.IntellUser;

using System;
using ViewModel.UserViewModel;

namespace Dto.Service.IntellUser
{
    public class LoginService: ILoginService
    {
        private readonly IUserInfoRepository _IUserInfoRepository;

        public LoginService(IUserInfoRepository iuserInfoRepository)
        {
            _IUserInfoRepository = iuserInfoRepository;
        }

        //登录验证
        public void Login_Valide(LoginViewModel loginViewModel)
        {
          
        }
        //添加用户
        public void User_Add(UserAddViewModel userAddViewModel)
        {
            
        }
    }
}
