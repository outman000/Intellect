using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.RequestViewModel
{
    public class BusPaymentSearchViewModel
    {
        /// <summary>
        /// 线路名
        /// </summary>
        public int? Bus_LineId { get; set; }


        /// <summary>
        /// 部门id
        /// </summary>
        public int? User_DepartId { get; set; }



        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        /// 订单号
        /// </summary>
        public string orderNo { get; set; }




        /// <summary>
        /// 乘车时间
        /// </summary>
        public DateTime? carDate { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        BusPaymentSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
