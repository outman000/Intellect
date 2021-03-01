using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RoomViewModel.ResponseModel
{
    public class RoomInformationUpdateResModel
    {
        public RoomInformationUpdateResModel()
        {
            baseViewModel = new BaseViewModel();
        }

        public bool IsSuccess;
        public int AddCount;

        public BaseViewModel baseViewModel;
    }
}
