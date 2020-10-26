using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;

namespace ViewModel.UserViewModel.RequsetModel
{
    public class IntegralCommodityUpdateViewModel
    {
        /// <summary>
        /// 商品主键ID
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
        /// 用户ID
        /// </summary>
        public string userId { get; set; }

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
        /// 工会信息
        /// </summary>
        public int? User_UnionId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 图片附件
        /// </summary>
        public Commodity_AttachsMiddles AttachsMiddles { get; set; }
    }
}
