using Dtol.dtol;
using IntellUser.BaseClass;
using IntellUser.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.UserViewModel;

namespace IntellUser.CLassService
{
    public class LoginService:EFBaseClass, LoginInterface
    {
        public LoginViewModel Login_Valid()
        {
            LoginViewModel viewModel=null;
            User_Info info = _dbContext.user_Info
                            .SingleOrDefault(a => a.UserId == "" & a.UserPwd == "");
            if (info != null)
            {
                viewModel.UserName = info.UserName;
            }
          

            return null;

        }

    }
}
