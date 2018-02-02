using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PluralExample1.Controllers
{
    public class ValuesController : ApiController
    {
        private static List<string> data = new List<string>() { "value1", "value2" };
        public IEnumerable<string> Get()
        {
            return data;
        }

        public HttpResponseMessage Get(int id)
        {
            if (id > data.Count - 1) return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found");
            else return Request.CreateResponse(HttpStatusCode.OK, data[id]);
        }

        public HttpResponseMessage Post([FromBody] string value)
        {
            data.Add(value);
            var message = Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri($"{Request.RequestUri}/{data.Count - 1}");
            return message;
        }

        public void Put(int id, [FromBody] string value)
        {
            data[id] = value;
        }

        public void Delete(int id)
        {
            data.RemoveAt(id);
        }
    }
}