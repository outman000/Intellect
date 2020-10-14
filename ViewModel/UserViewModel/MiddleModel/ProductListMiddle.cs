using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.MiddleModel
{
    public class ProductListMiddle
    {
        /// <summary>
        /// 商品名
        /// </summary>
        public string CommodityName { get; set; }

        /// <summary>
        /// 商品类型
        /// </summary>
        public string CommodityType { get; set; }

        /// <summary>
        /// 积分数
        /// </summary>
        public string IntegralNum { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 工会名称
        /// </summary>
        public string UnionName { get; set; }
  
        /// <summary>
        /// 商品个数
        /// </summary>
        public string CommodityNum { get; set; }

        /// <summary>
        /// 图片路径
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 兑换时间
        /// </summary>
        public DateTime? AddDate { get; set; }

    }
}
