using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            ViewBag.About = db.About.FirstOrDefault();

            HomeVM model = new HomeVM();
            model.Teachers = db.Teachers.Include("Position").ToList();
            model.TeachSocials = db.TeachSocials.ToList();

            return View(model);
        }

        public ActionResult Details(int? id)
        {
            ViewBag.About = db.About.FirstOrDefault();

            HomeVM model = new HomeVM();
            model.TeachSocials = db.TeachSocials.ToList();
            model.TeachSkills = db.TeachSkills.ToList();
            model.Positions = db.Positions.ToList();
            model.Faculties = db.Faculties.ToList();

            model.teacher = db.Teachers.Find(id);
            if (model.teacher == null)
            {
                return HttpNotFound();
            }

            model.teachContact = db.TeachContacts.FirstOrDefault(t => t.TeacherId == id);
            return View(model);
        }
    }
}