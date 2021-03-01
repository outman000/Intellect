using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RoomViewModel.ResponseModel
{
    public class RoomReservationUpdateResModel
    {
        public RoomReservationUpdateResModel()
        {
            baseViewModel = new BaseViewModel();

        }

        public bool IsSuccess;
        public int UpdateCount;

        public BaseViewModel baseViewModel;
    }
}
