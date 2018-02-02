using System;
using System.Net.Http;
using System.Web.Http;

namespace In_memory_hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("default", "api/{controller}/{id}", new {id = RouteParameter.Optional});

            var server = new HttpServer(config);
            var client = new HttpClient(server);

            var response = client.GetAsync("http://localhost/api/my").Result;
            var content = response.Content.ReadAsStringAsync().Result;

            //Console.WriteLine(content);
            //Console.ReadKey();
        }
    }
}
