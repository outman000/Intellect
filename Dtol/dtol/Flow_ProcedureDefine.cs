using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Flow_ProcedureDefine
    {
        public int id { get; set; }
        public string ProcedureName { get; set; }
        public string ProcedureCode { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Remark { get; set; }
        public DateTime? Updatetime { get; set; }
    }
}
