using ExOrg.Models;
using ExOrg.Models.ViewModels;
using ExOrg.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace ExOrg.Filters
{
    public class OnApiExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //base.OnException(actionExecutedContext);
            //var exceptionType = actionExecutedContext.Exception.GetType().Name;
            actionExecutedContext.Exception.Message.TraceError(actionExecutedContext.Exception);
            actionExecutedContext.Response = (new ResultMessage { StatusCode = MessageCodeEnum.SystemInternalError, Info = MessageCodeEnum.SystemInternalError.GetEnumText(HttpUtility.UrlDecode(actionExecutedContext.Request.Headers.GetValues("mailBoxLanguage").FirstOrDefault())), Data = null }).ToResponseJson();
        }
    }
}