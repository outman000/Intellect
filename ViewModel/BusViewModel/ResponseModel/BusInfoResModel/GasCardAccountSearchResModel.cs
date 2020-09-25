using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel
{
    public class GasCardAccountSearchResModel
    {
        public bool IsSuccess;
        public List<Gas_Card_Account>  gas_Card_Accounts;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public GasCardAccountSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
