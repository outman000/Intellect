using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RoomViewModel.RequestViewModel
{
    public class RoomInformationUpdateViewModel
    {
        /// <summary>
        /// id
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();


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

        public int? Sort { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        
        public string UpdateUser { get; set; }


        /// <summary>
        /// 会议室类型信息
        /// </summary>
        public string DataBase_TypeId { get; set; }
    }
}
