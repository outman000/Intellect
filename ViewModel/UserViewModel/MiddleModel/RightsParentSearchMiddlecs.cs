using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.MiddleModel
{
    public class RightsParentSearchMiddlecs
    {
        public int Id { get; set; }
        public string RightsName { get; set; }
        public string RightsValue { get; set; }
        public string Url { get; set; }
        public int? Sort { get; set; }
        public string ParentId { get; set; }
        public string Type { get; set; }
        public string Remark { get; set; }
        public List<RightsParentSearchMiddlecs> Children { get; set; }
    }
}
