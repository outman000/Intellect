using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel.LineInforResModel
{
    public class LineSearchResModel
    {
        public bool isSuccess;
        public List<LineSearchMiddlecs> bus_Line;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public LineSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
