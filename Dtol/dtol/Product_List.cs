using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dtol.dtol
{
    public class Product_List
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
        /// 商品类型
        /// </summary>
        [StringLength(50)]
        public string CommodityType { get; set; }

        /// <summary>
        /// 商品单位
        /// </summary>
        [StringLength(50)]
        public string CommodityUnit { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        [StringLength(50)]
        public string formid { get; set; }
        /// <summary>
        /// 积分数
        /// </summary>
        [StringLength(50)]
        public string IntegralNum { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        [StringLength(50)]
        public string userid { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(50)]
        public string userName { get; set; }

        [StringLength(50)]
        public int? User_DepartId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [StringLength(50)]
        public string DeptName { get; set; }
        /// <summary>
        /// 工会名称
        /// </summary>
        [StringLength(50)]
        public string UnionName { get; set; }
        /// <summary>
        /// 工会Id
        /// </summary>
        [StringLength(50)]
        public int? User_UnionId { get; set; }



        /// <summary>
        /// 商品个数
        /// </summary>
        [StringLength(50)]
        public string CommodityNum { get; set; }




        /// <summary>
        /// 状态
        /// </summary>
        [StringLength(50)]
        public string status { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [StringLength(50)]
        public string Orderid { get; set; }

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
