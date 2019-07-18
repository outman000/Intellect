using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.RequsetModel
{
    /// <summary>
    /// 部门更新视图
    /// </summary>
  public  class DepartUpdateViewModel
    {
        /// <summary>
        /// 部门id
        /// </summary>
        public int Id { get; set; }//部门id
        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }//部门名称
        /// <summary>
        /// 父部门id
        /// </summary>
        public string ParentId { get; set; }//父部门id
        /// <summary>
        /// 部门排序
        /// </summary>
        public int? Sort { get; set; }//部门排序
    }
}
