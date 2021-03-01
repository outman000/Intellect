using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RoomViewModel.MiddleModel
{
    public class DataBaseTypeSearchMiddle
    {

        /// <summary>
        /// id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// parentid
        /// </summary>

        public string Parentid { get; set; }

        /// <summary>
        /// 类别名 
        /// </summary>

        public string TypeName { get; set; }

        /// <summary>
        /// 类别号 
        /// </summary>

        public string TypeCode { get; set; }

        /// <summary>
        /// 权限 
        /// </summary>

        public string Purview { get; set; }

        /// <summary>
        /// 状态 
        /// </summary>

        public string Status { get; set; }

        /// <summary>
        /// 删除标识 0-未删除，1-已删除
        /// </summary>

        public string IsDelete { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>

        public int? Sort { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>

        public string CreateUser { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>

        public string UpdateUser { get; set; }

        /// <summary>
        /// 增加时间
        /// </summary>

        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>

        public DateTime? UpdateDate { get; set; }
    }
}
