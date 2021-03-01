using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.RoomViewModel.MiddleModel;

namespace ViewModel.RoomViewModel.ResponseModel
{
    public class DataBaseTypeSearchResModel
    {
        public bool isSuccess;
        public List<DataBaseTypeSearchMiddle> Room_info;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public DataBaseTypeSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
