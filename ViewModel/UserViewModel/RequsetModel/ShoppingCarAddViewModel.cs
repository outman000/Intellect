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
        /// 商品单位
        /// </summary>
        public string CommodityUnit { get; set; }

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
        /// 用户名
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// 部门Id
        /// </summary>
        public int? User_DepartId { get; set; }
        /// <summary>
        /// 工会名称
        /// </summary>

        public string UnionName { get; set; }
        /// <summary>
        /// 工会Id
        /// </summary>

        public int? User_UnionId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName { get; set; }
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
