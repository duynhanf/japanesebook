using JapaneseBook.Web.Infrastructure.Core;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace JapaneseBook.WebApi.Api
{
    [RoutePrefix("api/home")]
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class HomeController : ApiControllerBase
    {
        [HttpGet]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "Hello, TEDU Member. ";
        }

        [HttpGet]
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var testApi = "Nhan";

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, testApi);

                return response;
            });
        }
    }
}