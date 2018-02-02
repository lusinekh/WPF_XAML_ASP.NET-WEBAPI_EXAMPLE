using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstWebApiProject.Models;

namespace FirstWebApiProject.Controllers
{
    public class PostsController : ApiController
    {
        public IQueryable<Post> Get(int year, int month = 0, int day = 0)
        {
            // Do something to load the posts that match the date.
            return null;
        }

        [HttpGet]
        public string Category(int id)
        {
            return "I'm an attribute decorated non-http-verb custom action method";
        }
    }
}
