using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    public class FlowProcedureUpdateViewModel
    {
        public int Id { get; set; }
        public string status { get; set; }
        public DateTime? Starttime { get; set; }
        public DateTime? Endtime { get; set; }
        public string remark { get; set; }
    }
}
