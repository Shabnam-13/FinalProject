using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.Models;
using FinalProject_Eduhome.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index(int page=1)
        {
            ViewBag.About = db.About.FirstOrDefault();

            HomeVM model = new HomeVM();
            model.Blogs = db.Blogs.OrderByDescending(i=>i.Id).Skip((page-1)*4).Take(4).ToList();
            model.Categories = db.Categories.ToList();
            model.pageCount =Convert.ToInt32(Math.Ceiling(db.Blogs.Count() / 4.0));
            model.currentPage = page;
            return View(model);
        }

        public ActionResult Details(int? id)
        {
            ViewBag.About = db.About.FirstOrDefault();

            HomeVM model = new HomeVM();
            model.Blogs = db.Blogs.OrderByDescending(i => i.CreatedDate).Take(3).ToList();
            model.Categories = db.Categories.ToList();

            model.blog = db.Blogs.Find(id);
            if (model.blog == null)
            {
                return HttpNotFound();
            }
            else
            {
                model.blog.Read++;
                Blog post = db.Blogs.Find(model.blog.Id);
                post.Read = model.blog.Read;

                db.Entry(post).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return View(model);
        }
    }
}