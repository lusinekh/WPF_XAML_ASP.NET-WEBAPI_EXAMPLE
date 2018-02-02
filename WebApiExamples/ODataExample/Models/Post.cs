using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODataExample.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishingDate { get; set; }
    }
}