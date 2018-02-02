using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPISelfHosting
{
    public class MySimpleHttpMessageHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Received an http message");
            var task = new Task<HttpResponseMessage>(() =>
            {
                var msg = new HttpResponseMessage();
                msg.Content = new StringContent("Hello Self-Hosting");
                Console.WriteLine("http response sent");
                return msg;
            });
            task.Start();
            return task;
        }
    }
}
