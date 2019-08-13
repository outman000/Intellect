using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Food_Info
    {

        /// <summary>
        ///主键id
        /// </summary>
        public int Id { get; set; }

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
        /// 星期数
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 食物图片
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// 食物地点分类
        /// </summary>
        public string FoodType { get; set; }

        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? updateDate { get; set; }



    }
}
