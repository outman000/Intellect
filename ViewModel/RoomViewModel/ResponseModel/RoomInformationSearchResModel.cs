using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.RoomViewModel.MiddleModel;

namespace ViewModel.RoomViewModel.ResponseModel
{
    public class RoomInformationSearchResModel
    {
        public bool isSuccess;
        public List<RoomInformationSearchMiddle> Room_info;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public RoomInformationSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
