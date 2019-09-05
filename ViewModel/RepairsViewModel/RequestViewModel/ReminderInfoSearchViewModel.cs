using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    public class ReminderInfoSearchViewModel
    {
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 部门姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 表单外键id
        /// </summary>
        public int? Repair_InfoId { get; set; }

        /// <summary>
        /// 表单标题
        /// </summary>
        public string RepairTitle { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 备用
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddDate { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        ReminderInfoSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
