using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.FoodViewModel.RequestViewModel
{

    /// <summary>
    /// 菜单增加视图
    /// </summary>
    /// 
    public class FoodInfoAddViewModel
    {
        /// <summary>
        /// 食物名称
        /// </summary>
        public string FoodName { get; set; }

        /// <summary>
        /// 食物标识
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 食物价格
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// 食物简介
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 食物种类
        /// </summary>
        public string FoodType { get; set; }
        /// <summary>
        /// 食物图片
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddDate { get; set; }

    }
}
