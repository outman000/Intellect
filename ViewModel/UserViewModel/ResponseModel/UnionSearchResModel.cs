using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class UnionSearchResModel
    {
        public bool isSuccess;
        public List<User_Union>  user_Unions;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public UnionSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
