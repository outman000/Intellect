using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RoomViewModel.RequestViewModel
{
    public class RoomReservationAddViewModel
    {

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

        public DateTime Meetingtime { get; set; }

        ///<summary>
        ///结束时间
        /// </summary>

        public DateTime Endingtime { get; set; }

        ///<summary>
        ///楼
        /// </summary>

        public string Floor { get; set; }

        ///<summary>
        ///区
        /// </summary>

        public string Area { get; set; }

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
        /// UserId
        /// </summary>

        public string CreateUser { get; set; }

        ///<summary>
        ///会议室信息主键ID
        /// </summary>
        public string MeetingRoom_InformationId { get; set; }

    }
}
