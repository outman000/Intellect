using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.RepairsViewModel.MiddleModel;

namespace ViewModel.RepairsViewModel.ResponseModel
{
    public class ReminderInfoSearchResModel
    {
        public bool isSuccess;
        public List<ReminderInfoSearchMiddlecs> Reminder_Info;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public ReminderInfoSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
