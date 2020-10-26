using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.MiddleModel
{
    public class IntegralCommodityMiddle
    {
        /// <summary>
        /// 商品Id
        /// </summary>
        public string Id { get; set; }


        /// <summary>
        /// 商品名
        /// </summary>
        public string CommodityName { get; set; }


        /// <summary>
        /// 商品单位
        /// </summary>
        public string CommodityUnit { get; set; }

        /// <summary>
        /// 商品分类
        /// </summary>
        public string CommodityType { get; set; }
        /// <summary>
        /// 积分数
        /// </summary>
        public string IntegralNum { get; set; }

        /// <summary>
        /// 商品简介
        /// </summary>
        public string CommodityIntroduction { get; set; }

        /// <summary>
        /// 工会名称
        /// </summary>
        public string UnionName { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 头像URL
        /// </summary>
        public string Url { get; set; }


        /// <summary>
        /// 创建人
        /// </summary>
        public string createUser { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string updateUser { get; set; }

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
