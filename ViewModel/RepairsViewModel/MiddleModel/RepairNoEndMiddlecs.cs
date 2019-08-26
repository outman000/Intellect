﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.MiddleModel
{
    public class RepairNoEndMiddlecs
    {
        public string Title { get; set; }
        public int RepairInfoId { get; set; }
        public int? User_InfoId { get; set; }
        /// <summary>
        /// 报修时间
        /// </summary>
        public DateTime? repairsDate { get; set; }
    }
}
