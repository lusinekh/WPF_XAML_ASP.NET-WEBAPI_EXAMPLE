using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackEndSideWebAPI.Controllers
{
    [Authorize]
    public class FilesController : ApiController
    {
        //private static string rootPath = @"C:\Users\HP\Desktop\Test\Server files";
        private static string rootPath = @"D:\test";

        // GET api/values
        public IEnumerable<string> Get()
        {
            return Directory.GetFiles(rootPath);
        }

        // GET api/values/5
        public string Get(int id)
        {
            var files = Directory.GetFiles(rootPath);
            //if (id < 0 || id > files.Length) return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid id number");
            //else return Request.CreateResponse(HttpStatusCode.OK, files[id]);
            if (id < 0 || id > files.Length) throw new ArgumentOutOfRangeException("No file found with such id");
            else
            {
                try
                {
                    return File.ReadAllText(files[id]);
                }
                catch (IOException exception)
                {
                    return exception.Message;
                }
            }
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            var fileName = value; //Path.GetRandomFileName();
            var fileInfo = new FileInfo(Path.Combine(rootPath, fileName));
            if (!fileInfo.Exists) fileInfo.Create();
            else fileInfo.Create().Dispose();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            var files = Directory.GetFiles(rootPath);
            var fileContents = value;
            File.WriteAllText(files[id], fileContents);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            var files = Directory.GetFiles(rootPath);
            if (id < 0 || id > files.Length) throw new ArgumentOutOfRangeException("No file found with such id");
            else File.Delete(files[id]);
        }
    }
}
