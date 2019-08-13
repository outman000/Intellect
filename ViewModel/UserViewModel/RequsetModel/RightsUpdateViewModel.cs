﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.RequsetModel
{
    /// <summary>
    /// 权限更新视图
    /// </summary>
    public class RightsUpdateViewModel
    {
        /// <summary>
        /// 角色id
        /// </summary>
        public int Id { get; set; }//id
        /// <summary>
        /// 权限名称
        /// </summary>
        public string RightsName { get; set; }//权限名称
     
        /// <summary>
        /// url地址
        /// </summary>
        public string Url { get; set; }//url地址
        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort { get; set; }//排序
        /// <summary>
        /// 父节点id
        /// </summary>
        public string ParentId { get; set; }//父节点id 
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }//类型
    }
}
