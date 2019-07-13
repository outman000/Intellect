using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.RequsetModel
{
    public class RightsSearchViewModel
    {
        public string RightsName { get; set; }//权限名称
        public string RightsValue { get; set; }//权限标识
        public string Url { get; set; }//url地址
        public int? Sort { get; set; }//排序
        public string ParentId { get; set; }//父节点id 
        public string Type { get; set; }//类型
    }
}
