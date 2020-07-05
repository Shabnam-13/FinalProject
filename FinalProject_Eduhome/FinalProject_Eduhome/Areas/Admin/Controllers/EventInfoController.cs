using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Areas.Admin.Controllers
{
    public class EventInfoController : Controller
    {
        // GET: Admin/EventInfo
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            ViewBag.Speakers = db.Speakers.ToList();
            ViewBag.Events = db.Events.ToList();
            List<EventInfo> infos = db.EventInfo.ToList();
            return View(infos);
        }

        public ActionResult Create()
        {
            ViewBag.Speakers = db.Speakers.ToList();
            ViewBag.Events = db.Events.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(EventInfo info)
        {
            if (ModelState.IsValid)
            {
                db.EventInfo.Add(info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Speakers = db.Speakers.ToList();
            ViewBag.Events = db.Events.ToList();
            return View(info);
        }

        public ActionResult Update(int? id)
        {
            ViewBag.Speakers = db.Speakers.ToList();
            ViewBag.Events = db.Events.ToList();
            EventInfo info = db.EventInfo.Find(id);
            if (info == null)
            {
                return HttpNotFound();
            }
            return View(info);
        }

        [HttpPost]
        public ActionResult Update(EventInfo info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(info).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Speakers = db.Speakers.ToList();
            ViewBag.Events = db.Events.ToList();
            return View(info);
        }

        public ActionResult Delete(int? id)
        {
            EventInfo info = db.EventInfo.Find(id);
            if (info == null)
            {
                return HttpNotFound();
            }

            db.EventInfo.Remove(info);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}