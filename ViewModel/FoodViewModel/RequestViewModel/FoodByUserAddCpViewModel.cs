using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.FoodViewModel.RequestViewModel
{
    public class FoodByUserAddCpViewModel
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int User_InfoId { get; set; }

        /// <summary>
        /// 菜id
        /// </summary>
        public int Food_InfoId { get; set; }

        /// <summary>
        /// 点评标识  1-评论，2-差评
        /// </summary>
        public string status { get; set; }

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
