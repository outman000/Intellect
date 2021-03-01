using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.FoodViewModel.MiddleModel
{
    public class FoodCpMiddlecs
    {
      

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

     

        /// <summary>
        /// 菜名
        /// </summary>
        public string FoodName { get; set; }

        /// <summary>
        /// 部门名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 点评内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 周数
        /// </summary>
        public string WeekNumber { get; set; }

        /// <summary>
        /// 年份
        /// </summary>
        public string Year { get; set; }
        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
