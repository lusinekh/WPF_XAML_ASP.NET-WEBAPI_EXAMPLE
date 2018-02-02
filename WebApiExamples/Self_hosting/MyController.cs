using System.Web.Http;

namespace Self_hosting
{
    public class MyController : ApiController
    {
        public string[] Get()
        {
            return new[] { "All", "the", "harvest", "has", "grown" };
        }
    }
}
