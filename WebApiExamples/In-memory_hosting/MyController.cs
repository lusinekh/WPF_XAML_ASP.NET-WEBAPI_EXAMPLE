using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace In_memory_hosting
{
    public class MyController : ApiController
    {
        public string[] Get()
        {
            return new[] { "All", "the", "harvest", "has", "grown" };
        }
    }
}
