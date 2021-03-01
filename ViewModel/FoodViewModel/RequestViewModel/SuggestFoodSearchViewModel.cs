using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.FoodViewModel.RequestViewModel
{
    public class SuggestFoodSearchViewModel
    {
        /// <summary>
        /// 人名
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 部门Id
        /// </summary>
        public int? User_DepartId { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? strDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? endDate { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        SuggestFoodSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
