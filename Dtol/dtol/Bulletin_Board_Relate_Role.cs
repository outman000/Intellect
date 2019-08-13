using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Bulletin_Board_Relate_Role
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 公告栏Id
        /// </summary>
        public int Bulletin_BoardId { get; set; }

        public Bulletin_Board Bulletin_Board { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public int User_RoleId { get; set; }

        public User_Role User_Role { get; set; }
    }
}
