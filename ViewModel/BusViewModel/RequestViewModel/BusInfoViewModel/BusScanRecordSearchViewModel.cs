using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel
{
    public class BusScanRecordSearchViewModel
    {

      

        /// <summary>
        /// 部门名
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 线路名
        /// </summary>

        public string LineName { get; set; }


        /// <summary>
        /// 扫码状态
        /// </summary>

        public string status { get; set; }

        public DateTime? startdate { get; set; }
        public DateTime? enddate { get; set; }


        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        BusScanRecordSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }

    }
}
