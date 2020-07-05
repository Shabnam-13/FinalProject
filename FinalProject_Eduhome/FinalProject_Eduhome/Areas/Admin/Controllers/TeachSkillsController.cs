using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Areas.Admin.Controllers
{
    public class TeachSkillsController : Controller
    {
        // GET: Admin/TeachSkills
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            ViewBag.Teacher = db.Teachers.ToList();
            List<TeachSkills> skills = db.TeachSkills.ToList();
            return View(skills);
        }

        public ActionResult Create()
        {
            ViewBag.Teacher = db.Teachers.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(TeachSkills skills)
        {
            if (ModelState.IsValid)
            {
                db.TeachSkills.Add(skills);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Teacher = db.Teachers.ToList();
            return View(skills);
        }

        public ActionResult Update(int? id)
        {
            ViewBag.Teacher = db.Teachers.ToList();
            TeachSkills skill = db.TeachSkills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }
        [HttpPost]
        public ActionResult Update(TeachSkills skills)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skills).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Teacher = db.Teachers.ToList();
            return View(skills);
        }

        public ActionResult Delete(int? id)
        {
            TeachSkills skill = db.TeachSkills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            db.TeachSkills.Remove(skill);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}