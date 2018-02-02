using System.Web.Http;

namespace WebAPISelfHosting
{
    public class MyController : ApiController
    {
        public string Get()
        {
            return "Hello from Self hosting";
        }
    }
}
