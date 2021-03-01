using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RoomViewModel.RequestViewModel
{
    public class RoomInformationByInfoSearchViewModel
    {
        /// <summary>
        /// id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 会议室容量最大值
        /// </summary>
        public int? RoomCapacityMost { get; set; }

        /// <summary>
        /// 会议室容量最小值
        /// </summary>
        public int? RoomCapacityLeast { get; set; }

        /// <summary>
        /// 会议室设备name
        /// </summary>
        public string RoomEquipmentName { get; set; }

        /// <summary>
        /// 楼id
        /// </summary>
        public string FloorId { get; set; }

        /// <summary>
        /// 区id
        /// </summary>
        public string AreaAll { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        RoomInformationByInfoSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
