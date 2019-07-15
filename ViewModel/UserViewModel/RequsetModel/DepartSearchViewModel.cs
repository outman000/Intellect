using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.RequsetModel
{
    public class DepartSearchViewModel
    {
        public string Name { get; set; }//部门名称
        public string ParentId { get; set; }//父部门id
        public string Code { get; set; }//部门标识
        public int? Sort { get; set; }//部门排序
         /// <summary>
         /// 分页
         /// </summary>
        public PageViewModel pageViewModel { get; set; }
        DepartSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
