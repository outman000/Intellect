using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RoomViewModel.MiddleModel
{
    public class RoomInformationSearchMiddle
    {
        /// <summary>
        /// id
        /// </summary>
        public Guid Id { get; set; }


        /// <summary>
        /// 会议室门牌号
        /// </summary>

        public string RoomNum { get; set; }


        /// <summary>
        /// 会议室容量
        /// </summary>

        public string RoomCapacity { get; set; }


        /// <summary>
        /// 会议室描述
        /// </summary>
        public string RoomDescription { get; set; }

        /// <summary>
        /// 会议室设备code
        /// </summary>

        public string RoomEquipmentCode { get; set; }

        /// <summary>
        /// 会议室设备name
        /// </summary>

        public string RoomEquipmentName { get; set; }

        /// <summary>
        /// 会议室排序号
        /// </summary>

        public string Sort { get; set; }

        ///<summary>
        ///会议室状态 0-全天空闲，1-部分预定，2-已经订满
        /// </summary>

        public string RoomStatus { get; set; }

        /// <summary>
        /// 状态 0-有效，1-无效
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
        /// 预定时间
        /// </summary>
        public string ReservationDate { get; set; }

        /// <summary>
        /// 会议室类型信息
        /// </summary>
        public string DataBase_TypeId { get; set; }

        /// <summary>
        /// 会议室所对的区名
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// 会议室所对的楼名
        /// </summary>
        public string FloorName { get; set; }

        /// <summary>
        /// 物业人员
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// 物业人员手机号
        /// </summary>
        public string PropertyPhone { get; set; }

        /// <summary>
        /// 网址
        /// </summary>
        public string Website { get; set; }

    }
}
