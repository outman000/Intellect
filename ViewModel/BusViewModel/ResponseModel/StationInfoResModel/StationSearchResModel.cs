using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel.StationInfoResModel
{
    /// <summary>
    /// 站点查询返回视图
    /// </summary>
    public class StationSearchResModel
    {
        public bool isSuccess;
        public List<StationSearchMiddlecs> station_Infos;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public StationSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
