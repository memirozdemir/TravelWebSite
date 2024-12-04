using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelWebSite.Models.Classes;

namespace TravelWebSite.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context db = new Context();
        BlogComments blogComments = new BlogComments();
        public ActionResult Index()
        {
            //var values = db.Blogs.ToList();
            blogComments.blogs = db.Blogs.ToList();
            blogComments.recentblogs = db.Blogs.OrderByDescending(x=>x.ID).Take(5).ToList();
            blogComments.recentcomments = db.Comments.OrderByDescending(x=>x.ID).Take(5).ToList();
            return View(blogComments);
        }

        public ActionResult Details(int id)
        {
            ViewBag.ID = id;
            //var value = db.Blogs.Where(x => x.ID == id).ToList();
            blogComments.blogs=db.Blogs.Where(x=>x.ID==id).ToList();
            blogComments.comments=db.Comments.Where(x=>x.BlogID==id).ToList();
            blogComments.recentblogs = db.Blogs.OrderByDescending(x => x.ID).Take(5).ToList();
            blogComments.recentcomments = db.Comments.OrderByDescending(x => x.ID).Take(5).ToList();
            return View(blogComments);
            
        }
        [HttpPost]
        public ActionResult Details(Comment comment)
        {
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Details");
        }
        
    }
}