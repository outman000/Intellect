using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.RequsetModel
{
    public class DepartAddViewModel
    {
        public string Name { get; set; }//部门名称
        public string ParentId { get; set; }//父部门id
        public string Code { get; set; }//部门标识
        public int? Sort { get; set; }//部门排序
    }
}
