using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    /// <summary>
    /// 根据节点查角色
    /// </summary>
    public class RoleByNodeSearchViewModel
    {
        ///// <summary>
        ///// 当前节点id
        ///// </summary>
        //public int Flow_NodeDefineId { get; set; }


        /// <summary>
        /// 下一节点id
        /// </summary>
        public int Flow_NextNodeDefineId { get; set; }

        /// <summary>
        /// 节点保持
        /// </summary>
        public string NodeKeep { get; set; }

        /// <summary>
        /// 提交人用户id （用户保持的时候传）
        /// </summary>
        public int? user_InfoId { get; set; }

        /// <summary>
        /// 提交人部门id（部门保持的时候传）
        /// </summary>
        public int? departId { get; set; }

        /// <summary>
        /// 表单id(此属性可以为空)
        /// </summary>
        public int? Repair_InfoId { get; set; }
        /// <summary>
        /// 表单类型（1-报修类型，2-意见类型,3-班车类型）
        /// </summary>
        public string isHandler { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        public RoleByNodeSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
