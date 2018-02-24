using System.Web.Mvc;

namespace JapaneseBook.WebApi.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }
    }
}