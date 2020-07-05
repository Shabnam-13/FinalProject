using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Areas.Admin.Controllers
{
    public class EventsController : Controller
    {
        // GET: Admin/Events
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            ViewBag.Category = db.Categories.ToList();
            List<Event> events = db.Events.ToList();
            return View(events);
        }

        public ActionResult Create()
        {
            ViewBag.Category = db.Categories.ToList();

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Event event1)
        {
            if (ModelState.IsValid)
            {
                Event Event1 = new Event();
                if (event1.ImageFile == null)
                {
                    ModelState.AddModelError("ImageFile", "Image is required");
                    ViewBag.Category = db.Categories.ToList();
                    return View(event1);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + event1.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    event1.ImageFile.SaveAs(imagePath);
                    event1.Image = imageName;
                }
                Event1.Title = event1.Title;
                Event1.Content = event1.Content;
                Event1.Venue = event1.Venue;
                Event1.EventTime = event1.EventTime;
                Event1.EventDate = event1.EventDate;
                Event1.City = event1.City;
                Event1.CategoryId = event1.CategoryId;

                db.Events.Add(event1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = db.Categories.ToList();
            return View(event1);
        }

        public ActionResult Update(int? id)
        {
            ViewBag.Category = db.Categories.ToList();
            Event event1 = db.Events.Find(id);
            if (event1 == null)
            {
                return HttpNotFound();
            }
            return View(event1);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Event event1)
        {
            if (ModelState.IsValid)
            {
                Event Event1 = db.Events.Find(event1.Id);
                if (event1.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + event1.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads/"), Event1.Image);
                    System.IO.File.Delete(oldPath);

                    event1.ImageFile.SaveAs(imagePath);
                    Event1.Image = imageName;
                }

                Event1.Title = event1.Title;
                Event1.Content = event1.Content;
                Event1.CategoryId = event1.CategoryId;
                Event1.EventTime = event1.EventTime;
                Event1.Venue = event1.Venue;
                Event1.City = event1.City;
                Event1.EventDate = event1.EventDate;
                db.Entry(Event1).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = db.Categories.ToList();
            return View(event1);
        }

        public ActionResult Delete(int? id)
        {
            Event event1 = db.Events.Find(id);
            if (event1 == null)
            {
                return HttpNotFound();
            }
            string oldPath = Path.Combine(Server.MapPath("~/Uploads/"), event1.Image);
            System.IO.File.Delete(oldPath);

            db.Events.Remove(event1);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}