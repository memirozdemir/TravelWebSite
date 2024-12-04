using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;
using TravelWebSite.Models.Classes;

namespace TravelWebSite.Controllers
{
    public class AdminController : Controller
    {
        BlogComments bc = new BlogComments();
        Context db = new Context();
        public ActionResult Index()
        {
            var values = db.Blogs.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewContent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewContent(Blog blog)
        {
            db.Blogs.Add(blog);
            blog.Date = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            bc.blogs = db.Blogs.Where(x => x.ID == id).ToList();
            bc.comments = db.Comments.Where(x => x.BlogID == id).ToList();
            ViewBag.TotalComments = db.Comments.Count();
            return View(bc);
        }
        public ActionResult Edit(int id)
        {
            var value = db.Blogs.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult Edit(Blog blog)
        {
            var value = db.Blogs.Find(blog.ID);
            value.Description = blog.Description;
            value.Title = blog.Title;
            value.BlogIMG = blog.BlogIMG;
            value.Date= DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var value = db.Blogs.Find(id);
            db.Blogs.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CommentDelete(int id)
        {
            var value = db.Comments.Find(id);
            db.Comments.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Details");
        }
    }
}