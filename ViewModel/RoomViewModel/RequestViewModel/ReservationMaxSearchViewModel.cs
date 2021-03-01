using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RoomViewModel.RequestViewModel
{
    public class ReservationMaxSearchViewModel
    {

        ///<summary>
        ///开会时间
        /// </summary>

        public DateTime? Meetingtime { get; set; }

        ///<summary>
        ///结束时间
        /// </summary>

        public DateTime? Endingtime { get; set; }

        ///<summary>
        ///会议室状态 0-未预定，1-已预定，2-取消预订，3-使用中，4-结束
        /// </summary>

        public string RoomStatus { get; set; }

        ///<summary>
        ///楼
        /// </summary>

        public string Floor { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        ReservationMaxSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
