using System.Web.Mvc;

namespace JapaneseBook.WebApi.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
    }
}