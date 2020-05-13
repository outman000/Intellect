using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    public class RepairUpdateIsPassViewModel
    { 
        /// <summary>
        /// 报修id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 是否通过（通过，未通过）
        /// </summary>
        public string isPass { get; set; }
    }
}
