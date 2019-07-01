using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel;

namespace Dto.IService.IntellUser
{
    public interface IUserService
    {
          void User_Add(UserAddViewModel  userAddViewModel);
          void User_Update(UserDeleteViewModel userDeleteViewModel);
          void User_Delete(UserSearchViewModel  userSearchViewModel);
          void User_Search(UserUpdateViewModel  userUpdateViewModel);
    }
}
