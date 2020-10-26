using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dtol.dtol
{
    public class Integral_Commodity
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }

        /// <summary>
        /// 商品名
        /// </summary>
        [StringLength(50)]
        public string CommodityName { get; set; }


        /// <summary>
        /// 商品分类
        /// </summary>
        [StringLength(50)]
        public string CommodityType { get; set; }
        /// <summary>
        /// 积分数
        /// </summary>
        [StringLength(50)]
        public string IntegralNum { get; set; }

        /// <summary>
        /// 商品简介
        /// </summary>
        [StringLength(50)]
        public string CommodityIntroduction { get; set; }

        /// <summary>
        /// 商品单位
        /// </summary>
        [StringLength(50)]
        public string CommodityUnit { get; set; }
        /// <summary>
        /// 工会名称
        /// </summary>
        [StringLength(50)]
        public string UnionName { get; set; }
        /// <summary>
        /// 工会信息
        /// </summary>
        [StringLength(50)]
        public int? User_UnionId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [StringLength(50)]
        public string status { get; set; }


        /// <summary>
        /// 删除标识 0-未删除，1-已删除
        /// </summary>
        [StringLength(50)]
        public string IsDelete { get; set; }

        /// <summary>
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
