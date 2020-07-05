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
    public class SpeakerController : Controller
    {
        // GET: Admin/Speaker
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            List<Speakers> speakers = db.Speakers.ToList();
            return View(speakers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Speakers speaker)
        {
            if (ModelState.IsValid)
            {
                if (speaker.ImageFile == null)
                {
                    ModelState.AddModelError("ImageFile", "Image is required");
                    ViewBag.Category = db.Categories.ToList();
                    return View(speaker);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + speaker.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    speaker.ImageFile.SaveAs(imagePath);
                    speaker.Image = imageName;
                }
                db.Speakers.Add(speaker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(speaker);
        }

        public ActionResult Update(int? id)
        {
            Speakers speaker = db.Speakers.Find(id);
            if (speaker == null)
            {
                return HttpNotFound();
            }
            return View(speaker);
        }

        [HttpPost]
        public ActionResult Update(Speakers speaker)
        {
            if (ModelState.IsValid)
            {
                Speakers Speaker = db.Speakers.Find(speaker.Id);
                if (speaker.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + speaker.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads/"), Speaker.Image);
                    System.IO.File.Delete(oldPath);

                    speaker.ImageFile.SaveAs(imagePath);
                    Speaker.Image = imageName;
                }

                Speaker.FullName = speaker.FullName;
                Speaker.Position = speaker.Position;
                Speaker.Company = speaker.Company;

                db.Entry(Speaker).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(speaker);
        }

        public ActionResult Delete(int? id)
        {
            Speakers speaker = db.Speakers.Find(id);
            if (speaker == null)
            {
                return HttpNotFound();
            }
            string oldPath = Path.Combine(Server.MapPath("~/Uploads/"), speaker.Image);
            System.IO.File.Delete(oldPath);

            db.Speakers.Remove(speaker);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}