using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace FirstWebApiProject
{
    public static class WebApiConfig
    {
        //public static void Register(HttpConfiguration config)
        //{
        //    // Web API configuration and services

        //    // Web API routes
        //    config.MapHttpAttributeRoutes();

        //    config.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{id}",
        //        defaults: new { id = RouteParameter.Optional }
        //    );
        //}
        public static void Register(HttpConfiguration config)
        {
            //config.Routes.MapHttpRoute(
            //name: "PostByDate",
            //routeTemplate: "api/Posts/{year}/{month}/{day}", //It’s quite strange that every resource could be queried with a date, so it would better to create a tight link between the route and the controller.
            //defaults: new
            //{
            //    month = RouteParameter.Optional,
            //    day = RouteParameter.Optional
            //},
            //constraints: new
            //{
            //    month = @"\d{0,2}", //To be sure that the parameters are numbers
            //    day = @"\d{0,2}"
            //}
            //);
            config.Routes.MapHttpRoute(
            name: "PostsCustomAction",
            routeTemplate: "api/{controller}/{action}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}