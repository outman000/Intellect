using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dtol.dtol
{
    public class Book_Type
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [StringLength(50)]
        public Guid Id { get; set; } = Guid.NewGuid();


        /// <summary>
        /// 分类编号
        /// </summary>
        [StringLength(50)]
        public string BookTypeNum { get; set; }


        /// <summary>
        /// 分类名称
        /// </summary>
        [StringLength(50)]
        public string BookTypeName { get; set; }

        /// <summary>
        /// 分类描述
        /// </summary>
        [StringLength(500)]
        public string BookTypeDescription { get; set; }

        /// <summary>
        /// 分类排序号
        /// </summary>
        [StringLength(50)]
        public string sort { get; set; }


        /// <summary>
        /// 分类状态 
        /// </summary>
        [StringLength(50)]
        public string BookTypeStatus { get; set; }

        /// <summary>
        /// 删除标识 0-未删除，1-已删除
        /// </summary>
        [StringLength(50)]
        public string IsDelete { get; set; }



        /// 创建人
        /// </summary>
        [StringLength(50)]
        public string createUser { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        [StringLength(50)]
        public string updateUser { get; set; }

        /// <summary>
        /// 增加时间
        /// </summary>
        [Column(TypeName = "DateTime")]
        public DateTime? AddDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [Column(TypeName = "DateTime")]
        public DateTime? updateDate { get; set; }
    }
}
