using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.MiddleModel
{
    public class UseCarSelMiddle
    {
        /// <summary>
        /// id
        /// </summary>
        public string id;

        /// <summary>
        /// 用车事由
        /// </summary>
        public string title;

        /// <summary>
        /// projectid
        /// </summary>
        public string projectid;

        /// <summary>
        /// 用车时间
        /// </summary>
        public string docdate;

        /// <summary>
        /// 拟稿人
        /// </summary>
        public string nigaoren;

        /// <summary>
        /// 拟稿人id
        /// </summary>
        public string nigaoren_id;

        /// <summary>
        /// 拟稿单位
        /// </summary>
        public string nigaodanwei;

        /// <summary>
        /// 标题
        /// </summary>
        public string head;

        /// <summary>
        /// 拟稿人电话
        /// </summary>
        public string hdnr;

        /// <summary>
        /// 乘车人
        /// </summary>
        public string hyjylx;

        /// <summary>
        /// 乘车人电话
        /// </summary>
        public string zjly;

        /// <summary>
        /// 乘车人人数
        /// </summary>
        public string djbh;

        /// <summary>
        /// 出发地
        /// </summary>
        public string spzt;

        /// <summary>
        /// 目的地
        /// </summary>
        public string yylb;

        /// <summary>
        /// 用车类型
        /// </summary>
        public string jdfs;

        /// <summary>
        /// 申请时间
        /// </summary>
        public string Cratetime;

        /// <summary>
        /// 颜色
        /// </summary>
        public string dwmc;

        /// <summary>
        /// 车牌
        /// </summary>
        public string cxry;

        /// <summary>
        /// 司机
        /// </summary>
        public string FWJG;

        /// <summary>
        /// 司机电话
        /// </summary>
        public string Comsummary;

        /// <summary>
        /// 行车里程/当前总里程数
        /// </summary>
        public string Yuanyin;

        /// <summary>
        /// 还车公里数
        /// </summary>
        public string Hydd;


        /// <summary>
        /// 是否变更乘车人
        /// </summary>
        public string sfbgccr;


        /// <summary>
        /// 实际乘车人
        /// </summary>
        public string sjhyjylx;

        /// <summary>
        /// 状态
        /// </summary>
        public string status;

        /// <summary>
        /// 途径
        /// </summary>
        public List<string> dlist;

        /// <summary>
        /// 补充说明
        /// </summary>
        public string jychbm;
        public UseCarSelMiddle()
        {
            this.dlist = new List<string>();
        }
    }
}
