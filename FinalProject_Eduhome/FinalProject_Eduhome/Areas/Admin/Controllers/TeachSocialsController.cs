using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Areas.Admin.Controllers
{
    public class TeachSocialsController : Controller
    {
        // GET: Admin/TeachSocials
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            ViewBag.Teacher = db.Teachers.ToList();
            List<TeachSocial> socials = db.TeachSocials.ToList();
            return View(socials);
        }

        public ActionResult Create()
        {
            ViewBag.Teacher = db.Teachers.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(TeachSocial social)
        {
            if (ModelState.IsValid)
            {
                db.TeachSocials.Add(social);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Teacher = db.Teachers.ToList();
            return View(social);
        }

        public ActionResult Update(int? id)
        {
            ViewBag.Teacher = db.Teachers.ToList();
            TeachSocial social = db.TeachSocials.Find(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            return View(social);
        }

        [HttpPost]
        public ActionResult Update(TeachSocial social)
        {
            if (ModelState.IsValid)
            {
                db.Entry(social).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Teacher = db.Teachers.ToList();
            return View(social);
        }

        public ActionResult Delete(int? id)
        {
            TeachSocial social = db.TeachSocials.Find(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            db.TeachSocials.Remove(social);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}