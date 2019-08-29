using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.FoodViewModel.RequestViewModel
{
    public class FoodByUserSearchCpViewModel
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int? User_InfoId { get; set; }

        /// <summary>
        /// 菜id
        /// </summary>
        public int? Food_InfoId { get; set; }

        /// <summary>
        /// 点评标识  1-评价，2-差评
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 点评内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        FoodByUserSearchCpViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
