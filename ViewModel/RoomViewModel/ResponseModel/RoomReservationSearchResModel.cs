using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.RoomViewModel.MiddleModel;

namespace ViewModel.RoomViewModel.ResponseModel
{
    public class RoomReservationSearchResModel
    {
        public bool isSuccess;
        public List<RoomReservationSearchMiddle> Room_info;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public RoomReservationSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
