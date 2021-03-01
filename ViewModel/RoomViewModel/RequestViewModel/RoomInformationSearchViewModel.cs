using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RoomViewModel
{
    public class RoomInformationSearchViewModel
    {

        /// <summary>
        /// 会议室id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 会议室门牌号
        /// </summary>
        ///public string RoomNum { get; set; }

        /// <summary>
        /// 楼id
        /// </summary>
        public string FloorId { get; set; }

        /// <summary>
        /// 区id
        /// </summary>
        public string AreaAll { get; set; }

        /// <summary>
        /// 部门id
        /// </summary>
        public string departid { get; set; }

        /// <summary>
        /// 会议室设备name
        /// </summary>
        //public string RoomEquipmentName { get; set; }

        ///<summary>
        ///会议室状态 0-未预定，1-已预定，2-取消预订，3-使用中，4-结束
        /// </summary>
        //public string RoomStatus { get; set; }


        /// <summary>
        /// 预定时间
        /// </summary>
        public string  ReservationDate { get; set; }

        /// <summary>
        /// 会议室类型信息
        /// </summary>
        //public string DataBase_TypeId { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        RoomInformationSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
