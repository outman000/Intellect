using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Suggest_Box_Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public string Code { get; set; }
        public string Remark { get; set; }
        public string Type { get; set; }
        public int? Sort { get; set; }

        public string status { get; set; }

        public DateTime? AddDate { get; set; }
        public DateTime? updateDate { get; set; }

        public string createUser { get; set; }
        public string updateUser { get; set; }

    }
}
