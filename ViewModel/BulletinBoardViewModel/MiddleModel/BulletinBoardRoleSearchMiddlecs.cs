using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BulletinBoardViewModel.MiddleModel
{
    public class BulletinBoardRoleSearchMiddlecs
    {
        /// <summary>
        /// 用户主键id
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneCall { get; set; }

        /// <summary>
        /// 部门信息Id
        /// </summary>
        /// 
        public int User_DepartId { get; set; }
        /// <summary>
        ///  部门详细信息
        /// </summary>
        public User_Depart User_Depart { get; set; }
        /// <summary>
        /// 公告栏信息
        /// </summary>
        public List<Bulletin_Board> Bulletin_Board { get; set; }

    }
}
