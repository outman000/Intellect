using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace SystemFilter.PublicFilter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]

    public class ValidateModel: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            ModelStateDictionary modelState = actionContext.ModelState;
            if (!modelState.IsValid)
            {
                actionContext.Result = new BadRequestObjectResult(modelState);
            }
        }

    }
}
