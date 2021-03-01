using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RoomViewModel.RequestViewModel
{
    public class DataBaseTypeSearchViewModel
    {

        /// <summary>
        /// id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>

        public string Name { get; set; }


        /// <summary>
        /// 类别名 
        /// </summary>
        
        public string TypeName { get; set; }


        /// <summary>
        /// 权限 
        /// </summary>
        
        public string Purview { get; set; }


    }
}
