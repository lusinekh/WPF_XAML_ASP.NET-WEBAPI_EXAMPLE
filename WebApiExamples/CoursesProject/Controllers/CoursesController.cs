using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoursesProject.Models;

namespace CoursesProject.Controllers
{
    public class CoursesController : ApiController
    {
        private static List<Course> courses = new List<Course>()
        {
            new Course() {Id = 0, Title = "ASP.NET MVC 4"},
            new Course() {Id = 1, Title = "Web API fundamentals"}
        };

        public IEnumerable<Course> Get()
        {
            return courses;
        }

        public HttpResponseMessage Get(int id)
        {
            var search = from c in courses
                         where c.Id == id
                         select c;
            if (search.FirstOrDefault() == null) return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There is no item with such id");
            else return Request.CreateResponse(HttpStatusCode.OK, search.FirstOrDefault());
        }

        public HttpResponseMessage Post([FromBody]Course c)
        {
            c.Id = courses.Count;
            courses.Add(c);
            var message = Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri($"{Request.RequestUri}/{c.Id}");
            return message;
        }

        public void Put(int id, [FromBody] Course course)
        {
            var search = courses.FirstOrDefault(x => x.Id == id);
            search.Title = course.Title;
        }

        public void Delete(int id)
        {
            var search = courses.FirstOrDefault(x => x.Id == id);
            courses.RemoveAt(id);
        }
    }
}