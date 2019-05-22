using ExOrg.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ExOrg
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            config.Filters.Add(new AuthorizeAttribute());
            config.Filters.Add(new OnApiExceptionAttribute());
            // Web API 路由
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
