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
    public class CourseController : Controller
    {
        // GET: Admin/Course
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            ViewBag.Category = db.Categories.ToList();
            List<Course> courses = db.Courses.ToList();
            return View(courses);
        }

        public ActionResult Create()
        {
            ViewBag.Category = db.Categories.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                if (course.ImageFile == null)
                {
                    ModelState.AddModelError("ImageFile", "Image is required");
                    ViewBag.Category = db.Categories.ToList();
                    return View(course);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + course.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    course.ImageFile.SaveAs(imagePath);
                    course.Image = imageName;
                }

                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = db.Categories.ToList();
            return View(course);
        }

        public ActionResult Update(int? id)
        {
            ViewBag.Category = db.Categories.ToList();
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        [HttpPost]
        public ActionResult Update(Course course)
        {
            if (ModelState.IsValid)
            {
                Course Course = db.Courses.Find(course.Id);
                if (course.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + course.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads/"), Course.Image);
                    System.IO.File.Delete(oldPath);

                    course.ImageFile.SaveAs(imagePath);
                    Course.Image = imageName;
                }

                Course.Name = course.Name;
                Course.Content = course.Content;
                Course.CategoryId = course.CategoryId;
                Course.About = course.About;
                Course.Apply = course.Apply;
                Course.Certification = course.Certification;
                Course.StartDate = course.StartDate;
                Course.Duration = course.Duration;
                Course.ClassDuration = course.ClassDuration;
                Course.SkillLevel = course.SkillLevel;
                Course.Language = course.Language;
                Course.Students = course.Students;
                Course.Assessments = course.Assessments;
                Course.Price = course.Price;

                db.Entry(Course).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = db.Categories.ToList();
            return View(course);
        }

        public ActionResult Delete(int? id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            string oldPath = Path.Combine(Server.MapPath("~/Uploads/"), course.Image);
            System.IO.File.Delete(oldPath);

            db.Courses.Remove(course);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}