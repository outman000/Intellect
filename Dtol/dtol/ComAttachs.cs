using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class ComAttachs
    {
        public string Id { get; set; }
        public string Filename { get; set; }
        public string Physicsname { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? Updatedate { get; set; }
        public string Employeename { get; set; }
        public string Employeeid { get; set; }
        public string Formid { get; set; }
        public string Formtablename { get; set; }
        public string Isdelete { get; set; }
        public string Filesize { get; set; }
        public string Remark { get; set; }
        public string FileType { get; set; }
        public string Createmodifytime { get; set; }
        public string Lastmodifytime { get; set; }

        public int? HrDeptId { get; set; }
        public User_Depart HrDept { get; set; }

        public string UploadUserId { get; set; }
        public User_Depart UploadUser { get; set; }
    }
}
