using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Food_Evaluation
    {
        /// <summary>
        ///主键id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int User_InfoId { get; set; }

        public User_Info User_Info { get; set; }

        /// <summary>
        /// 食物Id
        /// </summary>
        public int Food_InfoId { get; set; }

        public Food_Info Food_Info { get; set; }
        /// <summary>
        /// 评论内容
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
