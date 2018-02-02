using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoursesAPI.Models;

namespace CoursesAPI.Controllers
{
    public class CoursesController : ApiController
    {
        private static List<Course> courses = new List<Course>()
        {
            new Course() {Id = 0, Title = "Web API fundamentals"},
            new Course() {Id = 1, Title = "C# professional"}
        };

        public IEnumerable<Course> Get()
        {
            return courses;
        }
    }
}
