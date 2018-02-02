using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace WebAPISelfHosting
{
    class Program //run visual studio as administrator
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:4554");
            config.Routes.MapHttpRoute("default", "api/{controller}/{id}", new {id = RouteParameter.Optional});
            var server = new HttpSelfHostServer(config);
            var task = server.OpenAsync();
            task.Wait();
            Console.WriteLine("Server is opened");
            Console.WriteLine("Hit enter to call server with client");
            Console.ReadLine();
            var client = new HttpClient(server); //HttpSelfHostServer derives from HttpMessageHandler => you can put server in HttpClient
            client.GetAsync("http://localhost:4554/api/my").ContinueWith((t) =>
            {
                var result = t.Result;
                result.Content.ReadAsStringAsync().ContinueWith((rt) =>
                {
                    Console.WriteLine($"Client got response {rt.Result}");
                });
            });

            //delay
            Console.ReadKey();
        }
    }
}
