using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Areas.Admin.Controllers
{
    public class EduContactsController : Controller
    {
        // GET: Admin/EduContacts
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            List<EduContacts> contacts = db.EduContacts.ToList();
            return View(contacts);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EduContacts contact)
        {
            if (ModelState.IsValid)
            {
                db.EduContacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        public ActionResult Update(int? id)
        {
            EduContacts contact = db.EduContacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [HttpPost]
        public ActionResult Update(EduContacts contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        public ActionResult Delete(int? id)
        {
            EduContacts contact = db.EduContacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            db.EduContacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}