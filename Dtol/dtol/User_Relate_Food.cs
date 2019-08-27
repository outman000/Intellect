using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class User_Relate_Food
    {
        public int Id { get; set; }
        
        /// <summary>
        /// 用户Id
        /// </summary>
        public int User_InfoId { get; set; }

        public User_Info User_Info { get; set; }

        /// <summary>
        /// 菜Id
        /// </summary>
        public int Food_InfoId { get; set; }

        public Food_Info Food_Info { get; set; }

        /// <summary>
        /// 点评标识  1-评价，2-差评
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 点评内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddDate { get; set; }


    }
}
