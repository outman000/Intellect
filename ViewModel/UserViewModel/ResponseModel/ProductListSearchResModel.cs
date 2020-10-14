using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.UserViewModel.MiddleModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class ProductListSearchResModel
    {
        public bool isSuccess;
        public List<ProductListMiddle>  productListMiddles;
        public BaseViewModel baseViewModel;
        public int TotalNum;

        public ProductListSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
