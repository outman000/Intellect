using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.FoodViewModel.MiddleModel
{
    public class FoodPraiseNumMiddlecs
    {
        /// <summary>
        ///菜id
        /// </summary>
        public int Food_InfoId { get; set; }
        /// <summary>
        ///每个菜的名字
        /// </summary>
        public string FoodName { get; set; }

        /// <summary>
        /// 所属地点
        /// </summary>
        public string FoodType { get; set; }

        /// <summary>
        /// 星期数
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 年份
        /// </summary>
        public string Year { get; set; }
        /// <summary>
        /// 周数
        /// </summary>
        public string WeekNumber { get; set; }
        /// <summary>
        ///每个菜的点赞数量
        /// </summary>
        public int PraiseNum { get; set; }



    }
}
