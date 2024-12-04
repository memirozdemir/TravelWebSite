using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelWebSite.Models.Classes;

namespace TravelWebSite.Controllers
{
    public class HomeController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            var values = db.Blogs.OrderBy(x=>x.ID).Take(10).ToList();
            return View(values);
        }
        public PartialViewResult PartialRecent()
        {
            var values = db.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialLastTen()
        {
            var values = db.Blogs
                           .OrderBy(x => Guid.NewGuid()) // Rastgele siralama
                           .Take(10)                    
                           .ToList();                   
            return PartialView(values);
        }
        public PartialViewResult PartialBestPlaces()
        {
            var values = db.Blogs
                           .OrderBy(x => Guid.NewGuid())
                           .Take(6)                    
                           .ToList();                   
            return PartialView(values);
        }
    }
}