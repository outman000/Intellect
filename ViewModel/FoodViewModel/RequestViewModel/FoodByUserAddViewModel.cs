using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.FoodViewModel.RequestViewModel
{
    public class FoodByUserAddViewModel
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
