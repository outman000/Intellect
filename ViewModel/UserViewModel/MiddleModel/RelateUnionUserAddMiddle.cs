using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.MiddleModel
{
    public class RelateUnionUserAddMiddle
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 工会id
        /// </summary>
        public int? User_UnionId { get; set; } 
    }
}
