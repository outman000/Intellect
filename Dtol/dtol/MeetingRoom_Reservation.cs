using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dtol.dtol
{
    public class MeetingRoom_Reservation
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [StringLength(50)]
        public Guid Id { get; set; } = Guid.NewGuid();
        ///<summary>
        ///姓名
        ///</summary>
        [StringLength(50)]
        public string Username { get; set; }
        ///<summary>
        ///部门名称
        /// </summary>
        [StringLength(50)]
        public string DepartName { get; set; }

        ///<summary>
        ///部门id
        /// </summary>
        [StringLength(50)]
        public string Departid { get; set; }

        ///<summary>
        ///手机号
        /// </summary>
        [StringLength(50)]
        public string Phone { get; set; }

        ///<summary>
        ///身份证号
        /// </summary>
        [StringLength(50)]
        public string Idcard { get; set; }

        ///<summary>
        ///开会时间
        /// </summary>
        [Column(TypeName = "DateTime")]
        public DateTime Meetingtime { get; set; }

        ///<summary>
        ///结束时间
        /// </summary>
        [Column(TypeName = "DateTime")]
        public DateTime Endingtime { get; set; }

        ///<summary>
        ///会议内容
        /// </summary>
        [StringLength(500)]
        public string MeetingContent { get; set; }

        ///<summary>
        ///参会人数
        /// </summary>
        [StringLength(50)]
        public string ParticipantsNum { get; set; }

        ///<summary>
        ///是否有领导
        /// </summary>
        [StringLength(50)]
        public string LeadershipWhether { get; set; }

        ///<summary>
        ///领导名
        /// </summary>
        [StringLength(500)]
        public string Leadership { get; set; }
        ///<summary>
        ///是否需要茶水
        /// </summary>
        [StringLength(50)]
        public string TeaWhether { get; set; }

        ///<summary>
        ///会议室状态 0-未预定，1-已预定，2-取消预订，3-使用中，4-结束
        /// </summary>
        [StringLength(50)]
        public string RoomStatus { get; set; }
        ///<summary>
        ///楼
        /// </summary>
        [StringLength(50)]
        public string Floor { get; set; }

        ///<summary>
        ///区
        /// </summary>
        [StringLength(50)]
        public string Area { get; set; }
        ///<summary>
        ///状态 0-有效，1-无效
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

        ///<summary>
        ///会议室信息外键
        /// </summary>
        public Guid MeetingRoom_InformationId { get; set; }
        public MeetingRoom_Information MeetingRoom_Information { get; set; }
    }
}
