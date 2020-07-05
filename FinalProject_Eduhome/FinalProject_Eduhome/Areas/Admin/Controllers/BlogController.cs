using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        // GET: Admin/Blog
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            ViewBag.Category = db.Categories.ToList();
            List<Blog> blogs = db.Blogs.ToList();
            return View(blogs);
        }

        public ActionResult Create()
        {
            ViewBag.Category = db.Categories.ToList();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                Blog Blog = new Blog();
                if (blog.ImageFile == null)
                {
                    ModelState.AddModelError("ImageFile", "Image is required");
                    ViewBag.Category = db.Categories.ToList();
                    return View(blog);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blog.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    blog.ImageFile.SaveAs(imagePath);
                    Blog.Image = imageName;
                }
                Blog.Title = blog.Title;
                Blog.CategoryId = blog.CategoryId;
                Blog.Content = blog.Content;
                Blog.Author = blog.Author;
                Blog.Read = 0;
                Blog.CreatedDate = DateTime.Now;

                db.Blogs.Add(Blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = db.Categories.ToList();
            return View(blog);
        }

        public ActionResult Update(int? id)
        {
            ViewBag.Category = db.Categories.ToList();
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Blog blog)
        {
            if (ModelState.IsValid)
            {
                Blog Blog = db.Blogs.Find(blog.Id);
                if (blog.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blog.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads/"), Blog.Image);
                    System.IO.File.Delete(oldPath);

                    blog.ImageFile.SaveAs(imagePath);
                    Blog.Image = imageName;
                }

                Blog.Title = blog.Title;
                Blog.Content = blog.Content;
                Blog.CategoryId = blog.CategoryId;
                Blog.Author = blog.Author;

                db.Entry(Blog).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = db.Categories.ToList();
            return View(blog);
        }

        public ActionResult Delete(int? id)
        {
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            string oldPath = Path.Combine(Server.MapPath("~/Uploads/"), blog.Image);
            System.IO.File.Delete(oldPath);

            db.Blogs.Remove(blog);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}