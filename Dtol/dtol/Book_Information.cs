using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dtol.dtol
{
    public class Book_Information
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [StringLength(50)]
        public Guid Id { get; set; } = Guid.NewGuid();


        /// <summary>
        /// 图书编号
        /// </summary>
        [StringLength(50)]
        public string BookNum { get; set; }


        /// <summary>
        /// 图书名称
        /// </summary>
        [StringLength(50)]
        public string BookName { get; set; }


        /// <summary>
        /// 图书作者
        /// </summary>
        [StringLength(50)]
        public string BookAuthor { get; set; }

        /// <summary>
        /// 图书出版社
        /// </summary>
        [StringLength(50)]
        public string BookPress { get; set; }

        


        /// <summary>
        /// 图书价格
        /// </summary>
        [StringLength(50)]
        public string BookPrice { get; set; }

        /// <summary>
        /// 图书描述
        /// </summary>
        [StringLength(500)]
        public string BookDescription { get; set; }


        /// <summary>
        /// 图书排序号
        /// </summary>
        [StringLength(50)]
        public string sort { get; set; }


        /// <summary>
        /// 图书状态 
        /// </summary>
        [StringLength(50)]
        public string BookStatus { get; set; }

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



        /// <summary>
        /// 图书类型信息
        /// </summary>
        public string Book_TypeId { get; set; }
        public Book_Type Book_Type { get; set; }


    }
}
