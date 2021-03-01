using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RoomViewModel.ResponseModel
{
    public class RoomInformationDeleteResModel
    {
        public RoomInformationDeleteResModel()
        {
            baseViewModel = new BaseViewModel();

        }

        public bool IsSuccess;
        public int DeleteCount;
        public int DeleteFalseCount;

        public BaseViewModel baseViewModel;
    }
}
