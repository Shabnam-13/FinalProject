using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            ViewBag.About = db.About.FirstOrDefault();

            HomeVM model = new HomeVM();
            model.Courses = db.Courses.ToList();
            model.Categories = db.Categories.ToList();

            return View(model);
        }

        public ActionResult Details(int? id)
        {
            ViewBag.About = db.About.FirstOrDefault();

            HomeVM model = new HomeVM();
            model.Courses = db.Courses.ToList();
            model.Categories = db.Categories.ToList();
            model.Blogs = db.Blogs.Take(3).ToList();

            model.course = db.Courses.Find(id);
            if (model.course == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
    }
}