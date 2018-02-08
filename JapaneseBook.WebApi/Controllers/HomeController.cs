using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JapaneseBook.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult _SideBar()
        {
            return PartialView();
        }
    }

    
}
