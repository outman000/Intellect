using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dtol.dtol
{
    public class MeetingRoom_Information
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [StringLength(50)]
        public Guid Id { get; set; } = Guid.NewGuid();


        /// <summary>
        /// 会议室门牌号
        /// </summary>
        [StringLength(50)]
        public string RoomNum { get; set; }


        /// <summary>
        /// 会议室容量
        /// </summary>
        [StringLength(50)]
        public string RoomCapacity { get; set; }


        /// <summary>
        /// 会议室描述
        /// </summary>
        [StringLength(500)]
        public string RoomDescription { get; set; }

        /// <summary>
        /// 会议室设备code
        /// </summary>
        [StringLength(50)]
        public string RoomEquipmentCode { get; set; }

        /// <summary>
        /// 会议室设备name
        /// </summary>
        [StringLength(50)]
        public string RoomEquipmentName { get; set; }

        /// <summary>
        /// 会议室排序号
        /// </summary>
        [StringLength(50)]
        public string Sort { get; set; }

        ///<summary>
        ///会议室状态 0-未预定，1-已预定，2-取消预订，3-使用中，4-结束
        /// </summary>
        [StringLength(50)]
        public string RoomStatus { get; set; }

        /// <summary>
        /// 状态 0-有效，1-无效
        /// </summary>
        [StringLength(50)]
        public string Status { get; set; }

        /// <summary>
        /// 删除标识 0-未删除，1-已删除
        /// </summary>
        [StringLength(50)]
        public string IsDelete { get; set; }

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

        /// <summary>
        /// 会议室类型信息
        /// </summary>
        public Guid DataBase_TypeId { get; set; }
        public DataBase_Type DataBase_Type { get; set; }

    }
}
