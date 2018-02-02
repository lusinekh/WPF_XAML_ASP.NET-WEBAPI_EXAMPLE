using System.Web.Http;
using System.Web.Http.Routing;
using CustomFormatter.MessageHandlers;

namespace CustomFormatter
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Add(new ImageFormatter());

            config.MessageHandlers.Add(new CustomHeaderMessageHandler());
            config.MessageHandlers.Add(new LogMessageHandler());

            IHttpRoute newRoute = config.Routes.CreateRoute(
                routeTemplate: "api/Posts/{id}", //this means that customheadermessagehandler will take place only for Posts
                defaults: new HttpRouteValueDictionary("route"),
                constraints:null,
                dataTokens: null,
                handler: new CustomHeaderMessageHandler() 
                );
            config.Routes.Add("WithCustomHandler", newRoute);
        }
    }
}
