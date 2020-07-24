using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.MiddleModel
{
    public class BusOrderExcelSearchMiddle
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int Id { get; set; }

      
        /// <summary>
        /// 订单号
        /// </summary>
        public string orderNo { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string departName { get; set; }

        /// <summary>
        /// 增加时间
        /// </summary>
        public string AddDateStr { get; set; }

        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddDate { get; set; }


        /// <summary>
        /// 总费用
        /// </summary>
        public string orderAmount { get; set; }
    }
}
