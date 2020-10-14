using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.RequsetModel
{
    public class ProductListSearchViewModel
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
        /// 部门Id
        /// </summary>
        public int? User_DepartId { get; set; }


        /// <summary>
        /// 工会Id
        /// </summary>
        public int? User_UnionId { get; set; }

        /// <summary>
        /// 商品个数
        /// </summary>
        public string CommodityNum { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? starDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? endDate { get; set; }

    


        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        ProductListSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
