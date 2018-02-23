using JapaneseBook.Model.Entities;
using JapaneseBook.WebApi.ViewModels.Shared;
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

       // [ChildActionOnly]
        //[OutputCache(Duration = 3600)]
        public ActionResult _SideBar()
        {
            SideBarModel objSideBarModel = new SideBarModel();
            objSideBarModel.listMenu1.Add(new Menu()
            {
                Name = "TRY N2",
                URL = "/Book/try-n2"
            });
            
            return PartialView(objSideBarModel);
        }
    }

    
}
