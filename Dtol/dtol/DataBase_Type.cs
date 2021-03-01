using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dtol.dtol
{
    public class DataBase_Type
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [StringLength(50)]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// 名称
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// parentid
        /// </summary>
        [StringLength(50)]
        public string Parentid { get; set; }

        /// <summary>
        /// 类别名 
        /// </summary>
        [StringLength(50)]
        public string TypeName { get; set; }

        /// <summary>
        /// 类别号 
        /// </summary>
        [StringLength(50)]
        public string TypeCode { get; set; }

        /// <summary>
        /// 权限 
        /// </summary>
        [StringLength(1000)]
        public string Purview { get; set; }

        /// <summary>
        /// 状态 
        /// </summary>
        [StringLength(50)]
        public string Status { get; set; }

        /// <summary>
        /// 删除标识 0-未删除，1-已删除
        /// </summary>
        [StringLength(50)]
        public string IsDelete { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        [StringLength(50)]
        public string Sort { get; set; }

        /// <summary>
        /// 物业人员
        /// </summary>
        [StringLength(500)]
        public string Property { get; set; }

        /// <summary>
        /// 物业人员手机号
        /// </summary>
        [StringLength(500)]
        public string PropertyPhone { get; set; }

        /// 创建人
        /// </summary>
        [StringLength(50)]
        public string CreateUser { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        [StringLength(50)]
        public string UpdateUser { get; set; }

        /// <summary>
        /// 增加时间
        /// </summary>
        [Column(TypeName = "DateTime")]
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [Column(TypeName = "DateTime")]
        public DateTime? UpdateDate { get; set; }
    }
}
