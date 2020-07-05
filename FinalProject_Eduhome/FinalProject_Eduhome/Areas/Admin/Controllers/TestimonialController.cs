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
    public class TestimonialController : Controller
    {
        // GET: Admin/Testimonial
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            List<Testimonial> testimonials = db.Testimonials.ToList();
            return View(testimonials);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Testimonial test)
        {
            if (ModelState.IsValid)
            {
                if (test.ImageFile == null)
                {
                    ModelState.AddModelError("ImageFile", "Image is required");
                    return View(test);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + test.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    test.ImageFile.SaveAs(imagePath);
                    test.Image = imageName;
                }

                db.Testimonials.Add(test);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(test);
        }

        public ActionResult Update(int? id)
        {
            Testimonial test = db.Testimonials.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        [HttpPost]
        public ActionResult Update(Testimonial test)
        {
            if (ModelState.IsValid)
            {
                Testimonial Test = db.Testimonials.Find(test.Id);
                if (test.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + test.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads/"), Test.Image);
                    System.IO.File.Delete(oldPath);

                    test.ImageFile.SaveAs(imagePath);
                    Test.Image = imageName;
                }

                Test.FullName = test.FullName;
                Test.Comment = test.Comment;
                Test.Position = test.Position;
                Test.Faculty = test.Faculty;

                db.Entry(Test).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = db.Categories.ToList();
            return View(test);
        }

        public ActionResult Delete(int? id)
        {
            Testimonial test = db.Testimonials.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            string oldPath = Path.Combine(Server.MapPath("~/Uploads/"), test.Image);
            System.IO.File.Delete(oldPath);

            db.Testimonials.Remove(test);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}