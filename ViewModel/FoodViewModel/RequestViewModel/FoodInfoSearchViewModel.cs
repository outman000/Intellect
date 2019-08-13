using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.FoodViewModel.RequestViewModel
{
    public class FoodInfoSearchViewModel
    {

        /// <summary>
        /// 食物名称
        /// </summary>
        public string FoodName { get; set; }
        /// <summary>
        /// 食物价格
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// 星期数
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 食物地点分类
        /// </summary>
        public string FoodType { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        FoodInfoSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
