using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;

namespace ViewModel.BusViewModel.ResponseModel
{
    public class UseCarSelRes
    {
        /// <summary>
        /// 列表
        /// </summary>
        public List<UseCarSelMiddle> list;
        /// <summary>
        /// 里程
        /// </summary>
        public string LiCheng;
        /// <summary>
        /// 轿车剩余里程
        /// </summary>
        public string JSyLiCheng;

        /// <summary>
        /// 查询总条数
        /// </summary>
        public string SearchNum;

        /// <summary>
        /// 商务车剩余里程
        /// </summary>
        public string SSyLiCheng;
        public UseCarSelRes()
        {
            this.list = new List<UseCarSelMiddle>();
        }
    }
}
