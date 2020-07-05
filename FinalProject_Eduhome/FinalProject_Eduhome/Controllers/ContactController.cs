using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            ViewBag.About = db.About.FirstOrDefault();

            HomeVM model = new HomeVM();
            model.eduContacts = db.EduContacts.FirstOrDefault();
            model.EduSocials = db.EduSocials.ToList();

            return View(model);
        }
    }
}