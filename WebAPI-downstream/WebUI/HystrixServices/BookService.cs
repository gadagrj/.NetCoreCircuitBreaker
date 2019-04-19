using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Steeltoe.CircuitBreaker.Hystrix;
using WebUI.Models;

namespace WebUI.HystrixServices
{
    public class BookService : HystrixCommand<List<Book>>
    {
        public BookService(IHystrixCommandOptions commandOptions) : base(commandOptions)
        {

        }

        /// <summary>
        ///     This will call when Circuit breaker is closed
        /// </summary>
        /// <returns></returns>
        protected override List<Book> Run()
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:5000/api/books").Result;

            var BookList = response.Content.ReadAsAsync<List<Book>>().Result;

            return BookList;
        }

        /// <summary>
        /// This will call when circute is open
        /// </summary>
        /// <returns></returns>
        protected override List<Book> RunFallback()
        {
            Book r1 = new Book();
            r1.Id = 100;
            r1.Name = "FallBack book Name";

            List<Book> list = new List<Book>();
            list.Add(r1);

            return list;
        }
    }
}
