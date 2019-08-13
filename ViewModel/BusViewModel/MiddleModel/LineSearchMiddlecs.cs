using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.MiddleModel
{
    public class LineSearchMiddlecs
    {
        public int Id { get; set; }
        public string LineName { get; set; }
        public string status { get; set; }
        public string Code { get; set; }
        public string Remark { get; set; }

        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? updateDate { get; set; }

    }
}
