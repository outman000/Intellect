using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class ProductListCheckResModel
    {
        public ProductListCheckResModel()
        {
            baseViewModel = new BaseViewModel();

        }

        public bool IsSuccess;
        public int status;

        public BaseViewModel baseViewModel;
    }
}
