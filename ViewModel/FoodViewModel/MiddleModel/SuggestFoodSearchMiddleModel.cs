using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.FoodViewModel.MiddleModel
{
    public class SuggestFoodSearchMiddleModel
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }


        /// <summary>
        /// 意见箱表单分类
        /// </summary>
        public string SuggestType { get; set; }

        /// <summary>
        /// 具体意见内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 意见表单填写时间
        /// </summary>
        public DateTime? SuggestDate { get; set; }
     
        /// 创建人
        /// </summary>
        public string UserName { get; set; }

        /// 部门
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 增加时间
        /// </summary>

        public DateTime? AddDate { get; set; }



    }
}
