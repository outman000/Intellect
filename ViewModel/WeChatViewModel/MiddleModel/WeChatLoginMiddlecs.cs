using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.WeChatViewModel.MiddleModel
{
    public class WeChatLoginMiddlecs
    {
        /// <summary>
        /// 用户主键id
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        /// 
        public string Name { get; set; }

        /// <summary>
        /// 权限id
        /// </summary>
        public int? RightsId { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string RightsName { get; set; }
        /// <summary>
        /// 权限code
        /// </summary>
        public string RightsValue { get; set; }
        /// <summary>
        /// 权限url
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 权限排序
        /// </summary>
        public int? Sort { get; set; }
        /// <summary>
        /// 权限父id
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 权限类型
        /// </summary>
        public string Type { get; set; }

    }
}
