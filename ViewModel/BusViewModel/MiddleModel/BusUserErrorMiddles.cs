using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.MiddleModel
{
    /// <summary>
    /// 用户错误表中间件儿
    /// </summary>
   public class BusUserErrorMiddles
    {
        public int Id { get; set; }
        public string  Username { get; set; }
        public string PayName { get; set; }
        public string BaseName { get; set; }
        public DateTime? CreateDate { get; set; }
   }
}
