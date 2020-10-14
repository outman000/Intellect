using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.RequsetModel
{
    public class IntegralCommoditySearchViewModel
    {
        /// <summary>
        /// 商品名
        /// </summary>
        public string CommodityName { get; set; }



        /// <summary>
        /// 积分数
        /// </summary>
        public string IntegralNum { get; set; }


        /// <summary>
        /// 工会信息
        /// </summary>
        public int? User_UnionId { get; set; }

        /// <summary>
        /// 状态 0-上架，1-下架
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        IntegralCommoditySearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }

}
