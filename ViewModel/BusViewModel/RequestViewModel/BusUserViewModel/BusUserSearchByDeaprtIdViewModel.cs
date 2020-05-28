using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.RequestViewModel.BusUserViewModel
{
    public class BusUserSearchByDeaprtIdViewModel
    {
        /// <summary>
        /// 部门id
        /// </summary>
        public string User_DepartId { get; set; }

        /// <summary>
        /// 乘车时间
        /// </summary>
        public DateTime? carDate { get; set; }
    }
}
