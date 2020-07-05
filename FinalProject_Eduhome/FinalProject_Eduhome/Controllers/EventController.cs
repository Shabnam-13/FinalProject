using FinalProject_Eduhome.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject_Eduhome.ViewModels;


namespace FinalProject_Eduhome.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            ViewBag.About = db.About.FirstOrDefault();

            HomeVM model = new HomeVM();
            model.Events = db.Events.ToList();
            model.Categories = db.Categories.ToList();
            model.Blogs = db.Blogs.ToList();

            return View(model);
        }

        public ActionResult Details(int? id)
        {
            ViewBag.About = db.About.FirstOrDefault();

            HomeVM model = new HomeVM();
            model.Events = db.Events.ToList();
            model.Categories = db.Categories.ToList();
            model.Blogs = db.Blogs.ToList();
            model.EventInfos = db.EventInfo.ToList();
            model.Speakers = db.Speakers.ToList();

            model.event1 = db.Events.Find(id);
            if (model.event1 == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
    }
}