using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel.BusInfoViewModel
{
    /// <summary>
    /// 班车查询返回视图
    /// </summary>
    public class BusSearchResModel
    {
        public bool isSuccess;
        public List<BusSearchMiddlecs> bus_Infos;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public BusSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
