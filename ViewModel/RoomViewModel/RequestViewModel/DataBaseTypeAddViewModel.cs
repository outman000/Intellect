using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RoomViewModel.RequestViewModel
{
    public class DataBaseTypeAddViewModel
    {

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
        /// 排序号
        /// </summary>
        
        public int? Sort { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>

        public string CreateUser { get; set; }

    }
}
