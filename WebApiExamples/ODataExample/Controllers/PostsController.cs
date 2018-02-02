using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ODataExample.Models;

namespace ODataExample.Controllers
{
    public class PostsController : ApiController
    {
        private static List<Post> posts;

        public PostsController()
        {
            posts = new List<Post>
            {
                new Post {Id = 0, Title = "Anlreli zangakatun", Author = "Sevak", PublishingDate = DateTime.Now},
                new Post {Id = 1, Title = "Dzaxord Panos", Author = "Tumanyan", PublishingDate = DateTime.Now},
                new Post {Id = 2, Title = "Et si c'etait vrai", Author = "Unknown", PublishingDate = DateTime.Now},
                new Post {Id = 3, Title = "Peppi dlinniy chulok", Author = "Lindgren", PublishingDate = DateTime.Now},
            };
        }
        //The only real difference is in the attribute odata.metadata that specifies a URL to which we can ask information about the Post resource.
        //f.e. http://localhost:65418/odata/$metadata#Posts
        public IQueryable<Post> Get()
        {
            return posts.AsQueryable();
        }
        /*examples on uri queries you can make
         * orderby
         * http://localhost:65418/odata/Posts?$orderby=Author desc
         * http://localhost:65418/odata/Posts?$orderby=PublishingDate,Author 
         * top
         * http://localhost:65418/odata/Posts?$top=2 takes top two records
         * filter
         * http://localhost:65418/odata/Posts?$filter=Author%20eq%20'Sevak'   it's like where in SQL
         * http://localhost:65418/odata/Posts?$filter=Author%20eq%20'Sevak'%20and%20Title%20eq%20'Anlreli zangakatun'
         * http://localhost:65418/odata/Posts?$filter=Id%20ne%202and%20Author%20eq%20'Tumanyan'
         * http://localhost:65418/odata/Posts?$filter=Id%20lt%202
         * http://localhost:65418/odata/Posts?$filter=Id%20ge%201
         * linecount
         * http://localhost:65418/odata/Posts?$inlinecount=allpages returns all records
         * skip
         * http://localhost:65418/odata/Posts?$skip=3    skips first 3 records
         */
    }
}
