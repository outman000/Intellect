using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.RequsetModel
{
    public class ShoppingCarAddViewModel
    {
        /// <summary>
        /// 商品名
        /// </summary>

        public string CommodityName { get; set; }

        /// <summary>
        /// 商品主键id
        /// </summary>

        public string formid { get; set; }
        /// <summary>
        /// 积分数
        /// </summary>

        public string IntegralNum { get; set; }

        /// <summary>
        /// 用户主键id
        /// </summary>

        public string userId { get; set; }

        /// <summary>
        /// 商品个数
        /// </summary>

        public string CommodityNum { get; set; }


        /// <summary>
        /// 商品类型
        /// </summary>
        public string CommodityType { get; set; }
    }
}
