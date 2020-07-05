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
    public class SlideController : Controller
    {
        // GET: Admin/Slide
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            List<Slide> slides = db.Slide.ToList();
            return View(slides);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Slide slide)
        {
            if (ModelState.IsValid)
            {
                if (slide.ImageFile == null)
                {
                    ModelState.AddModelError("ImageFile", "Image is required");
                    return View(slide);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + slide.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    slide.ImageFile.SaveAs(imagePath);
                    slide.Image = imageName;
                }

                db.Slide.Add(slide);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slide);
        }

        public ActionResult Update(int? id)
        {
            Slide slide = db.Slide.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        [HttpPost]
        public ActionResult Update(Slide slide)
        {
            if (ModelState.IsValid)
            {
                Slide Slide = db.Slide.Find(slide.Id);
                if (slide.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + slide.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads/"), Slide.Image);
                    System.IO.File.Delete(oldPath);

                    slide.ImageFile.SaveAs(imagePath);
                    Slide.Image = imageName;
                }

                Slide.Title = slide.Title;
                Slide.Subtitle = slide.Subtitle;

                db.Entry(Slide).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = db.Categories.ToList();
            return View(slide);
        }

        public ActionResult Delete(int? id)
        {
            Slide slide = db.Slide.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            string oldPath = Path.Combine(Server.MapPath("~/Uploads/"), slide.Image);
            System.IO.File.Delete(oldPath);

            db.Slide.Remove(slide);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}