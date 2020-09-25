using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class UserRegisterResModel
    {
        public UserRegisterResModel()
        {
            baseViewModel = new BaseViewModel();

        }

        public bool IsSuccess;
        /// <summary>
        /// 0-注册成功，可以调整登录页；1-注册失败,未注册过电子通行证；2-注册失败,注册过电子通行证并且智慧后勤也已经有身份信息,请勿重复操作
        /// </summary>
        public int Status;

        public BaseViewModel baseViewModel;
    }
}
