using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.RequsetModel
{
    /// <summary>
    /// 部门查询视图模型
    /// </summary>
    public class DepartSearchViewModel
    {     
        /// <summary>
         /// 部门名称
         /// </summary>
        public string Name { get; set; }//部门名称
        /// <summary>
        /// 父部门id
        /// </summary>
        public string ParentId { get; set; }//父部门id
        /// <summary>
        /// 部门标识
        /// </summary>
        public string Code { get; set; }//部门标识
        /// <summary>
        /// 部门排序
        /// </summary>
        public int? Sort { get; set; }//部门排序
         /// <summary>
         /// 分页
         /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        DepartSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
