using System.Collections.Generic;
using System.Web.Http;
using CustomFormatter.Models;

namespace CustomFormatter.Controllers
{
    public class AuthorsController : ApiController
    {
        private static List<Author> authors = InitAuthors();

        private static List<Author> InitAuthors()
        {
            return new List<Author>()
            {
                new Author() { Id = 0, Name = "Ionesco", PhotoUrl = "https://media1.britannica.com/eb-media/78/10778-004-8B76FE75.jpg"},
                new Author() {Id = 1, Name = "Shiraz", PhotoUrl = "https://i.ytimg.com/vi/IZJi9_JzCiA/hqdefault.jpg"},
                new Author() {Id = 2, Name = "Bakunts", PhotoUrl = "http://static.wixstatic.com/media/b94673_401f1e7ea00645aba4c713ecffd26e56.jpg/v1/fill/w_620,h_761/b94673_401f1e7ea00645aba4c713ecffd26e56.jpg"}
            };
        }

        public IEnumerable<Author> Get()
        {
            return authors;
        }

        public Author Get(int id)
        {
            return authors[id];
        }
    }
}
