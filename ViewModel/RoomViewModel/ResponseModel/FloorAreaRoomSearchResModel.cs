using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.RoomViewModel.RequestViewModel;

namespace ViewModel.RoomViewModel.ResponseModel
{
    public class FloorAreaRoomSearchResModel
    {
        public bool isSuccess;
        public List<FloorAreaRoomSearchViewModel> Room_info;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public FloorAreaRoomSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
