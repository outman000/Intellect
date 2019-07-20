using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel.LineInforResModel
{
    public class LineByStationSearchResModel
    {
       

        public bool IsSuccess;
        public List<LineSearchMiddlecs> line_Infos;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public LineByStationSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
