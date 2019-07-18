using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel.LineInforResModel
{
    public class LineSearchResModel
    {
        public bool isSuccess;
        public List<LineSearchResModel> bus_Infos;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public LineSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
