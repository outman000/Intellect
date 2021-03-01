using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RoomViewModel.MiddleModel
{
    public class RoomReservationSearchMiddle
    {
        /// <summary>
        /// id
        /// </summary>
        public Guid Id { get; set; }
        ///<summary>
        ///姓名
        ///</summary>

        public string Username { get; set; }
        ///<summary>
        ///部门名称
        /// </summary>

        public string DepartName { get; set; }

        ///<summary>
        ///部门id
        /// </summary>

        public string Departid { get; set; }

        ///<summary>
        ///手机号
        /// </summary>

        public string Phone { get; set; }

        ///<summary>
        ///开会时间
        /// </summary>

        public string Meetingtime { get; set; }

        ///<summary>
        ///结束时间
        /// </summary>

        public string Endingtime { get; set; }

        ///<summary>
        ///会议内容
        /// </summary>

        public string MeetingContent { get; set; }
        ///<summary>
        ///参会人数
        /// </summary>
        public string ParticipantsNum { get; set; }

        ///<summary>
        ///是否有领导
        /// </summary>
        public string LeadershipWhether { get; set; }

        ///<summary>
        ///领导名
        /// </summary>
        public string Leadership { get; set; }
        ///<summary>
        ///是否需要茶水
        /// </summary>
        public string TeaWhether { get; set; }

        ///<summary>
        ///会议室状态 0-未预定，1-已预定，2-取消预订，3-使用中，4-结束
        /// </summary>

        public string RoomStatus { get; set; }
        ///<summary>
        ///楼
        /// </summary>

        public string Floor { get; set; }

        ///<summary>
        ///区
        /// </summary>

        public string Area { get; set; }

        ///<summary>
        ///设备Name
        /// </summary>

        public string RoomEquipmentName { get; set; }

        ///<summary>
        ///会议室名称
        /// </summary>
        public string RoomNum { get; set; }

        ///<summary>
        ///状态 0-有效，1-无效
        /// </summary>

        public string Status { get; set; }

        /// <summary>
        /// 删除标识 0-未删除，1-已删除
        /// </summary>

        public string IsDelete { get; set; }
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

        /// <summary>
        /// 物业人员
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// 物业人员手机号
        /// </summary>
        public string PropertyPhone { get; set; }

        ///<summary>
        ///会议室信息外键
        /// </summary>
        public string MeetingRoom_InformationId { get; set; }

    }
}
