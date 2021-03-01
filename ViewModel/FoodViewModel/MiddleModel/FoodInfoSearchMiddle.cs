using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.FoodViewModel.MiddleModel
{
    public class FoodInfoSearchMiddle
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
        /// 食物种类
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// 食物地点分类
        /// </summary>
        public string FoodType { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        public string isDelete { get; set; }

        /// <summary>
        /// 标识 0-上架，1-下架
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 周数
        /// </summary>
        public string WeekNumber { get; set; }

        /// <summary>
        /// 年份
        /// </summary>
        public string Year { get; set; }


        /// 创建人
        /// </summary>
        public string createUser { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string updateUser { get; set; }
        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? updateDate { get; set; }


        /// 点赞状态 0-有好评，1-有差评,2-没有任何评价
        /// </summary>
        public string UpDownStatus { get; set; }

        ///// 差评状态
        ///// </summary>
        //public string thumbsDownStatus { get; set; }

    }
}
