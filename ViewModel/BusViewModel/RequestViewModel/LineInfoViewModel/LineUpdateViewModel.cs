using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel
{
   public class LineUpdateViewModel
   {    
        /// <summary>
        /// 线路id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string LineName { get; set; }
        /// <summary>
        /// 状态 0-禁用 1-启用
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 线路标识
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 线路描述
        /// </summary>
        public string Remark { get; set; }
   }
}
