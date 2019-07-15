using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.ResponseModel
{
   public class DepartSearchResModel
    {
        public bool isSuccess;
        public List<DepartSearchMiddlecs> user_Departs;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public DepartSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
