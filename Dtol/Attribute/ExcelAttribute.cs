using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.Attribute
{
    /// <summary>
    /// 自定义excel头部标签
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class ExcelAttribute : System.Attribute
    {

        /// <summary>
        /// 标签名称
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name"></param>
        public ExcelAttribute(string name)
        {
            ColumnName = name;
        }

    }
}
