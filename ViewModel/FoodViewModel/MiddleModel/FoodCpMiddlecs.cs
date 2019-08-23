using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.FoodViewModel.MiddleModel
{
    public class FoodCpMiddlecs
    {
        public int Id { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserName { get; set; }

     

        /// <summary>
        /// 菜名
        /// </summary>
        public int FoodName { get; set; }


        /// <summary>
        /// 点评内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
