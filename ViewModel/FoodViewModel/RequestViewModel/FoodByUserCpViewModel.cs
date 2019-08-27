using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.FoodViewModel.RequestViewModel
{
    /// <summary>
    /// 根据用户和菜单查询差评视图
    /// </summary>
    public class FoodByUserCpViewModel
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
        /// 点评标识  1-评价，2-差评
        /// </summary>
        public string status { get; set; }
    }
}
