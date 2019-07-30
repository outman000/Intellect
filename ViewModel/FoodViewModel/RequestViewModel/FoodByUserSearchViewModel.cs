using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.FoodViewModel.RequestViewModel
{
    /// <summary>
    /// 根据用户和菜单查询点赞视图
    /// </summary>
    public class FoodByUserSearchViewModel
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 菜id
        /// </summary>
        public int FoodId { get; set; }
       
    }
}
