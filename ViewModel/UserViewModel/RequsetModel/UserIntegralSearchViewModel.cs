using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.RequsetModel
{
    public class UserIntegralSearchViewModel
    {

        public string UserName { get; set; }

        /// <summary>
        /// 部门id
        /// </summary>
        public int? User_DepartId { get; set; }


        /// <summary>
        /// 开始分数
        /// </summary>
        public int? starPoints { get; set; }

        /// <summary>
        /// 结束分数
        /// </summary>
        public int? endPoints { get; set; }

        public string Mobile { get; set; }
        /// <summary>
        /// 工会信息
        /// </summary>
        public int? User_UnionId { get; set; }
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
        UserIntegralSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }

    }
}
