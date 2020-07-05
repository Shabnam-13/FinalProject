using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            ViewBag.About = db.About.FirstOrDefault();

            HomeVM model = new HomeVM();
            model.Events = db.Events.Take(4).ToList();
            model.Testimonials = db.Testimonials.ToList();
            model.Teachers = db.Teachers.Include("Position").Take(4).ToList();
            model.TeachSocials = db.TeachSocials.ToList();

            return View(model);
        }
    }
}