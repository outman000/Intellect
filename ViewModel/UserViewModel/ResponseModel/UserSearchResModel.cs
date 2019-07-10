using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.UserViewModel.MiddleModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class UserSearchResModel
    {
       public bool isSuccess;
       public List<UserSearchMiddlecs> user_Infos;
       public BaseViewModel baseViewModel;
        public UserSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }

}
