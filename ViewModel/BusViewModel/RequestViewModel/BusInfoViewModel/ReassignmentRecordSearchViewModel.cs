using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel
{
    public class ReassignmentRecordSearchViewModel
    {
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        ReassignmentRecordSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
