using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelWebSite.Models.Classes;

namespace TravelWebSite.Controllers
{
    public class AboutController : Controller
    {
        Context db = new Context();
        
        public ActionResult Index()
        {
            var values = db.Abouts.ToList();
            return View(values);
        }
    }
}