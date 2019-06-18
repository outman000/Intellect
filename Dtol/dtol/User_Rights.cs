using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public partial class User_Rights
    {
        public int Id { get; set; }
        public string RightsName { get; set; }
        public string RightsValue { get; set; }
        public string Remark { get; set; }
        public string Url { get; set; }
        public int? Sort { get; set; }
        public string ParentId { get; set; }
        public string Type { get; set; }
    }
}
