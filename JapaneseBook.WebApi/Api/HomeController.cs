using JapaneseBook.Web.Infrastructure.Core;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JapaneseBook.WebApi.Api
{
    [RoutePrefix("api/home")]
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

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.BadRequest, testApi);

                return response;
            });
        }
    }
}
