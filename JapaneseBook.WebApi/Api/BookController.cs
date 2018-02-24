using JapaneseBook.Model.Entities;
using JapaneseBook.Web.Infrastructure.Core;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace JapaneseBook.WebApi.Api
{
    [RoutePrefix("api/book")]
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class BookController : ApiControllerBase
    {
        [HttpGet]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "Hello, TEDU Member. ";
        }

        [HttpGet]
        [Route("getAllBooks")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listBooks = new List<Book>();
                listBooks.Add(new Book()
                {
                    Name = "TRY N2",
                    CategoryID = 1
                });
                listBooks.Add(new Book()
                {
                    Name = "TRY N3",
                    CategoryID = 1
                });
                listBooks.Add(new Book()
                {
                    Name = "TRY N4",
                    CategoryID = 1
                });

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listBooks);

                return response;
            });
        }

        [HttpPost]
        public HttpResponseMessage Book(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listBooks = new List<Book>();
                listBooks.Add(new Book()
                {
                    Name = "TRY N2",
                    CategoryID = 1
                });
                listBooks.Add(new Book()
                {
                    Name = "TRY N3",
                    CategoryID = 1
                });
                listBooks.Add(new Book()
                {
                    Name = "TRY N4",
                    CategoryID = 1
                });

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listBooks);

                return response;
            });
        }
    }
}