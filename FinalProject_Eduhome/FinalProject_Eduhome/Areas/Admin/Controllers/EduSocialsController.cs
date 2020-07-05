using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Areas.Admin.Controllers
{
    public class EduSocialsController : Controller
    {
        // GET: Admin/EduSocials
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            List<EduSocials> socials = db.EduSocials.ToList();
            return View(socials);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EduSocials socials)
        {
            if (ModelState.IsValid)
            {
                db.EduSocials.Add(socials);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socials);
        }

        public ActionResult Update(int? id)
        {
            EduSocials socials = db.EduSocials.Find(id);
            if (socials == null)
            {
                return HttpNotFound();
            }
            return View(socials);
        }

        [HttpPost]
        public ActionResult Update(EduSocials socials)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socials).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socials);
        }

        public ActionResult Delete(int? id, bool? a)
        {
            EduSocials socials = db.EduSocials.Find(id);
            if (socials == null)
            {
                return HttpNotFound();
            }
            db.EduSocials.Remove(socials);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}