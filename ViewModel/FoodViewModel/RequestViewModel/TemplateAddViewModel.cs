using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.FoodViewModel.RequestViewModel
{
    public class TemplateAddViewModel
    {
        /// 创建人
        /// </summary>
        public string createUser { get; set; }

        /// <summary>
        /// 食物地点分类
        /// </summary>
        public string FoodType { get; set; }


        /// <summary>
        /// 周数
        /// </summary>
        public string WeekNumber { get; set; }



        /// <summary>
        /// 年份
        /// </summary>
        public string Year { get; set; }

    }
}
