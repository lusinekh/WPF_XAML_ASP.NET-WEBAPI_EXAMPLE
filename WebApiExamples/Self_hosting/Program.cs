using System;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace Self_hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:3000");
            config.Routes.MapHttpRoute("default", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            var server = new HttpSelfHostServer(config);
            server.OpenAsync().Wait();
            Console.ReadLine();
        }
    }
}
