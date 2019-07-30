using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace SystemFilter.PublicFilter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
    public class ValitorLog : ActionFilterAttribute
    {
        public string Message { get; set; }
        /// <summary>
        /// 请求开始之前
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext) {

        }
        /// <summary>
        /// 请求结束之后
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext) {

        }
        /// <summary>
        /// 响应开始之前
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuting(ResultExecutingContext filterContext) {

        }
        /// <summary>
        /// 响应开始之后
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuted(ResultExecutedContext filterContext) {


        }

    }
}
