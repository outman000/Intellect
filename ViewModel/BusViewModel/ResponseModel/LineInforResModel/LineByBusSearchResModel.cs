using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel.LineInforResModel
{
    /// <summary>
    /// 线路查询返回视图
    /// </summary>
    public class LineByBusSearchResModel
    {
        public bool IsSuccess;
        public List<LineSearchMiddlecs> line_Infos;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public LineByBusSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
