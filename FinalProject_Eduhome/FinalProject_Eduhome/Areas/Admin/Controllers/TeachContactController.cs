using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Areas.Admin.Controllers
{
    public class TeachContactController : Controller
    {
        // GET: Admin/TeachContact
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            ViewBag.Teacher = db.Teachers.ToList();
            List<TeachContact> contacts = db.TeachContacts.ToList();
            return View(contacts);
        }

        public ActionResult Create()
        {
            ViewBag.Teacher = db.Teachers.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(TeachContact contact)
        {
            if (ModelState.IsValid)
            {
                db.TeachContacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Teacher = db.Teachers.ToList();
            return View(contact);
        }

        public ActionResult Update(int? id)
        {
            ViewBag.Teacher = db.Teachers.ToList();
            TeachContact contact = db.TeachContacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [HttpPost]
        public ActionResult Update(TeachContact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Teacher = db.Teachers.ToList();
            return View(contact);
        }

        public ActionResult Delete(int? id)
        {
            TeachContact contact = db.TeachContacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            db.TeachContacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}