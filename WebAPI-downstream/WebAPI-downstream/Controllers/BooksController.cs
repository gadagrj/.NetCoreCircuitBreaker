using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_downstream.Model;

namespace WebAPI_downstream.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // GET: api/Books
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            List<Book> list = new List<Book>();
            list.Add(new Book()
            {
                Id = 1,
                Name = "Real Data Coming from DB -- Book" + 1,
            });
            list.Add(new Book()
            {
                Id = 2,
                Name = "Real Data Coming from DB -- Book" + 2
            });
            list.Add(new Book()
            {
                Id = 3,
                Name = "Real Data Coming from DB --  Book" + 3
            });
            return list;
        }

       
    }
}
